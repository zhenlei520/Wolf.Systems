using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 时间类型
    /// </summary>
    public enum TimeType
    {
        /// <summary>
        /// 月初
        /// </summary>
        [Description("月初")] StartMonth = 1,

        /// <summary>
        /// 月末
        /// </summary>
        [Description("月末")] EndMonth = 2,

        /// <summary>
        /// 本周周一
        /// </summary>
        [Description("本周周一")] StartWeek = 3,

        /// <summary>
        /// 本周周日
        /// </summary>
        [Description("本周周日")] EndWeek = 4,

        /// <summary>
        /// 本季初
        /// </summary>
        [Description("本季初")] StartQuarter = 5,

        /// <summary>
        /// 本季末
        /// </summary>
        [Description("本季末")] EndQuarter = 6,

        /// <summary>
        /// 年初
        /// </summary>
        [Description("年初")] StartYear = 7,

        /// <summary>
        /// 年末
        /// </summary>
        [Description("年末")] EndYear = 8
    }
}
