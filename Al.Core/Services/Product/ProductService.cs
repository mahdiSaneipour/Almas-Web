using Al.Core.DTOs.Product;
using Al.Core.DTOs.Search;
using Al.Core.IServices.Product;
using Al.Domain.IRepository.Products.Discount;
using Al.Domain.IRepository.Products.Group;
using Al.Domain.IRepository.Products.Image;
using Al.Domain.IRepository.Products.Product;
using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Al.Core.Tools.Percentage;

namespace Al.Core.Services.Product
{
    public class ProductService : IProdcutService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IGroupRepository _groupRepository;

        public ProductService(IProductRepository productRepository, IDiscountRepository discountRepository,
            IImageRepository imageRepository, IGroupRepository groupRepository)
        {
            _productRepository = productRepository;
            _discountRepository = discountRepository;
            _imageRepository = imageRepository;
            _groupRepository = groupRepository;
        }

        public ProductShowViewModel GetProductByProductId(int productId)
        {
            ProductShowViewModel result = new ProductShowViewModel();

            Domain.Entities.Product.Product product = _productRepository.GetProductByProductId(productId);

            if (product == null)
            {
                return null;
            }

            int discountPercent = ((product.Discount != null) ? product.Discount.DiscountPercent : 0);

            int groupParentId = _groupRepository.GetParentIdGroupByGroupId(product.GroupId);

            List<Domain.Entities.Product.ProductImage> images = _imageRepository.GetImagesByProductId(productId).ToList();

            string[] rImages = null;

            if (images.Count != 0)
            {
                rImages = new string[images.Count];

                for (var i = 0; i < images.Count; i++)
                {
                    rImages[i] = images[i].ImageAddress;
                }
            }

            Domain.Entities.Product.ProductGroup parentGroup = _groupRepository.GetGroupByGroupId(groupParentId);

            result.ProductId = product.ProductId;
            result.Name = product.ProductName;
            result.GroupName = product.Group.GroupName;
            result.GroupId = product.GroupId;
            result.ParentGroupName = parentGroup.GroupName;
            result.ParentGroupId = parentGroup.GroupId;
            result.ModelName = product.Model;
            result.Year = product.Year.ProductionYear;
            result.Color = product.Color.ColorName;
            result.Country = product.Country.CountryName;
            result.Factory = product.Factory.FactoryName;
            result.Description = product.Description;
            result.Price = ((discountPercent != 0) ? Percentage.PercentagePrice(product.Price, discountPercent) : product.Price);
            result.OldPrice = ((discountPercent != 0) ? product.Price : 0);
            result.Images = rImages;
            

            return result;
        }

        public SearchViewModel SearchProduct(SearchViewModel model)
        {
            IQueryable<Domain.Entities.Product.Product> products = _productRepository.GetAllProduct()
                .Include(p => p.Images).Include(p => p.Discount).Include(p => p.Group);

            if (model.Groups != null && model.Groups.Count != 0)
            {
                List<Domain.Entities.Product.Product> allProducts = new List<Domain.Entities.Product.Product>();

                foreach(var group in model.Groups)
                {
                    allProducts.AddRange(products.ToList().
                        Where(a => a.GroupId == group || a.Group.ParentId == group)
                        .Where(a => !allProducts.Any(al => al.ProductId == a.ProductId))
                         .ToList());
                }
                
                products = allProducts.AsQueryable();
            }

            if(!String.IsNullOrEmpty(model.Search))
            {
                products = products.Where(p => p.ProductName.Contains(model.Search) || p.Description.Contains(model.Search));
            }

            if(model.MinimumPrice != 0)
            {
                products = products.Where(p => p.Price >= model.MinimumPrice);
            }

            if(model.MaximumPrice != 20000000)
            {
                products = products.Where(p => p.Price <= model.MaximumPrice);
            }

            switch (model.OrderBy)
            {
                case Enums.Search.OrderByEnum.Newest:
                    {
                        products = products.OrderBy(p => p.ProductId);
                        break;
                    }
                case Enums.Search.OrderByEnum.Cheapest:
                    {
                        products = products.OrderBy(p => p.Price);
                        break;
                    }
                case Enums.Search.OrderByEnum.Expensive:
                    {
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    }
            }

            int take = 15;
            int skip = (model.PageId - 1) * take;
            model.PageCount = (products.Count() / take);

            if((products.Count() % take) != 0) {
                model.PageCount++;
            }

            if(model.PageCount < model.PageId)
            {
                model.PageId = 1;
            }

            model.Products = products.Skip(skip).Take(take).Select(p => new DTOs.Home.ProductBoxViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductImage = ((p.Images.Count != 0) ? p.Images.ToList()[0].ImageAddress : ""),
                NewPrice = ((p.Discount != null) ? Percentage.PercentagePrice(p.Price, p.Discount.DiscountPercent) : p.Price),
                OldPrice = ((p.Discount != null) ? p.Price : 0)
            }).ToList();

            model.AllGroups = _groupRepository.GetAllGroups().ToList();

            return model;
        }
    }
}
