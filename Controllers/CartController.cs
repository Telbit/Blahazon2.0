using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blahazon2._0.Models;

namespace Blahazon2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        // misleading name
        private readonly ICartRepository _cart;

        public CartController(ICartRepository cart)
        {
            _cart = cart;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetCart()
        {
            return _cart.GetCart();
        }

        [HttpPost]
        public ActionResult<Product> AddToCart(Product product)
        {
            _cart.AddProduct(product);

            return product;
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteFromCart(long id)
        {
            _cart.DeleteProduct(id);

            return NoContent();
        }
    }
}
