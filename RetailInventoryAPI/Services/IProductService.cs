using RetailInventoryAPI.Models;

namespace RetailInventoryAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product CreateProduct(Product product);
        Product? UpdateProduct(int id, Product updatedProduct);

        bool DeleteProduct(int id);
    }
}
