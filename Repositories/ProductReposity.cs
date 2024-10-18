using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductReposity : IProductReposity
    {
        public void SaveProduct(Product p) => ProductDAO.Instance.SaveProduct(p);
        public void UpdateProduct(Product p) => ProductDAO.Instance.UpdateProduct(p);
        public void DeleteProduct(Product p) => ProductDAO.Instance.DeleteProduct(p);
        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        public Product GetProductById(int id) => ProductDAO.Instance.GetProductId(id);
        public int GetMaxProductId() => ProductDAO.Instance.GetMaxProductId();

    }
}
