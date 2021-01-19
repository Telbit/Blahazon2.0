using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
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
