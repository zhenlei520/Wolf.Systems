// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Common
{
  /// <summary>
  ///
  /// </summary>
  public class TypeCommon
    {
        #region 获取类型

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>()=> GetType(typeof(T));

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType(Type type)=> Nullable.GetUnderlyingType(type) ?? type;

        #endregion

        #region 查询继承type的接口与实现类集合

        /// <summary>
        /// 查询继承type的接口与实现类集合
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<KeyValuePair<Type, Type>> GetInterfaceAndImplementationType(Assembly[] assemblies, Type type)
        {
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
