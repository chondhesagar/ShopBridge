using System;
using System.Threading.Tasks;
using WebAPIEFCore.Models;
using Xunit;

namespace WebAPIEFCore.Test
{
    public class InventoryTests
    {
        [Fact]
        public async Task Should_Get_All()
        {
            // Act
            var result = new InventoryTestService().GetAll();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Get()
        {
            // Act
            var result = new InventoryTestService().GetInventoryById(2);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_AddItemAsync()
        {
            // Arrange


            // Act
            var itemId = new InventoryTestService().AddInventory(new Inventory() { Id = 3, CreatedDate = DateTime.Now, Description = "Test 3", ModifiedDate = DateTime.Now, Price = 7.00d });

            // Assert
            Assert.NotEqual(0, itemId);
            Assert.NotNull(itemId);
        }

        [Fact]
        public async Task Should_UpdateItem()
        {
            // Arrange


            // Act
            var itemId = new InventoryTestService().UpdateInventory(new Inventory() { Id = 3, CreatedDate = DateTime.Now, Description = "Test 3", ModifiedDate = DateTime.Now, Price = 7.00d });

            // Assert
            Assert.NotEqual(0, itemId);
            Assert.NotNull(itemId);

        }
    }
}
