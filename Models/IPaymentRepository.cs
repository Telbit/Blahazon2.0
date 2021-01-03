using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public interface IPaymentRepository
    {
        void AddAddress(string address);
        void AddPaymentDetails(string paymentDetails);
        string GetAddress();
        string GetPaymentDetails();
    }
}
