// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 血型
    /// </summary>
    public enum Blood
    {
        /// <summary>
        /// A
        /// </summary>
        [Description("A")] A = 1,

        /// <summary>
        /// B
        /// </summary>
        [Description("B")] B = 2,

        /// <summary>
        /// AB
        /// </summary>
        [Description("AB")] AB = 3,

        /// <summary>
        /// O
        /// </summary>
        [Description("O")] O = 4,

        /// <summary>
        /// 熊猫血型 阳性
        /// </summary>
        [Description("RhP")] RhP = 5,

        /// <summary>
        /// 熊猫血型 阴性
        /// </summary>
        [Description("RhN")] RhN = 6
    }
}
