// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.SpecifiedTimeAfter
{
    /// <summary>
    /// 月
    /// </summary>
    public sealed class MonthProvider : ISpecifiedTimeAfterProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int)TimeUnit.Month;

        /// <summary>
        /// 得到duration月后
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date, int duration) => date.AddMonths(duration);

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date, int duration) => date.AddMonths(duration);
    }
}