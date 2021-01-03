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
        private readonly IPaymentRepository paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet("address")]
        public ActionResult<string> GetAddress()
        {
            return paymentRepository.GetAddress();
        }

        [HttpGet("payment")]
        public ActionResult<string> GetPaymentDetails()
        {
            return paymentRepository.GetPaymentDetails();
        }

        [HttpPost("address")]
        public ActionResult<string> AddAddress(Object address)
        {
            var jsonAddress = JsonSerializer.Serialize(address);
            paymentRepository.AddAddress(jsonAddress);
            return StatusCode(201);
        }

        [HttpPost("payment")]
        public ActionResult<string> AddPaymentDetails(Object payment)
        {
            var jsonPayment = JsonSerializer.Serialize(payment);
            paymentRepository.AddPaymentDetails(jsonPayment);
            return NoContent();
        }
    }
}
