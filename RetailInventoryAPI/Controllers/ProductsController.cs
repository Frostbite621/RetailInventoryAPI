using Microsoft.AspNetCore.Mvc;
using RetailInventoryAPI.Models;
using RetailInventoryAPI.Services;
using System.Collections.Generic;
using System.Linq;
namespace RetailInventoryAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);

        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Quantity < 0)
            {
                return BadRequest("Invalid product data.");
            }
            var created = _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updatedProduct)
        {
            if (string.IsNullOrWhiteSpace(updatedProduct.Name) || updatedProduct.Quantity < 0)
            {
                return BadRequest("Invalid product data.");
            }

            var updated = _productService.UpdateProduct(id,updatedProduct);
            if (updated == null)
            {
                return NotFound();

            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
      
    }
}
