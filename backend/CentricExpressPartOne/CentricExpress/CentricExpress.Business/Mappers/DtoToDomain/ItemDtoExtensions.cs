using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Mappers.DtoToDomain
{
    public static class ItemDtoExtensions
    {
        public static Item MapToItem(this ItemDto itemDto) => itemDto == null
                                                                  ? null
                                                                  : new Item
                                                                    {
                                                                        Id = itemDto.Id,
                                                                        Description = itemDto.Description,
                                                                        Price = new Money(itemDto.Price, itemDto.Currency)
                                                                    };

        public static Item MapToItem(this ItemDto itemDto, Item dbItem)
        {
            dbItem.Id = itemDto.Id;
            dbItem.Description = itemDto.Description;
            dbItem.Price.Currency = itemDto.Currency;
            dbItem.Price.Value = itemDto.Price;
            return dbItem;
        }
    }
}