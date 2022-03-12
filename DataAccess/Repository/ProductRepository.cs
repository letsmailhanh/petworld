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
        public IEnumerable<Product> GetAccessories() => ProductDAO.Instance.GetAccessoryList();

        public IEnumerable<Product> GetPets() => ProductDAO.Instance.GetPetList();

        public IEnumerable<Product> GetProducts() => ProductDAO.Instance.GetProductList();

        public IEnumerable<Product> GetProductsByCatID(int catID) => ProductDAO.Instance.GetProductListByCatID(catID);
    }
}
