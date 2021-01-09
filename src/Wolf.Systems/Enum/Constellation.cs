// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 星座
    /// </summary>
    public enum Constellation
    {
        [EDescribe("白羊座")] Aries = 1,
        [EDescribe("金牛座")] Taurus = 2,
        [EDescribe("双子座")] Gemini = 3,
        [EDescribe("巨蟹座")] Cancer = 4,
        [EDescribe("狮子座")] Leo = 5,
        [EDescribe("处女座")] Virgo = 6,
        [EDescribe("天秤座")] Libra = 7,
        [EDescribe("天蝎座")] Scorpio = 8,
        [EDescribe("射手座")] Sagittarius = 9,
        [EDescribe("摩羯座")] Capricornus = 10,
        [EDescribe("水瓶座")] Aquarius = 11,
        [EDescribe("双鱼座")] Pisces = 12
    }
}