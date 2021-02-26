// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.Core.Common;
using Xunit;

namespace Wolf.Systems.UnitTest
{
    /// <summary>
    /// 类型转换测试
    /// </summary>
    public class TypeCommonUnitTest
    {
        /// <summary>
        ///
        /// </summary>
        [Fact]
        public void GetTypeTest()
        {
            var type = TypeCommon.GetType<string>();
        }
    }
}
