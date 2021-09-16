using Wolf.Systems.Core.Common;

namespace Wolf.Systems.Core.UnitTest;

[TestClass]
public class CloneableTest
{
    [TestMethod]
    public void TestClone()
    {
        Users mike = new Users() { Id = 1, Name = "Mike", UserInfo = new UserInfos() { Address = "Dep1" } };
        Users rose = mike.ShallowClone<Users>();

        mike.Id = 2;
        mike.Name = "Allen";
        mike.UserInfo.Address = "Dep2";
        Assert.IsTrue(mike.Id != rose.Id && mike.Name != rose.Name && mike.UserInfo.ToString() == rose.UserInfo.ToString());
    }
}

class Users : CloneableClass
{
    public long Id { get; set; }

    public string Name { get; set; }

    public UserInfos UserInfo { get; set; }
}

class UserInfos
{
    public string Address { get; set; }

    public override string ToString()
    {
        return this.Address;
    }
}

