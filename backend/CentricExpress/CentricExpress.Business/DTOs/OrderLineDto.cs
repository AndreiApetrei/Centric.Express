using System;

namespace CentricExpress.Business.DTOs
{
    public class OrderLineDto
    {
        public Guid Id { get; set; }

        public ItemDto Item { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
