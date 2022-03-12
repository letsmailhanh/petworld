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
    /// Interaction logic for WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        User user;
        IProductRepository productRepo;
        ICategoryRepository categoryRepo;
        public WindowProduct(User u, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            user = u;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            LoadProductList();
            LoadCategoryList();
        }

        private void LoadProductList()
        {
            List<Product> products = productRepo.GetProducts().ToList();
            lvProducts.ItemsSource = products;
        }

        private void LoadCategoryList()
        {
            List<Category> categories = categoryRepo.GetCategories().ToList();
            cbCategory.ItemsSource = categories;
        }

        private void cbCategoryChange(object sender, SelectionChangedEventArgs e)
        {
            Category selected = (Category)cbCategory.SelectedItem;
            int catID = Convert.ToInt32(selected.CategoryId);
            List<Product> products = productRepo.GetProductsByCatID(catID).ToList();
            lvProducts.ItemsSource = products;
        }
    }
}
