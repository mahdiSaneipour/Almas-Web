using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Factory
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly AlContext _context;

        public FactoryRepository(AlContext context)
        {
            _context = context;
        }

        public void AddFactory(ProductFactory factory)
        {
            _context.Factories.Add(factory);
        }

        public void EditFactory(ProductFactory factory)
        {
            _context.Factories.Update(factory);
        }

        public IQueryable<ProductFactory> GetAllFactories()
        {
            return _context.Factories;
        }

        public ProductFactory GetFactoryByFactoryId(int factoryId)
        {
            return _context.Factories.FirstOrDefault(f => f.FactoryId == factoryId);
        }

        public void RemoveFactory(ProductFactory factory)
        {
            _context.Factories.Remove(factory);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
