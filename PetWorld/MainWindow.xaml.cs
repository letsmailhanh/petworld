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
        IOrderDetailRepository ordDetailRepo;
        public MainWindow(IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            InitializeComponent();
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
            orderRepo = orderRepository;
            ordDetailRepo = orderDetailRepository;
        }

        private void btnSignupClick(object sender, RoutedEventArgs e)
        {
            var signup = new WindowSignup(userRepo, productRepo, categoryRepo, petRepo, orderRepo, ordDetailRepo);
            signup.Show();
            this.Close();
        }

        private void btnSigninClick(object sender, RoutedEventArgs e)
        {
            var signin = new WindowLogin(userRepo, productRepo, categoryRepo, petRepo, orderRepo, ordDetailRepo);
            signin.Show();
            this.Close();
        }
    }
}
