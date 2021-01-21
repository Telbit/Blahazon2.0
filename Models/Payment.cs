using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blahazon.Models
{
    public class Payment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        [ForeignKey("OrderId")]

        public decimal TotalPrice { get; set; }
        public bool IsPayed { get; set; }


    }
}
