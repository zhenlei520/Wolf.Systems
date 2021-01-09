namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 货币
    /// </summary>
    public interface ICurrencyProvider
    {
        /// <summary>
        /// 得到货币类型
        /// </summary>
        int CurrencyType { get; }

        /// <summary>
        /// 数值类型转货币
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        string ConvertToCurrency(decimal param);
    }
}
