using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.DTOs
{
    public class OrderDto
    {
        private Guid CustomerId { get; set; }
        public ICollection<OrderLineDto> OrderLines { get; set; }

        public Order ToDomain(IDictionary<Guid, Money> itemPrices)
        {
            var orderLines = OrderLines.Select(dto => new OrderLine(dto.ItemId, dto.Quantity, GetItemPrice(itemPrices, dto)));
            return new Order(CustomerId, orderLines);
        }

        private static Money GetItemPrice(IDictionary<Guid, Money> itemPrices, OrderLineDto dto)
        {
            if (!itemPrices.ContainsKey(dto.ItemId))
            {
                return new Money(0m, "");    
            }
            
            return itemPrices[dto.ItemId];
        }
    }
}
