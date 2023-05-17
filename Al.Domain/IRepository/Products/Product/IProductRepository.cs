using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Product
{
    public interface IProductRepository
    {
        public IQueryable<Entities.Product.Product> GetAllProduct();

        public Entities.Product.Product GetProductByProductId(int productId);

        public Entities.Product.Product GetProductByProductName(string productName);

        public IQueryable<Entities.Product.Product> SearchProduct(string search);

        public IQueryable<Entities.Product.Product> SearchProductNotSlide(string search);

        public IQueryable<Entities.Product.Product> GetProductsSliderByGroupId(int parentId);

        public IQueryable<Entities.Product.Product> GetAllProductSlides();

        public string GetProductNameByProductId(int productId);

        public int GetProductIdByProductName(string productName);

        public int GetTotalProducts();

        public void AddProduct(Entities.Product.Product product);

        public void UpdateProduct(Entities.Product.Product product);

        public void DeleteProduct(Entities.Product.Product product);

        public void SaveChanges();
    }
}
