// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Enum;

/// <summary>
/// 区间模式
/// </summary>
public enum RangeMode
{
    /// <summary>
    /// 开区间
    /// </summary>
    [Description("开区间")] Open = 1,

    /// <summary>
    /// 闭区间
    /// </summary>
    [Description("闭区间")] Close = 2,

    /// <summary>
    /// 左开右闭
    /// </summary>
    [Description("左开右闭")] OpenClose = 3,

    /// <summary>
    /// 左闭右开
    /// </summary>
    [Description("左闭右开")] CloseOpen = 4
}
