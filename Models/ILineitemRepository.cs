using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public interface ILineitemRepository
    {
        void Add(long productId, long cartId);
        void Remove(long productId);
        LineItem Get(long productId);
        void IncreaseQuantity(long cartId, long productId);
        void DecreaseQuantity(long cartId, long productId);
    }
}
