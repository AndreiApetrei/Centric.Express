using System;
using CentricExpress.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class CustomerOrdersTest
    {
        private Mock<IPointsCalculator> pointsCalculatorMock;

        [TestInitialize]
        public void Initialize()
        {
            pointsCalculatorMock = new Mock<IPointsCalculator>();
        }

        CustomerOrders CreateSUT()
        {
            return new CustomerOrders();
        }

        [TestMethod]
        public void Should_add_points_for_customer_based_on_order_value()
        {
            var order = new Order(Guid.Empty).AddOrderLine(Guid.NewGuid(), 1, Money.From(10, Currency.EUR));

            // we receive 2 points for 10 euro
            pointsCalculatorMock.Setup(calculator => calculator.Calculate(order)).Returns(2);

            var customerOrders = CreateSUT();

            customerOrders.PlaceOrder(order, pointsCalculatorMock.Object);

            Assert.AreEqual(2, customerOrders.NewPoints.Points);
        }
    }
}