using System;
using System.Linq;
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
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            return new ProductService(context);
        }

        [Fact]
        public void GetProductById_ReturnsNull_WhenMissing()
        {
            // Arrange
            var service = CreateService();

            // Act
            var result = service.GetProductById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateProduct_AssignsId_AndAddsToDatabase()
        {
            // Arrange
            var service = CreateService();
            var newProduct = new Product { Name = "HDMI Cable", Quantity = 10 };

            // Act
            var created = service.CreateProduct(newProduct);
            var all = service.GetAllProducts().ToList();

            // Assert
            Assert.True(created.Id > 0);
            Assert.Contains(all, p => p.Id == created.Id);
            Assert.Contains(all, p => p.Name == "HDMI Cable" && p.Quantity == 10);
        }

        [Fact]
        public void UpdateProduct_UpdatesExistingProduct()
        {
            // Arrange
            var service = CreateService();
            var created = service.CreateProduct(new Product { Name = "Old Name", Quantity = 1 });
            var updatedData = new Product { Name = "New Name", Quantity = 99 };

            // Act
            var updated = service.UpdateProduct(created.Id, updatedData);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(created.Id, updated!.Id);
            Assert.Equal("New Name", updated.Name);
            Assert.Equal(99, updated.Quantity);
        }

        [Fact]
        public void DeleteProduct_RemovesProduct_WhenExists()
        {
            // Arrange
            var service = CreateService();
            var created = service.CreateProduct(new Product { Name = "To Delete", Quantity = 5 });

            // Act
            var deleted = service.DeleteProduct(created.Id);
            var after = service.GetProductById(created.Id);

            // Assert
            Assert.True(deleted);
            Assert.Null(after);
        }

        [Fact]
        public void DeleteProduct_ReturnsFalse_WhenMissing()
        {
            // Arrange
            var service = CreateService();

            // Act
            var deleted = service.DeleteProduct(999);

            // Assert
            Assert.False(deleted);
        }
    }
}