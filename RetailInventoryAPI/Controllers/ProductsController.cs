using Microsoft.AspNetCore.Mvc;
using RetailInventoryAPI.Models;
using System.Collections.Generic;
using System.Linq;
namespace RetailInventoryAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Gaming Mouse", Quantity = 10 },
            new Product { Id = 2, Name = "Keyboard", Quantity = 5 }
        };

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);

        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {

            int NewId;

            if (_products.Any())
            {
                NewId = _products.Max(x => x.Id) + 1;
            }
            else
            {
                NewId = 1;
            }
            product.Id = NewId;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updatedProduct)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();

            }

            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            Product product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return NoContent();
        }
    }
}
