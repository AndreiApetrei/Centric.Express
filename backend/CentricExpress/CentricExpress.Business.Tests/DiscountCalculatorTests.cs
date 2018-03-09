using System;
using CentricExpress.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        private Mock<ICustomerTypeProvider> customerTypeMock;
        private int existingPoints = 100;
        private Order order;

        private static Order BuildOrder(Money value)
        {
            return new Order().AddOrderLine(Guid.Empty, 1, value);
        }

        private void MockCustomerTypeToBe(CustomerType customerType)
        {
            customerTypeMock.Setup(type => type.GetCustomerType(existingPoints)).Returns(customerType);
        }

        DiscountCalculator CreateSUT()
        {
            return new DiscountCalculator(customerTypeMock.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            customerTypeMock = new Mock<ICustomerTypeProvider>();
            order = BuildOrder(Money.From(10, Currency.EUR));
        }

        [TestMethod]
        public void Should_get_0_discount_if_customer_is_regular()
        {
            MockCustomerTypeToBe(CustomerType.Regular);

            Assert.AreEqual(Money.From(0, Currency.EUR), CreateSUT().GetDiscount(order, existingPoints));
        }

        [TestMethod]
        public void Should_get_a_10_procent_discount_if_customer_is_bronze()
        {
            MockCustomerTypeToBe(CustomerType.Bronze);

            Assert.AreEqual(Money.From(1, Currency.EUR), CreateSUT().GetDiscount(order, existingPoints));
        }

        [TestMethod]
        public void Should_get_a_20_procent_discount_if_customer_is_silver()
        {
            MockCustomerTypeToBe(CustomerType.Silver);

            Assert.AreEqual(Money.From(2, Currency.EUR), CreateSUT().GetDiscount(order, existingPoints));
        }
        
        [TestMethod]
        public void Should_get_a_30_procent_discount_if_customer_is_silver()
        {
            MockCustomerTypeToBe(CustomerType.Gold);
            
            Assert.AreEqual(Money.From(3, Currency.EUR), CreateSUT().GetDiscount(order, existingPoints));
        }
    }
}