// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Core.Internal.Currency;
using Wolf.Systems.Core.Internal.DateTimes;
using Wolf.Systems.Core.Internal.Security;
using Wolf.Systems.Core.Internal.SpecifiedTimeAfter;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// 全局配置
    /// </summary>
    public class GlobalConfigurations
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly GlobalConfigurations Instance = new GlobalConfigurations();

        /// <summary>
        /// 中国日历
        /// </summary>
        internal static ChineseLunisolarCalendar ChineseCalendar;

        /// <summary>
        ///
        /// </summary>
        static GlobalConfigurations()
        {
            Instance.ResetSecurityProviders();
            ChineseCalendar = new ChineseLunisolarCalendar();
        }

        #region 安全加密

        /// <summary>
        ///
        /// </summary>
        private static IList<ISecurityProvider> _securityProviders;

        #region 添加加密提供者集合

        /// <summary>
        /// 添加加密提供者集合
        /// </summary>
        /// <param name="securityProviders">加密提供者集合</param>
        protected void AddSecurityProvider(params ISecurityProvider[] securityProviders)
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
        public List<ISecurityProvider> GetSecurityProviders()
        {
            return _securityProviders?.ToList() ?? new List<ISecurityProvider>();
        }

        #endregion

        #region 得到加密提供者

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="securityType">加密方式</param>
        /// <returns></returns>
        public ISecurityProvider GetSecurityProvider(int securityType)
        {
            return GetSecurityProviders().FirstOrDefault(x => x.Type == securityType);
        }

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="securityType">加密方式</param>
        /// <returns></returns>
        public ISecurityProvider GetSecurityProvider(SecurityType securityType)
        {
            return GetSecurityProvider((int) securityType);
        }

        #endregion

        #region 重置加密提供者为初始状态

        /// <summary>
        /// 重置加密提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected void ResetSecurityProviders()
        {
            _securityProviders = new List<ISecurityProvider>()
            {
                new AesProvider(),
                new DesProvider(),
                new JsAesProvider()
            };
        }

        #endregion

        #region 清空加密提供者

        /// <summary>
        /// 清空加密提供者
        /// </summary>
        /// <returns></returns>
        protected void ClearSecurityProviders()
        {
            _securityProviders = new List<ISecurityProvider>();
        }

        #endregion

        #endregion

        #region 星期N

        /// <summary>
        ///
        /// </summary>
        private static IList<IWeekProvider> _weekProviders;

        #region 添加星期提供者集合

        /// <summary>
        /// 添加星期提供者集合
        /// </summary>
        /// <param name="weekProviders">加密提供者集合</param>
        protected void AddWeekProvider(params IWeekProvider[] weekProviders)
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
        public List<IWeekProvider> GetWeekProviders()
        {
            return _weekProviders?.ToList() ?? new List<IWeekProvider>();
        }

        #endregion

        #region 得到星期提供者

        /// <summary>
        /// 得到星期提供者
        /// </summary>
        /// <param name="nationality">国家</param>
        /// <returns></returns>
        public IWeekProvider GetWeekProvider(int nationality)
        {
            return GetWeekProviders().FirstOrDefault(x => x.Nationality == nationality);
        }

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="nationality">国家</param>
        /// <returns></returns>
        public IWeekProvider GetWeekProvider(Nationality nationality)
        {
            return GetWeekProvider((int) nationality);
        }

        #endregion

        #region 重置星期提供者为初始状态

        /// <summary>
        /// 重置星期提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected void ResetWeekProviders()
        {
            _weekProviders = new List<IWeekProvider>()
            {
                new Wolf.Systems.Core.Internal.Week.ChinaWeekProvider()
            };
        }

        #endregion

        #region 清空星期提供者

        /// <summary>
        /// 清空星期提供者
        /// </summary>
        /// <returns></returns>
        protected void ClearWeekProviders()
        {
            _weekProviders = new List<IWeekProvider>();
        }

        #endregion

        #endregion

        #region 时间

        /// <summary>
        ///
        /// </summary>
        private static IList<IDateTimeProvider> _dateTimeProviders;

        #region 添加时间提供者集合

        /// <summary>
        /// 添加时间提供者集合
        /// </summary>
        /// <param name="dateTimeProviders">提供者集合</param>
        protected void AddDateTimeProvider(params IDateTimeProvider[] dateTimeProviders)
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
        public List<IDateTimeProvider> GetDateTimeProviders()
        {
            return _dateTimeProviders?.ToList() ?? new List<IDateTimeProvider>();
        }

        #endregion

        #region 得到时间提供者

        /// <summary>
        /// 得到时间提供者
        /// </summary>
        /// <param name="type">时间类型</param>
        /// <returns></returns>
        public IDateTimeProvider GetDateTimeProvider(int type)
        {
            return GetDateTimeProviders().FirstOrDefault(x => x.Type == type);
        }

        /// <summary>
        /// 得到时间提供者
        /// </summary>
        /// <param name="type">时间类型</param>
        /// <returns></returns>
        public IDateTimeProvider GetDateTimeProvider(TimeType type)
        {
            return GetDateTimeProvider((int) type);
        }

        #endregion

        #region 重置时间提供者为初始状态

        /// <summary>
        /// 重置时间提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected void ResetDateTimeProviders()
        {
            _dateTimeProviders = new List<IDateTimeProvider>()
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
        }

        #endregion

        #region 清空时间提供者

        /// <summary>
        /// 清空时间提供者
        /// </summary>
        /// <returns></returns>
        protected void ClearDateTimeProviders()
        {
            _dateTimeProviders = new List<IDateTimeProvider>();
        }

        #endregion

        #endregion

        #region 得到指定时间后

        /// <summary>
        ///
        /// </summary>
        private static IList<ISpecifiedTimeAfterProvider> _specifiedTimeAfterProviders;

        #region 添加提供者集合

        /// <summary>
        /// 添加提供者集合
        /// </summary>
        /// <param name="specifiedTimeAfterProviders">提供者集合</param>
        protected void AddDateTimeProvider(params ISpecifiedTimeAfterProvider[] specifiedTimeAfterProviders)
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
        public List<ISpecifiedTimeAfterProvider> GetSpecifiedTimeAfterProviders()
        {
            return _specifiedTimeAfterProviders?.ToList() ?? new List<ISpecifiedTimeAfterProvider>();
        }

        #endregion

        #region 得到指定时间提供者

        /// <summary>
        /// 得到指定时间提供者
        /// </summary>
        /// <param name="type">时间类型</param>
        /// <returns></returns>
        public ISpecifiedTimeAfterProvider GetSpecifiedTimeAfterProvider(int type)
        {
            return GetSpecifiedTimeAfterProviders().FirstOrDefault(x => x.Type == type);
        }

        /// <summary>
        /// 得到指定时间提供者
        /// </summary>
        /// <param name="type">时间类型</param>
        /// <returns></returns>
        public ISpecifiedTimeAfterProvider GetSpecifiedTimeAfterProvider(TimeUnit type)
        {
            return GetSpecifiedTimeAfterProvider((int) type);
        }

        #endregion

        #region 重置指定时间提供者为初始状态

        /// <summary>
        /// 重置指定时间提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected void ResetSpecifiedTimeAfterProviders()
        {
            _specifiedTimeAfterProviders = new List<ISpecifiedTimeAfterProvider>()
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
        }

        #endregion

        #region 清空指定时间提供者

        /// <summary>
        /// 清空指定时间提供者
        /// </summary>
        /// <returns></returns>
        protected void ClearSpecifiedTimeAfterProviders()
        {
            _specifiedTimeAfterProviders = new List<ISpecifiedTimeAfterProvider>();
        }

        #endregion

        #endregion

        #region 数字转货币

        /// <summary>
        ///
        /// </summary>
        private static IList<ICurrencyProvider> _currencyProviders;

        #region 添加货币转换器提供者

        /// <summary>
        /// 添加货币转换器提供者
        /// </summary>
        /// <param name="currencyProviders">提供者集合</param>
        protected void AddCurrencyProvider(params ICurrencyProvider[] currencyProviders)
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
        public List<ICurrencyProvider> GetCurrencyProviders()
        {
            return _currencyProviders?.ToList() ?? new List<ICurrencyProvider>();
        }

        #endregion

        #region 得到指定货币转换器提供者

        /// <summary>
        /// 得到指定货币转换器提供者
        /// </summary>
        /// <param name="type">时间类型</param>
        /// <returns></returns>
        public ICurrencyProvider GetCurrencyProvider(int type)
        {
            return GetCurrencyProviders().FirstOrDefault(x => x.CurrencyType == type);
        }

        /// <summary>
        /// 得到指定时间提供者
        /// </summary>
        /// <param name="currencyType">货币类型</param>
        /// <returns></returns>
        public ICurrencyProvider GetCurrencyProvider(CurrencyType currencyType)
        {
            return GetCurrencyProvider((int) currencyType);
        }

        #endregion

        #region 重置指定时间提供者为初始状态

        /// <summary>
        /// 重置指定时间提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected void ResetCurrencyProviders()
        {
            _currencyProviders = new List<ICurrencyProvider>()
            {
                new CnyCurrencyProvider(),
            };
        }

        #endregion

        #region 清空指定时间提供者

        /// <summary>
        /// 清空指定时间提供者
        /// </summary>
        /// <returns></returns>
        protected void ClearCurrencyProviders()
        {
            _currencyProviders = new List<ICurrencyProvider>();
        }

        #endregion

        #endregion
    }
}
