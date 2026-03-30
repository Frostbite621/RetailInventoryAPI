using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventoryAPI.Data;
using RetailInventoryAPI.Models;
using RetailInventoryAPI.Services;
using Xunit;

namespace RetailInventoryAPI.Tests
{
    public class ProductServiceTests
    {
        private ProductService CreateService()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            return new ProductService(context);
        }

        [Fact]
        public async Task GetProductByIdAsync_ReturnsNull_WhenMissing()
        {
            var service = CreateService();

            var result = await service.GetProductByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProductAsync_AssignsId_AndAddsToDatabase()
        {
            var service = CreateService();
            var newProduct = new Product { Name = "HDMI Cable", Quantity = 10 };

            var created = await service.CreateProductAsync(newProduct);
            var all = (await service.GetAllProductsAsync()).ToList();

            Assert.True(created.Id > 0);
            Assert.Contains(all, p => p.Id == created.Id);
            Assert.Contains(all, p => p.Name == "HDMI Cable" && p.Quantity == 10);
        }

        [Fact]
        public async Task UpdateProductAsync_UpdatesExistingProduct()
        {
            var service = CreateService();
            var created = await service.CreateProductAsync(new Product { Name = "Old Name", Quantity = 1 });
            var updatedData = new Product { Name = "New Name", Quantity = 99 };

            var updated = await service.UpdateProductAsync(created.Id, updatedData);

            Assert.NotNull(updated);
            Assert.Equal(created.Id, updated!.Id);
            Assert.Equal("New Name", updated.Name);
            Assert.Equal(99, updated.Quantity);
        }

        [Fact]
        public async Task DeleteProductAsync_RemovesProduct_WhenExists()
        {
            var service = CreateService();
            var created = await service.CreateProductAsync(new Product { Name = "To Delete", Quantity = 5 });

            var deleted = await service.DeleteProductAsync(created.Id);
            var after = await service.GetProductByIdAsync(created.Id);

            Assert.True(deleted);
            Assert.Null(after);
        }

        [Fact]
        public async Task DeleteProductAsync_ReturnsFalse_WhenMissing()
        {
            var service = CreateService();

            var deleted = await service.DeleteProductAsync(999);

            Assert.False(deleted);
        }
    }
}