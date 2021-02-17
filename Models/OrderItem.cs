using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public struct OrderItem
    {
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
