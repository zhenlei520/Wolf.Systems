// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 语言
    /// </summary>
    public enum Language
    {
        [EDescribe("汉语")] Chinese = 1,
        [EDescribe("粤语")] Cantonese = 2,
        [EDescribe("日语")] Japanese = 3,
        [EDescribe("英语")] English = 4,
        [EDescribe("韩语")] Korean = 5,
        [EDescribe("法语")] French = 6,
        [EDescribe("印度语")] Hindi = 7
    }
}