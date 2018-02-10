using System;

namespace CentricExpress.Business.DTOs
{
    public class ItemDetailsDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string PictureUrl { get; set; }
    }
}
