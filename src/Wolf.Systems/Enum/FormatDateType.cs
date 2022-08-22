// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 格式化时间类型
    /// </summary>
    public enum FormatDateType
    {
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        [Description("yyyy-MM-dd")] Date = 1,

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        [Description("yyyy-MM-dd HH:mm:ss")] Full = 2,

        /// <summary>
        /// yyyy-MM-dd HH:mm:ss fff
        /// </summary>
        [Description("yyyy-MM-dd HH:mm:ss fff")]
        FullMillsecond = 3,

        /// <summary>
        /// yyyyMMdd
        /// </summary>
        [Description("yyyyMMdd")] DateFormat = 4,

        /// <summary>
        /// yyyyMMddHHmmss
        /// </summary>
        [Description("yyyyMMddHHmmss")] FullFormat = 5,

        /// <summary>
        /// yyyyMMddHHmmssfff
        /// </summary>
        [Description("yyyyMMddHHmmssfff")] FullMillsecondFormat = 6,

        /// <summary>
        /// HH:mm
        /// </summary>
        [Description("HH:mm")] Time = 7,

        /// <summary>
        /// HH:mm:ss
        /// </summary>
        [Description("HH:mm:ss")] TimeSecond = 8
    }
}