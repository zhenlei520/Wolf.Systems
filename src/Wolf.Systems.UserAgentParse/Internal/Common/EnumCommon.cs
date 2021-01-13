// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Wolf.Systems.ComponentModel;
using Wolf.Systems.Core.Common;

namespace Wolf.Systems.UserAgentParse.Internal.Common
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    internal class EnumCommon
    {
        #region 得到枚举字典（key对应枚举的值，value对应枚举的EDescription注释）

        /// <summary>
        /// 得到枚举字典（key对应枚举的值，value对应枚举的EDescription注释）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> ToDescriptionDictionary<TEnum>()
        {
            Array arrays = System.Enum.GetValues(typeof(TEnum));
            Dictionary<int, string> dics = new Dictionary<int, string>();
            foreach (System.Enum value in arrays)
            {
                string description = CustomAttributeCommon.GetCustomAttribute<EDescriptionAttribute, string>(
                    value.GetType(), x => x.Describe, value.ToString());
                dics.Add(Convert.ToInt32(value), description);
            }

            return dics;
        }

        #endregion
    }
}
