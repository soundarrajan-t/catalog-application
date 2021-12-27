using CatalogApplication.Dtos;
using CatalogApplication.Entities;

namespace CatalogApplication.Extensions
{
    public static class Extensions
    {
        public static ItemDto AsItemDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}