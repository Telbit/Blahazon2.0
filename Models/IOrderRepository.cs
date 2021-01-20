using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public interface IOrderRepository
    {
        void Add(Order order);

        void Delete(long orderId);

        long CheckStatus(long orderId);

        Order Get(long userId);


    }
}
