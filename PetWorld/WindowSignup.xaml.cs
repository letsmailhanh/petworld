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
    /// Interaction logic for WindowSignup.xaml
    /// </summary>
    public partial class WindowSignup : Window
    {
        IUserRepository userRepo;
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        IPetDetailRepository petRepo;
        public WindowSignup(IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository)
        {
            InitializeComponent();
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
        }

        private User GetUserObject()
        {
            User user = null;
            try
            {
                user = new User
                {
                    UserName = tbUsername.Text,
                    Password = pwbPass.Password.ToString(),
                    Role = "staff"
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get user");
            }
            return user;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            var previous = new MainWindow(userRepo, productRepo, categoryRepo, petRepo);
            previous.Show();
            this.Close();
        }

        private void btnSignupClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = tbUsername.Text;
                string pass = pwbPass.Password.ToString();
                string cfPass = pwbConfirmPass.Password.ToString();

                User u = userRepo.GetUserByUsername(username);
                if(u == null)
                {
                    if (pass.Equals(cfPass))
                    {
                        User user = GetUserObject();
                        userRepo.AddUser(user);
                        var signin = new WindowLogin(userRepo, productRepo, categoryRepo, petRepo);
                        signin.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password khong trung nhau");
                        pwbPass.Clear();
                        pwbConfirmPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Username da ton tai");
                    tbUsername.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sign up");
            }
        }
    }
}
