using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User u) => UserDAO.Instance.AddUser(u);

        public void DeleteUser(User u) => UserDAO.Instance.DeleteUser(u);

        public IEnumerable<User> GetCustomers() => UserDAO.Instance.GetCustomerList();

        public IEnumerable<User> GetCustomersByKey(string key) => UserDAO.Instance.GetListUserByKey(key);

        public User GetUserByUsername(string username) => UserDAO.Instance.GetUserByUsername(username);


        public IEnumerable<User> GetUsers() => UserDAO.Instance.GetUserList();

        public void UpdateUser(User u) => UserDAO.Instance.UpdateUser(u);
        public User GetUserByUsernameAndPassword(string username, string password) => UserDAO.Instance.GetUserByUsernameAndPassword(username, password);

        public User GetUserByEmail(string email) => UserDAO.Instance.GetUserByEmail(email);

        public void SendMail(string userEmail, string subject, string message) => UserDAO.Instance.SendEmail(userEmail, subject, message);
    }
}
