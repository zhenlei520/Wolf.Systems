// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 区间模式
    /// </summary>
    public enum RangeMode
    {
        /// <summary>
        /// 开区间
        /// </summary>
        [EDescribe("开区间")] Open = 1,
        [EDescribe("闭区间")] Close = 2,
        [EDescribe("左开右闭")] OpenClose = 3,
        [EDescribe("左闭右开")] CloseOpen = 4
    }
}