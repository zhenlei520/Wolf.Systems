// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Core;
using Xunit;

namespace Wolf.Systems.UnitTest
{
    /// <summary>
    /// 扩展类
    /// </summary>
    public class ExtensionsUnitTest
    {
        /// <summary>
        ///
        /// </summary>
        [Fact]
        public void GetTypeTest()
        {
            var ret =
                "appKey:uQgm4lejBtoIp1M2TPYnoCDO35JfqRpNappSecret:Un52ogDzNDhIJjm4tpU1p8qbQacBQrSstimestamp:1617618438000format:jsonv:1.0method:md5"
                    .GetMd5Hash();
            Console.WriteLine(ret);
        }
    }
}
