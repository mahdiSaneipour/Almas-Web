using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Discount
{
    public interface IDiscountRepository
    {
        public Entities.Product.ProductDiscount GetDiscountByDiscountId(int discountId);

        public int GetDiscountPercentByDiscountId(int discountId);

        public IQueryable<Entities.Product.ProductDiscount> GetAllDiscounts();

        public int GetDiscountPercentByProductId(int productId);

        public IQueryable<ProductDiscount> GetGoldenDiscounts();

        public void AddDiscount(Entities.Product.ProductDiscount discount);

        public void RemoveDiscount(Entities.Product.ProductDiscount discount);

        public void UpdateDiscount(Entities.Product.ProductDiscount discount);

        public void SaveChanges();
    }
}
