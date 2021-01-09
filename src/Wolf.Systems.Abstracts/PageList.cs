// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 列表
    /// </summary>
    public sealed class PageList<T> : Page<T>
    {
        /// <summary>
        ///
        /// </summary>
        public PageList()
        {
            Data = new List<T>();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="rowCount">总条数</param>
        /// <param name="data">当前列表</param>
        public PageList(int rowCount, List<T> data)
        {
            RowCount = rowCount;
            Data = data;
        }
    }
}
