using Al.Core.DTOs.Admin.Group;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Product;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Groups
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminGroupService _adminGroupService;

        public IndexModel(IAdminGroupService adminGroupService)
        {
            _adminGroupService = adminGroupService;
        }

        public BoxGroupInList Groups { get; set; }

        public void OnGet(int pageId)
        {
            Groups = _adminGroupService.GetParentGroups(pageId);
        }

        public IActionResult OnGetDeleteGroup(int groupId)
        {
            _adminGroupService.DeleteGroup(groupId);

            Groups = _adminGroupService.GetParentGroups(1);

            return RedirectToPage("Index");
        }
    }
}
