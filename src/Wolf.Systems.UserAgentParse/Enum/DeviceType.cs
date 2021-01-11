// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.UserAgentParse.Enum
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DeviceType
    {
        [Description("电脑")]Pc = 1,
        [Description("移动手机")]Mobile = 2,
        [Description("平板电脑")]Tablet = 3,
        [Description("电视")]Television = 4,
        [Description("移动设备")]Media = 5,
        [Description("阅读器")]Reader = 6,
        [Description("游戏机")]Gaming = 7,
        [Description("模拟器")]Emulator = 8
    }
}
