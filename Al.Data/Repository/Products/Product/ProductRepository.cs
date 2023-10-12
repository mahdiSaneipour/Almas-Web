using Al.Data.Context;
using Al.Domain.IRepository.Products.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AlContext _context;

        public ProductRepository(AlContext context)
        {
            _context = context;
        }

        public void AddProduct(Domain.Entities.Product.Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Domain.Entities.Product.Product product)
        {
            _context.Products.Remove(product);
        }

        public IQueryable<Domain.Entities.Product.Product> GetAllProduct()
        {
            return _context.Products.Include(p => p.Group).ThenInclude(g => g.Parent);
        }

        public Domain.Entities.Product.Product GetProductByProductId(int productId)
        {
            return _context.Products.Where(p => p.ProductId == productId).Include(p => p.Discount)
                .Include(p => p.Year).Include(p => p.Country).Include(p => p.Group).ThenInclude(g => g.Parent)
                .Include(p => p.Factory).Include(p => p.Color).Include(p => p.Images).FirstOrDefault();
        }

        public void UpdateProduct(Domain.Entities.Product.Product product)
        {
            _context.Products.Update(product);
        }

        public IQueryable<Domain.Entities.Product.Product> GetProductsSliderByGroupId(int parentId)
        {
            return _context.Products.Include(p => p.Group).ThenInclude(g => g.Parent).Include(p => p.Images)
                .Include(p => p.Discount).Where(p => p.Group.ParentId == parentId && p.IsSlide).AsSplitQuery();
        }

        public int GetTotalProducts()
        {
            return _context.Products.Count();
        }

        public string GetProductNameByProductId(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId).ProductName;
        }

        public IQueryable<Domain.Entities.Product.Product> SearchProduct(string search)
        {
            return _context.Products.Where(p => p.ProductName.Contains(search));
        }

        public int GetProductIdByProductName(string productName)
        {
            return _context.Products.FirstOrDefault(p => p.ProductName == productName).ProductId;
        }

        public Domain.Entities.Product.Product GetProductByProductName(string productName)
        {
            return _context.Products.FirstOrDefault(p => p.ProductName == productName);
        }

        public IQueryable<Domain.Entities.Product.Product> GetAllProductSlides()
        {
            return _context.Products.Where(p => p.IsSlide).Include(p => p.Group).ThenInclude(g => g.Parent);
        }

        public IQueryable<Domain.Entities.Product.Product> SearchProductNotSlide(string search)
        {
            return _context.Products.Where(p => p.ProductName.Contains(search) && !p.IsSlide);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
