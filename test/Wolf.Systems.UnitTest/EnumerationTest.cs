using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wolf.Systems.UnitTest.Enumerations;

namespace Wolf.Systems.UnitTest
{
    [TestClass]
    public class EnumerationTest
    {
        [TestMethod]
        public void TestEnumeration()
        {
            var paySuccess = OrderStatus.PaymentSuccess;
            Assert.IsTrue(paySuccess.ToString() == "PaymentSuccess");
            Assert.IsTrue(OrderStatus.GetAll<OrderStatus>().Count() == 3);
            Assert.IsTrue(paySuccess.Equals(OrderStatus.PaymentSuccess));
            Assert.IsNotNull(paySuccess.GetHashCode());
            Assert.IsTrue(OrderStatus.FromValue<OrderStatus>(2) == paySuccess);
            Assert.IsTrue(OrderStatus.FromDisplayName<OrderStatus>("PaymentSuccess") == paySuccess);
            Assert.IsTrue(paySuccess.CompareTo(OrderStatus.PaymentFail) == -1);
        }
    }
}
