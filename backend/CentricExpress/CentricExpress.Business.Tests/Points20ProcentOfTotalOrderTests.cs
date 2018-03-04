using System;
using CentricExpress.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class Points20ProcentOfTotalOrderTests
    {
        [TestMethod]
        public void Should_return_20_procent_of_the_value_in_points()
        {
            var order = new Order(Guid.Empty).AddOrderLine(Guid.NewGuid(), 1, Money.From(10.4m, Currency.EUR));

            Assert.AreEqual(2, new Points20ProcentOfTotalOrder().Calculate(order));
        }
    }
}