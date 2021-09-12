// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.



// ReSharper disable VirtualMemberCallInConstructor

namespace Wolf.Systems.Core;

/// <summary>
/// 全局配置
/// </summary>
public class GlobalConfigurations
{
    /// <summary>
    ///
    /// </summary>
    public static GlobalConfigurations Instance = new GlobalConfigurations();

    /// <summary>
    /// 中国日历
    /// </summary>
    internal static ChineseLunisolarCalendar ChineseCalendar;

    /// <summary>
    ///
    /// </summary>
    public GlobalConfigurations()
    {
        ResetSecurityProviders();
        ResetWeekProviders();
        ResetDateTimeProviders();
        ResetSpecifiedTimeAfterProviders();
        ResetCurrencyProviders();
        ResetGuidGeneratorProviders();
        ResetIdCardProviders();

        ChineseCalendar = new ChineseLunisolarCalendar();
    }

    #region 设置全局配置

    /// <summary>
    /// 设置全局配置
    /// </summary>
    /// <param name="globalConfigurations"></param>
    protected virtual void SetGlobalConfigurations(GlobalConfigurations globalConfigurations) => Instance = globalConfigurations;

    #endregion

    #region 安全加密

    /// <summary>
    ///
    /// </summary>
    protected static IList<ISecurityProvider> SecurityProviders;

    #region 添加加密提供者集合

    /// <summary>
    /// 添加加密提供者集合
    /// </summary>
    /// <param name="securityProviders">加密提供者集合</param>
    protected virtual void AddSecurityProvider(params ISecurityProvider[] securityProviders)
    {
        if (securityProviders.GetListCount() == 0)
        {
            return;
        }

        var providers = GetSecurityProviders();
        providers.AddRange(securityProviders);
    }

    #endregion

    #region 得到加密提供者集合

    /// <summary>
    /// 得到加密提供者集合
    /// </summary>
    /// <returns></returns>
    public List<ISecurityProvider> GetSecurityProviders() => SecurityProviders?.ToList() ?? new List<ISecurityProvider>();

    #endregion

    #region 得到加密提供者

    /// <summary>
    /// 得到加密提供者
    /// </summary>
    /// <param name="securityType">加密方式</param>
    /// <returns></returns>
    public ISecurityProvider GetSecurityProvider(int securityType) => GetSecurityProviders().FirstOrDefault(x => x.Type == securityType);

    /// <summary>
    /// 得到加密提供者
    /// </summary>
    /// <param name="securityType">加密方式</param>
    /// <returns></returns>
    public ISecurityProvider GetSecurityProvider(SecurityType securityType) => GetSecurityProvider((int)securityType);

    #endregion

    #region 重置加密提供者为初始状态

    /// <summary>
    /// 重置加密提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetSecurityProviders() => SecurityProviders = new List<ISecurityProvider>()
        {
            new AesProvider(),
            new DesProvider(),
            new JsAesProvider()
        };

    #endregion

    #region 清空加密提供者

    /// <summary>
    /// 清空加密提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearSecurityProviders() => SecurityProviders = new List<ISecurityProvider>();

    #endregion

    #endregion

    #region 星期N

    /// <summary>
    ///
    /// </summary>
    protected static IList<IWeekProvider> WeekProviders;

    #region 添加星期提供者集合

    /// <summary>
    /// 添加星期提供者集合
    /// </summary>
    /// <param name="weekProviders">加密提供者集合</param>
    protected virtual void AddWeekProvider(params IWeekProvider[] weekProviders)
    {
        if (weekProviders.GetListCount() == 0)
        {
            return;
        }

        var providers = GetWeekProviders();
        providers.AddRange(weekProviders);
    }

    #endregion

    #region 得到星期提供者集合

    /// <summary>
    /// 得到星期提供者集合
    /// </summary>
    /// <returns></returns>
    public List<IWeekProvider> GetWeekProviders() => WeekProviders?.ToList() ?? new List<IWeekProvider>();

    #endregion

    #region 得到星期提供者

