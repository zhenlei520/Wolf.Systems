// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Data.Abstractions;

namespace Wolf.Systems.Data.Entities
{
    /// <summary>
    /// 实体实现
    /// </summary>
    /// <typeparam name="T">主键类型</typeparam>
    public abstract class Entity<T> : DbEntity, IEntity<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual T Id { get; set; }

        /// <summary>
        /// 设置id
        /// </summary>
        /// <param name="id">实体id</param>
        public void SetId(T id) => this.Id = id;
    }
}
