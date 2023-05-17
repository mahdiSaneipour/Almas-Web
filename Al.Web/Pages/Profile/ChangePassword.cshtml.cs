using Al.Core.DTOs.ChangePassword;
using Al.Core.Enums.Profile;
using Al.Core.IServices.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Profile
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly IPasswordService _passwordService;

        public ChangePasswordModel(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [BindProperty]
        public ChangePasswordViewModel Model { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            ChangePasswordEnum result = _passwordService.ChangePassword(Model).Result;

            if (result == ChangePasswordEnum.CurrentPasswordNotValid)
            {
                ModelState.AddModelError("Model.OldPassword", "رمز فعلی صحیح نمیباشد");
                return Page();
            } else if (result == ChangePasswordEnum.NewPasswordNotValid)
            {
                ModelState.AddModelError("Model.NewPassword", "لطفا رمز طولانی تری انتخاب کنید");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
