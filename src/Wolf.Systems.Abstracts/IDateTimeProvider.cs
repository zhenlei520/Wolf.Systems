using System;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 时间提供者
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// 时间类型
        /// </summary>
        int Type { get; }

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        DateTime GetResult(DateTime date);

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        DateTimeOffset GetResult(DateTimeOffset date);
    }
}
