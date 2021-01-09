// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.ComponentModel;

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
        [EDescribe("Windows")] Windows = 1,
        [EDescribe("Linux")] Linux = 2,
        [EDescribe("OSX")] Osx = 3
    }
}
