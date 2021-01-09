// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 时间戳类型
    /// </summary>
    public enum TimestampType
    {
        [Description("10 bit timestamp")]Second = 1,
        [Description("13 bit timestamp")]MilliSecond = 2
    }
}
