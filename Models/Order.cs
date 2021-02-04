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
        [ForeignKey("UserId")]
        public long UserId { get; set; }

        public int StatusCode { get; set; }
        public User User { get; set; }
        public Payment Payment { get; set; }

    }
}
