using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IItemRepository _itemRepo;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(IItemRepository itemRepo, ILogger<ItemsController> logger)
        {
            _logger = logger;
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetItems()
        {
            IEnumerable<Item> items = await _itemRepo.GetItemsAsync();

            return items;
        }

        [HttpGet("{id}")]
        public async Task<Item> GetItem(Guid id)
        {
            Item item = await _itemRepo.GetItemByIdAsync(id);

            return item;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            await _itemRepo.CreateItemAsync(item);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(Item item)
        {
            var itemFromDb = await _itemRepo.GetItemByIdAsync(item.Id);
            if (itemFromDb == null)
            {
                return NoContent();
            }

            await _itemRepo.UpdateItemAsync(item);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            await _itemRepo.DeleteItemAsync(id);

            return Ok();
        }
    }
}