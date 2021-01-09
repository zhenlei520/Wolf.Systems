// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 取整方式
    /// </summary>
    public enum RectificationType
    {
        [EDescribe("向上取整")] Celling = 1,
        [EDescribe("向下取整")] Floor = 2,
    }
}