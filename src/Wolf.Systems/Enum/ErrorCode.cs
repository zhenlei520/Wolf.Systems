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
        [Description("unknown")] UnknownError = 1,
        [Description("customer error")] CustomerError = 2,
        [Description("type error")] TypeError = 3,
        [Description("param error")] ParamError = 4,
        [Description("param is null or empty")] ParamIsNullOrEmpty = 5
    }
}
