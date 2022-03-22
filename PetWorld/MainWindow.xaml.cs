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
        public MainWindow(IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository)
        {
            InitializeComponent();
            userRepo = userRepository;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
        }

        private void btnSignupClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSigninClick(object sender, RoutedEventArgs e)
        {
            var signin = new WindowLogin(userRepo, productRepo, categoryRepo, petRepo);
            signin.Show();
            this.Close();
        }
    }
}
