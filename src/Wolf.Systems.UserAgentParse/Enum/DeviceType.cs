// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.UserAgentParse.Enum
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DeviceType
    {
        [EDescribe("电脑")]Pc = 1,
        [EDescribe("移动手机")]Mobile = 2,
        [EDescribe("平板电脑")]Tablet = 3,
        [EDescribe("电视")]Television = 4,
        [EDescribe("移动设备")]Media = 5,
        [EDescribe("阅读器")]Reader = 6,
        [EDescribe("游戏机")]Gaming = 7,
        [EDescribe("模拟器")]Emulator = 8
    }
}