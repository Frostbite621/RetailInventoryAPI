using RetailInventoryAPI.Models;
using RetailInventoryAPI.Data;
namespace RetailInventoryAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product? UpdateProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }
          
            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;

            _context.SaveChanges();

            return product;
        }
        public bool DeleteProduct(int id) {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
