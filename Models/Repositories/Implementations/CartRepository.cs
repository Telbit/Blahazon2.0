using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public long GetCartId(long userId)
        {
            Cart cart = _context.Carts.Where(cart => cart.UserId == userId).FirstOrDefault();
            if (cart != null)
            {
                return cart.Id;
            }
            else
            {
                throw new NullReferenceException("Cart with the given User ID Not Found !");
            }
        }
        public void AddNewCart(long userId)
        {
            _context.Carts.Add(new Cart() { UserId = userId });
            _context.SaveChanges();
        }

        public IEnumerable<LineItem> GetCart(long userId)
        {
            Cart cart = _context.Carts.Where<Cart>(cart => cart.UserId == userId).FirstOrDefault();
            Cart cartTwo = _context.Carts.Include(cart => cart.LineItems).Where<Cart>(cart => cart.UserId == userId).FirstOrDefault();

            if (cart != null)
            {
                IEnumerable<LineItem> lineItems = _context.LineItems.Where<LineItem>(lineitem => lineitem.CartId == cart.Id);
                return lineItems;
            }
            else
            {
                throw new NullReferenceException("Cart with the given User ID Not Found !");
            }
            
        }

        public decimal GetTotalPrice(long userId)
        {
            throw new NotImplementedException(); 
        }

        
    }
    }

