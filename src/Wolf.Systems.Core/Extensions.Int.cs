﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// int扩展
    /// </summary>
    public partial class Extensions
    {
        #region 判断param的值是否在枚举中

        /// <summary>
        /// 判断值是否在枚举中
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool IsExist<T>(this int param) where T : System.Enum
        {
            return System.Enum.IsDefined(typeof(T), param);
        }

        /// <summary>
        /// 判断值是否在枚举中
        /// </summary>
        /// <param name="enumValue">需要判断的参数</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool IsExist(this int enumValue, Type type)
        {
            return System.Enum.IsDefined(type, enumValue);
        }

        #endregion

        #region Abs(返回数字的绝对值)

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="param">值</param>
        public static int Abs(this int param) => Math.Abs(param);

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="param">值</param>
        public static IEnumerable<int> Abs(this IEnumerable<int> param) => param.Select(x => x.Abs());

        #endregion

        #region 判断是否全部相等

        /// <summary>
        /// 判断数字是否全部相等
        /// </summary>
        /// <param name="number">待验证的数字</param>
        /// <returns></returns>
        public static bool IsEqualNumber(this int number)
        {
            int[] num = number.ToString().Select(s => int.Parse(s.ToString())).ToArray();
            for (int i = 0; i < num.Length - 1; i++)
            {
                if (num[i] != num[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 补足位数

        /// <summary>
        /// 指定字符串的固定长度，如果字符串小于固定长度，则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="number">原数字</param>
        /// <param name="limitedLength">固定几位长度</param>
        /// <returns></returns>
        public static string RepairZero(this int number, int limitedLength) =>
            number.ToString().RepairZero(limitedLength);

        #endregion

        #region 校验

        #region IsEven(是否偶数)

        /// <summary>
        /// 是否偶数
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEven(this int value) => value % 2 == 0;

        #endregion

        #region IsOdd(是否奇数)

        /// <summary>
        /// 是否奇数
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsOdd(this int value) => value % 2 != 0;

        #endregion

        #region IsPrime(是否质数)

        /// <summary>
        /// 是否质数（素数），一个质数（或素数）是具有两个不同约束的自然数：1和它本身
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsPrime(this int value)
        {
            return value.ConvertToLong().IsPrime();
        }

        /// <summary>
        /// 是否质数（素数），一个质数（或素数）是具有两个不同约束的自然数：1和它本身
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsPrime(this int? value)
        {
            return value.ConvertToLong().IsPrime();
        }

        #endregion

        #endregion
    }
}
