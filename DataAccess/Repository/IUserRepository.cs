using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetCustomers();
        User GetUserByUsername(string username);
        void AddUser(User u);
        void UpdateUser(User u);
        void DeleteUser(User u);
    }
}
