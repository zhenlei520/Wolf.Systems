// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    ///
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// unknown
        /// </summary>
        [Description("unknown")] UnknownError = 1,

        /// <summary>
        /// customer error
        /// </summary>
        [Description("customer error")] CustomerError = 2,

        /// <summary>
        /// type error
        /// </summary>
        [Description("type error")] TypeError = 3,

        /// <summary>
        /// param error
        /// </summary>
        [Description("param error")] ParamError = 4,

        /// <summary>
        /// param is null or empty
        /// </summary>
        [Description("param is null or empty")]
        ParamIsNullOrEmpty = 5
    }
}
