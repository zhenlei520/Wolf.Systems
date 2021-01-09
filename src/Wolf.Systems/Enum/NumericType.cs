using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 正负数类型
    /// </summary>
    public enum NumericType
    {
        [Description("正数")] Plus = 1,
        [Description("负数")] Minus = 2,
        [Description("全部")] All = 3
    }
}
