using System;
using System.Collections.Generic;
using System.Linq;
using CatalogApplication.Dtos;
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
    }
}