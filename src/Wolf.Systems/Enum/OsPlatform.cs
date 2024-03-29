// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 操作系统
    /// Windows、Linux、OSX、Unknow
    /// </summary>
    public enum OsPlatform
    {
        /// <summary>
        /// Windows
        /// </summary>
        [Description("Windows")] Windows = 1,

        /// <summary>
        /// Linux
        /// </summary>
        [Description("Linux")] Linux = 2,

        /// <summary>
        /// OSX
        /// </summary>
        [Description("OSX")] Osx = 3
    }
}