using Al.Core.DTOs.Admin.Factoe;
using Al.Core.DTOs.Admin.Product;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Factors;
using Al.Domain.Entities.Product;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.Products.Color;
using Al.Domain.IRepository.Products.Country;
using Al.Domain.IRepository.Products.Factory;
using Al.Domain.IRepository.Products.Group;
using Al.Domain.IRepository.Products.Image;
using Al.Domain.IRepository.Products.Product;
using Al.Domain.IRepository.Products.Year;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminProductService : IAdminProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IYearRepository _yearRepository;
        private readonly IFactoryRepository _factoryRepository;
        private readonly IImageRepository _imageRepository;

        public AdminProductService(IProductRepository productRepository, IGroupRepository groupRepository,
            ICountryRepository countryRepository, IColorRepository colorRepository,
            IYearRepository yearRepository, IFactoryRepository factoryRepository,
            IImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _groupRepository = groupRepository;
            _countryRepository = countryRepository;
            _colorRepository = colorRepository;
            _yearRepository = yearRepository;
            _factoryRepository = factoryRepository;
            _imageRepository = imageRepository;
        }

        public bool AddProduct(AddProduct product)
        {
            Domain.Entities.Product.Product result = new Domain.Entities.Product.Product() { 
            
                ProductName = product.ProductName,
                Model = product.Model,
                Description = product.Description,
                Price = product.ProductPrice,
                FactoryId = product.FactoryId,
                GroupId = product.SubGroupId,
                YearId = product.YearId,
                ColorId = product.ColorId,
                CountryId = product.CountryId
            };

            _productRepository.AddProduct(result);
            _productRepository.SaveChanges();

            foreach (var image in product.Images.Split(","))
            {
                _imageRepository.AddImage(new ProductImage()
                {
                    ImageAddress = image,
                    ProductId = result.ProductId
                });
            }

            _imageRepository.SaveChanges();

            if(result.ProductId == 0)
            {
                return false;
            }

            return true;
        }

        public void DeleteProductByProductId(int productId)
        {
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductId(productId);

            _productRepository.DeleteProduct(product);
            _productRepository.SaveChanges();
        }

        public SelectList GetAllColorsForShow()
        {
            List<ProductColor> colors = _colorRepository.GetAllColors().ToList();

            SelectList result = new SelectList(colors, "ColorId", "ColorName");

            return result;
        }

        public SelectList GetAllCountriesForShow()
        {
            List<ProductCountry> countries = _countryRepository.GetAllCountries().ToList();

            SelectList result = new SelectList(countries, "CountryId", "CountryName");

            return result;
        }

        public SelectList GetAllFactoriesForShow()
        {
            List<ProductFactory> factories = _factoryRepository.GetAllFactories().ToList();

            SelectList result = new SelectList(factories, "FactoryId", "FactoryName");

            return result;
        }

        public SelectList GetAllParentGroups()
        {
            List<ProductGroup> groups = new List<ProductGroup>();

            groups.Add(new ProductGroup()
            {
                GroupId = 0,
                GroupName = "همه"
            });

            groups.AddRange(_groupRepository.GetAllParentGroups());

            SelectList result = new SelectList(groups, "GroupId", "GroupName");

            return result;
        }

        public SelectList GetAllParentGroupsForShow()
        {
            List<ProductGroup> groups = _groupRepository.GetAllParentGroups();

            SelectList result = new SelectList(groups, "GroupId", "GroupName");

            return result;
        }

        public SelectList GetAllYearsForShow()
        {
            List<ProductYear> years = _yearRepository.GetAllYears().ToList();

            SelectList result = new SelectList(years, "YearId", "ProductionYear");

            return result;
        }

        public SelectList GetGroupsByParentId(int parentId)
        {
            List<ProductGroup> subGroups = new List<ProductGroup>();

            subGroups.Add(new ProductGroup()
            {
                GroupId = 0,
                GroupName = "همه"
            });

            subGroups.AddRange(_groupRepository.GetSubGroupsByParentId(parentId));

            SelectList result = new SelectList(subGroups, "GroupId", "GroupName");

            return result;
        }

        public SelectList GetGroupsByParentIdForShow(int parentId)
        {
            List<ProductGroup> subGroups = _groupRepository.GetSubGroupsByParentId(parentId);

            SelectList result = new SelectList(subGroups, "GroupId", "GroupName");

            return result;
        }

        public EditProduct GetProductEdit(int productId)
        {
            Domain.Entities.Product.Product product = _productRepository.GetProductByProductId(productId);

            EditProduct result = new EditProduct() { 
                ProductId = product.ProductId,
                Description = product.Description,
                CountryId = product.CountryId,
                ColorId = product.ColorId,
                YearId = product.YearId,
                FactoryId = product.FactoryId,
                GroupId = (int)product.Group.ParentId,
                SubGroupId = product.GroupId,
                ProductName = product.ProductName,
                ProductPrice = product.Price,
                Model = product.Model,
            };

            
            if(product.Images != null)
            {
                foreach (var image in product.Images)
                {
                    result.Images += $"{image.ImageAddress},";
                }
            }

            return result;
        }

        public BoxProductsList GetProductsForList(int pageId, string search, int group, int subGroup)
        {
            BoxProductsList result = new BoxProductsList();

            IQueryable<Domain.Entities.Product.Product> products = _productRepository.GetAllProduct();

            if (products.Count() == 0)
            {
                return result;
            }

            if (group != 0)
            {
                if (subGroup == 0)
                {
                    products = products.Where(p => p.Group.ParentId == group);
                }
                else
                {
                    products = products.Where(p => p.Group.GroupId == subGroup);
                }
            }

            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.ProductName.Contains(search));
            }

            int take = 10;
            int totalPage = 0;

            if ((pageId - 1) * take >= products.Count())
            {
                result.PageId = 1;
            }
            else
            {
                totalPage = products.Count() / take;
                int skip = (pageId - 1) * take;

                List<Domain.Entities.Product.Product> lProducts = products.Skip(skip).Take(take).OrderBy(p => p.GroupId).ToList();

                result.Products = new List<ShowProductsInList>();
                result.TotalPage = totalPage;
                result.PageId = pageId;

                foreach (var product in lProducts)
                {
                    result.Products.Add(new ShowProductsInList()
                    {
                        ProductName = product.ProductName,
                        Group = (int)product.Group.ParentId,
                        GroupName = product.Group.Parent.GroupName,
                        SubGroup = product.GroupId,
                        SubGroupName = product.Group.GroupName,
                        ProductId = product.ProductId,
                        ProductPrice = product.Price,
                    });
                }
            }

            return result;
        }

        public List<string> SearchProduct(string term)
        {
            IQueryable<Domain.Entities.Product.Product> products = _productRepository.SearchProduct(term);

            List<string> result = products.Select(p => p.ProductName).ToList();

            return result;
        }

        public List<string> SearchProductNotSlide(string term)
        {
            IQueryable<Domain.Entities.Product.Product> products = _productRepository.SearchProductNotSlide(term);

            List<string> result = products.Select(p => p.ProductName).ToList();

            return result;
        }
    }
}