using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class CartRepository : ICartRepository
    {
        private List<Product> products = new List<Product>();

        public CartRepository()
        {
        }

        public List<Product> GetCart()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(long Id)
        {
            foreach (Product product in products)
            {
                if (product.Id == Id)
                {
                    products.Remove(product);
                    break;
                }
            }
            
        }


    }
}
