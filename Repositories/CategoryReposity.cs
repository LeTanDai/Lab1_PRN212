using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryReposity : ICategoryReposity
    {
        public List<Category> GetCategories()
        {
            return CategoryDAO.Instance.GetCategories();
        }
    }
}
