using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Color
{
    public interface IColorRepository
    {
        public void AddColor(Entities.Product.ProductColor color);

        public string GetColorNameByColorId(int colorId);

        public ProductColor GetColorByColorId(int colorId);

        public IQueryable<Entities.Product.ProductColor> GetAllColors();

        public void RemoveColor(Entities.Product.ProductColor color);

        public void UpdateColor(Entities.Product.ProductColor color);

        public void SaveChanges();
    }
}
