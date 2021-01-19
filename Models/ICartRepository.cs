using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    
    public interface ICartRepository
    {
        void AddLineItem(long cartId, LineItem lineItem);
        void DeleteLineItem(long cartId, long lineItemId);
        void UpdateLineItem(long cartId, LineItem lineItem);
        IEnumerable<LineItem> GetCart();
        decimal GetTotalPrice();
    }
}
