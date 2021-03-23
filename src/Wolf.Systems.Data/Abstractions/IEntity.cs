// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Data.Abstractions
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T">实体主键类型</typeparam>
    public interface IEntity<T> : IDbEntity
    {
        /// <summary>
        /// 实体主键
        /// </summary>
        T Id { get; }
    }
}
