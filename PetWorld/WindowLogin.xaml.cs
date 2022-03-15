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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {

        IUserRepository userRepo;
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        IPetDetailRepository petRepo;

        public WindowLogin(IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository)
        {
            InitializeComponent();
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
        }

        private void btnSigninClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = tbUsername.Text.ToString();
                string pass = pwbPass.Password.ToString();

                User u = userRepo.GetUserByUsername(username);
                if (u != null)
                {
                    if (u.Password.Equals(pass) && (u.Role.Equals("admin") || u.Role.Equals("staff")))
                    {
                        var dashboard = new WindowDashboard(u, userRepo, productRepo, categoryRepo, petRepo);
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password!");
                        pwbPass.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("User does not exist!");
                    tbUsername.Clear();
                    pwbPass.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
