// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wolf.Systems.Core.ExpressionTrees;
using Wolf.Systems.Core.UnitTest.Models;

namespace Wolf.Systems.Core.UnitTest
{
    [TestClass]
    public class LambdaTest
    {
        [TestMethod]
        public void TestCreateInstance()
        {
            var user = InstanceExpression.New<User>().Invoke();
            Assert.IsNotNull(user);
            Assert.AreEqual(null, user.Name);
        }

        [TestMethod]
        public void TestCreateInstanceAndNotLessConstructor()
        {
            var people = InstanceExpression.NewByConstructor<People>(typeof(string), typeof(int))
                .Invoke(new Object[] { "张三", 18 });
            Assert.IsNotNull(people);
            Assert.AreEqual("张三", people.Name);
            Assert.AreEqual(18, people.Age);
        }

        [TestMethod]
        public void TestCreateInstanceAndAssign()
        {
            var user = InstanceExpression.New<User>().Invoke();
            Assert.IsNotNull(user);

            var instanceExpress = Expression.Parameter(typeof(User), "e");
            var propertyExpress = Expression.Property(instanceExpress, nameof(User.Name));

            var assignString = Expression.Assign(propertyExpress, Expression.Constant("张三"));
            Expression.Lambda<Action<User>>(assignString, instanceExpress).Compile()(user);
        }
    }
}
