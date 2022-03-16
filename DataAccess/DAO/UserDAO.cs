using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    class UserDAO
    {
        //---------------------------
        //Using Singleton Pattern
        private static UserDAO instance = null;
        private static readonly object instanceLock = new Object();

        private UserDAO() { }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }

        //Get danh sach user
        public IEnumerable<User> GetUserList()
        {
            List<User> users;
            try
            {
                var db = new prn221_petworldContext();
                users = db.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return users;
        }

        public IEnumerable<User> GetCustomerList()
        {
            List<User> users;
            List<User> result;
            try
            {
                var db = new prn221_petworldContext();
                users = db.Users.ToList();
                var query = from u in users
                            where u.Role.Equals("customer")
                            select u;
                result = query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        //Get user by usernam
        public User GetUserByUsername(string username)
        {
            User user = null;
            try
            {
                var db = new prn221_petworldContext();
                user = db.Users.SingleOrDefault(user => user.UserName.Equals(username));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        //Get user by ID
        public User GetUserByID(int id)
        {
            User user = null;
            try
            {
                var db = new prn221_petworldContext();
                user = db.Users.SingleOrDefault(user => user.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        //Add user
        public void AddUser(User u)
        {
            try
            {
                User _u = GetUserByUsername(u.UserName);
                if(_u == null)
                {
                    var db = new prn221_petworldContext();
                    db.Users.Add(u);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User da ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Update user
        public void UpdateUser(User u)
        {
            try
            {
                User _u = GetUserByID(u.UserId);
                if (_u != null)
                {
                    var db = new prn221_petworldContext();
                    db.Entry<User>(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User khong ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete user
        public void DeleteUser(User u)
        {
            try
            {
                User _u = GetUserByID(u.UserId);
                if (_u != null)
                {
                    var db = new prn221_petworldContext();
                    db.Users.Remove(u);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("User khong ton tai");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
