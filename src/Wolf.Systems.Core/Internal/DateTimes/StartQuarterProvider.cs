﻿// Copyright (c) zhenlei520 All rights reserved.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Internal.DateTimes
{
    /// <summary>
    /// 本季初
    /// </summary>
    public class StartQuarterProvider : IDateTimeProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int)TimeType.StartQuarter;

        /// <summary>
        /// 本季初
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date)
        {
            return date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day);
        }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date)
        {
            return date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day);
        }
    }
}
