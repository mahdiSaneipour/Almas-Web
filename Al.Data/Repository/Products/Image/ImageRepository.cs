using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Image
{
    public class ImageRepository : IImageRepository
    {
        private readonly AlContext _context;

        public ImageRepository(AlContext context)
        {
            _context = context;
        }

        public void AddImage(ProductImage Image)
        {
            _context.PImages.Add(Image);
        }

        public void EditImage(ProductImage Image)
        {
            _context.PImages.Update(Image);
        }

        public IQueryable<ProductImage> GetImagesByProductId(int productId)
        {
            return _context.PImages.Where(i => i.ProductId == productId);
        }

        public ProductImage GetImageByImageId(int imageId)
        {
            return _context.PImages.FirstOrDefault(i => i.ImageId == imageId);
        }

        public void RemoveImage(ProductImage Image)
        {
            _context.PImages.Remove(Image);
        }

        public ProductImage GetImageByValueAndProductId(string name, int productId)
        {
            return _context.PImages.FirstOrDefault(f => f.ImageAddress == name && f.ProductId == productId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
