// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Data.Abstractions
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public interface IDbContextFactory<TDbContext> where TDbContext : IDbContext
    {
        /// <summary>
        /// 创建DbContext提供者
        /// </summary>
        /// <returns></returns>
        IDbContextBuilder<TDbContext> CreateBuilder();
    }
}
