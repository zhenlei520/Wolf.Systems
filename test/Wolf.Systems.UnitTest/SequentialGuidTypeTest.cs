using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wolf.Systems.UnitTest
{
    [TestClass]
    public class SequentialGuidTypeTest
    {
        [TestMethod]
        public void TestAssignment()
        {
            Assert.IsFalse(new SequentialGuidType(1, "DefaultGuid").Equals(SequentialGuidType.Default));
        }
    }

    public class SequentialGuidType : Systems.Enumerations.SequentialGuidType
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">描述</param>
        public SequentialGuidType(int id, string name) : base(id, name)
        {
        }
    }
}