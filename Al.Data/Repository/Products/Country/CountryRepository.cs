using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Country
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AlContext _context;

        public CountryRepository(AlContext context)
        {
            _context = context;
        }

        public void AddCountry(ProductCountry country)
        {
            _context.Countries.Add(country);
        }

        public void EditCountry(ProductCountry country)
        {
            _context.Countries.Update(country);
        }

        public IQueryable<ProductCountry> GetAllCountries()
        {
            return _context.Countries;
        }

        public ProductCountry GetCountryByCountryId(int countryId)
        {
            return _context.Countries.FirstOrDefault(c => c.CountryId == countryId);
        }

        public void RemoveCountry(ProductCountry country)
        {
            _context.Remove(country);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
