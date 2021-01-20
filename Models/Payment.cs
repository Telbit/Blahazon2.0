using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class Payment
    {
        public long OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPayed { get; set; }

    }
}
