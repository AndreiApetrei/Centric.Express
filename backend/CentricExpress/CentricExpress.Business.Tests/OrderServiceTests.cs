using System;
using System.Collections.Generic;
using System.Linq;
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
        private Mock<IOrderFactory> orderFactoryMock;
        private Mock<ICustomerOrdersRepository> customerOrderRepositoryMock;
        private Mock<IUnitOfWork> unitOfWorkMock;
        private Mock<IPointsCalculator> pointsCalculatorMock;

        [TestInitialize]
        public void Initialize()
        {
            orderFactoryMock = new Mock<IOrderFactory>();
            customerOrderRepositoryMock = new Mock<ICustomerOrdersRepository>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            pointsCalculatorMock = new Mock<IPointsCalculator>();
        }

        private OrderService CreateSUT()
        {
            return new OrderService(orderFactoryMock.Object, customerOrderRepositoryMock.Object, unitOfWorkMock.Object,
                pointsCalculatorMock.Object);
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
        public void Should_save_all_chanmges()
        {
            customerOrderRepositoryMock.Setup(repository => repository.GetByCustomerId(It.IsAny<Guid>()))
                .Returns(new CustomerOrders());

            CreateSUT().PlaceOrder(new OrderDto());

            unitOfWorkMock.Verify(repository => repository.Commit());
        }
    }
}