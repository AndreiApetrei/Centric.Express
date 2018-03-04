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
        private Mock<IDiscountCalculator> discountCalculator;
        private int existingPoints;

        [TestInitialize]
        public void Initialize()
        {
            pointsCalculatorMock = new Mock<IPointsCalculator>();
            discountCalculator = new Mock<IDiscountCalculator>();
        }

        CustomerOrders CreateSUT()
        {
            return new CustomerOrders(Guid.Empty, existingPoints);
        }

        private static Order BuildOrder(Money price)
        {
            return new Order(Guid.Empty).AddOrderLine(Guid.NewGuid(), 1, price);
        }

        [TestMethod]
        public void Should_add_points_for_customer_based_on_order_value()
        {
            var order = BuildOrder(Money.From(10, Currency.EUR));

            // we receive 2 points for 10 euro
            pointsCalculatorMock.Setup(calculator => calculator.Calculate(order)).Returns(2);

            var customerOrders = CreateSUT();

            customerOrders.PlaceOrder(order, pointsCalculatorMock.Object);

            Assert.AreEqual(2, customerOrders.NewPoints.Points);
        }

        [TestMethod]
        public void Should_apply_discount_based_on_number_of_points_to_order()
        {
            var order = BuildOrder(Money.From(10, Currency.EUR));
            existingPoints = 10;
            // we shoule receive a discount of 3 euro
            var discount = Money.From(3, Currency.EUR);
            
            discountCalculator.Setup(calculator => calculator.GetDiscount(order, existingPoints)).Returns(discount);
            
            var customerOrders = CreateSUT();
            customerOrders.PlaceOrder(order, pointsCalculatorMock.Object, discountCalculator.Object);
            
            Assert.AreEqual(discount, customerOrders.NewOrderDiscount);
        }
    }
}