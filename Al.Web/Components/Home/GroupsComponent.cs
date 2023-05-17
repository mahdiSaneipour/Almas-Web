using Al.Domain.Entities.Product;
using Al.Domain.IRepository.Products.Group;
using Microsoft.AspNetCore.Mvc;

namespace Al.Web.Components.Home
{
    public class GroupsComponent:ViewComponent
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            List<ProductGroup> groups = _groupRepository.GetAllGroups().ToList();

            return await Task.FromResult((IViewComponentResult)View("../Home/ShowGroups", groups));
        }
    }
}
