// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.DateTimes
{
  /// <summary>
  /// 本周末
  /// </summary>
  public class EndWeekProvider : IDateTimeProvider
    {
        /// <summary>
        ///
        /// </summary>
        public int Type => (int)TimeType.EndWeek;

        /// <summary>
        /// 得到本周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date)
        {
            int count = date.DayOfWeek - DayOfWeek.Sunday;
            if (count != 0) count = 7 - count;
            return new DateTime(date.Year, date.Month, date.Day).AddDays(count); //本周周日
        }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date)
        {
            int count = date.DayOfWeek - DayOfWeek.Sunday;
            if (count != 0) count = 7 - count;
            var dateTime = new DateTime(date.Year, date.Month, date.Day).AddDays(count); //本周周日
            return new DateTimeOffset(dateTime, date.Offset);
        }
    }
}
