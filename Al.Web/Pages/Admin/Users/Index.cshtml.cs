using Al.Core.DTOs.Admin.User;
using Al.Core.Enums.Admin;
using Al.Core.IServices.Admin;
using Al.Core.Services.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminUserService _adminUserService;

        public IndexModel(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        public UsersInListViewModel Users { get; set; }

        public IActionResult OnGet( string search, int pageId = 1, UsersFilterBy filter = UsersFilterBy.All)
        {
            Users = _adminUserService.GetUsersForAdmin(pageId, search, filter);

            if (pageId != Users.PageId)
            {
                string oldPageId = $"pageId={pageId}";
                string newPageId = $"pageId={Users.PageId}";
                string url = HttpContext.Request.Path + HttpContext.Request.QueryString.Value.Replace(oldPageId, newPageId);

                return Redirect(url);
            }

            ViewData["Filter"] = filter;
            ViewData["Search"] = search;
            ViewData["PageId"] = pageId;

            return Page();
        }

        public IActionResult OnGetDeleteUser(string userId)
        {
            _adminUserService.DeleteUserByUserId(userId);
            return RedirectToPage("Index");
        }
    }
}
