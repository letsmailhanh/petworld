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
            cbCategory1.SelectedIndex = 0;
        }

        private void LoadProductList()
        {
            List<Product> products = productRepo.GetProducts().ToList();
            lvProducts.ItemsSource = products;
        }

        private void LoadCategoryList()
        {
            List<Category> categories = categoryRepo.GetCategories().ToList();
            List<Product> products = productRepo.GetProducts().ToList();
            Category all = new Category("Tất cả");
            categories.Add(all);
            cbCategory2.ItemsSource = categories;
            cbCategory2.SelectedIndex = categories.Count - 1;
        }

        private void cbCategory1Change(object sender, SelectionChangedEventArgs e)
        {
            string selected = cbCategory1.SelectedValue.ToString();
            List<Category> categories;
            if (selected.Equals("Pet"))
            {
                categories = categoryRepo.GetPetCategories().ToList();
            }else if (selected.Equals("Accessory"))
            {
                categories = categoryRepo.GetAccessoryCategories().ToList();
            }
            else
            {
                categories = categoryRepo.GetCategories().ToList();
            }
            cbCategory2.ItemsSource = categories;
            Category all = new Category("Tất cả");
            categories.Add(all);
            cbCategory2.SelectedIndex = categories.Count - 1;
        }

        private void cbCategory2Change(object sender, SelectionChangedEventArgs e)
        {
            Category selected = (Category)cbCategory2.SelectedItem;
            string selectedName;
            if (selected == null)
            {
                selectedName = "Tất cả";
            }
            else
            {
                selectedName = selected.Title.ToString();
            }
            List<Product> products;
            if (selectedName.Equals("Tất cả"))
            {
                products = productRepo.GetProducts().ToList();
            }
            else
            {
                int catID = Convert.ToInt32(selected.CategoryId);
                products = productRepo.GetProductsByCatID(catID).ToList();
            }
            lvProducts.ItemsSource = products;
        }
    }
}
