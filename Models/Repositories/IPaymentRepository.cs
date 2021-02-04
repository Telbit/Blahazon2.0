using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        Payment Get(long ordertId);
        void Update(Payment payment);
        void Delete(long paymentId);
    }
}
