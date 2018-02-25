using System;

namespace CentricExpress.Business.DTOs
{
    public class OrderLineDto
    {
        public Guid ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
