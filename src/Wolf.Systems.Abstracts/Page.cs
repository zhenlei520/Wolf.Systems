// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 分页数据集合
    /// </summary>
    public abstract class Page<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
        public virtual int RowCount { get; set; }

        /// <summary>
        /// 当前页数据集合
        /// </summary>
        public virtual IEnumerable<T> Data { get; set; }

        /// <summary>
        /// 扩展Data
        /// </summary>
        public virtual object ExtendedData { get; set; }
    }
}
