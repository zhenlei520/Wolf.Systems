// Copyright (c) zhenlei520 All rights reserved.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 加密方式
    /// </summary>
    public enum SecurityType
    {
        [EDescribe("Aes")] Aes = 1,
        [EDescribe("Des")] Des = 2,
        [EDescribe("JsAes")] JsAes = 3
    }
}