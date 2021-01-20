using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    
    public interface ICartRepository
    {
        void Add(Cart cart);
        void AddLineItem(long userId, LineItem lineItem);
        void DeleteLineItem(long userId, long productId);
        void IncreaseLineItem(LineItem lineItem);
        void DecreaseLineItem(long userId, LineItem lineItem);
        IEnumerable<LineItem> GetCart(long userId);
        decimal GetTotalPrice(long userId);
    }
}
