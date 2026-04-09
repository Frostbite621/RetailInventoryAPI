using Microsoft.AspNetCore.Mvc;
using RetailInventoryAPI.DTOs;
using RetailInventoryAPI.Mappings;
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
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products.Select(products => products.ToReadDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product.ToReadDto());

        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto createDto)
        {
            var product = createDto.ToEntity();

            var createdProduct = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct.ToReadDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto updateDto)
        {

            var product = new Product
            {
                Id = id,
                Name = updateDto.Name,
                Quantity = updateDto.Quantity
            };

            var updatedProduct = await _productService.UpdateProductAsync(id,product);
            if (updatedProduct == null)
            {
                return NotFound();

            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
      
    }
}
