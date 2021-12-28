using System;
using System.Collections.Generic;
using System.Linq;
using CatalogApplication.Dtos;
using CatalogApplication.Entities;
using CatalogApplication.Extensions;
using CatalogApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApplication.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GeItems()
        {
            var itemDtoList = _repository.GetItems().Select(item => item.AsItemDto());
            return itemDtoList;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null)
                return NotFound();

            return item.AsItemDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            
            _repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsItemDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
                return NotFound();

            var updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            
            _repository.UpdateItem(updatedItem);

            return NoContent();
        }
    }
}