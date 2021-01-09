// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 血型
    /// </summary>
    public enum Blood
    {
        [EDescribe("A")] A = 1,
        [EDescribe("B")] B = 2,
        [EDescribe("AB")] AB = 3,
        [EDescribe("O")] O = 4,
        [EDescribe("RhP")] RhP = 5,
        [EDescribe("RhN")] RhN = 6
    }
}