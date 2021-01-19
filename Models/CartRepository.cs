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

        public void AddLineItem(long cartId, LineItem lineItem)
        {
            Cart cart = context.Find<Cart>(cartId);
            cart.lineItems.Add(lineItem);
            context.SaveChanges();
        }

        public void DeleteLineItem(long cartId, long productId)
        {
            Cart cart = context.Find<Cart>(cartId);
            cart.lineItems.RemoveAll(lineitem => lineitem.CurrentProduct.Id == productId);
        }

        public IEnumerable<LineItem> GetCart()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void UpdateLineItem(long cartId, LineItem lineItem)
        {
            throw new NotImplementedException();
        }
    }
}
