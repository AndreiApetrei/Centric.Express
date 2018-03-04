using System;
using System.Collections.Generic;
using CentricExpress.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Should_have_the_total_amount_as_sum_of_orderline_amount()
        {
            var orderLines = new List<OrderLine>();
            orderLines.Add(new OrderLine(Guid.NewGuid(), 1, Money.From(10, Currency.EUR)));
            orderLines.Add(new OrderLine(Guid.NewGuid(), 2, Money.From(12, Currency.EUR)));
            orderLines.Add(new OrderLine(Guid.NewGuid(), 3, Money.From(3, Currency.EUR)));
            
            var order = new Order(Guid.NewGuid(), orderLines);
            
            Assert.AreEqual(new Money(10 + 2 * 12 + 3 * 3, "EUR"),  order.TotalAmount);
        }
    }
}