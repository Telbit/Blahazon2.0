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
    public class CartController : ControllerBase
    {
        
        private readonly ICartRepository _cart; 

        public CartController(ICartRepository cart)
        {
            _cart = cart;
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<LineItem>> GetCart(long userId)
        {
            IEnumerable<LineItem> lineItems = _cart.GetCart(userId);
            if (lineItems != null)
            {
                return lineItems.ToList();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Product> AddToCart(long userId,Product product)
        {
            IEnumerable<LineItem> actualLineItems = _cart.GetCart(userId);
            LineItem lineItemToUpdate = actualLineItems.Where<LineItem>(lineitem => lineitem.CurrentProduct.Id == product.Id).FirstOrDefault();
            if ( lineItemToUpdate == null)
            {
                _cart.AddLineItem(userId, new LineItem() { CurrentProduct = product, Quantity = 1 });
            }
            else
            {
                _cart.IncreaseLineItem(lineItemToUpdate);
            }
            

            return product;
        }

        [HttpDelete("{userId, productId}")]
        public ActionResult<Product> DeleteFromCart(long userId, long productId)
        {
            _cart.DeleteLineItem(userId, productId);

            return NoContent();
        }
    }
}
