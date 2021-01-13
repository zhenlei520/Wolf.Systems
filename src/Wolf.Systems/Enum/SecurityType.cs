// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;
using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 加密方式
    /// </summary>
    public enum SecurityType
    {
        [Description("Aes")] Aes = 1,
        [Description("Des")] Des = 2,
        [Description("JsAes")] JsAes = 3
    }
}
