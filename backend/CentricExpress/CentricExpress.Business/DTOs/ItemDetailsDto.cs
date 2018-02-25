using CentricExpress.Business.Domain;
using System;

namespace CentricExpress.Business.DTOs
{
    public class ItemDetailsDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public static ItemDetailsDto MapFromModel(Item item)
        {
            return item != null ?
                new ItemDetailsDto
                {
                    Id = item.Id,
                    Description = item.Description,
                    Price = item.Price.Value
                } : null;
        }
    }
}
