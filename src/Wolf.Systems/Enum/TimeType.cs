using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 时间类型
    /// </summary>
    public enum TimeType
    {
        [Description("月初")]StartMonth = 1,
        [Description("月末")]EndMonth = 2,
        [Description("本周周一")]StartWeek = 3,
        [Description("本周周日")]EndWeek = 4,
        [Description("本季初")]StartQuarter = 5,
        [Description("本季末")]EndQuarter = 6,
        [Description("年初")]StartYear = 7,
        [Description("年末")]EndYear = 8
    }
}
