using Al.Core.DTOs.Admin.Slide;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Admins.SlideBanner;
using Al.Domain.IRepository.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminSlideService : IAdminSlideService
    {
        private readonly IProductRepository _productRepository;

        public AdminSlideService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool AddSlideByName(string productName)
        {
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductName(productName);

            if(product == null)
            {
                return false;
            }

            product.IsSlide = true;

            _productRepository.UpdateProduct(product);
            _productRepository.SaveChanges();

            return true;
        }

        public void DisableProductSlide(int productId)
        {
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductId(productId);

            product.IsSlide = false;

            _productRepository.UpdateProduct(product);
            _productRepository.SaveChanges();
        }

        public BoxSlidesInList GetSlidesForShow(int pageId = 1, int groupId = 0)
        {
            BoxSlidesInList result = new BoxSlidesInList();
            IQueryable<Domain.Entities.Product.Product> qSlides = null;

            if(groupId == 0)
            {
                qSlides = _productRepository.GetAllProductSlides();
            } else
            {
                qSlides = _productRepository.GetProductsSliderByGroupId(groupId);
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            if((pageId - 1) * take >= qSlides.Count())
            {
                pageId = 1;
            }

            result.TotalPage = qSlides.Count() / take;
            result.PageId = pageId;

            result.Slides = qSlides.ToList().Skip(skip).Take(take).Select(s => new SingleSlideInList
            {
                GroupId = (int) s.Group.ParentId,
                GroupName = s.Group.Parent.GroupName,
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                SlideId = s.ProductId
            }).ToList();

            return result;
        }
    }
}