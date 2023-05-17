using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Year
{
    public interface IYearRepository
    {
        public IQueryable<Entities.Product.ProductYear> GetAllYears();

        public Entities.Product.ProductYear GetYearByYearId(int yearId);

        public void AddYear(Entities.Product.ProductYear year);

        public void EditYear(Entities.Product.ProductYear year);

        public void RemoveYear(Entities.Product.ProductYear year);

        public void SaveChanges();
    }
}
