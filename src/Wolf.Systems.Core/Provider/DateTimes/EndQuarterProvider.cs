// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Provider.DateTimes;

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
    public DateTime GetResult(DateTime date) => date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day).AddMonths(3)
            .AddDays(-1);

    /// <summary>
    /// 得到结果
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public DateTimeOffset GetResult(DateTimeOffset date) => date.AddMonths(0 - (date.Month - 1) % 3).AddDays(1 - date.Day).AddMonths(3).AddDays(-1);
}
