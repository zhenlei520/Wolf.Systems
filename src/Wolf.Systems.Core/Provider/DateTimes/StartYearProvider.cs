// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.DateTimes
{
    /// <summary>
    /// 本年初
    /// </summary>
    public class StartYearProvider : IDateTimeProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int)TimeType.StartYear;

        /// <summary>
        /// 得到本年初
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date) => new DateTime(date.Year, 1, 1);

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date) => new DateTimeOffset(new DateTime(date.Year, 1, 1), date.Offset);
    }
}