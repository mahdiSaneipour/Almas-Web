using Al.Core.DTOs.Accounts;
using Al.Core.ServiceModels.Singup;
using Al.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Account
{
    public interface IAccountService
    {
        public ApplicationUser GetuserByUserId(string userId);

        public ApplicationUser GetUserByEmail(string email);

        public SingupServiceModel CreatApplicationForSingup(SingupViewModel model);
    }
}
