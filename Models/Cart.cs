using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blahazon.Models
{
    public class Cart
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [ForeignKey("UserId")]

        public List<LineItem> lineItems = new List<LineItem>();

    }
}
