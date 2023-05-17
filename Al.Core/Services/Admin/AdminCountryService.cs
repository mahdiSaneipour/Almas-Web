using Al.Core.DTOs.Admin.Country;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminCountryService : IAdminCountryService
    {
        private readonly ICountryRepository _countryRepository;

        public AdminCountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public void AddCountry(ProductCountry country)
        {
            _countryRepository.AddCountry(country);
            _countryRepository.SaveChanges();
        }

        public void DeleteCountry(int countryId)
        {
            ProductCountry country = _countryRepository.GetCountryByCountryId(countryId);

            if(country == null)
            {
                return ;
            }

            _countryRepository.RemoveCountry(country);
            _countryRepository.SaveChanges();
        }

        public BoxCountryInList GetCountriesInList(int pageId = 1)
        {
            BoxCountryInList result = new BoxCountryInList();


            IQueryable<ProductCountry> countries = _countryRepository.GetAllCountries();

            if (countries == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = countries.Count() / take;

            result.Countries = countries.ToList().Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }

        public ProductCountry GetCountry(int countryId)
        {
            return _countryRepository.GetCountryByCountryId(countryId);
        }

        public void UpdateCountry(ProductCountry country)
        {
            _countryRepository.EditCountry(country);
            _countryRepository.SaveChanges();
        }
    }
}
