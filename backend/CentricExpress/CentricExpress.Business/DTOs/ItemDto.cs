using CentricExpress.Business.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace CentricExpress.Business.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(3000)]
        public string Description { get; set; }

        [Required] [Range(0.01, 100000)] public decimal Price { get; set; }

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