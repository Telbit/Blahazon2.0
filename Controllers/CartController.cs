﻿using System;
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
        private readonly ILineitemRepository _linteItems;

        public CartController(ICartRepository cart, ILineitemRepository lineItems)
        {
            _cart = cart;
            _linteItems = lineItems;
        }

        [HttpPost("new/{userId}")]
        public ActionResult AddNewCart(long userId)
        {
            _cart.AddNewCart(userId);
            return NoContent();
            //if (HttpContext.Session.GetString("username") != null)
            //{
            //    _cart.AddNewCart((long)HttpContext.Session.GetInt32("userId"));
            //    return NoContent();
            //}
            //else
            //{
            //    throw new FieldAccessException("There is no active session, register first!");
            //}
        }

        [HttpGet]
        public ActionResult<IEnumerable<LineItem>> GetCart(long userId)
        {
            long currentUserId = (long)HttpContext.Session.GetInt32("userId");
            IEnumerable<LineItem> lineItems = _cart.GetCart(currentUserId);
            if (lineItems != null)
            {
                return lineItems.ToList();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public ActionResult<LineItem> AddToCart(Product product)
        {
            long currentCartId = (long)HttpContext.Session.GetInt32("cartId");
            long userId = (long)HttpContext.Session.GetInt32("userId");

            IEnumerable<LineItem> actualLineItems = _cart.GetCart(userId);
            LineItem lineItemToUpdate = actualLineItems.Where<LineItem>(lineitem => lineitem.ProductId == product.Id).FirstOrDefault();
            if ( lineItemToUpdate == null)
            {

                _linteItems.Add(product.Id, currentCartId);
                return NoContent();
            }
            else
            {
                _linteItems.IncreaseQuantity(currentCartId, product.Id);
                return lineItemToUpdate;
            }
            

            
        }

        [HttpDelete("{productId}")]
        public ActionResult<Product> DeleteFromCart(long productId)
        {
            LineItem lineitem = _linteItems.Get(productId);
            if (lineitem != null)
            {
                _linteItems.DecreaseQuantity(lineitem.CartId, productId);
                return NoContent();

            }
            else
            {
                throw new NullReferenceException("Line item was not found with the given Product ID !");
            }

        }

        [HttpGet("checkout")]
        public ActionResult CheckoutCart()
        {
            long cartId = (long)HttpContext.Session.GetInt32("cartId");
            if (cartId != 0)
            {
                _linteItems.EmptyCart(cartId);
                return NoContent();
            }
            else
            {
                return NotFound("There is no active session");

            }

        }
    }
}
