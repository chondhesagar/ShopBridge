using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIEFCore.Models;

namespace WebAPIEFCore.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public IEnumerable<Inventory> GetAll()
        {
            try
            {
                return _context.inventories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddInventory(Inventory Model)
        {
            int Result;
            try
            {
                _context.inventories.Add(Model);
                Result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public int UpdateInventory(Inventory Model)
        {
            int Result;
            try
            {
                Inventory account = _context.inventories.AsNoTracking().Where(x => x.Id.Equals(Model.Id)).FirstOrDefault();
                if (account == null)
                {
                    throw new Exception("Account not present");
                }
                else
                {
                    _context.inventories.Update(Model);
                    Result = _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

        public Inventory GetInventoryById(int? Id)
        {
            try
            {
                Inventory Inventory = _context.inventories.FirstOrDefault(x => x.Id == Id);
                return Inventory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteInventory(int Id)
        {
            int Result;
            try
            {
                Inventory Inventory = _context.inventories.Where(x => x.Id == Id).FirstOrDefault();
                if (Inventory == null)
                {
                    throw new Exception("Inventory not present");
                }
                else
                {
                    _context.inventories.Remove(Inventory);
                    Result = _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Result;
        }

    }
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> GetAll();
        Inventory GetInventoryById(int? Id);
        int AddInventory(Inventory newModel);
        int UpdateInventory(Inventory newModel);
        int DeleteInventory(int id);
    }
}
