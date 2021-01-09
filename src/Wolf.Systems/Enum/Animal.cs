// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 生肖信息
    /// </summary>
    public enum Animal
    {
        [Description("鼠")] Rat = 1,
        [Description(("牛"))] Ox = 2,
        [Description("虎")] Tiger = 3,
        [Description("兔")] Animal = 4,
        [Description("龙")] Dragon = 5,
        [Description("蛇")] Snake = 6,
        [Description("马")] Horse = 7,
        [Description("羊")] Sheep = 8,
        [Description("猴")] Monkey = 9,
        [Description("鸡")] Cock = 10,
        [Description("狗")] Dog = 11,
        [Description("猪")] Boar = 12
    }
}
