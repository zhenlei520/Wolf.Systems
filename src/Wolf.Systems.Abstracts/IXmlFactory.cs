// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// Xml工厂
    /// </summary>
    public interface IXmlFactory
    {
        /// <summary>
        /// 根据唯一标识创建xml Provider
        /// 如果唯一标识为空，则获取默认权重最高的，如果未匹配到，则获取空的xml实现
        /// </summary>
        /// <param name="name">唯一标识</param>
        /// <returns></returns>
        IXmlProvider Create(string name = "");

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<IXmlProvider> GetServices();
    }
}
