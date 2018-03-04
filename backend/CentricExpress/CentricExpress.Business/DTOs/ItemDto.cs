using CentricExpress.Business.Domain;
using System;
using System.ComponentModel.DataAnnotations;

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
    }
}