using System;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class OrderFactoryTests
    {
        private Mock<IItemRepository> itemRepository;

        [TestInitialize]
        public void Intialize()
        {
            itemRepository = new Mock<IItemRepository>();
        }

        private OrderFactory CreateSut()
        {
            return new OrderFactory(itemRepository.Object);
        }

        [TestMethod]
        public void Should_create_order_with_item_prices()
        {
            var item1 = Guid.NewGuid();
            var item2 = Guid.NewGuid();

            var orderDto = new OrderDto()
                .WithOrderLine(item1, 1)
                .WithOrderLine(item2, 2);

            var prices = new ItemPrices()
                .WithPrice(item1, Money.From(10, Currency.EUR))
                .WithPrice(item2, Money.From(12, Currency.EUR));

            itemRepository.Setup(repository => repository.GetPrices(item1, item2)).Returns(prices);

            var sut = CreateSut();
            var order = sut.CreateOrder(orderDto);

            Assert.AreEqual(2, order.OrderLines.Count);
            Assert.IsTrue(order.OrderlineValueIs(item1, Money.From(10, Currency.EUR)));
            Assert.IsTrue(order.OrderlineValueIs(item2, Money.From(24, Currency.EUR)));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_not_allow_order_line_if_a_price_is_not_defined()
        {
            var item1 = Guid.NewGuid();
            var item2 = Guid.NewGuid();

            var orderDto = new OrderDto().WithOrderLine(item1, 1);

            var prices = new ItemPrices(); // no price defined

            itemRepository.Setup(repository => repository.GetPrices(item1)).Returns(prices);

            var sut = CreateSut();
            var order = sut.CreateOrder(orderDto);
        }
        
        [TestMethod]
        public void Should_map_the_customer()
        {
            var customerId = Guid.NewGuid();
            var orderDto = new OrderDto().WithCustomer(customerId);

            itemRepository.Setup(repository => repository.GetPrices()).Returns(new ItemPrices());

            var sut = CreateSut();
            var order = sut.CreateOrder(orderDto);

            Assert.AreEqual(customerId, order.CustomerId);
        } 
    }
}