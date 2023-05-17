using Al.Core.DTOs.ChangePassword;
using Al.Core.DTOs.ResetPassword;
using Al.Core.Enums.Profile;
using Al.Core.ExtraViewModel.ResetPassword;
using Al.Core.IServices.Profile;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.User;
using EP.Core.Tools.RenderViewToString;
using EP.Core.Tools.Senders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Profile
{
    public class PasswordService : IPasswordService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _context;
        private readonly IUserRepository _userRepository;
        private readonly IViewRenderService _viewRenderService;

        public PasswordService(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor context, IUserRepository userRepository,
            IViewRenderService viewRenderService)
        {
            _userManager = userManager;
            _context = context;
            _userRepository = userRepository;
            _viewRenderService = viewRenderService;
        }

        public async Task<ChangePasswordEnum> ChangePassword(ChangePasswordViewModel model)
        {
            ApplicationUser user = _userManager.GetUserAsync(_context.HttpContext.User).Result;

            if (!_userManager.CheckPasswordAsync(user, model.OldPassword).Result)
            {
                return ChangePasswordEnum.CurrentPasswordNotValid;
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if(result.Succeeded)
            {
                return ChangePasswordEnum.Success;
            } else
            {
                return ChangePasswordEnum.NewPasswordNotValid;
            }
        }

        public async Task<EmailResetPasswordViewModel> ForgotPassword(string email)
        {
            ApplicationUser user = _userRepository.GetUserByEmail(email);

            if (user == null || !_userManager.IsEmailConfirmedAsync(user).Result)
            {
                return null;
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var link = $"{_context.HttpContext.Request.Scheme}://{_context.HttpContext.Request.Host}/Account/ResetPassword?email={email}&token={token}";

            EmailResetPasswordViewModel model = new EmailResetPasswordViewModel()
            {
                Link = link
            };

            return model;
        }

        public async Task<bool> ResetPassword(ResetPasswordViewModel model)
        {
            ApplicationUser user = _userManager.FindByEmailAsync(model.Email).Result;

            if(user == null)
            {
                return false;
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if(result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}