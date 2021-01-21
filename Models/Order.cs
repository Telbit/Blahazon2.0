using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        
        public Payment OrderPayment { get; set; }

        public List<LineItem> Products { get; set; }

        public int StatusCode { get; set; }
        public Payment Payment { get; set; }

    }
}
