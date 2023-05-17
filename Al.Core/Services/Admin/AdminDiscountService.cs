using Al.Core.DTOs.Admin.Discount;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Discount;
using Al.Domain.IRepository.Products.Product;
using EP.Core.Tools.Date_Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminDiscountService : IAdminDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;

        public AdminDiscountService(IDiscountRepository discountRepository, IProductRepository productRepository)
        {
            _discountRepository = discountRepository;
            _productRepository = productRepository;
        }

        public void AddDiscount(SingleDiscountViewModel discount)
        {
            ProductDiscount result = new ProductDiscount();
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductName(discount.ProductName);

            if(product == null)
            {
                return;
            }

            string[] startD = discount.StartDate.Split('/');

            result.StartDiscount = new DateTime(Int32.Parse(startD[0]), 
                Int32.Parse(startD[1]), Int32.Parse(startD[2]), new PersianCalendar());

            string[] endD = discount.EndDate.Split('/');

            result.EndDiscount = new DateTime(Int32.Parse(endD[0]),
                Int32.Parse(endD[1]), Int32.Parse(endD[2]), new PersianCalendar());

            result.ProductId = product.ProductId;

            result.IsGolden = discount.IsGolden;
            result.DiscountPercent = discount.Percent;
            result.DiscountName = discount.DiscountName;

            _discountRepository.AddDiscount(result);
            _discountRepository.SaveChanges();

            product.DiscountId = result.DiscountId;

            _productRepository.UpdateProduct(product);
            _productRepository.SaveChanges();
        }

        public void DeleteDicount(int discountId)
        {
            ProductDiscount discount = _discountRepository.GetDiscountByDiscountId(discountId);

            if(discount == null)
            {
                return;
            }

            _discountRepository.RemoveDiscount(discount);
            _discountRepository.SaveChanges();
        }

        public SingleDiscountViewModel GetDiscountForEdit(int discountId)
        {
            SingleDiscountViewModel result = new SingleDiscountViewModel();
            ProductDiscount discount = _discountRepository.GetDiscountByDiscountId(discountId);

            if(discount == null)
            {
                return null;
            }

            result.DiscountId = discountId;
            result.DiscountName = discount.DiscountName;
            result.ProductName = _productRepository.GetProductNameByProductId((int) discount.ProductId);
            result.IsGolden = discount.IsGolden;
            result.Percent = discount.DiscountPercent;
            result.StartDate = discount.StartDiscount.Year + "/" + discount.StartDiscount.Month + "/" + discount.StartDiscount.Day;
            result.EndDate = discount.EndDiscount.Year + "/" + discount.EndDiscount.Month + "/" + discount.EndDiscount.Day;

            return result;
        }

        public DiscountsListViewModel GetDiscountsInList(int pageId = 1)
        {
            DiscountsListViewModel result = new DiscountsListViewModel();

            IQueryable<ProductDiscount> qDiscounts = _discountRepository.GetAllDiscounts();

            if(qDiscounts == null)
            {
                return null;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            result.TotalPage = qDiscounts.Count() / take;
            result.PageId = pageId;

            result.Discounts = qDiscounts.ToList().Skip(skip).Take(take).Select(d => new BoxDiscountViewModel()
            {
                DiscountId = d.DiscountId,
                DiscountName = d.DiscountName,
                DiscountPercent = d.DiscountPercent,
                IsGolden = d.IsGolden,
                ProductName = _productRepository.GetProductNameByProductId((int) d.ProductId),
                ProductId = (int)d.ProductId
            }).ToList();

            return result;
        }

        public void UpdateDiscount(SingleDiscountViewModel model)
        {
            ProductDiscount discount = _discountRepository.GetDiscountByDiscountId(model.DiscountId);
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductName(model.ProductName);


            if (discount == null || product == null)
            {
                return;
            }

            string[] startD = model.StartDate.Split('/');

            discount.StartDiscount = new DateTime(Int32.Parse(startD[0]),
                Int32.Parse(startD[1]), Int32.Parse(startD[2]), new PersianCalendar());

            string[] endD = model.EndDate.Split('/');

            discount.EndDiscount = new DateTime(Int32.Parse(endD[0]),
                Int32.Parse(endD[1]), Int32.Parse(endD[2]), new PersianCalendar());

            discount.DiscountName = model.DiscountName;
            discount.DiscountPercent = model.Percent;
            discount.ProductId = product.ProductId;
            discount.IsGolden = model.IsGolden;

            _discountRepository.UpdateDiscount(discount);
            _discountRepository.SaveChanges();
        }
    }
}
