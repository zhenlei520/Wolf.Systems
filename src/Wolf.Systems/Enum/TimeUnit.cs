// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

        /// <summary>
        /// 毫秒
        /// </summary>
        [Description("毫秒")] MilliSecond = 2,

        /// <summary>
        /// 秒
        /// </summary>
        [Description("秒")] Second = 3,

        /// <summary>
        /// 分钟
        /// </summary>
        [Description("分钟")] Minutes = 4,

        /// <summary>
        /// 小时
        /// </summary>
        [Description("小时")] Hours = 5,

        /// <summary>
        /// 天
        /// </summary>
        [Description("天")] Days = 6,

        /// <summary>
        /// 周
        /// </summary>
        [Description("周")] Weeks = 7,

        /// <summary>
        /// 月
        /// </summary>
        [Description("月")] Month = 8,

        /// <summary>
        /// 季
        /// </summary>
        [Description("季")] Quarter = 9,

        /// <summary>
        /// 年
        /// </summary>
        [Description("年")] Year = 10
    }
}
