using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class CartRepository : ICartRepository
    {
        private AppDbContext context;

        public CartRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }

        void ICartRepository.AddLineItem(long cartId, LineItem lineItem)
        {
            throw new NotImplementedException();
        }

        void ICartRepository.DeleteLineItem(long cartId, long lineItemId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<LineItem> ICartRepository.GetCart()
        {
            throw new NotImplementedException();
        }

        decimal ICartRepository.GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        void ICartRepository.UpdateLineItem(long cartId, LineItem lineItem)
        {
            throw new NotImplementedException();
        }
    }
}
