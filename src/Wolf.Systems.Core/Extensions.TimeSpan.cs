// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.ComponentModel;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// TimeSpan扩展信息
    /// </summary>
    public partial class Extensions
    {
        #region 格式化时间

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <param name="timeSpanFormatDateType">显示模式，默认：{0}天{1}小时{2}分钟{3}秒</param>
        /// <returns></returns>
        public static string FormatDate(this TimeSpan timeSpan,
            TimeSpanFormatDateType timeSpanFormatDateType = TimeSpanFormatDateType.Second)
        {
            if (!((int) timeSpanFormatDateType).IsExist<TimeSpanFormatDateType>())
            {
                throw new BusinessException("不支持的类型", ErrorCode.ParamError);
            }

            string name = timeSpanFormatDateType.GetCustomerObj<EDescribeAttribute>()?.Describe.SafeString();
            if (timeSpanFormatDateType == TimeSpanFormatDateType.Minutes)
            {
                return string.Format(name, timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
            }
            else if (timeSpanFormatDateType == TimeSpanFormatDateType.Second)
            {
                return string.Format(name, timeSpan.Days, timeSpan.Hours, timeSpan.Minutes,
                    timeSpan.Seconds);
            }
            else
            {
                return string.Format(name, timeSpan.Days, timeSpan.Hours, timeSpan.Minutes,
                    timeSpan.Seconds,timeSpan.Milliseconds);
            }
        }

        #endregion

        #region 得到当前多远时间

        /// <summary>
        /// 得到当前多远时间
        /// </summary>
        /// <param name="span">时间间隔</param>
        /// <returns></returns>
        public static string GetAccordingToCurrent(this TimeSpan span)
        {
            if (span == null)
            {
                throw new ArgumentNullException(nameof(span));
            }

            if (span.TotalMinutes < 1)
            {
                return "刚刚";
            }

            if (span.TotalSeconds < 60)
            {
                return "1分钟之前";
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

        #endregion
    }
}