    /// <summary>
    /// 得到星期提供者
    /// </summary>
    /// <param name="nationality">国家</param>
    /// <returns></returns>
    public IWeekProvider GetWeekProvider(int nationality) => GetWeekProviders().FirstOrDefault(x => x.Nationality == nationality);

    /// <summary>
    /// 得到加密提供者
    /// </summary>
    /// <param name="nationality">国家</param>
    /// <returns></returns>
    public IWeekProvider GetWeekProvider(Nationality nationality) => GetWeekProvider((int)nationality);

    #endregion

    #region 重置星期提供者为初始状态

    /// <summary>
    /// 重置星期提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetWeekProviders() => WeekProviders = new List<IWeekProvider>()
        {
            new ChinaWeekProvider()
        };

    #endregion

    #region 清空星期提供者

    /// <summary>
    /// 清空星期提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearWeekProviders() => WeekProviders = new List<IWeekProvider>();

    #endregion

    #endregion

    #region 时间

    /// <summary>
    ///
    /// </summary>
    protected static IList<IDateTimeProvider> DateTimeProviders;

    #region 添加时间提供者集合

    /// <summary>
    /// 添加时间提供者集合
    /// </summary>
    /// <param name="dateTimeProviders">提供者集合</param>
    protected virtual void AddDateTimeProvider(params IDateTimeProvider[] dateTimeProviders)
    {
        if (dateTimeProviders.GetListCount() == 0)
        {
            return;
        }

        var providers = GetDateTimeProviders();
        providers.AddRange(dateTimeProviders);
    }

    #endregion

    #region 得到时间提供者集合

    /// <summary>
    /// 得到时间提供者集合
    /// </summary>
    /// <returns></returns>
    public List<IDateTimeProvider> GetDateTimeProviders() => DateTimeProviders?.ToList() ?? new List<IDateTimeProvider>();

    #endregion

    #region 得到时间提供者

    /// <summary>
    /// 得到时间提供者
    /// </summary>
    /// <param name="type">时间类型</param>
    /// <returns></returns>
    public IDateTimeProvider GetDateTimeProvider(int type) => GetDateTimeProviders().FirstOrDefault(x => x.Type == type);

    /// <summary>
    /// 得到时间提供者
    /// </summary>
    /// <param name="type">时间类型</param>
    /// <returns></returns>
    public IDateTimeProvider GetDateTimeProvider(TimeType type) => GetDateTimeProvider((int)type);

    #endregion

    #region 重置时间提供者为初始状态

    /// <summary>
    /// 重置时间提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetDateTimeProviders() => DateTimeProviders = new List<IDateTimeProvider>()
        {
            new StartMonthProvider(),
            new EndMonthProvider(),
            new StartWeekProvider(),
            new EndWeekProvider(),
            new StartQuarterProvider(),
            new EndQuarterProvider(),
            new StartYearProvider(),
            new EndYearProvider()
        };

    #endregion

    #region 清空时间提供者

    /// <summary>
    /// 清空时间提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearDateTimeProviders() => DateTimeProviders = new List<IDateTimeProvider>();

    #endregion

    #endregion

    #region 得到指定时间后

    /// <summary>
    ///
    /// </summary>
    protected static IList<ISpecifiedTimeAfterProvider> SpecifiedTimeAfterProviders;

    #region 添加提供者集合

    /// <summary>
    /// 添加提供者集合
    /// </summary>
    /// <param name="specifiedTimeAfterProviders">提供者集合</param>
    protected virtual void AddDateTimeProvider(params ISpecifiedTimeAfterProvider[] specifiedTimeAfterProviders)
    {
        if (specifiedTimeAfterProviders.GetListCount() == 0)
        {
            return;
        }

        var providers = GetSpecifiedTimeAfterProviders();
        providers.AddRange(specifiedTimeAfterProviders);
    }

    #endregion

    #region 得到指定时间提供者集合

    /// <summary>
    /// 得到指定时间提供者集合
    /// </summary>
    /// <returns></returns>
    public List<ISpecifiedTimeAfterProvider> GetSpecifiedTimeAfterProviders() => SpecifiedTimeAfterProviders?.ToList() ?? new List<ISpecifiedTimeAfterProvider>();

