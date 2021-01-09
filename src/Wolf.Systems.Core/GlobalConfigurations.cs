// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;
using System.Linq;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Core.Internal.Security;
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
        public static GlobalConfigurations Instance = new GlobalConfigurations();

        /// <summary>
        ///
        /// </summary>
        static GlobalConfigurations()
        {
            Instance.ResetSecurityProviders();
        }

        #region 安全加密

        /// <summary>
        ///
        /// </summary>
        private static IList<SecurityProvider> _securityProviders;

        #region 添加加密提供者集合

        /// <summary>
        /// 添加加密提供者集合
        /// </summary>
        /// <param name="securityProviders">加密提供者集合</param>
        protected void AddSecurityProvider(params SecurityProvider[] securityProviders)
        {
            if (securityProviders == null || securityProviders.Length == 0)
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
        public List<SecurityProvider> GetSecurityProviders()
        {
            return _securityProviders?.ToList() ?? new List<SecurityProvider>();
        }

        #endregion

        #region 得到加密提供者

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="securityType">加密方式</param>
        /// <returns></returns>
        public SecurityProvider GetSecurityProvider(int securityType)
        {
            return GetSecurityProviders().FirstOrDefault(x => x.Type == securityType);
        }

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="securityType">加密方式</param>
        /// <returns></returns>
        public SecurityProvider GetSecurityProvider(SecurityType securityType)
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
            _securityProviders = new List<SecurityProvider>()
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
            _securityProviders = new List<SecurityProvider>();
        }

        #endregion

        #endregion

        #region 星期N

        /// <summary>
        ///
        /// </summary>
        private static IList<WeekProvider> _weekProviders;

        #region 添加加密提供者集合

        /// <summary>
        /// 添加加密提供者集合
        /// </summary>
        /// <param name="securityProviders">加密提供者集合</param>
        protected void AddWeekProvider(params SecurityProvider[] securityProviders)
        {
            if (securityProviders == null || securityProviders.Length == 0)
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
        public List<WeekProvider> GetWeekProviders()
        {
            return _weekProviders?.ToList() ?? new List<WeekProvider>();
        }

        #endregion

        #region 得到加密提供者

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="nationality">国家</param>
        /// <returns></returns>
        public WeekProvider GetWeekProvider(int nationality)
        {
            return GetWeekProviders().FirstOrDefault(x => x.Nationality == nationality);
        }

        /// <summary>
        /// 得到加密提供者
        /// </summary>
        /// <param name="nationality">国家</param>
        /// <returns></returns>
        public WeekProvider GetWeekProvider(Nationality nationality)
        {
            return GetWeekProvider((int) nationality);
        }

        #endregion

        #region 重置加密提供者为初始状态

        /// <summary>
        /// 重置加密提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected void ResetWeekProviders()
        {
            _weekProviders = new List<WeekProvider>()
            {
                new Wolf.Systems.Core.Internal.Week.ChinaProvider()
            };
        }

        #endregion

        #region 清空加密提供者

        /// <summary>
        /// 清空加密提供者
        /// </summary>
        /// <returns></returns>
        protected void ClearWeekProviders()
        {
            _weekProviders = new List<WeekProvider>();
        }

        #endregion

        #endregion
    }
}
