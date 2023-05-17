using Al.Core.DTOs.Basket;
using Al.Core.IServices.Profile;
using Al.Domain.Entities.Factors;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.Factors.Factor;
using Al.Domain.IRepository.Factors.Factor_Detail;
using Al.Domain.IRepository.Products.Product;
using AngleSharp.Io;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Parbad;
using Parbad.AspNetCore;
using Parbad.Gateway.ParbadVirtual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Antiforgery;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Al.Core.Tools.Percentage;
using System.Security.Claims;

namespace Al.Core.Services.Profile
{
    public class BasketService : IBasketService
    {
        private readonly IFactorRepository _factorRepository;
        private readonly IFactorDetailRepository _factorDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOnlinePayment _onlinePayment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public BasketService(IFactorRepository factorRepository, IFactorDetailRepository factorDetailRepository,
            IProductRepository productRepository, IOnlinePayment onlinePayment,
            IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _factorRepository = factorRepository;
            _factorDetailRepository = factorDetailRepository;
            _productRepository = productRepository;
            _onlinePayment = onlinePayment;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public void AddToBasket(AddToBasketViewModel model)
        {
            Domain.Entities.Factors.Factor factor = _factorRepository.GetOpenFactorByUserId(model.User.Id);
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductId(model.ProductId);

            if (factor == null)
            {
                factor = new Domain.Entities.Factors.Factor()
                {
                    UserId = model.User.Id,
                    Count = model.Count,
                    Sum = (product.Price * model.Count)
                };

                _factorRepository.AddFactor(factor);
                _factorRepository.SaveChanges();

                Domain.Entities.Factors.FactorDetail dFactor = new Domain.Entities.Factors.FactorDetail()
                {
                    FactorId = factor.FactorId,
                    Count = model.Count,
                    ProductId = model.ProductId,
                    ProductName = product.ProductName,
                };

                _factorDetailRepository.AddFactorDetail(dFactor);
                _factorRepository.SaveChanges();
            } else
            {
                Domain.Entities.Factors.FactorDetail dFactor = _factorDetailRepository.
                    GetFactorDetailByFactorIdAndProductId(factor.FactorId, product.ProductId);

                if(dFactor == null)
                {
                    dFactor = new Domain.Entities.Factors.FactorDetail()
                    {
                        FactorId = factor.FactorId,
                        Count = model.Count,
                        ProductName = product.ProductName,
                        ProductId = model.ProductId,
                    };

                    _factorDetailRepository.AddFactorDetail(dFactor);
                } else
                {
                    dFactor.Count += model.Count;
                }

                factor.Count += model.Count;
                factor.Sum += (product.Price * model.Count);

                _factorDetailRepository.SaveChanges();
            }
        }

        public void RemoveProductFromBasket(int factorId, int productId)
        {
            Domain.Entities.Factors.FactorDetail fDetail =
                _factorDetailRepository.GetFactorDetailByFactorIdAndProductId(factorId, productId);

            _factorDetailRepository.RemoveFactorDetail(fDetail);
            _factorDetailRepository.SaveChanges();

            SetFactorAmount(factorId);
        }

        public long GetActualPrice(int productId)
        {
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductId(productId);

            if(product.Discount == null)
            {
                return product.Price;
            }

            return Percentage.PercentagePrice(product.Price, product.Discount.DiscountPercent);
        }

        public Factor GetOpenFactorByUserId()
        {
            string userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            Factor factor = _factorRepository.GetOpenFactorByUserId(userId);

            if(factor == null)
            {
                return factor;
            }

            factor.Sum = SetFactorAmount(factor.FactorId);

            return factor;
        }

        public async Task<IActionResult> PayFactor()
        {
            string userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);

            Factor factor = _factorRepository.GetOpenFactorByUserId(userId);

            string scheme = _contextAccessor.HttpContext.Request.Scheme;
            string host = _contextAccessor.HttpContext.Request.Host.Value;
            string verifyLink = $"{scheme}://{host}/Profile/Basket?handler=Verify";

            var result = await _onlinePayment.RequestAsync(pay =>
            {
                pay.SetTrackingNumber(factor.FactorId)
                .SetAmount(factor.Sum)
                .SetCallbackUrl(verifyLink)
                .UseParbadVirtual();
            });

            if(result.IsSucceed)
            {
                return result.GatewayTransporter.TransportToGateway();
            }

            return null;
        }

        public async Task<bool> VerifyPayment()
        {
            string userId = _userManager.GetUserId(_contextAccessor.HttpContext.User);

            Factor factor = _factorRepository.GetOpenFactorByUserId(userId);

            if(factor == null)
            {
                return false;
            }

            if(_onlinePayment.VerifyAsync(factor.FactorId).IsCompletedSuccessfully)
            {
                factor.IsPay = true;

                _factorRepository.UpdateFactor(factor);
                _factorRepository.SaveChanges();

                return  true;
            } else
            {
                _onlinePayment.CancelAsync(factor.FactorId);
                return  false;
            }
        }

        public long SetFactorAmount(int factorId)
        {
            Factor factor = _factorRepository.GetFactorByFactorId(factorId);

            if(factor == null)
            {
                return 0;
            }

            long sum = 0;

            foreach(var fDetail in factor.FactorDetails)
            {
                sum += GetActualPrice(fDetail.ProductId) * fDetail.Count;
            }

            factor.Sum = sum;

            _factorRepository.UpdateFactor(factor);
            _factorRepository.SaveChanges();

            return sum;
        }

        public void AddPriceToFactorDetails()
        {
            Domain.Entities.Factors.Factor factor = _factorRepository.GetLastCloseFactor();

            for(var i = 0; i < factor.FactorDetails.Count; i++)
            {
                factor.FactorDetails.ToList()[i].Price = GetActualPrice(factor.FactorDetails.ToList()[i].ProductId);
            }

            _factorRepository.UpdateFactor(factor);
            _factorRepository.SaveChanges();

        }

        public int CountOfBasket()
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _factorRepository.CountOfBasket(userId);
        }
    }
}