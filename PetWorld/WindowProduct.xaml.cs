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
        IPetDetailRepository petRepo;
        //List<Product> selectedProducts;
        public WindowProduct(User u, IProductRepository productRepository, ICategoryRepository categoryRepository, IPetDetailRepository petRepository)
        {
            InitializeComponent();
            user = u;
            productRepo = productRepository;
            categoryRepo = categoryRepository;
            petRepo = petRepository;
            LoadProductList();
            LoadCategoryList();
            LoadPetInformation();
            cbCategory1.SelectedIndex = 0;
        }

        private void LoadProductList()
        {
            List<Product> products = productRepo.GetProducts().ToList();
            //selectedProducts = products;
            lvProducts.ItemsSource = products;
        }

        private void LoadCategoryList()
        {
            List<Category> categories = categoryRepo.GetCategories().ToList();
            List<Product> products = productRepo.GetProducts().ToList();
            //selectedProducts = products;
            Category all = new Category("Tất cả");
            categories.Add(all);
            cbCategory2.ItemsSource = categories;
            cbCategory2.SelectedIndex = categories.Count - 1;
        }

        private void cbCategory1Change(object sender, SelectionChangedEventArgs e)
        {
            //Get selected category
            string selected = cbCategory1.SelectedValue.ToString();
            List<Category> categories;
            List<Product> products;

            //Get list sub categories
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

            //Set sub categories
            cbCategory2.ItemsSource = categories;

            //Set product list
            products = productRepo.GetProducts().ToList();

            //selectedProducts = products;
            lvProducts.ItemsSource = products;

            //Add selection "All"
            Category all = new Category("Tất cả");
            categories.Add(all);

            //Set default selected index of sub category
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
            //selectedProducts = products;
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

                    int pID = Convert.ToInt32(product.ProductId);
                    PetDetail detail = petRepo.GetPetDetailByProductID(pID);
                    tbPetID.Text = detail.PetId.ToString();
                    tbWeight.Text = detail.Weight.ToString();
                    tbAge.Text = detail.Age.ToString();
                    tbName.Text = detail.PetName.ToString();
                    if(detail.Vaccinated == true)
                    {
                        rbVaccinated.IsChecked = true;
                    }
                    else
                    {
                        rbVaccinated.IsChecked = false;
                    }
                    if(detail.Gender == true)
                    {
                        rbMale.IsChecked = true;
                    }
                    else
                    {
                        rbFemale.IsChecked = true;
                    }
                    if (detail.IsRescued == true)
                    {
                        rbIsRescued.IsChecked = true;
                    }
                    else
                    {
                        rbIsRescued.IsChecked = false;
                    }
                    if (detail.Sterilized == true)
                    {
                        rbSterilized.IsChecked = true;
                    }
                    else
                    {
                        rbSterilized.IsChecked = false;
                    }
                }
                else
                {
                    spnPetInformation.Visibility = Visibility.Collapsed;
                }
            }
        }

        private Product GetProductObject()
        {
            Product p = null;
            try
            {
                int id = int.Parse(tbProductID.Text);
                string name = Convert.ToString(tbName.Text);
                int catID = int.Parse(tbCategory.Text);
                bool isPet = bool.Parse(tbIsPet.Text);
                decimal price = decimal.Parse(tbPrice.Text);
                int inStock = int.Parse(tbUnitInStock.Text);
                string image = Convert.ToString(tbImageLink.Text);
                p = new Product(id, name, catID, isPet, price, inStock, image);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        private PetDetail GetPetDetailObject()
        {
            PetDetail pd = null;
            try
            {
                int pid = Convert.ToInt32(tbProductID.Text);
                int id = Convert.ToInt32(tbPetID.Text);
                string name = tbName.Text;
                double age = Convert.ToDouble(tbAge.Text);
                double weight = Convert.ToDouble(tbWeight.Text);
                bool vaccinated = Convert.ToBoolean(rbVaccinated.IsChecked);
                bool sterilized = Convert.ToBoolean(rbSterilized.IsChecked);
                bool rescued = Convert.ToBoolean(rbIsRescued.IsChecked);
                bool gender;
                if (Convert.ToBoolean(rbMale.IsChecked))
                {
                    gender = true;
                }
                else
                {
                    gender = false;
                }
                pd = new PetDetail(id, pid, name, weight, vaccinated, gender, age, sterilized, rescued);
                MessageBox.Show($"Pet detail: product id {pid} - pet id {id} - {name} - {weight} \n - {age} - vaccine {vaccinated} - {sterilized} - {rescued} - {gender}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return pd;
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnUpdateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(tbProductID.Text);
                string name = tbName.Text;
                if(name.Trim() != null)
                {
                    Product p = GetProductObject();
                    productRepo.UpdateProduct(p);
                    
                    //Neu la pet thi update them pet detail
                    bool ispet = Convert.ToBoolean(tbIsPet.Text);
                    if (ispet == true)
                    {
                        PetDetail pd = GetPetDetailObject();
                        petRepo.UpdatePetDetail(pd);
                    }

                    MessageBox.Show($"Update product {p.ProductName} successfully");
                    LoadProductList();
                }
                else
                {
                    MessageBox.Show("All information is required!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update product");
            }
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(tbProductID.Text);
                string name = tbName.Text;
                Product p = productRepo.GetProductByID(id);
                productRepo.DeleteProduct(p);
                MessageBox.Show($"Delete {name} successfully!");
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete product");
            }
        }

        private void selectProduct(object sender, SelectionChangedEventArgs e)
        {
            LoadPetInformation();
            //Product p = (Product)lvProducts.SelectedItem;
            //MessageBox.Show($"{p.IsPet}");
        }
    }
}
