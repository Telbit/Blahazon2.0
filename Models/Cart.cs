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
        [ForeignKey("UserId")]
        public long UserId { get; set; }

        public List<LineItem> lineItems = new List<LineItem>();

    }
}
