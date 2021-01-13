// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// Json 序列化基础类库
    /// </summary>
    public interface IJsonProvider 
    {
        /// <summary>
        /// json序列化
        /// </summary>
        /// <param name="obj">待序列化的对象</param>
        /// <param name="format"></param>
        /// <param name="action">委托方法</param>
        /// <returns></returns>
        string Serializer(object obj, bool format = false, Func<System.Exception, string> action = null);

        /// <summary>
        /// json反序列化
        /// </summary>
        /// <param name="str">待反序列化的字符串</param>
        /// <param name="type"></param>
        /// <param name="action">委托方法</param>
        /// <returns></returns>
        object Deserialize(string str, Type type, Func<System.Exception, object> action = null);

        /// <summary>
        /// json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">待反序列化的字符串</param>
        /// <param name="defaultResult">反序列化异常</param>
        /// <param name="action">委托方法</param>
        /// <returns></returns>
        T Deserialize<T>(string str, T defaultResult = default(T), Action<System.Exception> action = null)
            where T : class, new();
    }
}
