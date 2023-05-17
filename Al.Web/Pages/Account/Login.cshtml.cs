using Al.Core.DTOs.Accounts;
using Al.Core.IServices.Account;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;

        public LoginModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        [BindProperty]
        public LoginViewModel User { get; set; }

        public void OnGet()
        {
            User = new LoginViewModel();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = _accountService.GetUserByEmail(User.Email);

            if (user == null)
            {
                ModelState.AddModelError("User.Email", "کاربری با این ایمیل وجود ندارد");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user, User.Password, true, false);

            if (result.Succeeded)
            {
                if(await _userManager.IsEmailConfirmedAsync(user))
                {
                    return await Task.FromResult(Redirect("/"));
                }

                ModelState.AddModelError("User.Email", "ابتدا ایمیل خود را تایید کنید");
                return Page();
            }

            ModelState.AddModelError("User.Password", "رمز عبور و ایمیل مطابقت ندارند");

            return Page();
        }
    }
}
