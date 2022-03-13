using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAccessoryCategories() => CategoryDAO.Instance.GetAccessoryCategory();

        public IEnumerable<Category> GetCategories() => CategoryDAO.Instance.GetCategoryList();

        public IEnumerable<Category> GetPetCategories() => CategoryDAO.Instance.GetPetCategory();
    }
}
