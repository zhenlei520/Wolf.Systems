// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Data.Enum;

namespace Wolf.Systems.Data.Abstractions
{
    /// <summary>
    /// Db上下文提供者
    /// </summary>
    public interface IDbContextBuilder<TDbContext> where TDbContext : IDbContext
    {
        /// <summary>
        /// 得到上下文
        /// </summary>
        /// <param name="dbOptionType">数据库操作类型</param>
        /// <returns></returns>
        IUnitOfWork Create(DbOptionType dbOptionType);
    }
}
