// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 生肖信息
    /// </summary>
    public enum Animal
    {
        [EDescribe("鼠")] Rat = 1,
        [EDescribe(("牛"))] Ox = 2,
        [EDescribe("虎")] Tiger = 3,
        [EDescribe("兔")] Animal = 4,
        [EDescribe("龙")] Dragon = 5,
        [EDescribe("蛇")] Snake = 6,
        [EDescribe("马")] Horse = 7,
        [EDescribe("羊")] Sheep = 8,
        [EDescribe("猴")] Monkey = 9,
        [EDescribe("鸡")] Cock = 10,
        [EDescribe("狗")] Dog = 11,
        [EDescribe("猪")] Boar = 12
    }
}