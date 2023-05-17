using Al.Core.DTOs.Accounts;
using Al.Core.Enums.Account;
using Al.Core.IServices.Account;
using Al.Core.ServiceModels.Singup;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userService;

        public AccountService(IUserRepository userService)
        {
            _userService = userService;
        }

        public SingupServiceModel CreatApplicationForSingup(SingupViewModel model)
        {
            SingupServiceModel result = new SingupServiceModel();

            bool emaiStatus = _userService.IsEmailExist(model.Email);

            if (emaiStatus)
            {
                result.Status = SingupEnum.NotValidEmail;
                return result;
            }

            bool usernameStatus = _userService.IsUsernameExist(model.Username);

            if (usernameStatus)
            {
                result.Status = SingupEnum.NotValidUsername;
                return result;
            }

            ApplicationUser user = new ApplicationUser();

            user.PhoneNumber = model.Number;
            user.UserName = model.Username;
            user.Email = model.Email;
            user.Name = model.Name;

            result.User = user;

            result.Status = SingupEnum.Success;

            return result;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }

        public ApplicationUser GetuserByUserId(string userId)
        {
            return _userService.GetUserByUserId(userId);
        }
    }
}