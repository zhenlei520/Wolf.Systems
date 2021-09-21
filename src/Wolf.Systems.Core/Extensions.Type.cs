// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Wolf.Systems.Exceptions;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// 类型扩展信息
    /// </summary>
    public partial class Extensions
    {
        #region 得到自定义描述

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="sourceType">类类型</param>
        /// <param name="name">属性名称</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetCustomAttribute<T>(this Type sourceType, string name) where T : Attribute
        {
            if (!string.IsNullOrEmpty(name))
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = sourceType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    if (Attribute.GetCustomAttribute(fieldInfo,
                        typeof(T), false) is T attr)
                    {
                        return attr;
                    }
                }
            }

            return null;
        }

        #endregion

        #region 得到枚举对应的值与自定义属性集合

        /// <summary>
        /// 得到枚举与对应的自定义属性信息
        /// </summary>
        /// <typeparam name="T">自定义属性</typeparam>
        /// <returns></returns>
        public static Dictionary<System.Enum, T> ToEnumAndAttributes<T>(this Type type) where T : Attribute
        {
            Array arrays = System.Enum.GetValues(type);
            Dictionary<System.Enum, T> dics = new Dictionary<System.Enum, T>();
            foreach (System.Enum item in arrays)
            {
                dics.Add(item, item.GetCustomerObj<T>());
            }

            return dics;
        }

        #endregion

        #region 得到枚举字典自定义属性的集合

        /// <summary>
        /// 得到枚举字典自定义属性的集合
        /// </summary>
        /// <param name="type">type必须是枚举</param>
        /// <returns></returns>
        public static List<T> GetCustomerObjects<T>(this Type type) where T : Attribute
        {
            if (!type.IsEnum)
            {
                throw new BusinessException(nameof(type) + "不是枚举");
            }

            Array arrays = System.Enum.GetValues(type);
            List<T> list = new List<T>();
            foreach (System.Enum array in arrays)
            {
                list.Add(type.GetCustomAttribute<T>(nameof(array)));
            }

            return list;
        }

        #endregion

#if !NET40
        #region 判断是否枚举

    /// <summary>
    /// 判断是否枚举
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool IsEnum(this Type type) => type.GetTypeInfo().IsEnum;

        #endregion
#endif

        #region 判断是list集合

        public static bool IsList(this object obj) => obj is IList || obj.IsGenericList();

        #endregion

        #region 判断是泛型集合

        /// <summary>
        /// 判断是泛型集合
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsGenericList(this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return IsGenericList(obj.GetType());
        }

        /// <summary>
        /// 判断Type是泛型List<T>集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsGenericList<T>(this object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return IsGenericList<T>(obj.GetType());
        }

        /// <summary>
        /// 判断Type是泛型List集合
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static bool IsGenericList(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);

        /// <summary>
        /// 判断Type是泛型List<T>集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericList<T>(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<T>);

        #endregion

        #region 判断可以构建泛型类

        /// <summary>
        /// 判断可以构建泛型类
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGeneric(this Type type)
        {
#if !NET40
            return type.GetTypeInfo().IsGenericTypeDefinition;
#elif NET40
            return type.IsGenericTypeDefinition;
#endif

        }

        /// <summary>
        /// 判断可以构建泛型类且当前类是接口
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericInterface(this Type type) => type.IsGeneric() && type.IsInterface;

        /// <summary>
        /// 判断可以构建泛型类且当前是普通类（包含普通类与抽象类）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericClass(this Type type) => type.IsGeneric() && type.IsClass;

        /// <summary>
        /// 判断可以构建泛型类且当前是非抽象类
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericNotAbstractClass(this Type type) => type.IsGeneric() && !type.IsAbstract;

        /// <summary>
        /// 判断可以构建泛型类且当前是抽象类
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsGenericAbstractClass(this Type type) => type.IsGeneric() && type.IsAbstract;

        #endregion

        #region 得到继承当前类的所有实现

        public static IEnumerable<Type> GetTypes(this Type type, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0) return new List<Type>();
            return type.GetTypes(assemblies.SelectMany(assembly => assembly.GetTypes()).ToArray());
        }

        public static List<Type> GetTypeList(this Type type, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0) return new List<Type>();
            var typeEnumerable = type.GetTypes(assemblies);
            if (typeEnumerable is List<Type> list)
            {
                return list;
            }
            return typeEnumerable.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes(this Type type, params Type[] types)
        {
            if (types == null || types.Length == 0) return new List<Type>();
            return types.Where(t => type.IsAssignableFrom(t));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static List<Type> GetTypeList(this Type type, params Type[] types)
        {
            var typeEnumerable = type.GetTypes(types);
            if (typeEnumerable is List<Type> list)
            {
                return list;
            }
            return typeEnumerable.ToList();
        }

        #endregion
    }
}
