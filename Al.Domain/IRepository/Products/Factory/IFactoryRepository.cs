using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Factory
{
    public interface IFactoryRepository
    {
        public IQueryable<Entities.Product.ProductFactory> GetAllFactories();

        public Entities.Product.ProductFactory GetFactoryByFactoryId(int factoryId);

        public void AddFactory(Entities.Product.ProductFactory factory);

        public void EditFactory(Entities.Product.ProductFactory factory);

        public void RemoveFactory(Entities.Product.ProductFactory factory);

        public void SaveChanges();
    }
}
