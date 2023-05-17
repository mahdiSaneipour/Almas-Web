using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.SubGroups
{
    [Authorize(Roles = "Admin")]
    public class EditSubGroupModel : PageModel
    {
        private readonly IAdminGroupService _adminGroupService;

        public EditSubGroupModel(IAdminGroupService adminGroupService)
        {
            _adminGroupService = adminGroupService;
        }

        [BindProperty]
        public ProductGroup Group { get; set; }

        public void OnGet(int groupId)
        {

            Group = _adminGroupService.GetGroupByGroupId(groupId);

        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(Group.GroupName))
            {
                return Page();
            }
            Console.WriteLine("parent : " + Group.ParentId);

            _adminGroupService.UpdateGroup(Group);

            return RedirectToPage("Index", new { parentId = Group.ParentId });
        }
    }
}
