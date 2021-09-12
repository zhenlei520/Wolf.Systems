// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Provider.DateTimes;

/// <summary>
/// 本月月末
/// </summary>
public class EndMonthProvider : IDateTimeProvider
{
    /// <summary>
    ///
    /// </summary>
    private GregorianCalendar Calendar => new GregorianCalendar();

    /// <summary>
    /// 时间类型
    /// </summary>
    public int Type => (int)TimeType.EndMonth;

    /// <summary>
    /// 得到结果
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public DateTime GetResult(DateTime date) => new DateTime(date.Year, date.Month, Calendar.GetDaysInMonth(date.Year, date.Month));

    /// <summary>
    /// 得到结果
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public DateTimeOffset GetResult(DateTimeOffset date)
    {
        var lastDay = Calendar.GetDaysInMonth(date.Year, date.Month);
        DateTime dateTime = new DateTime(date.Year, date.Month, lastDay);
        return new DateTimeOffset(dateTime, date.Offset);
    }
}
