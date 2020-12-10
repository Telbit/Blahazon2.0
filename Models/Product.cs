using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon2._0.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string ImagePath { get; set; }
    }
}
