using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIEFCore.Models;
using WebAPIEFCore.Repository;
using System;

namespace WebAPIEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _InventoryRepository;
        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _InventoryRepository = inventoryRepository;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_InventoryRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_InventoryRepository.GetInventoryById(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        // POST api/<InventoryController>
        [HttpPost]
        public IActionResult Post(Inventory inventory)
        {
            try
            {
                return Created("", _InventoryRepository.AddInventory(inventory));
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }

        // PUT api/<InventoryController>/5
        [HttpPut]
        public IActionResult Put(Inventory inventory)
        {
            try
            {
                return Accepted("", _InventoryRepository.UpdateInventory(inventory));
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_InventoryRepository.DeleteInventory(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }
    }
}
