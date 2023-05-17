using Al.Core.DTOs.Admin.User;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class ShowUserModel : PageModel
    {
        private readonly IAdminUserService _adminUserService;

        public ShowUserModel(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        public ShowUserViewModel User { get; set; }

        public void OnGet(string userId)
        {
            User = _adminUserService.GetUserByUserId(userId);
        }
    }
}
