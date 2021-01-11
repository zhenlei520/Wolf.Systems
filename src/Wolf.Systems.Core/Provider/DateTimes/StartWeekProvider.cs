// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.DateTimes
{
    /// <summary>
    /// 本周周一
    /// </summary>
    public class StartWeekProvider : IDateTimeProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int) TimeType.StartWeek;

        /// <summary>
        /// 得到本周周一
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date)
        {
            int count = date.DayOfWeek - DayOfWeek.Monday;
            if (count == -1) count = 6;
            return new DateTime(date.Year, date.Month, date.Day).AddDays(-count);
        }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date)
        {
            int count = date.DayOfWeek - DayOfWeek.Monday;
            if (count == -1) count = 6;
            return new DateTime(date.Year, date.Month, date.Day).AddDays(-count);
        }
    }
}
