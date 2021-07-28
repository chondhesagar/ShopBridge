using System;
using System.Collections.Generic;
using System.Text;
using WebAPIEFCore.Models;
using WebAPIEFCore.Repository;
using System.Linq;
namespace WebAPIEFCore.Test
{
    public class InventoryTestService : IInventoryRepository
    {
        private readonly List<Inventory> inventories;
        public InventoryTestService()
        {
            inventories = new List<Inventory>()
            {
                new Inventory() { Id = 1,CreatedDate=DateTime.Now,Description="Test 1",ModifiedDate=DateTime.Now, Price = 5.00d },
                new Inventory() { Id = 2,CreatedDate=DateTime.Now,Description="Test 2",ModifiedDate=DateTime.Now, Price = 6.00d },
            };
        }
        public int AddInventory(Inventory newModel)
        {
            inventories.Add(newModel);
            return inventories.Count();
        }

        public int DeleteInventory(int id)
        {
            var existing = inventories.First(a => a.Id == id);
            inventories.Remove(existing);
            return inventories.Count();
        }

        public IEnumerable<Inventory> GetAll()
        {
            return inventories;
        }

        public Inventory GetInventoryById(int? Id)
        {
            return inventories.FirstOrDefault(x => x.Id == Id);
        }

        public int UpdateInventory(Inventory newModel)
        {
            inventories.Remove(newModel);
            inventories.Add(newModel);
            return inventories.Count();
        }
    }
}
