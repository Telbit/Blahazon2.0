using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blahazon.Models
{
    public class PaymentRepository : IPaymentRepository
    {
        private AppDbContext context;

        public PaymentRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }
        public void Add(Payment payment)
        {
            context.Add<Payment>(payment);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            Payment payment = context.Find<Payment>(id);
            if ( payment != null)
            {
                context.Remove<Payment>(payment);
                context.SaveChanges();
            }
        }

        public Payment Get(long id)
        {
            Payment payment = context.Find<Payment>(id);
            if ( payment != null)
            {
                return payment;
            }
            throw new NullReferenceException("Requested Payment Not Found!");
        }

        public void Update(Payment payment)
        {
            var paymentToUpdate = context.Attach(payment);
            paymentToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
