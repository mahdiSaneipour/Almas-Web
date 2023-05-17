using Al.Core.DTOs.ChangePassword;
using Al.Core.DTOs.ResetPassword;
using Al.Core.Enums.Profile;
using Al.Core.ExtraViewModel.ResetPassword;
using Al.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Profile
{
    public interface IPasswordService
    {
        public Task<ChangePasswordEnum> ChangePassword(ChangePasswordViewModel model);

        public Task<EmailResetPasswordViewModel> ForgotPassword(string email);

        public Task<bool> ResetPassword(ResetPasswordViewModel model);
    }
}
