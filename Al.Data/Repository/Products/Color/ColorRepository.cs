using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Color
{
    public class ColorRepository : IColorRepository
    {
        private readonly AlContext _context;

        public ColorRepository(AlContext context)
        {
            _context = context;
        }

        public void AddColor(ProductColor color)
        {
            _context.Colors.Add(color);
        }

        public IQueryable<ProductColor> GetAllColors()
        {
            return _context.Colors;
        }

        public string GetColorNameByColorId(int colorId)
        {
            return _context.Colors.FirstOrDefault(c => c.ColorId == colorId).ColorName;
        }

        public ProductColor GetColorByColorId(int colorId)
        {
            return _context.Colors.FirstOrDefault(c => c.ColorId == colorId);
        }

        public void RemoveColor(ProductColor color)
        {
            _context.Remove(color);
        }

        public void UpdateColor(ProductColor color)
        {
            _context.Update(color);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
