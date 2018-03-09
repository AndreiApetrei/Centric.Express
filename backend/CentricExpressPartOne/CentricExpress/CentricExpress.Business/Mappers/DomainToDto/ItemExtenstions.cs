using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Mappers.DomainToDto
{
    public static class ItemExtenstions
    {
        public static ItemDto MapToItemDto(this Item item)
        {
            return item == null ? null
                       : new ItemDto
                         {
                             Id = item.Id,
                             Description = item.Description,
                             Price = (item.Price?.Value).GetValueOrDefault(),
                             Currency = item.Price?.Currency
                         };
        }
    }
}
