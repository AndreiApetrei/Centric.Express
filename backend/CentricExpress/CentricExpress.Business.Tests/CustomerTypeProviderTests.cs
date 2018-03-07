using CentricExpress.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class CustomerTypeProviderTests
    {
        private CustomerTypeProvider CreateSUT()
        {
            return new CustomerTypeProvider();
        }

        [DataTestMethod]
        [DataRow(3001, CustomerType.Gold)]
        [DataRow(3000, CustomerType.Gold)]
        [DataRow(2999, CustomerType.Silver)]
        
        [DataRow(2001, CustomerType.Silver)]
        [DataRow(2000, CustomerType.Silver)]
        [DataRow(1999, CustomerType.Bronze)]
        
        [DataRow(1001, CustomerType.Bronze)]
        [DataRow(1000, CustomerType.Bronze)]
        [DataRow(999, CustomerType.Regular)]
        [DataRow(1, CustomerType.Regular)]
        [DataRow(0, CustomerType.Regular)]
        
        [DataRow(3, CustomerType.Regular)]
        
        public void Test_customer_type(int points, CustomerType customerType)
        {
            Assert.AreEqual(customerType, CreateSUT().GetCustomerType(points));
        }        
    }
}