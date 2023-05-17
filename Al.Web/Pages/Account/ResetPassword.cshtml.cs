using Al.Core.DTOs.ResetPassword;
using Al.Core.IServices.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IPasswordService _passwordService;

        public ResetPasswordModel(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [BindProperty]
        public ResetPasswordViewModel Model { get; set; }

        public void OnGet(string email, string token)
        {
            Model = new ResetPasswordViewModel { Email = email, Token = token.Replace(" ", "+") };
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("token : " + Model.Token + " email : " + Model.Email);

            bool result = _passwordService.ResetPassword(Model).Result;

            if(result)
            {
                return RedirectToPage("Login");
            }

            ModelState.AddModelError("Model.Password","توکن نامعتبر است, دوباره تلاش کنید");

            return Page();
        }

    }
}