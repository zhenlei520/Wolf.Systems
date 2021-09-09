using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.UnitTest
{
    [TestClass]
    public class BusinessExceptionTest
    {
        [TestMethod]
        public void TestOneParameter()
        {
            var exception = new BusinessException("system error");
            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == (int)ErrorCode.CustomerError);
            Assert.IsTrue(exception.Error == null);
        }

        [TestMethod]
        public void TestTwoParameter()
        {
            var exception = new BusinessException("system error", 200);
            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == 200);
            Assert.IsTrue(exception.Error == null);

            exception = new BusinessException("system error", ErrorCode.ParamError);
            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == (int)ErrorCode.ParamError);
            Assert.IsTrue(exception.Error == null);

            var error = new { msg = "error" };
            exception = new BusinessException("system error", error);
            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == (int)ErrorCode.CustomerError);
            Assert.IsTrue(exception.Error == error);
        }

        [TestMethod]
        public void TestThreeParameter()
        {
            var error = new { msg = "error" };
            var exception = new BusinessException("system error", ErrorCode.CustomerError, error);

            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == (int)ErrorCode.CustomerError);
            Assert.IsTrue(exception.Error == error);
        }

        [TestMethod]
        public void TestOneParameterByGeneric()
        {
            var exception = new BusinessException<string>("system error");
            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == default(string));
            Assert.IsTrue(exception.Error == null);
        }


        [TestMethod]
        public void TestTwoParameterByGeneric()
        {
            var exception = new BusinessException<string>("system error", "error");
            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == "error");
            Assert.IsTrue(exception.Error == null);
        }


        [TestMethod]
        public void TestThreeParameterByGeneric()
        {
            var error = new { msg = "error" };
            var exception = new BusinessException<string>("system error", "error", error);

            Assert.IsTrue(exception.Message == "system error");
            Assert.IsTrue(exception.Code == "error");
            Assert.IsTrue(exception.Error == error);
        }
    }
}
