using Al.Core.DTOs.Admin.Group;
using Al.Core.IServices.Admin;
using Al.Core.Services.Admin;
using Al.Domain.Entities.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Al.Web.Pages.Admin.SubGroups
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminGroupService _adminGroupService;
        private readonly IAdminProductService _adminProductService;

        public IndexModel(IAdminGroupService adminGroupService, IAdminProductService adminProductService)
        {
            _adminGroupService = adminGroupService;
            _adminProductService = adminProductService;
        }

        public BoxGroupInList Groups { get; set; }

        public IActionResult OnGet(int ?parentId = 0, int pageId = 1)
        {
            Groups = _adminGroupService.GetSubGroups((int) parentId, pageId);

            if (pageId != Groups.PageId && pageId != 1)
            {
                string oldPageId = $"pageId={pageId}";
                string newPageId = $"pageId={Groups.PageId}";
                string url = HttpContext.Request.Path + HttpContext.Request.QueryString.Value.Replace(oldPageId, newPageId);

                return Redirect(url);
            }

            SelectList groups = _adminProductService.GetAllParentGroups();
            ViewData["LGroups"] = groups;

            ViewData["ParentId"] = parentId;

            return Page();
        }


        public IActionResult OnGetDeleteGroup(int groupId)
        {
            _adminGroupService.DeleteGroup(groupId);

            Groups = _adminGroupService.GetParentGroups(1);

            return RedirectToPage("Index");
        }
    }
}
