using System;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    ///
    /// </summary>
    public interface IUniqueProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        int Type { get; }

        /// <summary>
        /// 得到Guid
        /// </summary>
        /// <returns></returns>
        Guid GetGuid();
    }
}
