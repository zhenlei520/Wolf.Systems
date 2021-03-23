// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Data.Enum;

namespace Wolf.Systems.Data.Entities
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DbContextOptions
    {
        /// <summary>
        ///
        /// </summary>
        public Func<DbOptionType, string> ConnectionString { get; protected set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        public DbContextOptions(Func<DbOptionType, string> connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
