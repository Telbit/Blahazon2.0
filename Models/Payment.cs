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
        public long UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPayed { get; set; }
        public User PaymentUser { get; set; }
        public Order PaymentOrder { get; set; }

    }
}
