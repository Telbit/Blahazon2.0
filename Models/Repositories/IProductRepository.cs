using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public interface IProductRepository
    {
        Product GetProduct(long id);
        IEnumerable<Product> GetAllProduct();

        void Add(Product product);
        void Update(Product product);

        void Delete(long id);
    }
}
