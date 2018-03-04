using System;
using System.Collections.Generic;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;
using CentricExpress.Business.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private Mock<ICustomerOrdersRepository> customerOrderRepositoryMock;
        private Mock<IDiscountCalculator> discountCalculatorMock;
        private Mock<IOrderFactory> orderFactoryMock;
        private Mock<IPointsCalculator> pointsCalculatorMock;
        private Mock<IUnitOfWork> unitOfWorkMock;

        [TestInitialize]
        public void Initialize()
        {
            orderFactoryMock = new Mock<IOrderFactory>();
            customerOrderRepositoryMock = new Mock<ICustomerOrdersRepository>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            pointsCalculatorMock = new Mock<IPointsCalculator>();
            discountCalculatorMock = new Mock<IDiscountCalculator>();
        }

        private OrderService CreateSUT()
        {
            return new OrderService(orderFactoryMock.Object, customerOrderRepositoryMock.Object, unitOfWorkMock.Object,
                pointsCalculatorMock.Object, discountCalculatorMock.Object);
        }

        [TestMethod]
        public void Should_save_the_customer_order_entity_after_placing_the_order_on_it()
        {
            var orderDto = new OrderDto();
            var order = new Order(Guid.NewGuid(), new List<OrderLine>());

            var customerOrders = new CustomerOrders();

            customerOrderRepositoryMock.Setup(repository => repository.GetByCustomerId(orderDto.CustomerId))
                .Returns(customerOrders);
            orderFactoryMock.Setup(factory => factory.CreateOrder(orderDto)).Returns(order);

            CreateSUT().PlaceOrder(orderDto);

            customerOrderRepositoryMock.Verify(repository => repository.Save(customerOrders));
        }

        [TestMethod]
        public void Should_use_the_points_calculator()
        {
            var orderDto = new OrderDto();
            var order = new Order(Guid.NewGuid(), new List<OrderLine>());

            var customerOrders = new CustomerOrders();

            customerOrderRepositoryMock.Setup(repository => repository.GetByCustomerId(orderDto.CustomerId))
                .Returns(customerOrders);
            orderFactoryMock.Setup(factory => factory.CreateOrder(orderDto)).Returns(order);

            CreateSUT().PlaceOrder(orderDto);

            pointsCalculatorMock.Verify(calculator => calculator.Calculate(order));
        }

        [TestMethod]
        public void Should_use_the_discount_calculator()
        {
            var orderDto = new OrderDto();
            var order = new Order(Guid.NewGuid(), new List<OrderLine>());

            var customerOrders = new CustomerOrders();

            customerOrderRepositoryMock.Setup(repository => repository.GetByCustomerId(orderDto.CustomerId))
                .Returns(customerOrders);
            orderFactoryMock.Setup(factory => factory.CreateOrder(orderDto)).Returns(order);

            CreateSUT().PlaceOrder(orderDto);

            discountCalculatorMock.Verify(calculator => calculator.GetDiscount(order, customerOrders.TotalPoints));
        }

        [TestMethod]
        public void Should_save_all_chanmges()
        {
            customerOrderRepositoryMock.Setup(repository => repository.GetByCustomerId(It.IsAny<Guid>()))
                .Returns(new CustomerOrders());

            CreateSUT().PlaceOrder(new OrderDto());

            unitOfWorkMock.Verify(repository => repository.Commit());
        }

        [TestMethod]
        public void Should_return_non_customer_order_summary_if_customer_do_not_exist()
        {
            customerOrderRepositoryMock.Setup(repository => repository.GetByCustomerId(It.IsAny<Guid>()))
                .Returns((CustomerOrders) null);

            var orderPaymentSummary = CreateSUT().PlaceOrder(new OrderDto());

            Assert.AreEqual(OrderPaymentSummary.NoCustoemrFound, orderPaymentSummary);
        }
    }
}