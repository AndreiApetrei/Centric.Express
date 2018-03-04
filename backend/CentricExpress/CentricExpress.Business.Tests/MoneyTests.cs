using CentricExpress.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CentricExpress.Business.Tests
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void Should_choose_the_right_currency_when_adding_with_zero()
        {
            Money money = Money.From(2, Currency.RON);
            
            Assert.AreEqual(money, money + Money.Zero);
            Assert.AreEqual(money, Money.Zero + money);
        }
    }
}