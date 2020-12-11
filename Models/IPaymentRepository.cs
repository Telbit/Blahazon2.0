using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon2._0.Models
{
    public interface IPaymentRepository
    {
        public void AddAddress(string address);
        public void AddPaymentDetails(string paymentDetails);
        public string GetAddress();
        public string GetPaymentDetails();
    }
}
