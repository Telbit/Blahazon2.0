using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    [NotMapped]
    public class LineItem : ILineItem
    {
        public int Quantity { get; set; }
        public Product CurrentProduct { get; set; }

        public void IncreaseQuantity() 
        {
            Quantity++;
        }
        public void DecreaseQuantity() 
        {
            Quantity--;
        }
        public decimal GetTotalPrice() 
        {
            return Quantity * CurrentProduct.Price;
        }
    }
}
