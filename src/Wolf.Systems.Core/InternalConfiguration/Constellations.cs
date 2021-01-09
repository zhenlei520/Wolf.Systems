// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.InternalConfiguration
{
    /// <summary>
    /// 星座
    /// </summary>
    internal class Constellations
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 星座
        /// </summary>
        public Constellation Key { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public float MinTime { get; set; }

        /// <summary>
        /// 截至时间
        /// </summary>
        public float MaxTime { get; set; }
    }
}
