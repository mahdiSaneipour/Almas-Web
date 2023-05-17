using Al.Core.DTOs.Admin.Country;
using Al.Core.DTOs.Admin.Factory;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminFactoryService : IAdminFactoryService
    {
        private readonly IFactoryRepository _factoryRepository;

        public AdminFactoryService(IFactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }

        public void AddFactory(ProductFactory factory)
        {
            _factoryRepository.AddFactory(factory);
            _factoryRepository.SaveChanges();
        }

        public void DeleteFactory(int factoryId)
        {
            ProductFactory factory = _factoryRepository.GetFactoryByFactoryId(factoryId);

            if(factory == null)
            {
                return;
            }

            _factoryRepository.RemoveFactory(factory);
            _factoryRepository.SaveChanges();
        }

        public BoxFactoryInList GetFactoriesInList(int pageId = 1)
        {
            BoxFactoryInList result = new BoxFactoryInList();

            IQueryable<ProductFactory> factories = _factoryRepository.GetAllFactories();

            if (factories == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = factories.Count() / take;

            result.Factories = factories.ToList().Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }

        public ProductFactory GetFactoryByFactoryId(int factoryId)
        {
            return _factoryRepository.GetFactoryByFactoryId(factoryId);
        }

        public void UpdateFactory(ProductFactory factory)
        {
            _factoryRepository.EditFactory(factory);
            _factoryRepository.SaveChanges();
        }
    }
}
