// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

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
