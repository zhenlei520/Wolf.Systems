﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Wolf.Systems.Data.Entities
{
    /// <summary>
    /// 添加/修改/删除聚合根
    /// </summary>
    public class Fulls<T> : AddAndUpdate<T>
    {
        /// <summary>
        ///
        /// </summary>
        public Fulls():base()
        {
            IsDel = false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        public Fulls(T accountId) : base(accountId)
        {
            IsDel = false;
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="accountId">账户id</param>
        public void DeleteInfo(T accountId)
        {
            IsDel = true;
            DelAccountId = accountId;
            DelTime = DateTime.Now;
            UpdateInfo(accountId);
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 删除用户id
        /// </summary>
        public T DelAccountId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DelTime { get; set; }
    }
}
