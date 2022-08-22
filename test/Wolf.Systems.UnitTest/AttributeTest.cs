using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.UnitTest
{
    [TestClass]
    public class AttributeTest
    {
        private readonly Attribute[] _attributes;

        public AttributeTest()
        {
            var orderType = typeof(Order);
            _attributes = System.Attribute.GetCustomAttributes(orderType);
        }

        [TestMethod]
        public void TestEName()
        {
            ENameAttribute? eNameAttribute = _attributes.Where(attribute => attribute is ENameAttribute).FirstOrDefault() as ENameAttribute;
            Assert.IsTrue(eNameAttribute != null && eNameAttribute.Name == "order");
        }

        [TestMethod]
        public void TestEVersion()
        {
            var eVersionAttribute = _attributes.Where(attribute => attribute is EVersionAttribute).FirstOrDefault() as EVersionAttribute;
            Assert.IsTrue(eVersionAttribute != null && eVersionAttribute.Version == "1.0");
        }

        [TestMethod]
        public void TestEDescription()
        {
            var eDescription = _attributes.Where(attribute => attribute is EDescriptionAttribute).FirstOrDefault() as EDescriptionAttribute;
            Assert.IsTrue(eDescription != null && eDescription.Describe == "order class");
        }
    }

    [EName("order")]
    [EVersion("1.0")]
    [EDescription("order class")]
    public class Order
    {

    }
}
