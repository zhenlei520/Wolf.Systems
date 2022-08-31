// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wolf.Systems.Core.Common.Systems;

namespace Wolf.Systems.Core.Common
{
    /// <summary>
    ///
    /// </summary>
    public static class TypeCommon
    {
#if !NET40
        #region 判断继承关系

        /// <summary>
        /// 判断targetType是否继承type(支持泛型)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this Type type, Type targetType)
        {
            if (type.IsGenericType &&
                type.GetTypeInfo().GenericTypeParameters.Length > 0 &&
                targetType.IsGenericType &&
                targetType.GetTypeInfo().GenericTypeParameters.Length > 0)
                return targetType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == type);

            return type.IsAssignableFrom(targetType);
        }

        /// <summary>
        /// 判断targetType是否被type所继承(支持泛型)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool IsAssignableTo(this Type type, Type targetType)
        {
            return IsAssignableFrom(targetType, type);
        }

        #endregion
#endif
    }
}
