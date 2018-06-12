using AWM.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWM.BusinessLayer
{
    public class ProductLogic
    {
        ProductRepository pr = new ProductRepository();

        public Task<List<Product>> GetAllProducts()
        {
            return pr.GetAllProducts();
        }

        public void SaveProduct(Product p)
        {
            if (p.ListPrice < 0)
                throw new Exception("ListPrice may not be negative!");

            if (p.StandardCost < 0)
                throw new Exception("StandardCost may not be negative!");

            p.ModifiedDate = DateTime.Now;

            pr.SaveProduct(p);
        }

        public List<Product> GetProducts(int productCategoryID)
        {
            return pr.GetProducts(productCategoryID);
        }
    }
}
