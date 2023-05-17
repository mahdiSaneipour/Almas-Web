using Al.Core.DTOs.Admin.Country;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminCountryService
    {
        public BoxCountryInList GetCountriesInList(int pageId = 1);

        public void DeleteCountry(int countryId);

        public void AddCountry(ProductCountry country);

        public void UpdateCountry(ProductCountry country);

        public ProductCountry GetCountry(int countryId);
    }
}
