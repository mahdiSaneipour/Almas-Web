using Al.Core.DTOs.Admin.Year;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminYearService
    {
        public BoxYearsInList GetYearsInList(int pageId = 1);

        public ProductYear GetYearByYearId(int yearId);

        public void DeleteYear(int yearId);

        public void AddYear(ProductYear year);

        public void UpdateYear(ProductYear year);
    }
}
