using System;
using System.Collections.Generic;
using CatalogApplication.Entities;

namespace CatalogApplication.Repositories
{
    public interface IItemRepository
    {
        public IEnumerable<Item> GetItems();
        public Item GetItem(Guid id);
        public void CreateItem(Item item);
        public void UpdateItem(Item item);

        public void DeleteItem(Guid id);
    }
}
