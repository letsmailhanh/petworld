﻿using DataAccess.DAO;
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
        public IEnumerable<User> GetCustomers() => UserDAO.Instance.GetCustomerList();

        public User GetUserByUsername(string username) => UserDAO.Instance.GetUserByUsername(username);

        public IEnumerable<User> GetUsers() => UserDAO.Instance.GetUserList();
    }
}