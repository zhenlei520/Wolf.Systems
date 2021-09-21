// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 分页数据集合
    /// </summary>
    public interface IPage<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        int RowCount { get; set; }

        /// <summary>
        /// 当前页数据集合
        /// </summary>
        IEnumerable<T> Data { get; set; }

        /// <summary>
        /// 扩展Data
        /// </summary>
        object ExtendedData { get; set; }
    }
}