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

        private Cart FindCart(long userId)
        {
            return context.Carts.Where<Cart>(cart => cart.UserId == userId).FirstOrDefault();
        }

        public void AddLineItem(long userId, LineItem lineItem)
        {
            Cart cart = FindCart(userId);
            cart.lineItems.Add(lineItem);
            context.SaveChanges();
        }


        public void DeleteLineItem(long userId, long productId)
        {
            Cart cart = FindCart(userId);
            //should we use removeAll or find the needed lineitem and then use Remove on that
            cart.lineItems.RemoveAll(lineitem => lineitem.CurrentProduct.Id == productId);
            context.SaveChanges();
        }

        public IEnumerable<LineItem> GetCart(long userId)
        {
            Cart cart = FindCart(userId);
            return cart.lineItems;
        }

        public decimal GetTotalPrice(long userId)
        {
            Cart cart = FindCart(userId);
            decimal totalPrice = cart.lineItems.Select(total => total.GetTotalPrice()).Sum();
            return totalPrice;
        }

        public void IncreaseLineItem(LineItem lineItem)
        {
            lineItem.IncreaseQuantity();
            context.SaveChanges();
        }
        public void DecreaseLineItem(long userId, LineItem lineItem)
        {
            lineItem.DecreaseQuantity();
            if (lineItem.Quantity == 0)
            {
                DeleteLineItem(userId, lineItem.CurrentProduct.Id);
                context.SaveChanges();
            }
        }
    }
}
