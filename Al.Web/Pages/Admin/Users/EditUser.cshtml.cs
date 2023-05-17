using Al.Core.DTOs.Admin.User;
using Al.Core.Enums.Admin;
using Al.Core.IServices.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Al.Web.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class EditUserModel : PageModel
    {
        private readonly IAdminUserService _adminUserService;

        public EditUserModel(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        [BindProperty]
        public ShowUserViewModel User { get; set; }

        public void OnGet(string userId)
        {
            User = _adminUserService.GetUserByUserId(userId);
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            EditUserAdminEnum result = _adminUserService.EditUser(User).Result;

            switch(result)
            {
                case EditUserAdminEnum.EmailNotValid:
                    ModelState.AddModelError("User.Email", "این ایمیل قبلا استفاده شده است");
                    return Page();

                case EditUserAdminEnum.UsernameNotValid:
                    ModelState.AddModelError("User.Username", "این نام کاربری قبلا استفاده شده است");
                    return Page();

                case EditUserAdminEnum.UserNotValid:
                    return NotFound();

                case EditUserAdminEnum.Error:
                    return NotFound();
            }

            return RedirectToPage("Index");
        }
    }
}
