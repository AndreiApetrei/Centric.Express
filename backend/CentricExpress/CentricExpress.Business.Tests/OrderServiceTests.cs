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
        private Mock<IRepository<Order>> orderRepositoryMock;
        private Mock<IOrderFactory> orderFactoryMock;

        [TestInitialize]
        public void Initialize()
        {
            orderRepositoryMock = new Mock<IRepository<Order>>();
            orderFactoryMock = new Mock<IOrderFactory>();
        }
        
        public OrderService CreateSUT()
        {
            return new OrderService(orderRepositoryMock.Object, orderFactoryMock.Object);
        }

        [TestMethod]
        public void Should_insert_the_order()
        {
            var orderDto = new OrderDto();
            var order = new Order(Guid.NewGuid(), new List<OrderLine>());
            orderFactoryMock.Setup(factory => factory.CreateOrder(orderDto)).Returns(order);
            
            CreateSUT().PlaceOrder(orderDto);
            
            orderRepositoryMock.Verify(repository => repository.Insert(order));
        }
        
        [TestMethod]
        public void Should_save_the_changes()
        {
            var orderDto = new OrderDto();
            
            CreateSUT().PlaceOrder(orderDto);
            
            orderRepositoryMock.Verify(repository => repository.SaveChanges());
        }
    }
}