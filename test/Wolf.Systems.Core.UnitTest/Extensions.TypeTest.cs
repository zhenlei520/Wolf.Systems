// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wolf.Systems.Core.UnitTest
{
    /// <summary>
    /// Type Unit Test
    /// </summary>
    public partial class ExtensionsTest
    {
        [TestMethod]
        public void TestIsGeneric()
        {
            Assert.IsFalse(typeof(IPeople).IsGeneric());
            Assert.IsFalse(typeof(Boy).IsGeneric());
            Assert.IsFalse(typeof(ITransaction).IsGeneric());

            Assert.IsTrue(typeof(ITransaction<>).IsGeneric());
            Assert.IsTrue(typeof(Transaction<>).IsGeneric());
        }

        [TestMethod]
        public void TestIsGenericInterface()
        {
            Assert.IsTrue(typeof(ITransaction<>).IsGenericInterface());
        }

        [TestMethod]
        public void TestIsGenericClass()
        {
            Assert.IsTrue(typeof(Transaction<>).IsGenericClass());
            Assert.IsTrue(typeof(UnitOfWork<>).IsGenericClass());
        }

        [TestMethod]
        public void TestIsGenericAbstractClass()
        {
            Assert.IsTrue(typeof(UnitOfWork<>).IsGenericAbstractClass());
        }

        [TestMethod]
        public void TestIsGenericNotAbstractClass()
        {
            Assert.IsFalse(typeof(ITransaction<>).IsGenericNotAbstractClass());
            Assert.IsFalse(typeof(UnitOfWork<>).IsGenericNotAbstractClass());
        }

        [TestMethod]
        public void TestGetTypes()
        {
            var list = typeof(ITransaction).GetTypeList(AppDomain.CurrentDomain.GetAssemblies());
            Assert.IsTrue(list.Count == 11);
        }

        public interface IPeople
        {
        }

        public class Boy : IPeople
        {
        }

        public interface ITransaction
        {
        }

        public interface ITransaction<TDbContext> : ITransaction
            where TDbContext : DbContext
        {
        }

        public interface IUnitOfWork : ITransaction
        {
        }

        public interface IUnitOfWork<TDbContext> : ITransaction<TDbContext>
            where TDbContext : DbContext
        {
        }

        public class DbContext
        {
        }

        public class Transaction : ITransaction
        {
        }

        public class Transaction<TDbContext> : Transaction, ITransaction<TDbContext>
            where TDbContext : DbContext
        {
        }


        public class UnitOfWork : Transaction, IUnitOfWork
        {
        }

        public class UnitOfWork<TDbContext> : UnitOfWork, IUnitOfWork<TDbContext>
            where TDbContext : DbContext
        {
        }

        public class NewUnitOfWork2 : UnitOfWork<DbContext>
        {
        }

        public class NewUnitOfWork3<T> : UnitOfWork<DbContext>
        {
        }

        public class NewUnitOfWork4<T, TDbContext> : UnitOfWork<TDbContext>
            where TDbContext : DbContext
        {
        }

        public interface ISaga<T>
        {
        }

        public class Saga<T> : ISaga<T>
        {
        }
    }
}
