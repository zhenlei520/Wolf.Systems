﻿// Copyright (c) zhenlei520 All rights reserved.

using System.ComponentModel;

namespace Wolf.Systems.Data.Enum
{
    /// <summary>
    /// 数据库操作类型
    /// </summary>
    public enum DbOptionType
    {
        [Description("写")] Write = 1,
        [Description("读")] Read = 2
    }
}
