using Al.Core.DTOs.Admin.Group;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminGroupService : IAdminGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public AdminGroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public void AddGroup(ProductGroup group)
        {
            _groupRepository.AddGroup(group);
            _groupRepository.SaveChanges();
        }

        public void DeleteGroup(int groupId)
        {
            ProductGroup group = _groupRepository.GetGroupByGroupId(groupId);

            if (group == null)
            {
                return;
            }

            if (group.ParentId == null)
            {
                DeleteSubGroupsByParentId(groupId);
            }

            _groupRepository.RemoveGroup(group);
            _groupRepository.SaveChanges();
        }

        public void DeleteSubGroupsByParentId(int parentId)
        {
            List<ProductGroup> groups = _groupRepository.GetSubGroupsByParentId(parentId);

            foreach (ProductGroup group in groups)
            {
                _groupRepository.RemoveGroup(group);
            }

            _groupRepository.SaveChanges();
        }

        public ProductGroup GetGroupByGroupId(int groupId)
        {
            return _groupRepository.GetGroupByGroupId(groupId);
        }

        public BoxGroupInList GetGroups(int pageId = 1)
        {
            BoxGroupInList result = new BoxGroupInList();

            IQueryable<ProductGroup> groups = _groupRepository.GetAllGroups();

            if(groups == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = groups.Count() / take;

            result.Groups = groups.ToList().Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }

        public BoxGroupInList GetParentGroups(int pageId = 1)
        {
            BoxGroupInList result = new BoxGroupInList();

            List<ProductGroup> groups = _groupRepository.GetAllParentGroups();

            if (groups == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = groups.Count() / take;

            result.Groups = groups.Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }

        public BoxGroupInList GetSubGroups(int parentId, int pageId)
        {
            BoxGroupInList result = new BoxGroupInList();

            IQueryable<ProductGroup> groups = null;

            if(parentId == 0)
            {
                groups = _groupRepository.GetAllSubGroups();
            } else
            {
                groups = _groupRepository.GetSubGroupsByParentId(parentId).AsQueryable();
            }

            if (groups == null)
            {
                return result;
            }

            int take = 10;
            int skip = (pageId - 1) * take;

            int totalPage = groups.Count() / take;

            result.Groups = groups.ToList().Skip(skip).Take(take).ToList();
            result.PageId = pageId;
            result.TotalPage = totalPage;

            return result;
        }

        public void UpdateGroup(ProductGroup group)
        {
            _groupRepository.EditGroup(group);
            _groupRepository.SaveChanges();
        }
    }
}
