using RetailInventoryAPI.Models;
namespace RetailInventoryAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Keyboard", Quantity = 25 },
            new Product { Id = 2, Name = "Mouse", Quantity = 40 }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product CreateProduct(Product product)
        {
            int newId = _products.Any() ? _products.Max(x => x.Id) + 1 : 1;
            product.Id = newId;
            _products.Add(product);
            return product;
        }

        public Product? UpdateProduct(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }

            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            _products.Remove(product);
            return true;
        }
    }
}
