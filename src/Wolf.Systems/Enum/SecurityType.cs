// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 加密方式
    /// </summary>
    public enum SecurityType
    {
        /// <summary>
        /// Aes
        /// </summary>
        [Description("Aes")] Aes = 1,

        /// <summary>
        /// Des
        /// </summary>
        [Description("Des")] Des = 2,

        /// <summary>
        /// JsAes
        /// </summary>
        [Description("JsAes")] JsAes = 3
    }
}
