// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.DateTimes
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
        public DateTime GetResult(DateTime date) => date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day);

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date) => date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day);
    }
}
