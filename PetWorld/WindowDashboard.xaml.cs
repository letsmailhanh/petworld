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
    /// Interaction logic for WindowDashboard.xaml
    /// </summary>
    public partial class WindowDashboard : Window
    {
        User user;
        IUserRepository userRepo;
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        IPetDetailRepository petRepo;
        IOrderRepository orderRepo;
        public WindowDashboard(User u, IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository, IOrderRepository orderRepository)
        {
            InitializeComponent();
            user = u;
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
            orderRepo = orderRepository;
        }

        private void btnUserClick(object sender, RoutedEventArgs e)
        {
            var userWindow = new WindowUser(userRepo, user);
            userWindow.Show();
            this.Close();
        }

        private void btnProductClick(object sender, RoutedEventArgs e)
        {
            var productWindow = new WindowProduct(user, productRepo, categoryRepo, petRepo);
            productWindow.Show();
            this.Close();
        }

        private void btnOrderClick(object sender, RoutedEventArgs e)
        {
            var orderWindow = new WindowOrder(orderRepo);
            orderWindow.Show();
            this.Close();
        }
    }
}
