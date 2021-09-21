// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Wolf.Systems.Core.Internal.Configuration;
using Wolf.Systems.Enum;
using Wolf.Systems.Exceptions;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// Decimal扩展
    /// </summary>
    public partial class Extensions
    {
        #region 转换为货币

        /// <summary>
        /// 转换为货币
        /// </summary>
        /// <param name="dec">带转换的金额</param>
        /// <param name="currencyType">货币类型，默认人民币</param>
        /// <returns></returns>
        public static string ConvertToCurrency(this decimal dec, CurrencyType currencyType = CurrencyType.Cny)
        {
            var provider = GlobalConfigurations.Instance.GetCurrencyProvider(currencyType);
            return provider?.ConvertToCurrency(dec) ?? throw new BusinessException("暂不支持当前货币转换", ErrorCode.ParamError);
        }

        #endregion

        #region Abs(返回数字的绝对值)

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="dec">值</param>
        public static decimal Abs(this decimal dec) => Math.Abs(dec);

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="dec">值</param>
        public static IEnumerable<decimal> Abs(this IEnumerable<decimal> dec) => dec.Select(x => x.Abs());

        #endregion

        #region 保留指定位数(默认四舍五入)

        /// <summary>
        /// 保留指定位数(默认四舍五入)
        /// </summary>
        /// <param name="dec">值</param>
        /// <param name="num">保留位数</param>
        /// <param name="midpointRounding">默认正常的四舍五入</param>
        /// <returns></returns>
        public static string ToFixed(this decimal dec, int num,
            MidpointRounding midpointRounding = MidpointRounding.AwayFromZero)
        {
            dec = Math.Round(dec, num, midpointRounding);
            return dec.ToString("0." + Const.Empty.RepairZero(num));
        }

        #endregion

        #region 判断精度是否正确

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this decimal str, int maxScale) => str.ToString(CultureInfo.InvariantCulture).IsMaxScale(maxScale);

        #endregion
    }
}
