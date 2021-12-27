using System;
using System.Collections.Generic;
using System.Linq;
using CatalogApplication.Dtos;
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
            var itemDtoList = _repository.GetItems().Select(item => new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            });
            
            return itemDtoList;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null)
                return NotFound();
            
            var itemDto = new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
            
            return itemDto;
        }
    }
}