    #endregion

    #region 得到指定时间提供者

    /// <summary>
    /// 得到指定时间提供者
    /// </summary>
    /// <param name="type">时间类型</param>
    /// <returns></returns>
    public ISpecifiedTimeAfterProvider GetSpecifiedTimeAfterProvider(int type) => GetSpecifiedTimeAfterProviders().FirstOrDefault(x => x.Type == type);

    /// <summary>
    /// 得到指定时间提供者
    /// </summary>
    /// <param name="type">时间类型</param>
    /// <returns></returns>
    public ISpecifiedTimeAfterProvider GetSpecifiedTimeAfterProvider(TimeUnit type) => GetSpecifiedTimeAfterProvider((int)type);

    #endregion

    #region 重置指定时间提供者为初始状态

    /// <summary>
    /// 重置指定时间提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetSpecifiedTimeAfterProviders() => SpecifiedTimeAfterProviders = new List<ISpecifiedTimeAfterProvider>()
        {
            new TickProvider(),
            new MilliSecondProvider(),
            new SecondProvider(),
            new MinutesProvider(),
            new HourProvider(),
            new DayProvider(),
            new WeeksProvider(),
            new MonthProvider(),
            new QuarterProvider(),
            new YearProvider()
        };

    #endregion

    #region 清空指定时间提供者

    /// <summary>
    /// 清空指定时间提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearSpecifiedTimeAfterProviders() => SpecifiedTimeAfterProviders = new List<ISpecifiedTimeAfterProvider>();

    #endregion

    #endregion

    #region 数字转货币

    /// <summary>
    ///
    /// </summary>
    protected static IList<ICurrencyProvider> CurrencyProviders;

    #region 添加货币转换器提供者

    /// <summary>
    /// 添加货币转换器提供者
    /// </summary>
    /// <param name="currencyProviders">提供者集合</param>
    protected virtual void AddCurrencyProvider(params ICurrencyProvider[] currencyProviders)
    {
        if (currencyProviders.GetListCount() == 0)
        {
            return;
        }

        var providers = GetCurrencyProviders();
        providers.AddRange(currencyProviders);
    }

    #endregion

    #region 得到指定货币转换器提供者集合

    /// <summary>
    /// 得到指定货币转换器提供者集合
    /// </summary>
    /// <returns></returns>
    public List<ICurrencyProvider> GetCurrencyProviders() => CurrencyProviders?.ToList() ?? new List<ICurrencyProvider>();

    #endregion

    #region 得到指定货币转换器提供者

    /// <summary>
    /// 得到指定货币转换器提供者
    /// </summary>
    /// <param name="type">时间类型</param>
    /// <returns></returns>
    public ICurrencyProvider GetCurrencyProvider(int type) => GetCurrencyProviders().FirstOrDefault(x => x.CurrencyType == type);

    /// <summary>
    /// 得到指定时间提供者
    /// </summary>
    /// <param name="currencyType">货币类型</param>
    /// <returns></returns>
    public ICurrencyProvider GetCurrencyProvider(CurrencyType currencyType) => GetCurrencyProvider((int)currencyType);

    #endregion

    #region 重置指定时间提供者为初始状态

    /// <summary>
    /// 重置指定时间提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetCurrencyProviders() => CurrencyProviders = new List<ICurrencyProvider>()
        {
            new CnyCurrencyProvider(),
        };

    #endregion

    #region 清空指定时间提供者

    /// <summary>
    /// 清空指定时间提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearCurrencyProviders() => CurrencyProviders = new List<ICurrencyProvider>();

    #endregion

    #endregion

    #region 唯一标识

    /// <summary>
    ///
    /// </summary>
    protected static IList<IGuidGeneratorProvider> GuidGenerators;

    #region 添加唯一标识提供者

