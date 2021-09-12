// Copyright (c) zhenlei520 All rights reserved.

// ReSharper disable once CheckNamespace

using Wolf.Systems.Core.Configuration;

// ReSharper disable once CheckNamespace
namespace Wolf.Systems.Core
{
    /// <summary>
    ///
    /// </summary>
    public partial class Extensions
    {
        #region 两个集合计较

        /// <summary>
        /// 两个集合计较
        /// </summary>
        /// <param name="sourceList">源集合</param>
        /// <param name="optList">新集合</param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static ListCompare<T, TKey> Compare<T, TKey>(this IEnumerable<T> sourceList, IEnumerable<T> optList)
            where T : IEntity<TKey>
            where TKey : struct
        {
            return new ListCompare<T, TKey>(sourceList, optList);
        }

        #endregion
    }
}
