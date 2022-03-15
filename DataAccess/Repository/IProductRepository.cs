using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetPets();
        IEnumerable<Product> GetAccessories();
        IEnumerable<Product> GetProductsByCatID(int catID);
        Product GetProductByID(int id);
        void AddProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
    }
}
