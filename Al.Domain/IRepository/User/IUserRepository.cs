using Al.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.IRepository.User
{
    public interface IUserRepository
    {
        public ApplicationUser GetUserByUserId(string userId);

        public ApplicationUser GetUserByEmail(string email);

        public void DeleteUser(ApplicationUser user);

        public IQueryable<ApplicationUser> GetAllUsers();

        public bool IsEmailExist(string email);

        public bool IsUsernameExist(string username);

        public int GetTotalUsers();

        public void SaveChanges();
    }
}
