using System;

namespace CentricExpress.Business.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public byte[] Picture { get; set; }
    }
}
