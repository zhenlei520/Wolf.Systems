// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Common
{
    /// <summary>
    /// Gps帮助类
    /// </summary>
    public class GpsCommon
    {
        #region 度分秒转度

        /// <summary>
        /// 度分秒转度
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        public static double DmsConvertToDegree(DmsResponse dms)
        {
            if (null != dms)
            {
                decimal decD = new decimal(dms.Degree);
                decimal decM = new decimal(dms.Minute);
                decimal decS = new decimal(dms.Second);
                decimal dec60 = new decimal(60.0);

                decimal decDDouble = decD + (decM / dec60) + (decS / dec60 / dec60);
                return decimal.ToDouble(decDDouble);
            }
            return 0;
        }

        #endregion

        #region 度转换为度分秒

        /// <summary>
        /// 度转换为度分秒
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DmsResponse DegreeConvertDms(double param)
        {
            decimal dec = new decimal(param);
            decimal dec60 = new decimal(60.0);
            DmsResponse cd = new DmsResponse
            {
                Degree = dec.ConvertToInt(0)
            };
            decimal min = decimal.Multiply(dec - new decimal(cd.Degree), dec60);
            cd.Minute = min.ConvertToInt(0);
            decimal sec = min - new decimal(cd.Minute);
            cd.Second = decimal.Multiply(sec, dec60).ConvertToDouble(0);
            return cd;
        }

        #endregion

        /// <summary>
        /// 度分秒响应信息
        /// </summary>
        public class DmsResponse
        {
            /// <summary>
            /// 度
            /// </summary>
            public int Degree { get; set; }

            /// <summary>
            /// 分
            /// </summary>
            public int Minute { get; set; }

            /// <summary>
            /// 秒
            /// </summary>
            public double Second { get; set; }
        }
    }
}