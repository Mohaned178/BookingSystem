using BookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore
{
    public interface IUserService
    {
        void CreateUser(string name, string email, string role);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(int id, string newName, string newEmail, string newRole);
        void DeleteUser(int id);

    }
}
