using Blahazon2._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon2._0.Controllers
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

        [HttpGet("/address")]
        public ActionResult<string> GetAddress()
        {
            return paymentRepository.GetAddress();
        }

        [HttpGet("/payment")]
        public ActionResult<string> GetPaymentDetails()
        {
            return paymentRepository.GetPaymentDetails();
        }

        [HttpPost("/address")]
        public ActionResult<string> AddAddress(string address)
        {
            paymentRepository.AddAddress(address);
            Console.WriteLine(address);

            return address;
        }

        [HttpPost("/payment")]
        public ActionResult<string> AddPaymentDetails(string address)
        {
            paymentRepository.AddAddress(address);

            return NoContent();
        }
    }
}
