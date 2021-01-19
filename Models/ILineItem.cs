using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    interface ILineItem
    {
        void IncreaseQuantity();
        void DecreaseQuantity();
        decimal GetTotalPrice();
    }
}
