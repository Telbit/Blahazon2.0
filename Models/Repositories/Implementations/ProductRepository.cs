using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        public void Add(Product product)
        {
            context.Add<Product>(product);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Remove<Product>(product);
                context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return context.Products;
        }

        public Product GetProduct(long id)
        {
            return context.Find<Product>(id);
        }

        public void Update(Product product)
        {
            var productToUpdate = context.Attach(product);
            productToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
