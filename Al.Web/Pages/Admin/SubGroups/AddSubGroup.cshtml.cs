using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.SubGroups
{
    [Authorize(Roles = "Admin")]
    public class AddSubGroupModel : PageModel
    {
        private readonly IAdminGroupService _adminGroupService;

        public AddSubGroupModel(IAdminGroupService adminGroupService)
        {
            _adminGroupService = adminGroupService;
        }

        [BindProperty]
        public ProductGroup Group { get; set; }

        public void OnGet(int parentId)
        {
            Group = new ProductGroup
            {
                ParentId = parentId
            };
        }

        public IActionResult OnPost()
        {
            if (Group.GroupName == null)
            {
                return Page();
            }

            _adminGroupService.AddGroup(Group);

            return RedirectToPage("Index", new { parentId = Group.ParentId });
        }
    }
}
