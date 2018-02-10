using System;
using System.Collections.Generic;

namespace CentricExpress.Business.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderLineDto> OrderLines { get; set; }
    }
}
