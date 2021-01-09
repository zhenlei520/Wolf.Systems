using System.ComponentModel;

namespace Wolf.Systems.Enum
{
    /// <summary>
    /// 货币类型
    /// </summary>
    public enum CurrencyType
    {
        [Description("人民币")] Cny = 1,
        [Description("美元")] Dollar = 2,
        [Description("日元")] Yen = 3,
        [Description("欧元")] Euro = 4,
        [Description("韩币")] Krw = 5,
        [Description("法郎")] Franc = 6,
        [Description("港元")] Hkd = 7,
        [Description("加元")] Cad = 8,
        [Description("泰铢")] Baht = 9,
        [Description("卢布")] Rouble = 10,
        [Description("越南盾")] Dong = 11,
        [Description("缅元")] Kyat = 12,
        [Description("台币")] Twd = 13,
        [Description("英镑")] Pound = 14,
        [Description("马克")] GermanCurrency = 15
    }
}
