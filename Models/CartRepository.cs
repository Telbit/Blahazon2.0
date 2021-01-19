using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class CartRepository : ICartRepository
    {
        private AppDbContext context;

        public CartRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }

        public void AddProduct(long id, Product product)
        {
            Cart cart = context.Find<Cart>(id);
            
        }

        public void DeleteProduct(long cartId, long productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetCart()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(long cartId, Product product)
        {
            throw new NotImplementedException();
        }


    }
}
