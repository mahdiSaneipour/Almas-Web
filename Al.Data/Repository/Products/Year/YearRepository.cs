using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Year;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Year
{
    public class YearRepository : IYearRepository
    {
        private readonly AlContext _context;

        public YearRepository(AlContext context)
        {
            _context = context;
        }

        public void AddYear(ProductYear year)
        {
            _context.Years.Add(year);
        }

        public void EditYear(ProductYear year)
        {
            _context.Years.Update(year);
        }

        public IQueryable<ProductYear> GetAllYears()
        {
            return _context.Years;
        }

        public ProductYear GetYearByYearId(int yearId)
        {
            return _context.Years.FirstOrDefault(y => y.YearId == yearId);
        }

        public void RemoveYear(ProductYear year)
        {
            _context.Years.Remove(year);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
