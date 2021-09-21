// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Internal.Configuration
{
    /// <summary>
    ///
    /// </summary>
    internal class RegexConst
    {
        /// <summary>
        /// 中文
        /// </summary>
        public const string Chinese = @"^[\u4e00-\u9fa5]";

        /// <summary>
        /// 网址
        /// </summary>
        public const string WebSite =
            @"((http|https)://)?(www.)?[a-z0-9\.]+(\.(com|net|cn|com\.cn|com\.net|net\.cn))(/[^\s\n]*)?";

        /// <summary>
        /// 网址
        /// </summary>
        public const string Ip =
            @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>
        /// 邮箱
        /// </summary>
        public const string Email =
            @"^([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$";
    }
}