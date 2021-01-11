namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 身份证帮助类
    /// </summary>
    public interface IIdCardProvider
    {
        /// <summary>
        /// 国家
        /// </summary>
        int Nationality { get; }

        /// <summary>
        /// 是否身份证
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        bool IsIdCard(string cardNo);
    }
}
