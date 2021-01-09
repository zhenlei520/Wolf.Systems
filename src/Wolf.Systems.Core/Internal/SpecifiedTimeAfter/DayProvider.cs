// Copyright (c) zhenlei520 All rights reserved.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Internal.SpecifiedTimeAfter
{
    /// <summary>
    /// 天
    /// </summary>
    public sealed class DayProvider : ISpecifiedTimeAfterProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int) TimeUnit.Days;

        /// <summary>
        /// 得到duration天后
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date, int duration)
        {
            return date.AddDays(duration);
        }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date, int duration)
        {
            return date.AddDays(duration);
        }
    }
}
