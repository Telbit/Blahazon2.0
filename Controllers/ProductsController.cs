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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _context;

        public ProductsController(IProductRepository context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.GetAllProduct();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product>  GetProduct(long id)
        {
            var product = _context.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(Product product)
        {
            var productToUpdate = _context.GetProduct(product.Id);
            if (productToUpdate == null)
            {
                return NotFound();
            }

            _context.Update(product);

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            _context.Add(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(long id)
        {
            var product = _context.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Delete(id);

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.GetProduct(id) != null;
        }
    }
}
