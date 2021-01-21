using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Cart UserCart { get; set; }
        public Order Order { get; set; }
        public List<Payment> Payments { get; set; }

    } 
}
