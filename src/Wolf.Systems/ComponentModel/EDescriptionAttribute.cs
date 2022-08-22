// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Wolf.Systems.ComponentModel
{
    /// <summary>
    /// 描述信息
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class EDescriptionAttribute : Attribute
    {
        private readonly string _describe;

        /// <summary>
        ///
        /// </summary>
        public virtual string Describe => _describe;

        /// <summary>
        /// 自定义描述信息
        /// </summary>
        /// <param name="describe"></param>
        public EDescriptionAttribute(string describe) => _describe = describe;
    }
}
