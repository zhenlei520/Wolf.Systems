﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Wolf.Systems.UserAgentParse
{
    /// <summary>
    /// 系统
    /// </summary>
    public class Os
    {
        /// <summary>
        ///
        /// </summary>
        public Os()
        {
        }

        /// <summary>
        /// 系统名称
        /// </summary>
        public virtual string Name { get; internal set; }

        /// <summary>
        /// 别名
        /// </summary>
        public virtual string Alias { get; internal set; }

        /// <summary>
        /// 系统版本
        /// </summary>
        public  virtual Versions Version { get; internal set; }

        /// <summary>
        /// 详情
        /// </summary>
        public virtual string Details { get; internal set; }

        /// <summary>
        /// 版本与系统别名关系
        /// </summary>
        private List<KeyValuePair<string, string>> VersionAndAliasRelarionList =
            new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(6.2 + "", "8"),
                new KeyValuePair<string, string>(6.1 + "", "7"),
                new KeyValuePair<string, string>(6.0 + "", "Vista"),
                new KeyValuePair<string, string>(5.2 + "", "Server 2003"),
                new KeyValuePair<string, string>(5.1 + "", "XP"),
                new KeyValuePair<string, string>(5.0 + "", "2000"),
            };

        #region 设置别名

        /// <summary>
        /// 设置别名
        /// </summary>
        internal void SetAlias()
        {
            Alias = VersionAndAliasRelarionList.Where(x => x.Key == Version.ToString()).Select(x => x.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(Alias))
            {
                Alias = "NT" + Version;
            }
        }

        #endregion
    }
}
