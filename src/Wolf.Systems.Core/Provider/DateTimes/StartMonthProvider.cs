// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.DateTimes
{
    /// <summary>
    /// 月初
    /// </summary>
    public class StartMonthProvider : IDateTimeProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int)TimeType.StartMonth;

        /// <summary>
        /// 得到本月初
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date)
        {
            return date.AddDays(1 - date.Day); //本月月初
        }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date)
        {
            return date.AddDays(1 - date.Day); //本月月初
        }
    }
}
