// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Configuration
{
    /// <summary>
    /// 点
    /// </summary>
    public struct Points<T1, T2>
    {
        /// <summary>
        /// 经度
        /// </summary>
        public T1 X { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public T2 Y { get; set; }
    }
}