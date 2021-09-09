// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Enum
{
    /// <summary>
    ///
    /// </summary>
    public enum TimeSpanFormatDateType
    {
        /// <summary>
        /// {0}天{1}小时{2}分钟
        /// </summary>
        [Description("{0}天{1}小时{2}分钟")] Minutes = 1,

        /// <summary>
        /// {0}天{1}小时{2}分钟{3}秒
        /// </summary>
        [Description("{0}天{1}小时{2}分钟{3}秒")] Second = 2,

        /// <summary>
        /// {0}天{1}小时{2}分钟{3}秒{4}毫秒
        /// </summary>
        [Description("{0}天{1}小时{2}分钟{3}秒{4}毫秒")]
        MilliSecond = 3
    }
}
