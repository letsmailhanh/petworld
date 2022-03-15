using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product p) => ProductDAO.Instance.AddProduct(p);
        public void DeleteProduct(Product p) => ProductDAO.Instance.DeleteProduct(p);

        public IEnumerable<Product> GetAccessories() => ProductDAO.Instance.GetAccessoryList();

        public IEnumerable<Product> GetPets() => ProductDAO.Instance.GetPetList();

        public Product GetProductByID(int id) => ProductDAO.Instance.GetProductByID(id);

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public IEnumerable<Product> GetProductsByCatID(int catID) => ProductDAO.Instance.GetProductListByCatID(catID);

        public void UpdateProduct(Product p) => ProductDAO.Instance.UpdateProduct(p);
    }
}
