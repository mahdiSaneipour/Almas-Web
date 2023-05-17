using Al.Core.DTOs.Home;
using Al.Core.IServices.Home;
using Al.Core.Tools.Percentage;
using Al.Data.Repository.Admins.SlideBanner;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Admins.SlideBanner;
using Al.Domain.IRepository.Products.Discount;
using Al.Domain.IRepository.Products.Group;
using Al.Domain.IRepository.Products.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Al.Core.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly ISlideBannerRepository _slideBannerRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGroupRepository _groupRepository;

        public HomeService(ISlideBannerRepository slideBannerRepository, IProductRepository productRepository,
            IGroupRepository groupRepository, IDiscountRepository discountRepository)
        {
            _slideBannerRepository = slideBannerRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _groupRepository = groupRepository;
        }

        public ICollection<SlideBannerViewModel> GetSlideBanners()
        {
            return _slideBannerRepository.GetAllBanners().Select(sb => new SlideBannerViewModel
            {
                ImageUrl = sb.ImageUrl,
                Link = sb.Link
            }).ToList();
        }

        public ICollection<ProductSlidesViewModel> GetAllProductSlides()
        {
            ICollection<ProductSlidesViewModel> result = new List<ProductSlidesViewModel>();

            var groups = _groupRepository.GetAllParentGroups().ToList();

            foreach (var group in groups)
            {
                ProductSlidesViewModel slides = new ProductSlidesViewModel();

                slides.GroupId = group.GroupId;
                slides.GroupName = group.GroupName;

                ICollection<ProductBoxViewModel> slidesbox = new List<ProductBoxViewModel>();

                slidesbox = _productRepository.GetProductsSliderByGroupId(group.GroupId).Select(p => new ProductBoxViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductImage = ((p.Images.Count != 0) ? p.Images.ToList()[0].ImageAddress : ""),
                    NewPrice = ((p.DiscountId != null) ?
                        Percentage.PercentagePrice(p.Price, p.Discount.DiscountPercent)
                        : p.Price),
                    OldPrice = ((p.Discount != null) ? p.Price : 0)
                }).ToList();

                slides.Slides = slidesbox;
                

                result.Add(slides);
            }

            return result;
        }

        public ICollection<ProductBoxViewModel> GetGoldenDiscounts()
        {
            ICollection<ProductBoxViewModel> result = new List<ProductBoxViewModel>();

            List<ProductDiscount> discounts = _discountRepository.GetGoldenDiscounts().ToList();

            foreach (ProductDiscount discount in discounts)
            {
                Domain.Entities.Product.Product product = _productRepository.GetProductByProductId((int)discount.ProductId);

                result.Add(new ProductBoxViewModel {
                    ProductId = (int)discount.ProductId,
                    ProductName = product.ProductName,
                    ProductImage = ((product.Images.Count != 0) ? product.Images.ToList()[0].ImageAddress : "") ,
                    OldPrice = product.Price,
                    NewPrice = Percentage.PercentagePrice(product.Price, discount.DiscountPercent)
                });
            }

            return result;
        }
    }
}