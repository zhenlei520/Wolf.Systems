// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// ICollection扩展
    /// </summary>
    public partial class Extensions
    {
        #region 对list集合分页

        /// <summary>
        /// 对list集合分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageSize">页码</param>
        /// <param name="pageIndex">页大小</param>
        /// <param name="isTotal">是否计算总条数</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Page<T> ListPager<T>(this ICollection<T> query, int pageSize, int pageIndex, bool isTotal)
        {
            PageList<T> list = new PageList<T>();

            if (isTotal)
            {
                list.RowCount = query.Count();
            }

            if (pageIndex - 1 < 0)
            {
                throw new BusinessException("页码必须大于等于1",ErrorCode.ParamError);
            }

            query = query.Skip((pageIndex - 1) * pageSize).ToList();
            if (pageSize > 0)
            {
                list.Data = query.Take(pageSize).ToList();
            }
            else if (pageSize != -1)
            {
                throw new BusinessException("页大小须等于-1或者大于0", ErrorCode.ParamError);
            }
            else
            {
                list.Data = query.ToList();
            }

            return list;
        }

        #endregion
    }
}
