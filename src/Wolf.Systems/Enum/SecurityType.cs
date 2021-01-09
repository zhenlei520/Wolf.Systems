// Copyright (c) zhenlei520 All rights reserved.

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
