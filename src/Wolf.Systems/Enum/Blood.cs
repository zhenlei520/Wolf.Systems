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
        [Description("A")] A = 1,
        [Description("B")] B = 2,
        [Description("AB")] AB = 3,
        [Description("O")] O = 4,
        [Description("RhP")] RhP = 5,
        [Description("RhN")] RhN = 6
    }
}
