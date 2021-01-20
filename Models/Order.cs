using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class Order
    {
        public long UserId { get; set; }
        
        public Payment OrderPayment { get; set; }

        public List<LineItem> Products { get; set; }

        public int StatusCode { get; set; }
    }
}
