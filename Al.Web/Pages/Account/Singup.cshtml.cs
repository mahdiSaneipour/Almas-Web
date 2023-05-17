using Al.Core.DTOs.Accounts;
using Al.Core.ExtraViewModel.ConfirmEmail;
using Al.Core.IServices.Account;
using Al.Core.ServiceModels.Singup;
using Al.Core.Services.Account;
using Al.Domain.Entities.User;
using EP.Core.Tools.RenderViewToString;
using EP.Core.Tools.Senders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Account
{
    public class SingupModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IViewRenderService _viewRenderService;

        public SingupModel(SignInManager<ApplicationUser> signInManager, IAccountService accountService,
            UserManager<ApplicationUser> userManager, IViewRenderService viewRenderService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
            _viewRenderService = viewRenderService;
        }

        [BindProperty]
        public SingupViewModel User { get; set; }

        public void OnGet()
        {
            User = new SingupViewModel();
        }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            SingupServiceModel result = _accountService.CreatApplicationForSingup(User);

            if(result.Status == Core.Enums.Account.SingupEnum.NotValidEmail)
            {
                ModelState.AddModelError("User.Email", "این ایمیل قبلا استفاده شده است");
                return Page();
            }

            if(result.Status == Core.Enums.Account.SingupEnum.NotValidUsername)
            {
                ModelState.AddModelError("User.Username", "این نام کاربری قبلا استفاده شده");
                return Page();
            }

            var user = await _userManager.CreateAsync(result.User, User.Password);
            
            if(user.Succeeded)
            {
                string token = await _userManager.GenerateEmailConfirmationTokenAsync(result.User);

                var confirmLink = $"{this.Request.Scheme}://{this.Request.Host}/Account/ConfirmEmail?userId={result.User.Id}&token={token}&password={User.Password}";

                ConfirmEmailViewModel model = new ConfirmEmailViewModel();

                model.Name = result.User.Name;
                model.Url = confirmLink;

                string html = _viewRenderService.RenderToStringAsync("ExternalView/Email/ConfirmEmailView", model);

                SendEmail.Send(result.User.Email, "تایید ایمیل", html);

                return await Task.FromResult(RedirectToPage("SentConfirmEmail", new { email = result.User.Email}));
            } else if (user.Errors.Any(e => e.Code == "PasswordTooShort"))
            {
                ModelState.AddModelError("User.Password", "رمز نمیتواند کمتر از 8 رقم باشد");
                return Page();
            }

            return Page();

        }

        public async Task<IActionResult> OnGetLogout()
        {
            _signInManager.SignOutAsync();

            return Redirect("/");
        }
    }
}