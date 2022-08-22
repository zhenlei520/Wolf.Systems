// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 得到指定时间后
    /// </summary>
    public interface ISpecifiedTimeAfterProvider
    {
        /// <summary>
        /// 时间类型
        /// </summary>
        int Type { get; }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        DateTime GetResult(DateTime date, int duration);

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date">时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        DateTimeOffset GetResult(DateTimeOffset date, int duration);
    }
}