// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// 校验类
    /// </summary>
    public partial class Extensions
    {
        #region 是否为Double类型

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsDouble(this object parameter)
        {
            return parameter.ConvertToDouble().IsNull() == false;
        }

        #endregion

        #region 是否为Decimal类型

        /// <summary>
        /// 是否为Decimal类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsDecimal(this object parameter)
        {
            return parameter.ConvertToDecimal().IsNull() == false;
        }

        #endregion

        #region 是否为Long类型

        /// <summary>
        /// 是否为Long类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsLong(this object parameter)
        {
            return parameter.ConvertToLong().IsNull() == false;
        }

        #endregion

        #region 是否为Int类型

        /// <summary>
        /// 是否为Int类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsInt(this object parameter)
        {
            return parameter.ConvertToInt().IsNull() == false;
        }

        #endregion

        #region 是否为Short类型

        /// <summary>
        /// 是否为Short类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsShort(this object parameter)
        {
            return parameter.ConvertToShort().IsNull() == false;
        }

        #endregion

        #region 是否为Guid类型

        /// <summary>
        /// 是否为Guid类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsGuid(this object parameter)
        {
            return parameter.ConvertToGuid().IsNull() == false;
        }

        #endregion

        #region 是否为Char类型

        /// <summary>
        /// 是否为Char类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsChar(this object parameter)
        {
            return parameter.ConvertToChar().IsNull() == false;
        }

        #endregion

        #region 是否为Float类型

        /// <summary>
        /// 是否为Float类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsFloat(this object parameter)
        {
            return parameter.ConvertToFloat().IsNull() == false;
        }

        #endregion

        #region 是否为DateTime类型

        /// <summary>
        /// 是否为DateTime类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsDateTime(this object parameter)
        {
            return parameter.ConvertToDateTime().IsNull() == false;
        }

        #endregion

        #region 是否为Byte类型

        /// <summary>
        /// 是否为Byte类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsByte(this object parameter)
        {
            return parameter.ConvertToByte().IsNull() == false;
        }

        #endregion

        #region 是否为SByte类型

        /// <summary>
        /// 是否为SByte类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsSByte(this object parameter)
        {
            return parameter.ConvertToSByte().IsNull() == false;
        }

        #endregion

        #region 是否为Bool类型

        /// <summary>
        /// 是否为Bool类型
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static bool IsBool(this object parameter)
        {
            return parameter.ConvertToBool().IsNull() == false;
        }

        #endregion

        #region 判断值是否在指定范围内

        /// <summary>
        /// 判断值是否在指定范围内
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="rangeMode">区间模式，如果为null，则视为开区间</param>
        public static bool InRange<T>(this T value, T minValue, T maxValue, RangeMode rangeMode = RangeMode.Open)
            where T : IComparable
        {
            if (rangeMode == RangeMode.Open)
            {
                return value.GreaterThanOrEqualTo(minValue) && value.LessThanOrEqualTo(maxValue);
            }

            if (rangeMode == RangeMode.Close)
            {
                return value.GreaterThan(minValue) && value.LessThan(maxValue);
            }

            if (rangeMode == RangeMode.OpenClose)
            {
                return value.GreaterThanOrEqualTo(minValue) && value.LessThan(maxValue);
            }

            if (rangeMode == RangeMode.CloseOpen)
            {
                return value.GreaterThan(minValue) && value.LessThanOrEqualTo(maxValue);
            }

            throw new NotImplementedException("不支持的区间模式");
        }

        #endregion

        #region 参数1大于参数2

        /// <summary>
        /// 参数1大于参数2
        /// </summary>
        /// <param name="param1">参数1</param>
        /// <param name="param2">参数2</param>
        public static bool GreaterThan<T>(this T param1, T param2) where T : IComparable
        {
            return param1.CompareTo(param2) > 0;
        }

        /// <summary>
        /// 参数1大于等于参数2
        /// </summary>
        /// <param name="param1">参数1</param>
        /// <param name="param2">参数2</param>
        public static bool GreaterThanOrEqualTo<T>(this T param1, T param2) where T : IComparable
        {
            return param1.CompareTo(param2) == 0 || param1.CompareTo(param2) > 0;
        }

        #endregion

        #region 参数1小于等于参数2

        /// <summary>
        /// 参数1小于参数2
        /// </summary>
        /// <param name="param1">参数1</param>
        /// <param name="param2">参数2</param>
        public static bool LessThan<T>(this T param1, T param2) where T : IComparable
        {
            return param1.CompareTo(param2) < 0;
        }

        /// <summary>
        /// 参数1小于等于参数2
        /// </summary>
        /// <param name="param1">参数1</param>
        /// <param name="param2">参数2</param>
        public static bool LessThanOrEqualTo<T>(this T param1, T param2) where T : IComparable
        {
            return param1.CompareTo(param2) == 0 || param1.CompareTo(param2) < 0;
        }

        #endregion

        #region 判断是否在/不在指定列表内

        /// <summary>
        /// 是否在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsIn<T>(this T source, params T[] list) where T : IComparable =>
            !source.IsNull() && !list.IsNull() && list.Any(t => t.CompareTo(source) == 0);

        /// <summary>
        /// 判断不在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsNotIn<T>(this T source, params T[] list) where T : IComparable =>
            !source.IsNull() && !list.IsNull() && list.All(t => t.CompareTo(source) != 0);

        /// <summary>
        /// 是否全部在指定列表内 sourceList是list的子集或者sourceList与list相等
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this T[] sourceList, params T[] list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            return sourceList.All(x => list.Any(y => y.CompareTo(x) == 0));
        }

        /// <summary>
        /// 是否全部在指定列表内 sourceList是list的子集或者sourceList与list相等
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this T[] sourceList, List<T> list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            return sourceList.All(x => list.Any(y => y.CompareTo(x) == 0));
        }

        /// <summary>
        /// 是否在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsIn<T>(this T source, IEnumerable<T> list) where T : IComparable =>
            !source.IsNull() && !list.IsNull() && list.Any(t => t.CompareTo(source) == 0);

        /// <summary>
        /// 判断不在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsNotIn<T>(this T source, IEnumerable<T> list) where T : IComparable =>
            !source.IsNull() && !list.IsNull() && list.All(t => t.CompareTo(source) != 0);

        /// <summary>
        /// 是否全部在指定列表内 sourceList是list的子集或者sourceList与list相等
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this IEnumerable<T> sourceList, params T[] list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            return sourceList.All(x => list.Any(y => y.CompareTo(x) == 0));
        }

        /// <summary>
        /// 是否全部在指定列表内 sourceList是list的子集或者sourceList与list相等
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this IEnumerable<T> sourceList, List<T> list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            return sourceList.All(x => list.Any(y => y.CompareTo(x) == 0));
        }

        /// <summary>
        /// 是否在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsIn<T>(this T source, HashSet<T> list) where T : IComparable =>
            !source.IsNull() && !list.IsNull() && list.Any(t => t.CompareTo(source) == 0);

        /// <summary>
        /// 判断不在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsNotIn<T>(this T source, HashSet<T> list) where T : IComparable =>
            !source.IsNull() && !list.IsNull() && list.All(t => t.CompareTo(source) != 0);

        /// <summary>
        /// 是否全部在指定列表内 sourceList是list的子集或者sourceList与list相等
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this IEnumerable<T> sourceList, HashSet<T> list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            return sourceList.All(x => list.Any(y => y.CompareTo(x) == 0));
        }

        /// <summary>
        /// 是否全部在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this HashSet<T> sourceList, HashSet<T> list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            foreach (var item in sourceList)
            {
                if (item.IsNotIn(list))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 是否全部在指定列表内
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sourceList">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsAllIn<T>(this HashSet<T> sourceList, IEnumerable<T> list) where T : IComparable
        {
            if (sourceList.IsNull() || list.IsNull())
            {
                return false;
            }

            foreach (var item in sourceList)
            {
                if (item.IsNotIn(list))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 是否Null

        /// <summary>
        /// 是否Null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// 是否null或者DBNull
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrDbNull(this object obj)
        {
            return obj == null || obj is DBNull;
        }

        /// <summary>
        /// 是否为Null或者空或者DbNull
        /// </summary>
        /// <param name="value">待验证的对象</param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrDbNull(this object value)
        {
            return value.IsNullOrDbNull() || value.ToString().IsNullOrEmpty();
        }

        /// <summary>
        /// 是否为Null或者空以字符串或者DbNull
        /// </summary>
        /// <param name="value">待验证的对象</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpaceOrDbNull(this object value)
        {
            return value.IsNullOrDbNull() || value.ToString().IsNullOrWhiteSpace();
        }

        /// <summary>
        /// 是否为Null或者空以字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this object value)
        {
            if (value.IsNull())
            {
                return true;
            }

            return value.ToString().IsNullOrWhiteSpace();
        }

        #endregion
    }
}
