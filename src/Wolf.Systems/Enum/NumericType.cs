namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 正负数类型
    /// </summary>
    public enum NumericType
    {
        /// <summary>
        /// 正数
        /// </summary>
        [Description("正数")] Plus = 1,

        /// <summary>
        /// 负数
        /// </summary>
        [Description("负数")] Minus = 2,

        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")] All = 3
    }
}
