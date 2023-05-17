using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Country
{
    public interface ICountryRepository
    {
        public IQueryable<Entities.Product.ProductCountry> GetAllCountries();

        public Entities.Product.ProductCountry GetCountryByCountryId(int countryId);

        public void AddCountry(Entities.Product.ProductCountry country);

        public void EditCountry(Entities.Product.ProductCountry country);

        public void RemoveCountry(Entities.Product.ProductCountry country);

        public void SaveChanges();
    }
}
