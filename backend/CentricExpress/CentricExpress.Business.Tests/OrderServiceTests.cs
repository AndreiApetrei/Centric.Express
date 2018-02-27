using CentricExpress.Business.Domain;
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
        private Mock<IItemRepository> itemRepository;

        [TestInitialize]
        public void Intialize()
        {
            orderRepositoryMock = new Mock<IRepository<Order>>();
            itemRepository = new Mock<IItemRepository>();
        }
        
        public OrderService CreateSUT()
        {
            return new OrderService(orderRepositoryMock.Object, itemRepository.Object);
        }
        
        [TestMethod]
        public void Should_create_order_with_order_line()
        {
        }
    }
}
