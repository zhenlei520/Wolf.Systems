// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel;
using Wolf.Systems.Core.Common;

namespace Wolf.Systems.Core
{
  /// <summary>
  /// 枚举信息扩展
  /// </summary>
  public partial class Extensions
    {
        #region 得到自定义描述

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCustomerObj<T>(this System.Enum value) where T : Attribute => value.GetType().GetCustomAttribute<T>(value.ToString());

        #endregion

        #region 返回枚举项的描述信息

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(this System.Enum value) => CustomAttributeCommon.GetCustomAttribute<DescriptionAttribute, string>(
                value.GetType(), x => x.Description, value.ToString());

        #endregion
    }
}
