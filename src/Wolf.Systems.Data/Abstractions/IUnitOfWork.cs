// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Wolf.Systems.Data.Abstractions
{
    /// <summary>
    /// 单元模式
    /// </summary>
    public interface IUnitOfWork : IDbContext
    {
        /// <summary>
        /// 提交保存
        /// </summary>
        /// <returns></returns>
        bool Commit();

        /// <summary>
        /// 异步保存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 异步保存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    // /// <summary>
    // /// 单元模式，可以指定数据库
    // /// </summary>
    // /// <typeparam name="T"></typeparam>
    // public interface IUnitOfWork<T>
    //     where T : IDbContext
    // {
    //     /// <summary>
    //     /// 提交保存
    //     /// </summary>
    //     /// <returns></returns>
    //     bool Commit();
    //
    //     /// <summary>
    //     /// 异步保存
    //     /// </summary>
    //     /// <param name="cancellationToken"></param>
    //     /// <returns></returns>
    //     Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    //
    //     /// <summary>
    //     /// 异步保存
    //     /// </summary>
    //     /// <param name="cancellationToken"></param>
    //     /// <returns></returns>
    //     Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    // }
}
