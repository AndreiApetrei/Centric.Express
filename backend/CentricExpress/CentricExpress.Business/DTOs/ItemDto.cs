using CentricExpress.Business.Domain;
using System;

namespace CentricExpress.Business.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public byte[] Picture { get; set; }

        public Item ToDomain()
        {
            return new Item(Id)
            {
                Description = Description,
                Price = Money.From(Price, Currency.Nothing)
            };
        }

        public static ItemDto FromDomain(Item item)
        {
            if (item == null)
            {
                return null;
            }

            return new ItemDto
            {
                Id = item.Id,
                Description = item.Description,
                Price = item.Price.Value,
                Picture = item.Picture
            };
        }
    }
}