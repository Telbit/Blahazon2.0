using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class PaymentRepository : IPaymentRepository
    {
        private string address;
        private string paymentDetails;

        public void AddAddress(string address)
        {
            this.address = address;
        }

        public void AddPaymentDetails(string paymentDetails)
        {
            this.paymentDetails = paymentDetails;
        }

        public string GetAddress() 
        {
            return address;
        }
        public string GetPaymentDetails()
        { 
            return paymentDetails; 
        }
    }
}
