using Al.Core.DTOs.Admin.User;
using Al.Core.Enums.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Admin
{
    public interface IAdminUserService
    {
        public UsersInListViewModel GetUsersForAdmin(int pageId, string search, UsersFilterBy filter);

        public ShowUserViewModel GetUserByUserId(string userId);

        public Task<EditUserAdminEnum> EditUser(ShowUserViewModel model);

        public void DeleteUserByUserId(string userId);
    }
}