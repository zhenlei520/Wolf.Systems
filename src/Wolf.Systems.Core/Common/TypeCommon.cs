// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Wolf.Systems.Core.Common
{
    /// <summary>
    ///
    /// </summary>
    public class TypeCommon
    {
        #region 查询继承type的接口与实现类集合

        /// <summary>
        /// 查询继承type的接口与实现类集合
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<KeyValuePair<Type, Type>> GetInterfaceAndImplementationType(Type type, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
                throw new ArgumentNullException(nameof(assemblies));

            var fulleName = type.Namespace + type.Name;
            var list = assemblies
                .SelectMany(x =>
                    x.GetTypes().Where(y => y.GetInterfaces().Any(z => (z.Namespace + z.Name).Equals(fulleName))))
                .ToList();

            var typeList = new List<KeyValuePair<Type, Type>>();
            foreach (var interfaceType in list.Where(x => x.IsInterface))
            {
                var interfaceTypeFullName = interfaceType.Namespace + interfaceType.Name;

                list.Where(x =>
                    !x.IsInterface && x.GetInterfaces().Any(z =>
                        (z.Namespace + z.Name).Equals(interfaceTypeFullName))).ToList().ForEach(implementationType =>
                {
                    typeList.Add(new KeyValuePair<Type, Type>(interfaceType, implementationType));
                });
            }

            return typeList;
        }

        #endregion
    }
}
