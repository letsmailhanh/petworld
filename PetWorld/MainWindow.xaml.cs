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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUserRepository userRepo;
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        IPetDetailRepository petRepo;
        IOrderRepository orderRepo;
        public MainWindow(IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository, IOrderRepository orderRepository)
        {
            InitializeComponent();
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
            orderRepo = orderRepository;
        }

        private void btnSignupClick(object sender, RoutedEventArgs e)
        {
            var signup = new WindowSignup(userRepo, productRepo, categoryRepo, petRepo, orderRepo);
            signup.Show();
            this.Close();
        }

        private void btnSigninClick(object sender, RoutedEventArgs e)
        {
            var signin = new WindowLogin(userRepo, productRepo, categoryRepo, petRepo, orderRepo);
            signin.Show();
            this.Close();
        }
    }
}
