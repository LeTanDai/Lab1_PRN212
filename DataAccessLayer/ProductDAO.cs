using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        List<Product> list;
        public ProductDAO()
        {
            list = new List<Product>
            {
                new Product{ProductId = 1, ProductName="Chai", CategoryId = 3, UnitsInStock = 12, UnitPrice=18},
                new Product{ProductId = 2, ProductName="Chang", CategoryId = 1, UnitsInStock = 23, UnitPrice=19},
                new Product{ProductId = 3, ProductName="Aniseed Syup", CategoryId = 2, UnitsInStock = 23, UnitPrice=10}

            };
        }
        public List<Product> GetProducts()
        {
            //list.AddRange(new List<Product>() {
            //    new Product{ProductId = 1, ProductName="Chai", CategoryId = 3, UnitsInStock = 12, UnitPrice=18},
            //    new Product{ProductId = 2, ProductName="Chang", CategoryId = 1, UnitsInStock = 23, UnitPrice=19},
            //    new Product{ProductId = 1, ProductName="Aniseed Syup", CategoryId = 2, UnitsInStock = 23, UnitPrice=10}


            //});
            return list;
        }
        public int GetMaxProductId()
        {
            if(list.Count > 0)
            {
                return list.Max(p => p.ProductId) + 1;
            }
            else
            {
                return 0;
            }
        }
        public void SaveProduct(Product product)
        {
            list.Add(product);
        } 
        public void UpdateProduct(Product product)
        {
            foreach(var current in list.ToList())
            {
                if(current.ProductId == product.ProductId)
                {
                    current.ProductName = product.ProductName;
                    current.CategoryId = product.CategoryId;
                    current.ProductId = product.ProductId;
                    current.UnitPrice = product.UnitPrice;
                    current.UnitsInStock = product.UnitsInStock;
                }
            }
        }
        public void DeleteProduct(Product product)
        {
            foreach (var current in list.ToList())
            {
                if(current.ProductId == product.ProductId)
                {
                    list.Remove(product);
                }
            }
        }
        public Product GetProductId(int id)
        {
            foreach (var current in list.ToList())
            {
                if (current.ProductId == id)
                {
                    return current;
                }
            }
            return null;

        }
        
    }
}
