using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PetWorld
{
    /// <summary>
    /// Interaction logic for WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        IUserRepository userRepo;
        User user;

        public WindowUser(IUserRepository repository, User u)
        {
            InitializeComponent();
            userRepo = repository;
            user = u;
            LoadUserList();
        }

        private void LoadUserList()
        {
            if (user.Role.Equals("staff"))
            {
                List<User> users = userRepo.GetCustomers().ToList();
                lvUser.ItemsSource = users;
            }
            else
            {
                List<User> users = userRepo.GetUsers().ToList();
                lvUser.ItemsSource = users;
            }
        }

        private User GetUserObject()
        {
            User user = null;
            try
            {
                user = new User
                {
                    UserName = tbUsername.Text,
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text,
                    Address = tbAddress.Text,
                    Password = tbPass.Text,
                    Role = cbRole.SelectedValue.ToString()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return user;
        }

        private User GetUserObjectWithID()
        {
            User user = null;
            try
            {
                user = new User
                {
                    UserId = int.Parse(tbUserID.Text),
                    UserName = tbUsername.Text,
                    Phone = tbPhone.Text,
                    Email = tbEmail.Text,
                    Address = tbAddress.Text,
                    Password = tbPass.Text,
                    Role = cbRole.SelectedValue.ToString()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return user;
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                User u = GetUserObject();
                userRepo.AddUser(u);
                LoadUserList();
                MessageBox.Show($"Insert user {u.UserName} successfully", "Insert user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert user");
            }
        }

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbUserID.Text);
                User user = GetUserObjectWithID();
                userRepo.UpdateUser(user);
                LoadUserList();
                MessageBox.Show($"Update user {user.UserName} successfully", "Update user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update user");
            }
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbUserID.Text);
                User user = GetUserObjectWithID();
                userRepo.DeleteUser(user);
                LoadUserList();
                MessageBox.Show($"Delete user {user.UserName} successfully", "Delete user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete user");
            }
        }

        private void selectUser(object sender, SelectionChangedEventArgs e)
        {
            User selected = (User) lvUser.SelectedItem;
            string role;
            if (selected == null)
            {
                role = "customer";
            }
            else
            {
                role = selected.Role;
                cbRole.SelectedValue = role;
            }
        }
    }
}
