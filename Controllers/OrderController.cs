using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blahazon.Models;

namespace Blahazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orders;
        public OrderController(IOrderRepository order)
        {
            _orders = order;
        }

        [HttpGet("{userId}")]
        public ActionResult<Order> GetOrder(long userId)
        {
            return _orders.Get(userId);

        }

        [HttpPost]
        public ActionResult<Order> AddOrder(Order order) 
        {
            _orders.Add(order);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Order> DeleteOrder(long orderId) 
        {
            _orders.Delete(orderId);
            return NoContent();
        }

        [HttpGet("{orderId}")]
        public ActionResult<long> GetStatus(long orderId) 
    {
            return _orders.CheckStatus(orderId);
        }


    }
}
