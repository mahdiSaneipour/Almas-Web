using Al.Data.Context;
using Al.Domain.Entities.User;
using Al.Domain.IRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AlContext _context;

        public UserRepository(AlContext context)
        {
            _context = context;
        }

        public void DeleteUser(ApplicationUser user)
        {
            _context.Users.Remove(user);
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {
            return _context.Users;
        }

        public int GetTotalUsers()
        {
            return _context.Users.Count();
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public ApplicationUser GetUserByUserId(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
