// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.DateTimes
{
  /// <summary>
  ///  本年末
  /// </summary>
  public class EndYearProvider : IDateTimeProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        public int Type => (int)TimeType.EndYear;

        /// <summary>
        /// 得到本年末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime GetResult(DateTime date) => new DateTime(date.Year, 12, 31); //本年年末

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeOffset GetResult(DateTimeOffset date) => new DateTimeOffset(new DateTime(date.Year, 12, 31), date.Offset);
    }
}
