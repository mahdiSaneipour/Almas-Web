using Al.Core.DTOs.Admin.Factoe;
using Al.Core.DTOs.Admin.Factor;
using Al.Core.Enums.Admin;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Factors;
using Al.Domain.IRepository.Factors.Factor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminFactorService : IAdminFactorService
    {
        private readonly IFactorRepository _factorRepository;

        public AdminFactorService(IFactorRepository factorRepository)
        {
            _factorRepository = factorRepository;
        }

        public Tuple<int, int, List<ShowFactorTableViewModel>> GetFactorsForList(int pageId, FactorsFilterBy filter)
        {
            List<ShowFactorTableViewModel> result = new List<ShowFactorTableViewModel>();

            IQueryable<Domain.Entities.Factors.Factor> factors = _factorRepository.GetAllFactors();

            switch(filter)
            {
                case FactorsFilterBy.All:
                    break;

                case FactorsFilterBy.Sending:
                    factors = factors.Where(f => !f.IsDeliver);
                    break;

                case FactorsFilterBy.Sent:
                    factors = factors.Where(f => f.IsDeliver);
                    break;
            }

            int take = 10;
            int totalPage = 0;

            if ((pageId - 1) * take >= factors.Count())
            {
                pageId = 1;
            }
            else
            {

                totalPage = factors.Count() / take;
                int skip = (pageId - 1) * take;

                List<Factor> lFactors = factors.Skip(skip).Take(take).OrderByDescending(f => f.CreatDate).ToList();

                foreach (var factor in lFactors)
                {
                    result.Add(new ShowFactorTableViewModel()
                    {
                        CreatDate = factor.CreatDate,
                        IsDeliver = factor.IsDeliver,
                        Count = factor.Count,
                        FactorId = factor.FactorId,
                        Sum = factor.Sum,
                        FactorName = factor.User.Name
                    });
                }

            }
            return Tuple.Create(totalPage, pageId, result);
        }

        public ShowUserAndOrderViewModel GetShowOrder(int orderId)
        {
            ShowUserAndOrderViewModel result = new ShowUserAndOrderViewModel();
            Factor order = _factorRepository.GetFactorByFactorId(orderId);

            result.Name = order.User.Name;
            result.OrderId = order.FactorId;
            result.Number = (order.User.PhoneNumber == null) ? "--" : order.User.PhoneNumber;
            result.Address = order.User.Address;
            result.Email = order.User.Email;
            result.CreatDate = order.CreatDate;
            result.IsDeliver = order.IsDeliver;

            result.OrderDetails = order.FactorDetails.Select(fd => new DetailOrderViewModel
            {
                Price = fd.Price,
                ProductName = fd.ProductName,
                Count = fd.Count,
                DiscountPercent = ((fd.Product.DiscountId == null) ? 0 : fd.Product.Discount.DiscountPercent)
            }).ToList();

            return result;
        }

        public void SetDeliverByFactorId(int factorId)
        {
            _factorRepository.SetDeliverByFactorId(factorId);
            _factorRepository.SaveChanges();
        }
    }
}