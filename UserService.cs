using BookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService()
        {
            _context = new ApplicationDbContext();
        }
        public void CreateUser(string name, string email, string role)
        {
            var user = new User { Name = name , Email = email , Role = role };
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
           return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void UpdateUser(int id, string newName, string newEmail, string newRole)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return;
            }
            user.Name = newName;
            user.Email = newEmail;
            user.Role = newRole;
            _context.SaveChanges();
        }
    }
}
