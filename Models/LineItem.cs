using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    
    public class LineItem 
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }
        [ForeignKey("CartId")]
        public long CartId { get; set; }

    }
}
