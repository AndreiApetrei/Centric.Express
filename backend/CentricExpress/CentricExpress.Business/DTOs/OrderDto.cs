using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.DTOs
{
    public class OrderDto
    {
        public Guid CustomerId { get; set; }
        public ICollection<OrderLineDto> OrderLines { get; set; }

        public Order ToDomain(Func<IEnumerable<Guid>, IDictionary<Guid, Money>> getPricesFunction)
        {
            var itemPrices = getPricesFunction(OrderLines.Select(dto => dto.ItemId));

            var orderLines =
                OrderLines.Select(dto => new OrderLine(dto.ItemId, dto.Quantity, GetItemPrice(itemPrices, dto)));
            return new Order(CustomerId, orderLines);
        }

        private static Money GetItemPrice(IDictionary<Guid, Money> itemPrices, OrderLineDto dto)
        {
            return !itemPrices.ContainsKey(dto.ItemId) ? Money.Zero : itemPrices[dto.ItemId];
        }
    }
}