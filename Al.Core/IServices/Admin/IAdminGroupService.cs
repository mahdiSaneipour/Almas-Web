using Al.Core.DTOs.Admin.Group;
using Al.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminGroupService
    {
        public BoxGroupInList GetGroups(int pageId = 1);

        public BoxGroupInList GetParentGroups(int pageId = 1);

        public BoxGroupInList GetSubGroups(int parentId, int pageId = 1);

        public ProductGroup GetGroupByGroupId(int groupId);

        public void UpdateGroup(ProductGroup group);

        public void DeleteSubGroupsByParentId(int parentId);

        public void AddGroup(ProductGroup group);

        public void DeleteGroup(int groupId);
    }
}
