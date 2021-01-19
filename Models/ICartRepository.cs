using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    
    public interface ICartRepository
    {
        void AddProduct(long cartId, Product product);
        void DeleteProduct(long cartId, long productId);
        void UpdateProduct(long cartId, Product product);
        IEnumerable<Product> GetCart();
        decimal GetTotalPrice();
    }
}
