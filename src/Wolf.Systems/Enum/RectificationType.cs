// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Enum;

/// <summary>
/// 取整方式
/// </summary>
public enum RectificationType
{
    /// <summary>
    /// 向上取整
    /// </summary>
    [Description("向上取整")] Celling = 1,

    /// <summary>
    /// 向下取整
    /// </summary>
    [Description("向下取整")] Floor = 2,
}
