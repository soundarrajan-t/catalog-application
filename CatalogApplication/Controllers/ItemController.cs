using System;
using System.Collections.Generic;
using CatalogApplication.Entities;
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
        public IEnumerable<Item> GeItems()
        {
            return _repository.GetItems();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null)
                return NotFound();
            
            return item;
        }
    }
}