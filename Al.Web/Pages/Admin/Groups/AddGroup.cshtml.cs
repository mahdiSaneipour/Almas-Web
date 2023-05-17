using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Groups
{
    [Authorize(Roles = "Admin")]
    public class AddGroupModel : PageModel
    {
        private readonly IAdminGroupService _adminGroupService;

        public AddGroupModel(IAdminGroupService adminGroupService)
        {
            _adminGroupService = adminGroupService;
        }

        [BindProperty]
        public ProductGroup Group { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (Group.GroupName == null)
            {
                return Page();
            }

            _adminGroupService.AddGroup(Group);

            return RedirectToPage("Index");
        }
    }
}
