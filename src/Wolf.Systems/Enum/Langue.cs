// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 语言
    /// </summary>
    public enum Language
    {
        [Description("汉语")] Chinese = 1,
        [Description("粤语")] Cantonese = 2,
        [Description("日语")] Japanese = 3,
        [Description("英语")] English = 4,
        [Description("韩语")] Korean = 5,
        [Description("法语")] French = 6,
        [Description("印度语")] Hindi = 7
    }
}
