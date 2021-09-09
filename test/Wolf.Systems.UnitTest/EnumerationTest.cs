using Wolf.Systems.Enumerations.SeedWork;
using Wolf.Systems.Enumerations.SeedWork.Configurations;

namespace Wolf.Systems.UnitTest
{
    [TestClass]
    public class EnumerationTest
    {
        [TestMethod]
        public void TestEnumeration()
        {
            int id = 7;
            var name = "xiaowang";
            var enumeration = new People(id, name);
            Assert.IsTrue(enumeration.Id == id);
            Assert.IsTrue(enumeration.Name == name);

            var user = new User(id, name);
            Assert.IsTrue(user.Id == id);
            Assert.IsTrue(user.Name == name);

        }
    }

    public class People : Enumeration<int, string>
    {
        public People()
        {
        }

        public People(int id, string name) : base(id, name)
        {
        }
    }

    public class User : Enumeration
    {
        /// <summary>
        /// 
        /// </summary>
        public User()
        {

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">描述</param>
        public User(int id, string name) : base(id, name)
        {
        }
    }
}
