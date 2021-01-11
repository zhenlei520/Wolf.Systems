// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Wolf.Systems.Abstracts;

namespace Wolf.Systems.Core.Configuration
{
    /// <summary>
    /// 列表
    /// </summary>
    public class Page<T> : IPage<T>
    {
        /// <summary>
        ///
        /// </summary>
        public Page()
        {
            this.Data = new List<T>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="data"></param>
        /// <param name="extendedData"></param>
        public Page(int rowCount, IEnumerable<T> data, object extendedData = null)
        {
            RowCount = rowCount;
            Data = data;
            ExtendedData = extendedData;
        }

        /// <summary>
        /// 总条数
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// 当前页数据集合
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// 扩展Data
        /// </summary>
        public object ExtendedData { get; set; }
    }
}
