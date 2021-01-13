// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;
using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 时间单位
    /// </summary>
    public enum TimeUnit
    {
        /// <summary>
        /// 刻度
        /// </summary>
        [Description("刻度")] Ticks = 1,
        [Description("毫秒")] MilliSecond = 2,
        [Description("秒")] Second = 3,
        [Description("分钟")] Minutes = 4,
        [Description("小时")] Hours = 5,
        [Description("天")] Days = 6,
        [Description("周")] Weeks = 7,
        [Description("月")] Month = 8,
        [Description("季")] Quarter = 9,
        [Description("年")] Year = 10
    }
}
