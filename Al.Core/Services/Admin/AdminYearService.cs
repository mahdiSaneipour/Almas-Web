using Al.Core.DTOs.Admin.Year;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Year;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminYearService : IAdminYearService
    {
        private readonly IYearRepository _yearRepository;

        public AdminYearService(IYearRepository yearRepository)
        {
            _yearRepository = yearRepository;
        }

        public void AddYear(ProductYear year)
        {
            _yearRepository.AddYear(year);
            _yearRepository.SaveChanges();
        }

        public void DeleteYear(int yearId)
        {
            ProductYear year = _yearRepository.GetYearByYearId(yearId);

            if (year == null)
            {
                return;
            }

            _yearRepository.RemoveYear(year);
            _yearRepository.SaveChanges();
        }

        public ProductYear GetYearByYearId(int yearId)
        {
            return _yearRepository.GetYearByYearId(yearId);
        }

        public BoxYearsInList GetYearsInList(int pageId = 1)
        {
            BoxYearsInList result = new BoxYearsInList();

            IQueryable<ProductYear> years = _yearRepository.GetAllYears();

            if(years == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            result.TotalPage = years.Count() / take;
            result.PageId = pageId;

            result.Years = years.ToList().Skip(skip).Take(take).ToList();

            return result;
        }

        public void UpdateYear(ProductYear year)
        {
            _yearRepository.EditYear(year);
            _yearRepository.SaveChanges();
        }
    }
}
