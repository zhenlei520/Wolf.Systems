using System.ComponentModel;
using Wolf.Systems.ComponentModel;

namespace Wolf.Systems.UserAgentParse.Internal.Enum
{
    /// <summary>
    /// 匹配方式
    /// </summary>
    internal enum DeviceMatchType
    {
        [Description("模糊匹配")]Vague = 1,
        [Description("正则表达式")]Regex = 2,
        [Description("模糊匹配和除什么之外的模糊匹配")]VagueAndExceptVague = 3,
        [Description("正则表达式和除什么之外正则表达式匹配")]RegexAndExceptRegex = 4,
        [Description("模糊匹配和除什么之外的正则表达式匹配")]VagueAndExceptRegex = 5,
        [Description("正则表达式和除什么之外模糊匹配")]RegexAndExceptVague = 6,
        [Description("模糊匹配和正则表达式")]VagueAndRegex = 7,
        [Description("模糊匹配和正则表达式以及排除模糊匹配和排除正则表达式")]All = 8
    }
}
