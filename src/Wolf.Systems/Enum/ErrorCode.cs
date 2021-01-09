// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    ///
    /// </summary>
    public enum ErrorCode
    {
        [EDescribe("unknown")] UnknownError = 1,
        [EDescribe("customer error")] CustomerError = 2,
        [EDescribe("type error")] TypeError = 3,
        [EDescribe("param error")] ParamError = 4,
        [EDescribe("param is null or empty")] ParamIsNullOrEmpty = 5
    }
}
