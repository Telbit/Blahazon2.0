using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon2._0.Models
{
    
    public interface ICartRepository
    {
        public void AddProduct(Product product);
        public void DeleteProduct(long Id);
        public List<Product> GetCart();
    }
}
