﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Data.Abstractions;

namespace Wolf.Systems.Data.Entities
{
    /// <summary>
    /// 聚合跟实现
    /// </summary>
    /// <typeparam name="T">主键类型</typeparam>
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot<T>
    {
        /// <summary>
        ///
        /// </summary>
        public AggregateRoot()
        {
            Id = default(T);
        }
    }
}
