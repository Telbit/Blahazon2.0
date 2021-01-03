using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon2._0.Models
{
    
    public interface ICartRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(long Id);
        List<Product> GetCart();
    }
}
