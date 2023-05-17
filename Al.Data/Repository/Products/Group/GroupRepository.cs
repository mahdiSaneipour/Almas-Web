using Al.Data.Context;
using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.Products.Group
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AlContext _context;

        public GroupRepository(AlContext context)
        {
            _context = context;
        }

        public void AddGroup(ProductGroup group)
        {
            _context.Groups.Add(group);
        }

        public void EditGroup(ProductGroup group)
        {
            _context.Groups.Update(group);
        }

        public IQueryable<ProductGroup> GetAllGroups()
        {
            return _context.Groups;
        }

        public List<ProductGroup> GetAllParentGroups()
        {
            return _context.Groups.Where(g => g.ParentId == null).ToList(); ;
        }

        public IQueryable<ProductGroup> GetAllSubGroups()
        {
            return _context.Groups.Where(sg => sg.ParentId != null);
        }

        public ProductGroup GetGroupByGroupId(int groupId)
        {
            return _context.Groups.FirstOrDefault(g => g.GroupId == groupId);
        }

        public int GetGroupIdByGroupName(string groupName)
        {
            return _context.Groups.FirstOrDefault(g => g.GroupName == groupName).GroupId;
        }

        public int GetParentIdGroupByGroupId(int groupId)
        {
            return (int)_context.Groups.FirstOrDefault(g => g.GroupId == groupId).ParentId;
        }

        public List<ProductGroup> GetSubGroupsByParentId(int parentId)
        {
            return _context.Groups.Where(g => g.ParentId == parentId).ToList();
        }

        public void RemoveGroup(ProductGroup group)
        {
            _context.Groups.Remove(group);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
