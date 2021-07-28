using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIEFCore.Models;
using WebAPIEFCore.Repository;

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
            return Ok(_InventoryRepository.GetAll());
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_InventoryRepository.GetInventoryById(id));
        }

        // POST api/<InventoryController>
        [HttpPost]
        public IActionResult Post(Inventory inventory)
        {
            return Created("", _InventoryRepository.AddInventory(inventory));
        }

        // PUT api/<InventoryController>/5
        [HttpPut]
        public IActionResult Put(Inventory inventory)
        {
            return Accepted("", _InventoryRepository.UpdateInventory(inventory));
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_InventoryRepository.DeleteInventory(id));
        }
    }
}
