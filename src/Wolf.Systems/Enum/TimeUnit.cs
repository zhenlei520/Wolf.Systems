// Copyright (c) zhenlei520 All rights reserved.

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
        [EDescribe("刻度")] Ticks = 1,
        [EDescribe("毫秒")] MilliSecond = 2,
        [EDescribe("秒")] Second = 3,
        [EDescribe("分钟")] Minutes = 4,
        [EDescribe("小时")] Hours = 5,
        [EDescribe("天")] Days = 6,
        [EDescribe("周")] Weeks = 7,
        [EDescribe("月")] Month = 8,
        [EDescribe("季")] Quarter = 9,
        [EDescribe("年")] Year = 10
    }
}