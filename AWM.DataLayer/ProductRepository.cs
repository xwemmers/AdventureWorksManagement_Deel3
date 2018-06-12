using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWM.DataLayer
{
    public class ProductRepository
    {
        AdventureWorksEntities ctx = new AdventureWorksEntities();

        public ProductRepository()
        {

        }

        public Task<List<Product>> GetAllProducts()
        {
            return ctx.Products.AsNoTracking().ToListAsync();
        }

        public void SaveProduct(Product p)
        {
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public List<Product> GetProducts(int productCategoryID)
        {
            var query = from p in ctx.Products
                        where p.ProductCategoryID == productCategoryID
                        select p;

            return query.ToList();
        }
    }
}
