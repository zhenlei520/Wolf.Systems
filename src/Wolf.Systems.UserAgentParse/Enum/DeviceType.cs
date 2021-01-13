// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;
using Wolf.Systems.ComponentModel;
using Wolf.Systems.UserAgentParse.Internal.Common;

namespace Wolf.Systems.UserAgentParse.Enum
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DeviceType
    {
        [Description("电脑")] [EDescription("desktop")]
        Pc = 1,

        [Description("移动手机")] [EDescription("mobile")]
        Mobile = 2,

        [Description("平板电脑")] [EDescription("tablet")]
        Tablet = 3,

        [Description("电视")] [EDescription("television")]
        Television = 4,

        [Description("移动设备")] [EDescription("media")]
        Media = 5,

        [Description("阅读器")] [EDescription("ereader")]
        Reader = 6,

        [Description("游戏机")] [EDescription("gaming")]
        Gaming = 7,

        [Description("模拟器")] [EDescription("emulator")]
        Emulator = 8
    }

    public class Test{
        public void T()
        {
            
        }
    }
}
