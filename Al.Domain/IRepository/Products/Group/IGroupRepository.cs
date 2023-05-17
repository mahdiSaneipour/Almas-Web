using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.Products.Group
{
    public interface IGroupRepository
    {
        public IQueryable<Entities.Product.ProductGroup> GetAllGroups();

        public Entities.Product.ProductGroup GetGroupByGroupId(int groupId);

        public int GetGroupIdByGroupName(string groupName);

        public int GetParentIdGroupByGroupId(int groupId);

        public List<Entities.Product.ProductGroup> GetAllParentGroups();

        public List<Entities.Product.ProductGroup> GetSubGroupsByParentId(int parentId);

        public IQueryable<ProductGroup> GetAllSubGroups();

        public void AddGroup(Entities.Product.ProductGroup group);

        public void EditGroup(Entities.Product.ProductGroup group);

        public void RemoveGroup(Entities.Product.ProductGroup group);

        public void SaveChanges();
    }
}
