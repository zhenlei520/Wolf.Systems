// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    ///
    /// </summary>
    public enum TimeSpanFormatDateType
    {
        [Description("{0}天{1}小时{2}分钟")] Minutes = 1,
        [Description("{0}天{1}小时{2}分钟{3}秒")] Second = 2,
        [Description("{0}天{1}小时{2}分钟{3}秒{4}毫秒")] MilliSecond = 3
    }
}
