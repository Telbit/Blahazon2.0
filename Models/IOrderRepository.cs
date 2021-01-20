using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    interface IOrderRepository
    {
        void Add(IEnumerable<LineItem> lineitems, long userId);

        void Delete(long orderId);

        bool IsPayed();

        string CheckStatus();


    }
}
