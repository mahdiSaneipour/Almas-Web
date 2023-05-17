using Al.Core.DTOs.Profile;
using Al.Core.IServices.Profile;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(IHttpContextAccessor contextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;

        }

        public async void EditUserInformation(ShowUserInformation info)
        {
            ApplicationUser user = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result;

            user.Address = info.Address;
            user.PhoneNumber = info.Phone;
            user.Email = info.Email;
            user.UserName = info.Username;
            user.Name = info.Name;

            var identity = _userManager.UpdateAsync(user).Result;
        }

        public ShowUserInformation GetUserInformationForProfile()
        {
            ShowUserInformation info = new ShowUserInformation();

            ApplicationUser user = _userManager.GetUserAsync(_contextAccessor.HttpContext.User).Result;

            info.Address = user.Address;
            info.Phone = user.PhoneNumber;
            info.Email = user.Email;
            info.Username = user.UserName;
            info.Name = user.Name;

            return info;
        }
    }
}
