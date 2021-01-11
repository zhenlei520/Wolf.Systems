// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 星期
    /// </summary>
    public interface IWeekProvider
    {
        /// <summary>
        /// 国家
        /// </summary>
        int Nationality { get; }

        /// <summary>
        /// 得到星期N
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        string GetName(int serialNumber);
    }
}
