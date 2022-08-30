// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Wolf.Systems.Core.ExpressionTrees
{
    /// <summary>
    /// 实例Expression
    /// </summary>
    public class InstanceExpression
    {

        #region 初始化对象(必须有无参构造函数)

        /// <summary>
        /// 初始化对象(必须有无参构造函数)
        /// </summary>
        /// <param name="constructorInfo">构造函数，允许为空（自动获取）</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Func<T> New<T>(ConstructorInfo constructorInfo = null) where T : class
        {
            if (constructorInfo == null)
                constructorInfo = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .FirstOrDefault(c => c.GetParameters().Length == 0) ?? throw new Exception("不存在无参的构造函数");

            Expression instanceExpression = Expression.New(constructorInfo);
            return Expression.Lambda<Func<T>>(instanceExpression).Compile();
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="constructorInfo">构造函数（不能为空）</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Func<object[], T> NewByConstructor<T>(ConstructorInfo constructorInfo) where T : class
        {
            if (constructorInfo == null)
            {
                throw new ArgumentNullException(nameof(constructorInfo));
            }

            var parameters = constructorInfo.GetParameters();
            var parametersParameter = Expression.Parameter(typeof(object[]));
            var parameterExpressions = new List<Expression>();
            for (var i = 0; i < parameters.Length; i++)
            {
                var valueObj = Expression.ArrayIndex(parametersParameter, Expression.Constant(i));
                var valueCast = Expression.Convert(valueObj, parameters[i].ParameterType);

                parameterExpressions.Add(valueCast);
            }

            Expression instanceExpression = Expression.New(constructorInfo, parameterExpressions);

            return Expression.Lambda<Func<object[], T>>(instanceExpression, parametersParameter).Compile();
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="types">参数类型</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Func<object[], T> NewByConstructor<T>(params Type[] types) where T : class
        {
            var constructorInfos = typeof(T)
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(c => c.GetParameters().Length == types.Length)
                .ToList();
            ConstructorInfo constructorInfo = null;
            if (constructorInfos.Count == 1)
            {
                constructorInfo = constructorInfos.FirstOrDefault();
            }
            else
            {
                foreach (var item in constructorInfos)
                {
                    for (int i = 0; i < types.Length; i++)
                    {
                        if (item.GetParameters()[i].ParameterType != types[i])
                        {
                            constructorInfo = null;
                            break;
                        }

                        if (constructorInfo == null)
                        {
                            constructorInfo = item;
                        }
                    }
                    if (constructorInfo != null)
                        break;
                }
            }

            return NewByConstructor<T>(constructorInfo);
        }

        #endregion

    }
}
