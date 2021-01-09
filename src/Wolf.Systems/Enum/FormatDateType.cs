// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 格式化时间类型
    /// </summary>
    public enum FormatDateType
    {
        [Description("yyyy-MM-dd")] Date = 1,
        [Description("yyyy-MM-dd HH:mm:ss")] Full = 2,
        [Description("yyyy-MM-dd HH:mm:ss fff")] FullMillsecond = 3,
        [Description("yyyyMMdd")] DateFormat = 4,
        [Description("yyyyMMddHHmmss")] FullFormat = 5,
        [Description("yyyyMMddHHmmssfff")] FullMillsecondFormat = 6,
        [Description("HH:mm")] Time = 7,
        [Description("HH:mm:ss")] TimeSecond = 8
    }
}