    /// <summary>
    /// 添加唯一标识提供者
    /// </summary>
    /// <param name="GuidGenerators">提供者集合</param>
    protected virtual void AddGuidGeneratorProvider(params IGuidGeneratorProvider[] GuidGenerators)
    {
        if (GuidGenerators.GetListCount() == 0)
        {
            return;
        }

        var providers = GetGuidGenerators();
        providers.AddRange(GuidGenerators);
    }

    #endregion

    #region 得到指定唯一标识提供者集合

    /// <summary>
    /// 得到指定唯一标识提供者集合
    /// </summary>
    /// <returns></returns>
    public List<IGuidGeneratorProvider> GetGuidGenerators() => GuidGenerators?.ToList() ?? new List<IGuidGeneratorProvider>();

    #endregion

    #region 得到指定唯一标识提供者

    /// <summary>
    /// 得到指定唯一标识提供者
    /// </summary>
    /// <param name="type">唯一标识类型</param>
    /// <returns></returns>
    public IGuidGeneratorProvider GetGuidGeneratorProvider(int type) => GetGuidGenerators().FirstOrDefault(x => x.Type == type);

    /// <summary>
    /// 得到唯一标识提供者
    /// </summary>
    /// <param name="sequentialGuidType">唯一标识类型</param>
    /// <returns></returns>
    public IGuidGeneratorProvider GetGuidGeneratorProvider(SequentialGuidType sequentialGuidType) => GetGuidGeneratorProvider(sequentialGuidType.Id);

    #endregion

    #region 重置唯一标识提供者为初始状态

    /// <summary>
    /// 重置唯一标识提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetGuidGeneratorProviders() => GuidGenerators = new List<IGuidGeneratorProvider>()
        {
            new GuidProvider()
        };

    #endregion

    #region 清空唯一标识提供者

    /// <summary>
    /// 清空唯一标识提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearGuidGeneratorProviders() => GuidGenerators = new List<IGuidGeneratorProvider>();

    #endregion

    #endregion

    #region 身份证身份提供者

    /// <summary>
    ///
    /// </summary>
    protected static IList<IIdCardProvider> IdCardProviders;

    #region 添加身份证身份提供者

    /// <summary>
    /// 添加身份证身份提供者
    /// </summary>
    /// <param name="idCardProviders">提供者集合</param>
    protected virtual void AddIdCardProvider(params IIdCardProvider[] idCardProviders)
    {
        if (idCardProviders.GetListCount() == 0)
        {
            return;
        }

        var providers = GetIdCardProviders();
        providers.AddRange(idCardProviders);
    }

    #endregion

    #region 得到指定身份证身份提供者集合

    /// <summary>
    /// 得到指定身份证身份提供者集合
    /// </summary>
    /// <returns></returns>
    public List<IIdCardProvider> GetIdCardProviders() => IdCardProviders?.ToList() ?? new List<IIdCardProvider>();

    #endregion

    #region 得到指定身份证身份提供者

    /// <summary>
    /// 得到指定身份证身份提供者
    /// </summary>
    /// <param name="nationality">国家</param>
    /// <returns></returns>
    public IIdCardProvider GetIdCardProvider(int nationality) => GetIdCardProviders().FirstOrDefault(x => x.Nationality == nationality);

    /// <summary>
    /// 得到身份证身份提供者
    /// </summary>
    /// <param name="nationality">国家</param>
    /// <returns></returns>
    public IIdCardProvider GetIdCardProvider(Nationality nationality) => GetIdCardProvider((int)nationality);

    #endregion

    #region 重置身份证身份提供者为初始状态

    /// <summary>
    /// 重置身份证身份提供者为初始状态
    /// </summary>
    /// <returns></returns>
    protected virtual void ResetIdCardProviders() => IdCardProviders = new List<IIdCardProvider>()
        {
            new ChinaIdCardProvider(),
        };

    #endregion

    #region 清空身份证身份提供者

    /// <summary>
    /// 清空身份证身份提供者
    /// </summary>
    /// <returns></returns>
    protected virtual void ClearIdCardProviders() => IdCardProviders = new List<IIdCardProvider>();

    #endregion

    #endregion
}
