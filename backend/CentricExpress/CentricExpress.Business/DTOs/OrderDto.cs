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

        public static OrderDto FromDomain(Order order)
        {
            return new OrderDto()
            {
                CustomerId = order.CustomerId,
                OrderLines = order.OrderLines.Select(BuildOrderLineDto).ToList()
            };
        }

        private static OrderLineDto BuildOrderLineDto(OrderLine line)
        {
            return new OrderLineDto
            {
                ItemId = line.ItemId, Quantity = line.Quantity
            };
        }

        public Order ToDomain(Func<Guid[], ItemPrices> getPricesFunction)
        {
            var itemPrices = getPricesFunction(ItemIds);

            var orderLines = BuildDomainOrderLines(itemPrices);
            return new Order(CustomerId, orderLines);
        }

        private IEnumerable<OrderLine> BuildDomainOrderLines(ItemPrices itemPrices)
        {
            if (OrderLines == null)
            {
                return new List<OrderLine>();
            }
            
            var orderLines =
                OrderLines.Select(dto => new OrderLine(dto.ItemId, dto.Quantity, itemPrices.GetPrice(dto.ItemId)));
            return orderLines;
        }

        private Guid[] ItemIds
        {
            get
            {
                return OrderLines?.Select(dto => dto.ItemId).ToArray() ?? new Guid[0];
            }
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

        public OrderDto WithCustomer(Guid customerId)
        {
            this.CustomerId = customerId;

            return this;
        }
    }
}