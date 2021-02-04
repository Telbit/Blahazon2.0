using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class LineItemRepository : ILineitemRepository
    {
        private readonly AppDbContext _lineItems;

        
        public LineItemRepository(AppDbContext appContext)
        {
            _lineItems = appContext;
        }

        public void Add(long productId, long cartId)
        {
            
            LineItem newLineItem = new LineItem() { CartId = cartId, ProductId = productId, Quantity = 1 };
            _lineItems.LineItems.Add(newLineItem);
            _lineItems.SaveChanges();
        }

        public void DecreaseQuantity(long cartId, long productId)
        {
            LineItem lineItem = _lineItems.LineItems.Where<LineItem>(lineitem => lineitem.ProductId == productId && lineitem.CartId == cartId).FirstOrDefault();
            lineItem.Quantity--;
            if (lineItem.Quantity == 0)
            {
                _lineItems.LineItems.Remove(lineItem);
            }
            _lineItems.SaveChanges();

        }

        public LineItem Get(long productId)
        {
            LineItem lineItem = _lineItems.LineItems.Where<LineItem>(lineitem => lineitem.ProductId == productId).FirstOrDefault();
            if (lineItem != null)
            {
                return lineItem;
            }
            else
            {
                throw new ArgumentNullException("Lineitem not found for the given Product ID !");
            }
        }

        public void IncreaseQuantity(long cartId, long productId)
        {
            LineItem lineItem = _lineItems.LineItems.Where<LineItem>(lineitem => lineitem.ProductId == productId && lineitem.CartId == cartId).FirstOrDefault();
            lineItem.Quantity++;
            _lineItems.SaveChanges();
        }

        public void Remove(long productId)
        {
            LineItem lineItem = _lineItems.LineItems.Where<LineItem>(lineitem => lineitem.ProductId == productId).FirstOrDefault();
            if (lineItem != null)
            {
                _lineItems.Remove<LineItem>(lineItem);
                _lineItems.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Lineitem not found for the given Product ID !");
            }
        }

        public void EmptyCart(long cartId)
        {
            foreach (var lineitem in _lineItems.LineItems)
            {
                if (lineitem.CartId == cartId)
                {
                    _lineItems.LineItems.Remove(lineitem);
                }
            }
            _lineItems.SaveChanges();
            
        }   
    }
}
