using Blahazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blahazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository payments;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            payments = paymentRepository;
        }

        [HttpPost]
        public ActionResult AddNewPayment(Payment payment)
        {
            payments.Add(payment);
            return NoContent();
        }

        [HttpGet("{paymentId}")]
        public ActionResult<Payment> GetPayment(long paymentId)
        {
            Payment payment = payments.Get(paymentId);
            if (payment == null)
            {
                return NotFound("Payment with the given Payment ID Not Found !");
            }
            else
            {
                return payment;
            }
        }

        [HttpDelete("{paymentId}")]
        public ActionResult  DeletePayment(long paymentId)
        {
            Payment payment = payments.Get(paymentId);
            if (payment == null)
            {
                return NotFound("Payment with the given Payment ID Not Found !");
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPut]
        public ActionResult UpdatePayment(Payment payment)
        {
            payments.Update(payment);
            return NoContent();
        }
        
    }
}
