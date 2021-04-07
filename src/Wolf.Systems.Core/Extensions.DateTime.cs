// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wolf.Systems.Core.Common;
using Wolf.Systems.Core.Internal.Configuration;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public partial class Extensions
    {
        #region 获得两个日期的间隔

        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="dateTime1">日期一(较大一点的时间)。</param>
        /// <param name="dateTime2">日期二(较小一点的时间)。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public static TimeSpan DateDiff(this DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1 - dateTime2;
        }

        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="dateTime1">日期一(较大一点的时间)。</param>
        /// <param name="dateTime2">日期二(较小一点的时间)。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public static TimeSpan DateDiff(this DateTimeOffset dateTime1, DateTimeOffset dateTime2)
        {
            return dateTime1 - dateTime2;
        }

        #endregion

        #region 格式化日期时间

        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(this DateTime dateTime, FormatDateType dateMode = FormatDateType.Full)
        {
            if (!((int) dateMode).IsExist<FormatDateType>())
            {
                throw new BusinessException("unsupported mode", ErrorCode.ParamError);
            }

            return dateTime.ToString(dateMode.GetDescription());
        }

        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(this DateTimeOffset dateTime, FormatDateType dateMode = FormatDateType.Full)
        {
            return dateTime.Date.FormatDate(dateMode);
        }

        #endregion

        #region 得到随机日期

        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTime GetRandomTime(this DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime;

            var ts = new TimeSpan(time1.Ticks - time2.Ticks);

            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds;

            if (dTotalSecontds > int.MaxValue)
            {
                iTotalSecontds = int.MaxValue;
            }
            else if (dTotalSecontds < int.MinValue)
            {
                iTotalSecontds = int.MinValue;
            }
            else
            {
                iTotalSecontds = (int) dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= int.MinValue)
                maxValue = int.MinValue + 1;

            int i = random.Next(Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }

        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTimeOffset GetRandomTime(this DateTimeOffset time1, DateTimeOffset time2)
        {
            Random random = new Random();
            DateTimeOffset minTime;

            var ts = new TimeSpan(time1.Ticks - time2.Ticks);

            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds;

            if (dTotalSecontds > int.MaxValue)
            {
                iTotalSecontds = int.MaxValue;
            }
            else if (dTotalSecontds < int.MinValue)
            {
                iTotalSecontds = int.MinValue;
            }
            else
            {
                iTotalSecontds = (int) dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= int.MinValue)
                maxValue = int.MinValue + 1;

            int i = random.Next(Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }

        #endregion

        #region 得到月初/月末/本周一/本周日/本季初/本季末/年初/年末时间

        /// <summary>
        /// 得到月初/月末/本周一/本周日/本季初/本季末/年初/年末时间
        /// </summary>
        /// <param name="dateTime">指定时间，如果为null，则默认当前时间</param>
        /// <param name="timeKey">时间Key</param>
        /// <returns></returns>
        public static DateTime Get(this DateTime? dateTime, TimeType timeKey)
        {
            return (dateTime ?? DateTime.Now).Get(timeKey);
        }

        /// <summary>
        /// 得到月初/月末/本周一/本周日/本季初/本季末/年初/年末时间
        /// </summary>
        /// <param name="dateTime">指定时间，如果为null，则默认当前时间</param>
        /// <param name="timeKey">时间Key</param>
        /// <returns></returns>
        public static DateTimeOffset Get(this DateTimeOffset? dateTime, TimeType timeKey)
        {
            return (dateTime ?? DateTimeOffset.Now).Get(timeKey);
        }

        /// <summary>
        /// 得到月初/月末/本周一/本周日/本季初/本季末/年初/年末时间
        /// </summary>
        /// <param name="dateTime">指定时间</param>
        /// <param name="timeKey">时间Key</param>
        /// <returns></returns>
        public static DateTime Get(this DateTime dateTime, TimeType timeKey)
        {
            var provider = GlobalConfigurations.Instance.GetDateTimeProvider(timeKey);
            return provider?.GetResult(dateTime) ?? throw new BusinessException("unsupported timeType");
        }

        /// <summary>
        /// 得到月初/月末/本周一/本周日/本季初/本季末/年初/年末时间
        /// </summary>
        /// <param name="dateTime">指定时间</param>
        /// <param name="timeKey">时间Key</param>
        /// <returns></returns>
        public static DateTimeOffset Get(this DateTimeOffset dateTime, TimeType timeKey)
        {
            return dateTime.DateTime.Get(timeKey);
        }

        #endregion

        #region 得到指定的时间后

        /// <summary>
        /// 得到指定的时间后
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="timeUnit">时间类型</param>
        /// <param name="duration">时长，允许为负数,为正时：指定时间后持续时间，为负时：指定时间前持续时间</param>
        /// <returns></returns>
        public static DateTime GetSpecifiedTimeAfter(this DateTime dateTime, TimeUnit timeUnit, int duration)
        {
            var provider = GlobalConfigurations.Instance.GetSpecifiedTimeAfterProvider(timeUnit);
            return provider?.GetResult(dateTime, duration) ?? throw new BusinessException("unsupported timeUnit");
        }

        /// <summary>
        /// 得到指定的时间后
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="timeType">时间类型</param>
        /// <param name="duration">时长，允许为负数,为正时：指定时间后持续时间，为负时：指定时间前持续时间</param>
        /// <returns></returns>
        public static DateTime GetSpecifiedTimeAfter(this DateTime? dateTime, TimeUnit timeType, int duration)
        {
            return (dateTime ?? DateTime.Now).GetSpecifiedTimeAfter(timeType, duration);
        }

        /// <summary>
        /// 得到指定的时间后
        /// </summary>
        /// <param name="dateTimeOffset">时间</param>
        /// <param name="timeUnit">时间类型</param>
        /// <param name="duration">时长，允许为负数,为正时：指定时间后持续时间，为负时：指定时间前持续时间</param>
        /// <returns></returns>
        public static DateTimeOffset GetSpecifiedTimeAfter(this DateTimeOffset? dateTimeOffset, TimeUnit timeUnit,
            int duration)
        {
            return (dateTimeOffset ?? DateTimeOffset.Now).GetSpecifiedTimeAfter(timeUnit, duration);
        }

        /// <summary>
        /// 得到指定的时间后
        /// </summary>
        /// <param name="dateTimeOffset">时间</param>
        /// <param name="timeUnit">时间类型</param>
        /// <param name="duration">时长，允许为负数,为正时：指定时间后持续时间，为负时：指定时间前持续时间</param>
        /// <returns></returns>
        public static DateTimeOffset GetSpecifiedTimeAfter(this DateTimeOffset dateTimeOffset, TimeUnit timeUnit,
            int duration)
        {
            var provider = GlobalConfigurations.Instance.GetSpecifiedTimeAfterProvider(timeUnit);
            return provider?.GetResult(dateTimeOffset, duration) ?? throw new BusinessException("unsupported timeUnit");
        }

        #endregion

        #region 转换为DateTimeOffset

        /// <summary>
        /// 转换为DateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset ConvertToDateTimeOffset(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime
                ? DateTimeOffset.MinValue
                : new DateTimeOffset(dateTime);
        }

        /// <summary>
        /// 转换为DateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset ConvertToDateTimeOffset(this DateTime? dateTime)
        {
            return (dateTime ?? DateTime.Now).ConvertToDateTimeOffset();
        }

        /// <summary>
        /// 转换为DateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="defaultDateTimeOffset">默认值</param>
        /// <returns></returns>
        public static DateTimeOffset ConvertToDateTimeOffset(this DateTime? dateTime,
            DateTimeOffset defaultDateTimeOffset)
        {
            return dateTime ?? defaultDateTimeOffset;
        }

        /// <summary>
        /// 转换为DateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="defaultDateTimeOffset">默认值</param>
        /// <returns></returns>
        public static DateTimeOffset? ConvertToDateTimeOffset(this DateTime? dateTime,
            DateTimeOffset? defaultDateTimeOffset)
        {
            return dateTime ?? defaultDateTimeOffset;
        }

        #endregion

        #region 得到距离当前多远时间

        /// <summary>
        /// 得到两个时间间隔差多远
        /// </summary>
        /// <param name="dateTime1">日期一(较大一点的时间)。</param>
        /// <param name="dateTime2">日期二(较小一点的时间)。</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetAccordingToCurrent(this DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan span = DateDiff(dateTime1, dateTime2);
            if (span == null)
            {
                throw new ArgumentNullException(nameof(span));
            }

            if (span.TotalSeconds < 60)
            {
                return "刚刚";
            }

            if (span.TotalMinutes < 60)
            {
                return Math.Ceiling(span.TotalMinutes) + "分钟之前";
            }

            if (span.TotalHours < 24)
            {
                return Math.Ceiling(span.TotalHours) + "小时之内";
            }

            if (span.TotalDays < 7)
            {
                return Math.Ceiling(span.TotalDays) + "天之内";
            }

            if (span.TotalDays < 30)
            {
                return Math.Ceiling(span.TotalDays / 7) + "周之内";
            }

            if (span.TotalDays < 180)
            {
                return Math.Ceiling(span.TotalDays / 30) + "月之内";
            }

            return Math.Ceiling(span.TotalDays / 360) + "年之内";
        }

        /// <summary>
        /// 得到两个时间间隔差多远
        /// </summary>
        /// <param name="dateTime1">日期一(较大一点的时间)。</param>
        /// <param name="dateTime2">日期二(较小一点的时间)。</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetAccordingToCurrent(this DateTimeOffset dateTime1, DateTimeOffset dateTime2)
        {
            TimeSpan span = DateDiff(dateTime1, dateTime2);
            if (span == null)
            {
                throw new ArgumentNullException(nameof(span));
            }

            if (span.TotalSeconds < 60)
            {
                return "刚刚";
            }

            if (span.TotalMinutes < 60)
            {
                return Math.Ceiling(span.TotalMinutes) + "分钟之前";
            }

            if (span.TotalHours < 24)
            {
                return Math.Ceiling(span.TotalHours) + "小时之内";
            }

            if (span.TotalDays < 7)
            {
                return Math.Ceiling(span.TotalDays) + "天之内";
            }

            if (span.TotalDays < 30)
            {
                return Math.Ceiling(span.TotalDays / 7) + "周之内";
            }

            if (span.TotalDays < 180)
            {
                return Math.Ceiling(span.TotalDays / 30) + "月之内";
            }

            return Math.Ceiling(span.TotalDays / 360) + "年之内";
        }

        /// <summary>
        /// 得到据当前多远时间
        /// </summary>
        /// <param name="date">较小一点的时间</param>
        /// <returns></returns>
        public static string GetAccordingToCurrent(this DateTime date)
        {
            return DateTime.Now.GetAccordingToCurrent(date);
        }

        /// <summary>
        /// 得到据当前多远时间
        /// </summary>
        /// <param name="date">较小一点的时间</param>
        /// <returns></returns>
        public static string GetAccordingToCurrent(this DateTimeOffset date)
        {
            return DateTimeOffset.Now.GetAccordingToCurrent(date);
        }

        /// <summary>
        /// 得到据当前多远时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetAccordingToCurrent(this DateTime? date)
        {
            if (date == null)
                return "未知";
            return GetAccordingToCurrent((DateTime) date);
        }

        /// <summary>
        /// 得到据当前多远时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetAccordingToCurrent(this DateTimeOffset? date)
        {
            if (date == null)
                return "未知";
            return GetAccordingToCurrent((DateTimeOffset) date);
        }

        #endregion

        #region 阳历转阴历(农历)

        #region 农历信息获取

        private static readonly string[] Jq =
        {
            "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分",
            "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
        };

        private static readonly int[] JqData =
        {
            0, 21208, 43467, 63836, 85337, 107014, 128867, 150921, 173149, 195551, 218072, 240693, 263343, 285989,
            308563, 331033, 353350, 375494, 397447, 419210, 440795, 462224, 483532, 504758
        };

        #endregion

        #region 获取农历年份

        /// <summary>
        /// 获取农历年份
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetYear(this DateTime dateTime)
        {
            int yearIndex = GlobalConfigurations.ChineseCalendar.GetSexagenaryYear(dateTime);
            string yearTG = " 甲乙丙丁戊己庚辛壬癸";
            string yearDZ = " 子丑寅卯辰巳午未申酉戌亥";
            string yearSX = " 鼠牛虎兔龙蛇马羊猴鸡狗猪";
            int year = GlobalConfigurations.ChineseCalendar.GetYear(dateTime);
            int yTg = GlobalConfigurations.ChineseCalendar.GetCelestialStem(yearIndex);
            int yDz = GlobalConfigurations.ChineseCalendar.GetTerrestrialBranch(yearIndex);

            string str = string.Format("[{1}]{2}{3}{0}", year, yearSX[yDz], yearTG[yTg], yearDZ[yDz]);
            return str;
        }

        /// <summary>
        /// 获取农历年份
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static string GetYear(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime.GetYear();
        }

        #endregion

        #region 获取农历月份

        /// <summary>
        /// 获取农历月份
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetMonth(this DateTime dateTime)
        {
            int year = GlobalConfigurations.ChineseCalendar.GetYear(dateTime);
            int iMonth = GlobalConfigurations.ChineseCalendar.GetMonth(dateTime);
            int leapMonth = GlobalConfigurations.ChineseCalendar.GetLeapMonth(year);
            bool isLeapMonth = iMonth == leapMonth;
            if (leapMonth != 0 && iMonth >= leapMonth)
            {
                iMonth--;
            }

            string szText = "正二三四五六七八九十";
            StringBuilder stringBuilder = new StringBuilder(isLeapMonth ? "闰" : "");
            if (iMonth <= 10)
            {
                stringBuilder.Append(szText.Substring(iMonth - 1, 1));
            }
            else if (iMonth == 11)
            {
                stringBuilder.Append("十一");
            }
            else
            {
                stringBuilder.Append("腊");
            }

            return stringBuilder.Append("月").ToString();
        }

        /// <summary>
        /// 获取农历月份
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static string GetMonth(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime.GetMonth();
        }

        #endregion

        #region 获取农历日期

        /// <summary>
        /// 获取农历日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetDay(this DateTime dateTime)
        {
            int iDay = GlobalConfigurations.ChineseCalendar.GetDayOfMonth(dateTime);
            string szText1 = "初十廿三";
            string szText2 = "一二三四五六七八九十";
            string strDay;
            if (iDay == 20)
            {
                strDay = "二十";
            }
            else if (iDay == 30)
            {
                strDay = "三十";
            }
            else
            {
                strDay = szText1.Substring((iDay - 1) / 10, 1);
                strDay = strDay + szText2.Substring((iDay - 1) % 10, 1);
            }

            return strDay;
        }

        /// <summary>
        /// 获取农历日期
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static string GetDay(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime.GetDay();
        }

        #endregion

        #region 获取节气

        /// <summary>
        /// 获取节气
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetSolarTerm(this DateTime dateTime)
        {
            DateTime dtBase = new DateTime(1900, 1, 6, 2, 5, 0);
            string strReturn = "";

            var y = dateTime.Year;
            for (int i = 1; i <= 24; i++)
            {
                var num = 525948.76 * (y - 1900) + JqData[i - 1];
                var dtNew = dtBase.AddMinutes(num);
                if (dtNew.DayOfYear == dateTime.DayOfYear)
                {
                    strReturn = Jq[i - 1];
                }
            }

            return strReturn;
        }

        /// <summary>
        /// 获取节气
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static string GetSolarTerm(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime.GetSolarTerm();
        }

        #endregion

        #region 阴历-阳历-转换

        #region 阴历转阳历

        /// <summary>
        /// 阴历转阳历
        /// </summary>
        /// <param name="dateTime">阴历日期</param>
        public static DateTime GetLunarYearDate(this DateTime dateTime)
        {
            return TimeCommon.GetLunarYearDate(dateTime.Year, dateTime.Month, dateTime.Day,
                TimeCommon.IsLeapYear(dateTime.Year));
        }

        /// <summary>
        /// 阴历转阳历
        /// </summary>
        /// <param name="dateTimeOffset">阴历日期</param>
        public static DateTime GetLunarYearDate(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime.GetLunarYearDate();
        }

        #endregion

        #region 阳历转为阴历

        /// <summary>
        /// 阳历转为阴历
        /// </summary>
        /// <param name="dateTime">公历日期</param>
        /// <returns>农历的日期</returns>
        public static DateTime GetSunYearDate(this DateTime dateTime)
        {
            int year = GlobalConfigurations.ChineseCalendar.GetYear(dateTime);
            int iMonth = GlobalConfigurations.ChineseCalendar.GetMonth(dateTime);
            int iDay = GlobalConfigurations.ChineseCalendar.GetDayOfMonth(dateTime);
            int leapMonth = GlobalConfigurations.ChineseCalendar.GetLeapMonth(year);
            if (leapMonth != 0 && iMonth >= leapMonth)
            {
                iMonth--;
            }

            string str = $"{year}-{iMonth}-{iDay}";
            DateTime dtNew = DateTime.Now;
            try
            {
                dtNew = Convert.ToDateTime(str); //防止出现2月份时，会出现超过时间，出现“2015-02-30”这种错误日期
            }
            catch
            {
                // ignored
            }

            return dtNew;
        }

        /// <summary>
        /// 阳历转为阴历
        /// </summary>
        /// <param name="dateTimeOffset">公历日期</param>
        /// <returns>农历的日期</returns>
        public static DateTime GetSunYearDate(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime.GetSunYearDate();
        }

        #endregion

        #endregion

        #endregion

        #region 生成时间戳

        /// <summary>
        /// 生成时间戳
        /// </summary>
        /// <param name="target">待转换的时间</param>
        /// <param name="timestampType">时间戳类型：10位或者13位</param>
        /// <param name="dateTimeKind"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime target, TimestampType timestampType,
            DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            if (timestampType == TimestampType.MilliSecond)
            {
                return (TimeZoneInfo.ConvertTimeToUtc(target).Ticks - TimeZoneInfo
                           .ConvertTimeToUtc(new DateTime(1970, 1, 1, 0, 0, 0, 0, dateTimeKind)).Ticks) /
                       10000; //除10000调整为13位
            }

            if (timestampType == TimestampType.Second)
            {
                return (long) (TimeZoneInfo.ConvertTimeToUtc(target) - new DateTime(1970, 1, 1, 0, 0, 0, dateTimeKind))
                    .TotalSeconds;
            }

            throw new BusinessException("不支持的类型", ErrorCode.ParamError);
        }

        /// <summary>
        /// 生成时间戳
        /// </summary>
        /// <param name="target">待转换的时间</param>
        /// <param name="timestampType">时间戳类型：10位或者13位</param>
        /// <param name="dateTimeKind"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTimeOffset target, TimestampType timestampType,
            DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            return target.DateTime.ToUnixTimestamp(timestampType, dateTimeKind);
        }

        #endregion

        #region 得到dateTime是当月的第几周

        /// <summary>
        /// 得到dateTime是当月的第几周，如果习惯周一到周日为一周，则nationality传Nationality.China
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="nationality">国家，默认为中国</param>
        /// <returns></returns>
        public static int GetWeekIndexOfMonth(this DateTime dateTime, Nationality nationality = Nationality.China)
        {
            int i = dateTime.GetDayOfWeek(Nationality.China);
            if (nationality.Equals(Nationality.China))
            {
                return (dateTime.Date.Day + i - 2) / 7 + 1;
            }

            return (dateTime.Date.Day + i - 1) / 7;
        }

        /// <summary>
        /// 得到dateTime是当月的第几周，如果习惯周一到周日为一周，则nationality传Nationality.China
        /// </summary>
        /// <param name="dateTimeOffset">时间</param>
        /// <param name="nationality">国家，默认为中国</param>
        /// <returns></returns>
        public static int GetWeekIndexOfMonth(this DateTimeOffset dateTimeOffset,
            Nationality nationality = Nationality.China)
        {
            return dateTimeOffset.DateTime.GetWeekIndexOfMonth(nationality);
        }

        #endregion

        #region 获取当前是周几(中国时间)

        /// <summary>
        /// 获取当前是周几(中国时间)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="nationality">国家，默认为中国</param>
        /// <returns></returns>
        public static string GetDayName(this DateTime dateTime, Nationality nationality = Nationality.China)
        {
            var dayOfWeek = dateTime.GetDayOfWeek(nationality);
            return GlobalConfigurations.Instance.GetWeekProvider(nationality).GetName(dayOfWeek);
        }

        /// <summary>
        /// 获取当前是周几(中国时间)
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <param name="nationality">国家，默认为中国</param>
        /// <returns></returns>
        public static string GetDayName(this DateTimeOffset dateTimeOffset, Nationality nationality = Nationality.China)
        {
            return dateTimeOffset.DateTime.GetDayName(nationality);
        }

        #endregion

        #region 根据日期得到序号，支持国家

        /// <summary>
        /// 根据日期得到序号，支持国家
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="nationality">国家，默认中国等</param>
        /// <returns></returns>
        public static int GetDayOfWeek(this DateTime dateTime, Nationality nationality = Nationality.China)
        {
            return dateTime.DayOfWeek.GetDayOfWeek(nationality);
        }

        /// <summary>
        /// 根据日期得到序号，支持国家
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dateTimeOffset">时间</param>
        /// <param name="nationality">国家，默认中国等</param>
        /// <returns></returns>
        public static int GetDayOfWeek(this DateTimeOffset dateTimeOffset, Nationality nationality = Nationality.China)
        {
            return dateTimeOffset.DateTime.GetDayOfWeek(nationality);
        }

        /// <summary>
        /// 根据DayOfWeek得到序号，支持国家
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="nationality">国家,默认是中国</param>
        /// <returns></returns>
        public static int GetDayOfWeek(this DayOfWeek dayOfWeek, Nationality nationality = Nationality.China)
        {
            int? num = dayOfWeek.ToString("d").ConvertToInt();
            if (num == null)
            {
                throw new NotSupportedException(nameof(dayOfWeek));
            }

            if (nationality==Nationality.China)
            {
                if (num == 0)
                {
                    return 7;
                }
            }

            return num.Value;
        }

        #endregion

        #region 判断是同一年

        /// <summary>
        /// 判断是同一年
        /// </summary>
        /// <param name="dateTime">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static bool IsInSameYear(this DateTime dateTime, DateTime dateTime2)
        {
            return dateTime.Year == dateTime2.Year;
        }

        /// <summary>
        /// 判断是同一年
        /// </summary>
        /// <param name="dateTimeOffset1">时间1</param>
        /// <param name="dateTimeOffset2">时间2</param>
        /// <returns></returns>
        public static bool IsInSameYear(this DateTimeOffset dateTimeOffset1, DateTimeOffset dateTimeOffset2)
        {
            return dateTimeOffset1.Year == dateTimeOffset2.Year;
        }

        #endregion

        #region 判断是同一年的同一月

        /// <summary>
        /// 判断是同一年的同一月
        /// </summary>
        /// <param name="dateTime">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <returns></returns>
        public static bool IsInSameMonth(this DateTime dateTime, DateTime dateTime2)
        {
            return dateTime.Year == dateTime2.Year && dateTime.Month == dateTime2.Month;
        }

        /// <summary>
        /// 判断是同一年的同一月
        /// </summary>
        /// <param name="dateTimeOffset1">时间1</param>
        /// <param name="dateTimeOffset2">时间2</param>
        /// <returns></returns>
        public static bool IsInSameMonth(this DateTimeOffset dateTimeOffset1, DateTimeOffset dateTimeOffset2)
        {
            return dateTimeOffset1.Year == dateTimeOffset2.Year && dateTimeOffset1.Month == dateTimeOffset2.Month;
        }

        #endregion

        #region 判断是同一年的同一月的同一周

        /// <summary>
        /// 判断是同一年的同一月的同一周
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dateTime">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <param name="nationality">国家,默认是中国</param>
        /// <returns></returns>
        public static bool IsInSameWeek(this DateTime dateTime, DateTime dateTime2,
            Nationality nationality = Nationality.China)
        {
            return dateTime.AddDays(-(int) dateTime.GetDayOfWeek(nationality)).Date ==
                   dateTime2.AddDays(-(int) dateTime2.GetDayOfWeek(nationality)).Date;
        }

        /// <summary>
        /// 判断是同一年的同一月的同一周
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dateTimeOffset1">时间1</param>
        /// <param name="dateTimeOffset2">时间2</param>
        /// <param name="nationality">国家,默认是中国</param>
        /// <returns></returns>
        public static bool IsInSameWeek(this DateTimeOffset dateTimeOffset1, DateTimeOffset dateTimeOffset2,
            Nationality nationality = Nationality.China)
        {
            return dateTimeOffset1.AddDays(-(int) dateTimeOffset1.GetDayOfWeek(nationality)).Date ==
                   dateTimeOffset2.AddDays(-(int) dateTimeOffset2.GetDayOfWeek(nationality)).Date;
        }

        #endregion

        #region 得到间隔周数

        /// <summary>
        /// 得到间隔周数
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dateTime">时间1</param>
        /// <param name="dateTime2">时间2</param>
        /// <param name="nationality">国家,默认是中国</param>
        /// <returns></returns>
        public static int IntervalWeek(this DateTime dateTime, DateTime dateTime2,
            Nationality nationality = Nationality.China)
        {
            var intervalWeek = Math.Abs((dateTime.AddDays(-(int) dateTime.GetDayOfWeek(nationality)).Date -
                                         dateTime2.AddDays(-(int) dateTime2.GetDayOfWeek(nationality))).TotalDays / 7);
            return intervalWeek.ConvertToInt(0);
        }

        /// <summary>
        /// 得到间隔周数
        /// 目前除中国外，周一是1，周日是7
        /// 其他国家为：周日是0，周六是7
        /// </summary>
        /// <param name="dateTimeOffset1">时间1</param>
        /// <param name="dateTimeOffset2">时间2</param>
        /// <param name="nationality">国家,默认是中国</param>
        /// <returns></returns>
        public static int IntervalWeek(this DateTimeOffset dateTimeOffset1, DateTimeOffset dateTimeOffset2,
            Nationality nationality = Nationality.China)
        {
            var intervalWeek = Math.Abs(
                (dateTimeOffset1.AddDays(-(int) dateTimeOffset1.GetDayOfWeek(nationality)).Date -
                 dateTimeOffset2.AddDays(-(int) dateTimeOffset2.GetDayOfWeek(nationality))).TotalDays / 7);
            return intervalWeek.ConvertToInt(0);
        }

        #endregion

        #region 根据日期得到星座信息

        /// <summary>
        /// 星座map
        /// </summary>
        private static readonly List<Constellations> ConstellationMaps = new List<Constellations>
        {
            new Constellations
            {
                Key = Constellation.Aquarius,
                Value = "水瓶座",
                MinTime = 1.20F,
                MaxTime = 2.19F
            },
            new Constellations
            {
                Key = Constellation.Pisces,
                Value = "双鱼座",
                MinTime = 2.19F,
                MaxTime = 3.21F
            },
            new Constellations
            {
                Key = Constellation.Aries,
                Value = "白羊座",
                MinTime = 3.21F,
                MaxTime = 4.20F
            },
            new Constellations
            {
                Key = Constellation.Taurus,
                Value = "金牛座",
                MinTime = 4.20F,
                MaxTime = 5.21F
            },
            new Constellations
            {
                Key = Constellation.Gemini,
                Value = "双子座",
                MinTime = 5.21F,
                MaxTime = 6.22F
            },
            new Constellations
            {
                Key = Constellation.Cancer,
                Value = "巨蟹座",
                MinTime = 6.22F,
                MaxTime = 7.23F
            },
            new Constellations
            {
                Key = Constellation.Leo,
                Value = "狮子座",
                MinTime = 7.23F,
                MaxTime = 8.23F
            },
            new Constellations
            {
                Key = Constellation.Virgo,
                Value = "处女座",
                MinTime = 8.23F,
                MaxTime = 9.23F
            },
            new Constellations
            {
                Key = Constellation.Libra,
                Value = "天秤座",
                MinTime = 9.23F,
                MaxTime = 10.24F
            },
            new Constellations
            {
                Key = Constellation.Scorpio,
                Value = "天蝎座",
                MinTime = 10.24F,
                MaxTime = 11.23F
            },
            new Constellations
            {
                Key = Constellation.Sagittarius,
                Value = "射手座",
                MinTime = 11.23F,
                MaxTime = 12.22F
            },
            new Constellations
            {
                Key = Constellation.Capricornus,
                Value = "魔羯座",
                MinTime = 12.22F,
                MaxTime = 12.32F
            },
            new Constellations
            {
                Key = Constellation.Capricornus,
                Value = "魔羯座",
                MinTime = 1.01F,
                MaxTime = 1.20F
            }
        };

        /// <summary>
        /// 根据日期得到星座信息
        /// </summary>
        /// <param name="birthday">日期</param>
        /// <returns></returns>
        public static Constellation? GetConstellationFromBirthday(this DateTime? birthday)
        {
            return birthday?.GetConstellationFromBirthday();
        }

        /// <summary>
        /// 根据日期得到星座信息
        /// </summary>
        /// <param name="dateTimeOffset">日期</param>
        /// <returns></returns>
        public static Constellation? GetConstellationFromBirthday(this DateTimeOffset? dateTimeOffset)
        {
            return dateTimeOffset?.GetConstellationFromBirthday();
        }

        /// <summary>
        /// 根据日期得到星座信息
        /// </summary>
        /// <param name="birthday">日期</param>
        /// <returns></returns>
        public static Constellation? GetConstellationFromBirthday(this DateTime birthday)
        {
            float fBirthDay = Convert.ToSingle(birthday.ToString("M.dd"));
            return ConstellationMaps.Where(x => fBirthDay >= x.MinTime && fBirthDay < x.MaxTime)
                .Select(x => x.Key).FirstOrDefault();
        }

        /// <summary>
        /// 根据日期得到星座信息
        /// </summary>
        /// <param name="dateTimeOffset">日期</param>
        /// <returns></returns>
        public static Constellation GetConstellationFromBirthday(this DateTimeOffset dateTimeOffset)
        {
            float fBirthDay = Convert.ToSingle(dateTimeOffset.ToString("M.dd"));
            return ConstellationMaps.Where(x => fBirthDay >= x.MinTime && fBirthDay < x.MaxTime)
                .Select(x => x.Key).FirstOrDefault();
        }

        #endregion
    }
}
