﻿// Copyright (c) zhenlei520 All rights reserved.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Internal.DateTimes
{
    /// <summary>
    /// 本季末
    /// </summary>
    public class EndQuarterProvider : IDateTimeProvider
    {
        /// <summary>
        /// 时间类型
        /// </summary>
        public int Type => (int)TimeType.EndQuarter;

        /// <summary>
        /// 得到本季末时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date)
        {
            return date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day).AddMonths(3)
                .AddDays(-1);
        }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date)
        {
            return date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day).AddMonths(3)
                .AddDays(-1);
        }
    }
}
