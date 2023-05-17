using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Discount
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AlContext _context;

        public DiscountRepository(AlContext context)
        {
            _context = context;
        }

        public void AddDiscount(ProductDiscount discount)
        {
            _context.Discounts.Add(discount);
        }

        public IQueryable<ProductDiscount> GetAllDiscounts()
        {
            return _context.Discounts;
        }

        public ProductDiscount GetDiscountByDiscountId(int discountId)
        {
            return _context.Discounts.FirstOrDefault(d => d.DiscountId == discountId);
        }

        public int GetDiscountPercentByDiscountId(int discountId)
        {
            return _context.Discounts.FirstOrDefault(d => d.DiscountId == discountId).DiscountPercent;
        }

        public void RemoveDiscount(ProductDiscount discount)
        {
            _context.Discounts.Remove(discount);
        }

        public void UpdateDiscount(ProductDiscount discount)
        {
            _context.Update(discount);
        }

        public int GetDiscountPercentByProductId(int productId)
        {
            return (_context.Discounts.FirstOrDefault(d => d.ProductId == productId) != null) ? _context.Discounts.FirstOrDefault(d => d.ProductId == productId).DiscountPercent : 0;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IQueryable<ProductDiscount> GetGoldenDiscounts()
        {
            return _context.Discounts.Where(d => d.IsGolden == true)
                .OrderBy(d => d.DiscountPercent);
        }
    }
}
