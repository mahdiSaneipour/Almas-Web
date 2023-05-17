using Al.Core.ExtraViewModel.ConfirmEmail;
using Al.Core.ExtraViewModel.ResetPassword;
using Al.Core.IServices.Profile;
using EP.Core.Tools.RenderViewToString;
using EP.Core.Tools.Senders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IPasswordService _passwordService;
        private readonly IViewRenderService _viewRenderService;

        public ForgotPasswordModel(IPasswordService passwordService, IViewRenderService viewRenderService)
        {
            _passwordService = passwordService;
            _viewRenderService = viewRenderService;
        }

        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(String.IsNullOrEmpty(Email))
            {
                return Page();
            }

            EmailResetPasswordViewModel result = _passwordService.ForgotPassword(Email).Result;

            if(result == null)
            {
                return Page();
            }

            string html = _viewRenderService.RenderToStringAsync("ExternalView/Email/ForgotPasswordView", result);

            SendEmail.Send(Email, "بازیابی رمز عبور", html);

            return RedirectToPage("SentConfirmEmail", new { email = Email });
        }
    }
}
