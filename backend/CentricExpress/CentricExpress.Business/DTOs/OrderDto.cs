using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.DTOs
{
    public class OrderDto
    {
        public ICollection<OrderLineDto> OrderLines { get; set; }

        public static OrderDto FromDomain(Order order)
        {
            if (order == null)
            {
                return null;
            }
            
            return new OrderDto()
            {
                OrderLines = order.OrderLines?.Select(BuildOrderLineDto).ToList() ?? new List<OrderLineDto>()
            };
        }

        private static OrderLineDto BuildOrderLineDto(OrderLine line)
        {
            return new OrderLineDto
            {
                ItemId = line.ItemId,
                Quantity = line.Quantity
            };
        }

        public Order ToDomain(ItemPrices itemPrices)
        {
            var orderLines = BuildDomainOrderLines(itemPrices);
            return new Order(orderLines);
        }

        private IEnumerable<OrderLine> BuildDomainOrderLines(ItemPrices itemPrices)
        {
            return OrderLines?.Select(dto =>
                       new OrderLine(dto.ItemId, dto.Quantity, itemPrices.GetPrice(dto.ItemId))) ??
                   new List<OrderLine>();
        }

        public OrderDto WithOrderLine(Guid itemId, int quantity)
        {
            if (OrderLines == null)
            {
                OrderLines = new List<OrderLineDto>();
            }

            OrderLines.Add(new OrderLineDto()
            {
                ItemId = itemId,
                Quantity = quantity
            });

            return this;
        }
    }
}