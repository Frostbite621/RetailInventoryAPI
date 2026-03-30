using RetailInventoryAPI.Models;
using RetailInventoryAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace RetailInventoryAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return null;
            }
          
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Quantity = updatedProduct.Quantity;

            await _context.SaveChangesAsync();

            return existingProduct;
        }
        public async Task<bool> DeleteProductAsync(int id) {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
