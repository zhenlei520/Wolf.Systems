namespace Wolf.Systems.Abstracts
{
    /// <summary>
    ///
    /// </summary>
    public interface IGuidGeneratorProvider
    {
        /// <summary>
        /// 类型
        /// </summary>
        int Type { get; }

        /// <summary>
        /// 得到Guid
        /// </summary>
        /// <returns></returns>
        Guid Create();
    }
}
