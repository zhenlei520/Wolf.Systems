﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.UserAgentParse
{
    /// <summary>
    /// 引擎
    /// 浏览器内核
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 引擎名称
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// 版本
        /// </summary>
        public virtual Versions Version { get; internal set; }
    }
}
