using Al.Core.DTOs.Admin.Factory;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminFactoryService
    {
        public BoxFactoryInList GetFactoriesInList(int pageId);

        public ProductFactory GetFactoryByFactoryId(int factoryId);

        public void DeleteFactory(int factoryId);

        public void UpdateFactory(ProductFactory factory);

        public void AddFactory(ProductFactory factory);
    }
}
