// Copyright (c) zhenlei520 All rights reserved.

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 星期
    /// </summary>
    public abstract class WeekProvider
    {
        /// <summary>
        /// 国家
        /// </summary>
        public abstract int Nationality { get; }

        /// <summary>
        /// 得到星期N
        /// </summary>
        /// <param name="serialNumber">序列号</param>
        /// <returns></returns>
        public abstract string GetName(int serialNumber);
    }
}
