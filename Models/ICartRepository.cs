using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    
    public interface ICartRepository
    {
        void AddNewCart(long  userId);
        IEnumerable<LineItem> GetCart(long userId);
        decimal GetTotalPrice(long userId);

        long GetCartId(long userId);
    }
}
