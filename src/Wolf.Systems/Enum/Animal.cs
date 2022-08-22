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
        /// <summary>
        /// 鼠
        /// </summary>
        [Description("鼠")] Rat = 1,

        /// <summary>
        /// 牛
        /// </summary>
        [Description(("牛"))] Ox = 2,

        /// <summary>
        /// 虎
        /// </summary>
        [Description("虎")] Tiger = 3,

        /// <summary>
        /// 兔
        /// </summary>
        [Description("兔")] Animal = 4,

        /// <summary>
        /// 龙
        /// </summary>
        [Description("龙")] Dragon = 5,

        /// <summary>
        /// 蛇
        /// </summary>
        [Description("蛇")] Snake = 6,

        /// <summary>
        /// 马
        /// </summary>
        [Description("马")] Horse = 7,

        /// <summary>
        /// 羊
        /// </summary>
        [Description("羊")] Sheep = 8,

        /// <summary>
        /// 猴
        /// </summary>
        [Description("猴")] Monkey = 9,

        /// <summary>
        /// 鸡
        /// </summary>
        [Description("鸡")] Cock = 10,

        /// <summary>
        /// 狗
        /// </summary>
        [Description("狗")] Dog = 11,

        /// <summary>
        /// 猪
        /// </summary>
        [Description("猪")] Boar = 12
    }
}