// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 格式化时间类型
    /// </summary>
    public enum FormatDateType
    {
        [EDescribe("yyyy-MM-dd")] Date = 1,
        [EDescribe("yyyy-MM-dd HH:mm:ss")] Full = 2,
        [EDescribe("yyyy-MM-dd HH:mm:ss fff")] FullMillsecond = 3,
        [EDescribe("yyyyMMdd")] DateFormat = 4,
        [EDescribe("yyyyMMddHHmmss")] FullFormat = 5,
        [EDescribe("yyyyMMddHHmmssfff")] FullMillsecondFormat = 6,
        [EDescribe("HH:mm")] Time = 7,
        [EDescribe("HH:mm:ss")] TimeSecond = 8
    }
}