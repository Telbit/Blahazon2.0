using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class SQLProductRepository : IProductRepository
    {
        private AppDbContext context;

        public SQLProductRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
        void IProductRepository.Add(Product product)
        {
            context.Add<Product>(product);
            context.SaveChanges();
        }

        void IProductRepository.Delete(long id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        IEnumerable<Product> IProductRepository.GetAllProduct()
        {
            return context.Products;
        }

        Product IProductRepository.GetProduct(long id)
        {
            return context.Products.Find(id);
        }

        void IProductRepository.Update(Product product)
        {
            var productToUpdate = context.Attach(product);
            productToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
