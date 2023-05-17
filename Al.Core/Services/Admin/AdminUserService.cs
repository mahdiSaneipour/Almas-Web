using Al.Core.DTOs.Admin.User;
using Al.Core.Enums.Admin;
using Al.Core.IServices.Admin;
using Al.Domain.Entities.Factors;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.Services.Admin
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminUserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public void DeleteUserByUserId(string userId)
        {
            ApplicationUser user = _userRepository.GetUserByUserId(userId);

            _userRepository.DeleteUser(user);
            _userRepository.SaveChanges();
        }

        public async Task<EditUserAdminEnum> EditUser(ShowUserViewModel model)
        {
            ApplicationUser user = _userRepository.GetUserByUserId(model.UserId);

            if (user == null)
            {
                return EditUserAdminEnum.UserNotValid;
            }

            if(_userRepository.IsEmailExist(model.Email) && model.Email != user.Email)
            {
                return EditUserAdminEnum.EmailNotValid;
            }

            if(_userRepository.IsUsernameExist(model.Username) && model.Username != user.UserName)
            {
                return EditUserAdminEnum.UsernameNotValid;
            }

            user.Email = model.Email;
            user.EmailConfirmed = model.IsConfirm;
            user.Address = model.Address;
            user.PhoneNumber = model.Number;
            user.UserName = model.Username;
            user.Name = model.Name;

            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return EditUserAdminEnum.Success;
            }

            return EditUserAdminEnum.Error;
        }

        public ShowUserViewModel GetUserByUserId(string userId)
        {
            ApplicationUser user = _userRepository.GetUserByUserId(userId);

            if (user == null)
            {
                return null;
            }

            ShowUserViewModel result = new ShowUserViewModel() {
                Address = user.Address,
                Name = user.Name,
                Email = user.Email,
                IsConfirm = user.EmailConfirmed,
                Number = user.PhoneNumber,
                Username = user.UserName,
                UserId = userId
            };

            return result;
        }

        public UsersInListViewModel GetUsersForAdmin(int pageId, string search, UsersFilterBy filter)
        {
            UsersInListViewModel result = new UsersInListViewModel();
            List<ShowUsersInListViewModel> users = new List<ShowUsersInListViewModel>();

            IQueryable<ApplicationUser> qUsers = _userRepository.GetAllUsers();

            switch(filter)
            {
                case UsersFilterBy.All:
                    break;
                case UsersFilterBy.ConfirmedEmail:
                    qUsers = qUsers.Where(u => u.EmailConfirmed);
                    break;
                case UsersFilterBy.NotConfirmedEmail:
                    qUsers = qUsers.Where(u => !u.EmailConfirmed);
                    break;
            }

            if(!String.IsNullOrEmpty(search))
            {
                qUsers = qUsers.Where(u => u.Email.Contains(search) || u.UserName.Contains(search));
            }

            int take = 10;
            int totalPage = 0;

            if ((pageId - 1) * take >= qUsers.Count())
            {
                pageId = 1;
            } else
            {
                totalPage = qUsers.Count() / take;
                int skip = (pageId - 1) * take;

                users = qUsers.Skip(skip).Take(take).Select(u => new ShowUsersInListViewModel
                {
                    Email = u.Email,
                    Name = u.Name,
                    IsConfirm = u.EmailConfirmed,
                    Username = u.UserName,
                    UserId = u.Id
                }).ToList();
            }

            result.PageId = pageId;
            result.TotalPage = totalPage;
            result.Users = users;

            return result;
        }
    }
}
