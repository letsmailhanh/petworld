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
    }
}
