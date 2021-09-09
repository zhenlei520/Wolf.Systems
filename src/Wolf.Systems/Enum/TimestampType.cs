// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 时间戳类型
    /// </summary>
    public enum TimestampType
    {
        /// <summary>
        /// 10位时间戳
        /// </summary>
        [Description("10 bit timestamp")] Second = 1,

        /// <summary>
        /// 13位时间戳
        /// </summary>
        [Description("13 bit timestamp")] MilliSecond = 2
    }
}
