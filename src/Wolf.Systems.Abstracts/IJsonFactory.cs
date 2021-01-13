// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// Json工厂
    /// </summary>
    public interface IJsonFactory
    {
        /// <summary>
        /// 根据唯一标识获取JsonProvider
        /// 如果唯一标识为空，则获取默认权重最高的，如果未匹配到，则获取空的Json实现
        /// </summary>
        /// <param name="name">服务的唯一标识</param>
        /// <returns></returns>
        IJsonProvider Create(string name = "");

        /// <summary>
        /// 得到JsonProvider集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<IJsonProvider> GetServices();
    }
}
