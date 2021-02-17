using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blahazon.Models;

namespace Blahazon.EmailService
{
    public interface IEmailService
    {
        void Setup(string adminEmail, string adminPassword);
        void SendRecipt(string userEmail, List<OrderItem> products);
        
    }
}
