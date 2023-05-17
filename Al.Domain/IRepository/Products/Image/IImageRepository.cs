using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Image
{
    public interface IImageRepository
    {
        public IQueryable<Entities.Product.ProductImage> GetImagesByProductId(int productId);

        public Entities.Product.ProductImage GetImageByImageId(int imageId);

        public ProductImage GetImageByValueAndProductId(string name, int productId);

        public void AddImage(Entities.Product.ProductImage Image);

        public void EditImage(Entities.Product.ProductImage Image);

        public void RemoveImage(Entities.Product.ProductImage Image);

        public void SaveChanges();
    }
}
