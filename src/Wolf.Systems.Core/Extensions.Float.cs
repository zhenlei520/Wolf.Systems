// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core
{
    /// <summary>
    /// Float扩展
    /// </summary>
    public partial class Extensions
    {
        #region Abs(返回数字的绝对值)

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="dec">值</param>
        public static float Abs(this float dec) => Math.Abs(dec);

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="dec">值</param>
        public static IEnumerable<float> Abs(this IEnumerable<float> dec) => dec.Select(x => x.Abs());

        #endregion

        #region 保留指定位数(默认四舍五入)

        /// <summary>
        /// 保留指定位数(默认四舍五入)
        /// </summary>
        /// <param name="param">值</param>
        /// <param name="num">保留位数</param>
        /// <param name="midpointRounding">默认正常的四舍五入</param>
        /// <returns></returns>
        public static string ToFixed(this float param, int num,
            MidpointRounding midpointRounding = MidpointRounding.AwayFromZero) => Math.Round(param, num, midpointRounding).ConvertToFloat(0).ToString("0." + Const.Empty.RepairZero(num));

        #endregion

        #region 判断精度是否正确

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this float str, int maxScale) => str.ToString(CultureInfo.InvariantCulture).IsMaxScale(maxScale);

        #endregion
    }
}
