using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        List<Product> selectedProducts;
        public WindowProduct(User u, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            user = u;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            LoadProductList();
            LoadCategoryList();
            LoadPetInformation();
            cbCategory1.SelectedIndex = 0;
        }

        private void LoadProductList()
        {
            List<Product> products = productRepo.GetProducts().ToList();
            selectedProducts = products;
            lvProducts.ItemsSource = products;
        }

        private void LoadCategoryList()
        {
            List<Category> categories = categoryRepo.GetCategories().ToList();
            List<Product> products = productRepo.GetProducts().ToList();
            selectedProducts = products;
            Category all = new Category("Tất cả");
            categories.Add(all);
            cbCategory2.ItemsSource = categories;
            cbCategory2.SelectedIndex = categories.Count - 1;
        }

        private void cbCategory1Change(object sender, SelectionChangedEventArgs e)
        {
            string selected = cbCategory1.SelectedValue.ToString();
            List<Category> categories;
            List<Product> products;
            if (selected.Equals("Pet"))
            {
                categories = categoryRepo.GetPetCategories().ToList();
            }
            else if (selected.Equals("Accessory"))
            {
                categories = categoryRepo.GetAccessoryCategories().ToList();
            }
            else
            {
                categories = categoryRepo.GetCategories().ToList();
            }
            cbCategory2.ItemsSource = categories;
            products = productRepo.GetProducts().ToList();
            selectedProducts = products;
            lvProducts.ItemsSource = products;
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
            if (cbCategory1.SelectedValue == null)
            {
                cbCategory1.SelectedValue = "Tất cả";
            }
            string subselected = cbCategory1.SelectedValue.ToString();
            
            if (selectedName.Equals("Tất cả"))
            {
                if (subselected.Equals("Pet"))
                {
                    products = productRepo.GetPets().ToList();
                }else if (subselected.Equals("Accessory"))
                {
                    products = productRepo.GetAccessories().ToList();
                }
                else
                {
                    products = productRepo.GetProducts().ToList();
                }
            }
            else
            {
                int catID = Convert.ToInt32(selected.CategoryId);
                products = productRepo.GetProductsByCatID(catID).ToList();
            }
            selectedProducts = products;
            lvProducts.ItemsSource = products;
        }

        private void cbOrderByChange(object sender, SelectionChangedEventArgs e)
        {
            string orderBy = cbOrderBy.SelectedValue.ToString();
            
            if (orderBy.Equals("Giá tăng dần"))
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProducts.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
            }
            else if (orderBy.Equals("Giá giảm dần"))
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvProducts.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Descending));
            }
        }

        private void LoadPetInformation()
        {
            Product product = (Product) lvProducts.SelectedItem;
            if(product == null)
            {
                spnPetInformation.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (product.IsPet == true)
                {
                    spnPetInformation.Visibility = Visibility.Visible;
                }
                else
                {
                    spnPetInformation.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {

        }

        private void selectProduct(object sender, SelectionChangedEventArgs e)
        {
            LoadPetInformation();
        }
    }
}
