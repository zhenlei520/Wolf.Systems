﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Wolf.Systems.Core.InternalConfiguration;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public partial class Extensions
    {
        #region 大小写转换

        #region 全部转换为大小写

        #region 转为大写(去除Null的情况)

        /// <summary>
        /// 转为大写(去除Null的情况)
        /// </summary>
        /// <param name="parameter">需要转换的参数</param>
        /// <returns></returns>
        public static string ToUppers(this string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                return string.Empty;
            }

            return parameter.ToUpper();
        }

        #endregion

        #region 转为小写(去除Null的情况)

        /// <summary>
        /// 转为小写(去除Null的情况)
        /// </summary>
        /// <param name="parameter">需要转换的参数</param>
        /// <returns></returns>
        public static string ToLowers(this string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                return string.Empty;
            }

            return parameter.ToLower();
        }

        #endregion

        #endregion

        #region 首字母转换大小写

        #region 首字母小写

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstLowerCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            return $"{value.Substring(0, 1).ToLower()}{value.Substring(1)}";
        }

        #endregion

        #region 首字母大写

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstUpperCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            return $"{value.Substring(0, 1).ToUpper()}{value.Substring(1)}";
        }

        #endregion

        #endregion

        #endregion

        #region Replace 结合正则表达式移除

        /// <summary>
        ///
        /// </summary>
        /// <param name="str">原参数</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="newStr">替换后的值</param>
        /// <returns></returns>
        public static string ReplaceRegex(this string str, string regex, string newStr)
        {
            return ReplaceRegex(str, regex, RegexOptions.None, newStr);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str">原参数</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="options"></param>
        /// <param name="newStr">替换后的值</param>
        /// <returns></returns>
        public static string ReplaceRegex(this string str, string regex, RegexOptions options, string newStr)
        {
            Regex reg = new Regex(regex, options);
            return reg.Replace(str, newStr);
        }

        #endregion

        #region 字符串转换为泛型集合

        /// <summary>
        /// 字符串转化为泛型集合
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitStr">要分割的字符,默认以,分割</param>
        /// <param name="isReplaceSpace">是否移除空格</param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this string str, string splitStr = ",", bool isReplaceSpace = true)
        {
            if (str.IsNullOrWhiteSpace())
            {
                return new List<T>();
            }

            string[] strArray = str.Split(new[] {splitStr},
                isReplaceSpace ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
            return strArray.ChangeType<T>().ToList();
        }

        /// <summary>
        /// 字符串转化为泛型集合
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="splitStr">要分割的字符,默认以,分割</param>
        /// <param name="isReplaceSpace">是否移除空格</param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this string str, char splitStr = ',', bool isReplaceSpace = true)
        {
            if (str.IsNullOrWhiteSpace())
            {
                return new List<T>();
            }

            string[] strArray = str.Split(new[] {splitStr},
                isReplaceSpace ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
            return strArray.ChangeType<T>().ToList();
        }

        #endregion

        #region 获取字符第出现的下标位置

        #region 得到第number次出现character的位置下标

        /// <summary>
        /// 得到第number次出现character的位置下标
        /// </summary>
        /// <param name="parameter">待匹配字符串</param>
        /// <param name="character">匹配的字符串</param>
        /// <param name="number">得到第number次（默认第1次）</param>
        /// <param name="defaultIndexof">默认下标-1（未匹配到）</param>
        /// <returns></returns>
        public static int IndexOfNumber(this string parameter, char character, int number = 1, int defaultIndexof = -1)
        {
            if (string.IsNullOrEmpty(parameter) || number <= 0)
            {
                return defaultIndexof;
            }

            int index = 0;
            int count = 1; //第1次匹配
            while (count < number)
            {
                var tempIndex = parameter.IndexOf(character);
                index += tempIndex;
                parameter = parameter.Substring(tempIndex + 1);
                count++;
            }

            var index2 = parameter.IndexOf(character);
            if (index2 == -1)
            {
                return -1;
            }

            return index + index2 + number - 1;
        }

        #endregion

        #region 得到第number次出现character的位置下标

        /// <summary>
        /// 得到第number次出现str的位置下标
        /// </summary>
        /// <param name="parameter">待匹配字符串</param>
        /// <param name="str">匹配的字符串</param>
        /// <param name="number">得到第number次（默认第1次）</param>
        /// <param name="comparisonType">默认StringComparison.CurrentCulture</param>
        /// <param name="defaultIndexof">默认下标-1（未匹配到）</param>
        /// <returns></returns>
        public static int IndexOfNumber(this string parameter, string str, int number = 1,
            StringComparison comparisonType = StringComparison.CurrentCulture, int defaultIndexof = -1)
        {
            if (string.IsNullOrEmpty(parameter) || number <= 0)
            {
                return defaultIndexof;
            }

            int index = 0;
            int count = 1; //第1次匹配
            while (count < number)
            {
                var tempIndex = parameter.IndexOf(str, comparisonType);
                index += tempIndex;
                parameter = parameter.Substring(tempIndex + 1);
                count++;
            }

            var index2 = parameter.IndexOf(str, comparisonType);
            if (index2 == -1)
            {
                return -1;
            }

            return index + index2 + number - 1;
        }

        #endregion

        #region 得到倒数第number次出现character的位置下标

        /// <summary>
        /// 得到倒数第number次出现character的位置下标
        /// </summary>
        /// <param name="parameter">待匹配字符串</param>
        /// <param name="character">匹配的字符串</param>
        /// <param name="number">倒数第n次出现（默认倒数第1次）</param>
        /// <param name="defaultIndexof">默认下标-1（未匹配到）</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static int LastIndexOfNumber(this string parameter, char character, int number = 1,
            int defaultIndexof = -1)
        {
            return IndexOfNumber(parameter, character, parameter.Split(character).Length - number, defaultIndexof);
        }

        #endregion

        #region 得到倒数第number次出现str的位置下标

        /// <summary>
        /// 得到倒数第number次出现str的位置下标
        /// </summary>
        /// <param name="parameter">待匹配字符串</param>
        /// <param name="str">匹配的字符串</param>
        /// <param name="number">倒数第n次出现（默认倒数第1次）</param>
        /// <param name="comparisonType">默认StringComparison.CurrentCulture</param>
        /// <param name="defaultIndexof">默认下标-1（未匹配到）</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static int LastIndexOfNumber(this string parameter, string str, int number = 1,
            StringComparison comparisonType = StringComparison.CurrentCulture, int defaultIndexof = -1)
        {
            var array = parameter.Split(str, false);
            return IndexOfNumber(parameter, str, array.Length - number, comparisonType, defaultIndexof);
        }

        #endregion

        #endregion

        #region 加密隐藏信息（将原信息其中一部分数据替换为特殊字符）

        /// <summary>
        /// 加密隐藏信息（将原信息其中一部分数据替换为特殊字符）
        /// </summary>
        /// <param name="param">原参数信息</param>
        /// <param name="key">更换后的特殊字符</param>
        /// <param name="index">下标</param>
        /// <param name="length">位数,-1代表到队尾</param>
        /// <returns></returns>
        public static string EncryptSpecialStr(this string param, string key, int index, int length = -1)
        {
            if (param.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            string str = string.Empty;
            if (index > param.Length - 1)
            {
                return param;
            }

            str = param.Substring(0, index);
            if (length == -1)
            {
                length = param.Length - index;
            }

            for (int i = 0; i < length; i++)
            {
                str += key;
            }

            if (index + length < param.Length)
            {
                str += param.Substring(index + length);
            }

            return str;
        }

        #endregion

        #region 得到字符串长度（一个汉字占用两个字符）

        /// <summary>
        /// 得到字符串的字符长度（一个汉字占用两个字符）
        /// </summary>
        /// <param name="param">待校验的字符串</param>
        /// <returns></returns>
        public static int GetLength(this string param)
        {
            if (param.IsNullOrEmpty())
            {
                return 0;
            }

            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(param);
            foreach (var t in s)
            {
                if (t == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }

            return tempLen;
        }

        #endregion

        #region 补足位数

        /// <summary>
        /// 补足位数，指定字符串的固定长度，如果字符串小于固定长度，则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        public static string RepairZero(this string text, int limitedLength) => text.PadLeft(limitedLength, '0');

        #endregion

        #region 半角与全角互转

        #region 半角转全角

        /// <summary>
        /// 半角转全角
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        /// <returns></returns>
        public static string ConvertToSbc(this string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = c[i].ConvertToSbc();
            }

            return new string(c);
        }

        #endregion

        #region 全角转换为半角字符

        /// <summary>
        /// 全角转换为半角字符
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        public static string ConvertToDbc(this string str)
        {
            char[] c = str.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = c[i].ConvertToDbc();
            }

            return new string(c);
        }

        #endregion

        #endregion

        #region 提取字符串中所有数字

        /// <summary>
        /// 提取字符串中所有数字
        /// </summary>
        /// <param name="str">待提取的字符串</param>
        /// <returns></returns>
        public static string ExtractNumbers(this string str) => str.Where(char.IsDigit).ConvertToString();

        #endregion

        #region 提取字符串中所有字母

        /// <summary>
        /// 提取字符串中所有字母
        /// </summary>
        /// <param name="value">值</param>
        public static string ExtractLetters(this string value) =>
            value.Where(x => !x.IsChinese() && char.IsLetter(x)).ConvertToString();

        #endregion

        #region 提取字符串中所有汉字

        /// <summary>
        /// 提取字符串中所有汉字
        /// </summary>
        /// <param name="value">值</param>
        public static string ExtractChinese(this string value) => value.Where(x => x.IsChinese()).ConvertToString();

        #endregion

        #region 截断最大长度的字符串

        /// <summary>
        /// 截断最大长度的字符串
        /// </summary>
        /// <param name="param">原始字符串</param>
        /// <param name="maxLength">最大长度</param>
        public static string Truncate(this string param, int maxLength)
        {
            if (param.IsNullOrWhiteSpace() || maxLength == 0)
                return string.Empty;
            if (param.Length <= maxLength)
                return param;
            return param.Substring(0, maxLength);
        }

        #endregion

        #region 截断字符串扩展

        /// <summary>
        /// 截断字符串。子字符串从指定字符串之后开始
        /// 例如：text：helloworld，from：llo
        /// 结果：world
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="from">开始字符串</param>
        /// <param name="isContainerTo">是否包含开始字符串，默认不包含</param>
        /// <param name="stringComparison">匹配方式，默认忽略大小写</param>
        public static string SubstringFrom(this string text, string from,
            bool isContainerTo = false,
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (text.IsNullOrWhiteSpace() || from.IsNullOrWhiteSpace())
            {
                return text;
            }

            var index = isContainerTo
                ? text.IndexOf(from, stringComparison)
                : text.IndexOf(from, stringComparison) + from.Length;
            return index < 0 ? string.Empty : text.Substring(index);
        }

        /// <summary>
        /// 截断字符串。子字符串从0开始到指定字符串之前
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="to">结尾字符串</param>
        /// <param name="isContainerTo">是否包含结尾字符串</param>
        /// <param name="stringComparison">匹配方式，默认忽略大小写</param>
        public static string SubstringTo(this string text, string to,
            bool isContainerTo = false,
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            var index = isContainerTo == false
                ? text.IndexOf(to, stringComparison)
                : text.IndexOf(to, stringComparison) + to.Length;
            return index < 0 ? string.Empty : text.Substring(0, index);
        }

        #endregion

        #region String转换为Byte数组

        /// <summary>
        /// String转换为Byte数组
        /// </summary>
        /// <param name="para">待转换参数</param>
        /// <returns></returns>
        public static byte[] ConvertToByteArray(this string para)
        {
            return para.ConvertToByteArray(Encoding.UTF8);
        }

        /// <summary>
        /// String转换为Byte数组
        /// </summary>
        /// <param name="para">待转换参数</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static byte[] ConvertToByteArray(this string para, Encoding encoding)
        {
            if (string.IsNullOrWhiteSpace(para))
                return new byte[] { };
            return encoding.GetBytes(para);
        }

        #endregion

        #region 得到指定下标的字符串

        /// <summary>
        /// 得到指定下标的字符串
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetSafeString(this string[] array, int index)
        {
            if (index < 0)
            {
                throw new NotSupportedException("Unsupported subscript");
            }

            if (array.IsNull() || array.Length < index - 1)
            {
                return string.Empty;
            }

            return array[index].SafeString();
        }

        #endregion

        #region 分割

        /// <summary>
        /// 分割
        /// </summary>
        /// <param name="str">待分割的字符串</param>
        /// <param name="splitString">分割符</param>
        /// <param name="isReplaceEmpty">是否移除空格，默认移除</param>
        /// <returns></returns>
        public static string[] Split(this string str, string splitString, bool isReplaceEmpty = true)
        {
            StringSplitOptions stringSplitOptions =
                isReplaceEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            return str.SafeString().Split(new[] {splitString}, stringSplitOptions);
        }

        #endregion

        #region 加密管理

        #region Aes加解密

        #region Aes加密

        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">aes秘钥（32位）</param>
        /// <returns></returns>
        public static string AesEncrypt(this string str, string key)
        {
            var provider = GlobalConfigurations.Instance.GetSecurityProvider(SecurityType.Aes);
            return provider?.Encrypt(str, key, string.Empty, Encoding.UTF8) ??
                   throw new NotImplementedException("Unsupported encryption methods");
        }

        #endregion

        #region Aes解密

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="key">aes秘钥（32位）</param>
        /// <returns></returns>
        public static string AesDecrypt(this string str, string key)
        {
            var provider = GlobalConfigurations.Instance.GetSecurityProvider(SecurityType.Aes);
            return provider?.Decrypt(str, key, string.Empty, Encoding.UTF8) ??
                   throw new NotImplementedException("Unsupported decryption methods");
        }

        #endregion

        #endregion

        #region Des加密

        #region 对字符串进行DES加密

        /// <summary>
        /// 对字符串进行DES加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns>加密后的BASE64编码的字符串</returns>
        public static string DesEncrypt(this string str, string key, string iv)
        {
            var provider = GlobalConfigurations.Instance.GetSecurityProvider(SecurityType.Des);
            return provider?.Encrypt(str, key, string.Empty, Encoding.UTF8) ??
                   throw new NotImplementedException("Unsupported encryption methods");
        }

        #endregion

        #region 对DES加密后的字符串进行解密

        /// <summary>
        /// 对DES加密后的字符串进行解密
        /// </summary>
        /// <param name="str">待解密的字符串</param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns>解密后的字符串</returns>
        public static string DesDecrypt(this string str, string key, string iv)
        {
            var provider = GlobalConfigurations.Instance.GetSecurityProvider(SecurityType.Des);
            return provider?.Decrypt(str, key, string.Empty, Encoding.UTF8) ??
                   throw new NotImplementedException("Unsupported decryption methods");
        }

        #endregion

        #endregion

        #region Js Aes 加解密

        #region JS Aes 加密

        /// <summary>
        /// JsAesEncrypt
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns></returns>
        public static string JsAesEncrypt(this string str, string key, string iv)
        {
            var provider = GlobalConfigurations.Instance.GetSecurityProvider(SecurityType.JsAes);
            return provider?.Encrypt(str, key, string.Empty, Encoding.UTF8) ??
                   throw new NotImplementedException("Unsupported encryption methods");
        }

        #endregion

        #region JS Aes解密

        /// <summary>
        /// JS Aes解密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">偏移量</param>
        /// <returns></returns>
        public static string JsAesDecrypt(this string str, string key, string iv)
        {
            var provider = GlobalConfigurations.Instance.GetSecurityProvider(SecurityType.JsAes);
            return provider?.Encrypt(str, key, string.Empty, Encoding.UTF8) ??
                   throw new NotImplementedException("Unsupported decryption methods");
        }

        #endregion

        #endregion

        #region Md5加密

        #region Md5加密，返回16位结果

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isUpper">是否转大写</param>
        public static string GetMd5HashBy16(this string str, Encoding encoding = null, bool isUpper = true)
        {
            return SecurityCommon.GetMd5HashBy16(str, encoding, isUpper);
        }

        #endregion

        #region MD5加密(32位)

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string GetMd5Hash(this string str, Encoding encoding = null, bool isUpper = true)
        {
            return SecurityCommon.GetMd5Hash(str, encoding, isUpper);
        }

        #endregion

        #endregion

        #region Sha系列加密

        #region Sha1加密

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha1(this string str, bool isUpper = true)
        {
            return SecurityCommon.Sha1(str, isUpper);
        }

        #endregion

        #region Sha256加密

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha256(this string str, bool isUpper = true)
        {
            return SecurityCommon.Sha256(str, isUpper);
        }

        #endregion

        #region Sha384加密

        /// <summary>
        /// Sha384
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha384(this string str, bool isUpper = true)
        {
            return SecurityCommon.Sha384(str, isUpper);
        }

        #endregion

        #region Sha512加密

        /// <summary>
        /// Sha512加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha512(this string str, bool isUpper = true)
        {
            return SecurityCommon.Sha512(str, isUpper);
        }

        #endregion

        #endregion

        #region HMACSHA加密

        #region HMacSha1加密

        /// <summary>
        /// HMacSha1加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <returns></returns>
        public static string HMacSha1(this string str, string key)
        {
            return SecurityCommon.HMacSha1(str, key);
        }

        #endregion

        #region HMacSha256

        /// <summary>
        /// HMacSha256
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <returns></returns>
        public static string HMacSha256(string str, string key)
        {
            return SecurityCommon.HMacSha256(str, key);
        }

        #endregion

        #region HMacSha384

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <returns></returns>
        public static string HMacSha384(string str, string key)
        {
            return SecurityCommon.HMacSha384(str, key);
        }

        #endregion

        #region HMacSha512

        /// <summary>
        /// HMacSha512
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <returns></returns>
        public static string HMacSha512(string str, string key)
        {
            return SecurityCommon.HMacSha512(str, key);
        }

        #endregion

        #endregion

        #region url编码与解码

        #region 得到url地址

        /// <summary>
        /// 得到url地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetUrl(this string str)
        {
            string regexStr = "[a-zA-z]+://[^\\s]*";
            Regex reg = new Regex(regexStr, RegexOptions.Multiline);
            MatchCollection matchs = reg.Matches(str);
            foreach (Match item in matchs)
            {
                if (item.Success)
                {
                    return item.Value;
                }
            }

            throw new BusinessException("无效的链接", ErrorCode.ParamError);
        }

        #endregion

        #region Url编码

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <returns></returns>
        public static string UrlEncode(this string target)
        {
            return HttpUtility.UrlEncode(target);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string UrlEncode(this string target, Encoding encoding)
        {
            return HttpUtility.UrlEncode(target, encoding);
        }

        #endregion

        #region Url解码

        /// <summary>
        ///
        /// </summary>
        /// <param name="target">待解密字符串</param>
        /// <returns></returns>
        public static string UrlDecode(this string target)
        {
            return HttpUtility.UrlDecode(target);
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="target">待解密字符串</param>
        /// <param name="encoding">编码类型</param>
        /// <returns></returns>
        public static string UrlDecode(this string target, Encoding encoding)
        {
            return HttpUtility.UrlDecode(target, encoding);
        }

        #endregion

        #region Html属性编码

        /// <summary>
        /// Html属性编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <returns></returns>
        public static string AttributeEncode(this string target)
        {
            return HttpUtility.HtmlAttributeEncode(target);
        }

        #endregion

        #region Html编码

        /// <summary>
        /// Html编码
        /// </summary>
        /// <param name="target">待加密字符串</param>
        /// <returns></returns>
        public static string HtmlEncode(this string target)
        {
            return HttpUtility.HtmlDecode(target);
        }

        #endregion

        #region Html解码

        /// <summary>
        /// Html解码
        /// </summary>
        /// <param name="target">待解密字符串</param>
        /// <returns></returns>
        public static string HtmlDecode(this string target)
        {
            return HttpUtility.HtmlDecode(target);
        }

        #endregion

        #endregion

        #region Unicode编码与接码

        #region Unicode编码

        /// <summary>
        /// 汉字转换为Unicode编码
        /// </summary>
        /// <param name="str">要编码的汉字字符串</param>
        /// <returns>Unicode编码的的字符串</returns>
        public static string ConvertStringToUnicode(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            byte[] bts = Encoding.Unicode.GetBytes(str);
            string r = string.Empty;
            for (int i = 0; i < bts.Length; i += 2)
                r += "\\u" + bts[i + 1].ToString("x").PadLeft(2, '0') + bts[i].ToString("x").PadLeft(2, '0');
            return r;
        }

        #endregion

        #region 将Unicode编码转换为汉字字符串

        /// <summary>
        /// 将Unicode编码转换为汉字字符串
        /// </summary>
        /// <param name="str">Unicode编码字符串</param>
        /// <returns>汉字字符串</returns>
        public static string ConvertUnicodeToString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            string r = string.Empty;
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            foreach (Match m in mc)
            {
                bts[0] = (byte) int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
                bts[1] = (byte) int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                r += Encoding.Unicode.GetString(bts);
            }

            return r;
        }

        #endregion

        #endregion

        #region Base64算法加密

        /// <summary>
        /// Base64算法加密
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static byte[] ConvertToBase64ByteArray(this string str)
        {
            return Convert.FromBase64String(str);
        }

        #endregion

        #endregion

        #region 清空小数点后0

        /// <summary>
        /// 保留两位小数并对其四舍五入，如果最后的两位小数为*.00则去除小数位，否则保留两位小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearDecimal(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return "0";
            str = float.Parse(str).ToString("0.00");
            if (Int32.Parse(str.Substring(str.IndexOf(".", StringComparison.Ordinal) + 1)) == 0)
            {
                return str.Substring(0, str.IndexOf(".", StringComparison.Ordinal));
            }

            return str;
        }

        #endregion

        #region 格式化转义符

        /// <summary>
        /// 格式化转义符
        /// </summary>
        /// <param name="str">待格式化字符串</param>
        /// <returns></returns>
        public static string FormatEscapes(this string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            return sb.ToString();
        }

        #endregion

        #region 字符串增加前缀

        /// <summary>
        /// 字符串增加前缀
        /// </summary>
        /// <param name="original">原字符串</param>
        /// <param name="prefix">前缀</param>
        /// <param name="isRefEmpty">源字符串为空时是否返回空字符串</param>
        public static string AddPrefix(this string original, string prefix, bool isRefEmpty = true)
        {
            if (original.IsNullOrWhiteSpace() && isRefEmpty)
            {
                return string.Empty;
            }

            return string.Concat(prefix, original ?? string.Empty);
        }

        #endregion

        #region 字符串增加后缀

        /// <summary>
        /// 字符串增加后缀
        /// </summary>
        /// <param name="original">原字符串</param>
        /// <param name="suffix">后缀</param>
        /// <param name="isRefEmpty">源字符串为空时是否返回空</param>
        /// <returns></returns>
        public static string AddSuffix(this string original, string suffix, bool isRefEmpty = true)
        {
            if (original.IsNullOrWhiteSpace() && isRefEmpty)
            {
                return string.Empty;
            }

            return string.Concat(original ?? string.Empty, suffix);
        }

        #endregion

        #region 转换进制

        /// <summary>
        /// 转换进制
        /// 进制只支持2、8、10、16
        /// </summary>
        /// <param name="str">待转换的参数</param>
        /// <param name="from">源进制</param>
        /// <param name="to">目标禁止</param>
        /// <returns></returns>
        public static string ConvertBinary(this string str, int from, int to)
        {
            if (@from != 2 && @from != 8 && @from != 10 && @from != 16 ||
                to != 2 && to != 8 && to != 10 && to != 16)
            {
                throw new NotSupportedException(
                    "Source base and target base only support binary, octal, decimal and hexadecimal");
            }

            int intValue = Convert.ToInt32(str, from); //先转成10进制
            return Convert.ToString(intValue, to);
        }

        #endregion

        #region 获取字数

        #region 获取总英文字母数

        /// <summary>
        /// 获取总英文字母数
        /// </summary>
        /// <param name="str">字符串</param>
        public static int TotalLetters(this string str) =>
            str.IsNullOrWhiteSpace() ? 0 : str.ToCharArray().Count(char.IsLetter);

        #endregion

        #region 获取总大写英文字母数

        /// <summary>
        /// 获取总大写英文字母数
        /// </summary>
        /// <param name="str">字符串</param>
        public static int TotalUpperLetters(this string str) => str.IsNullOrWhiteSpace()
            ? 0
            : str.ToCharArray().Count(x => char.IsLetter(x) && char.IsUpper(x));

        #endregion

        #region 获取总小写英文字母数

        /// <summary>
        /// 获取总小写英文字母数
        /// </summary>
        /// <param name="str">字符串</param>
        public static int TotalLowerLetters(this string str) => str.IsNullOrWhiteSpace()
            ? 0
            : str.ToCharArray().Count(x => char.IsLetter(x) && char.IsLower(x));

        #endregion

        #region 获取十进制数字字数

        /// <summary>
        /// 获取十进制数字字数
        /// 十进制数字，就是 '0 '.. '9 '
        /// </summary>
        /// <param name="str">字符串</param>
        public static int TotalDigits(this string str) =>
            str.IsNullOrWhiteSpace() ? 0 : str.ToCharArray().Count(char.IsDigit);

        #endregion

        #region 获取总数字字符字数

        /// <summary>
        /// 获取总数字字符字数
        ///  判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。
        /// </summary>
        /// <param name="str">字符串</param>
        public static int TotalNumber(this string str) =>
            str.IsNullOrWhiteSpace() ? 0 : str.ToCharArray().Count(char.IsNumber);

        #endregion

        #region 获取标点符号字数

        /// <summary>
        /// 获取标点符号字数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static int TotalPunctuation(this string str) =>
            str.IsNullOrWhiteSpace() ? 0 : str.ToCharArray().Count(char.IsPunctuation);

        #endregion

        #region 获取分隔符号字数

        /// <summary>
        /// 获取分隔符号字数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static int TotalSeparator(this string str) =>
            str.IsNullOrWhiteSpace() ? 0 : str.ToCharArray().Count(char.IsSeparator);

        #endregion

        #region 获取符号字符字数

        /// <summary>
        /// 获取符号字符字数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static int TotalSymbol(this string str) =>
            str.IsNullOrWhiteSpace() ? 0 : str.ToCharArray().Count(char.IsSymbol);

        #endregion

        #endregion

        #region 匹配信息

        #region 仅返回英文字母

        /// <summary>
        /// 仅返回英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        public static string OnlyLetters(this string text) => OnlyLetters(text, null);

        /// <summary>
        /// 仅返回英文字母(排除例外字符)
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="exceptions">例外字符</param>
        public static string OnlyLetters(this string text, params char[] exceptions)
        {
            var res = new StringBuilder();
            foreach (var c in text)
            {
                if (char.IsLetter(c) || exceptions != null && exceptions.Contains(c))
                    res.Append(c);
            }

            return res.ToString();
        }

        #endregion

        #region 仅返回大写英文字母

        /// <summary>
        /// 仅返回大写英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        public static string OnlyUpperLetters(this string text) => OnlyUpperLetters(text, null);

        /// <summary>
        /// 仅返回大写英文字母(排除例外字符)
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="exceptions">例外字符</param>
        public static string OnlyUpperLetters(this string text, params char[] exceptions)
        {
            var res = new StringBuilder();
            foreach (var c in text)
            {
                if (char.IsLetter(c) && char.IsUpper(c) || exceptions != null && exceptions.Contains(c))
                    res.Append(c);
            }

            return res.ToString();
        }

        #endregion

        #region 仅返回小写英文字母

        /// <summary>
        /// 仅返回小写英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        public static string OnlyLowerLetters(this string text) => OnlyLowerLetters(text, null);

        /// <summary>
        /// 仅返回小写英文字母(排除例外字符)
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="exceptions">例外字符</param>
        public static string OnlyLowerLetters(this string text, params char[] exceptions)
        {
            var res = new StringBuilder();
            foreach (var c in text)
            {
                if (char.IsLetter(c) && char.IsLower(c) || exceptions != null && exceptions.Contains(c))
                    res.Append(c);
            }

            return res.ToString();
        }

        #endregion

        #region 仅返回数字

        /// <summary>
        /// 仅返回数字
        /// </summary>
        /// <param name="text">字符串</param>
        public static string OnlyDigits(this string text) => OnlyDigits(text, null);

        /// <summary>
        /// 仅返回数字(排除例外字符)
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="exceptions">例外字符</param>
        public static string OnlyDigits(this string text, params char[] exceptions)
        {
            var res = new StringBuilder();
            foreach (var c in text)
            {
                if (char.IsDigit(c) || exceptions != null && exceptions.Contains(c))
                    res.Append(c);
            }

            return res.ToString();
        }

        #endregion

        #region 仅返回数字(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)

        /// <summary>
        /// 仅返回数字(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)
        /// </summary>
        /// <param name="text">字符串</param>
        public static string OnlyNumber(this string text) => OnlyNumber(text, null);

        /// <summary>
        /// 仅返回数字(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。) (排除例外字符)
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="exceptions">例外字符</param>
        public static string OnlyNumber(this string text, params char[] exceptions)
        {
            var res = new StringBuilder();
            foreach (var c in text)
            {
                if (char.IsNumber(c) || exceptions != null && exceptions.Contains(c))
                    res.Append(c);
            }

            return res.ToString();
        }

        #endregion

        #endregion

        #region 验证

        #region 判断字符串是否全部相等

        /// <summary>
        /// 判断字符串是否全部相等
        /// </summary>
        /// <param name="str">待验证的字符串</param>
        /// <returns></returns>
        public static bool IsEqualNumber(this string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] != str[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 判断正则表达式是否匹配

        /// <summary>
        /// 判断正则表达式是否匹配
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static bool Test(this string str, string regex)
        {
            return str.Test(regex, RegexOptions.None);
        }

        /// <summary>
        /// 判断正则表达式是否匹配到
        /// </summary>
        /// <param name="str">待匹配的字符串</param>
        /// <param name="regex">正则表达式</param>
        /// <param name="options">正则表达式设置</param>
        /// <returns></returns>
        public static bool Test(this string str, string regex, RegexOptions options)
        {
            if (str.IsNullOrEmpty())
            {
                return false;
            }

            return new Regex(regex, options).IsMatch(str);
        }

        #endregion

        #region 是否为邮箱

        /// <summary>
        /// 是否为邮箱
        /// </summary>
        public static bool IsEmail(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            return new Regex(RegexConst.Email, RegexOptions.IgnoreCase).IsMatch(str);
        }

        #endregion

        #region 是否是纯数字（支持正负数）

        /// <summary>
        /// 是否是纯数字（支持正负数，默认不验证正负数）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="numericType">类型，默认不限制正负数</param>
        /// <returns></returns>
        public static bool IsNumber(this string str, NumericType numericType = NumericType.All)
        {
            if (string.IsNullOrEmpty(str)) //验证这个参数是否为空
                return false; //是，就返回False
            ASCIIEncoding ascii = new ASCIIEncoding(); //new ASCIIEncoding 的实例
            byte[] byteStr = ascii.GetBytes(str); //把string类型的参数保存到数组里
            List<int> asciiList = new List<int>();
            foreach (byte c in byteStr) //遍历这个数组里的内容
            {
                if (numericType.Equals(NumericType.All))
                {
                    if ((c < 48 || c > 57) && c != 45 && c != 43 ||
                        (c == 45 || c == 43) && asciiList.Any(x => x == 45 || x == 43)) //判断是否为数字
                    {
                        return false; //不是，就返回False
                    }
                }
                else if (numericType == NumericType.Plus)
                {
                    if ((c < 48 || c > 57) && c != 43 ||
                        c == 43 && asciiList.Any(x => x == 43))
                    {
                        return false; //不是，就返回False
                    }
                }
                else if (numericType == NumericType.Minus)
                {
                    if ((c < 48 || c > 57) && c != 45 ||
                        c == 45 && asciiList.Any(x => x == 45))
                    {
                        return false; //不是，就返回False
                    }
                }
                else
                {
                    return false;
                }

                asciiList.Add(c);
            }

            if (numericType == NumericType.Minus && asciiList.All(x => x != 45))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region 是否为IP

        /// <summary>
        /// 是否为IP
        /// </summary>
        public static bool IsIp(this string str)
        {
            return new Regex(RegexConst.Ip, RegexOptions.IgnoreCase).IsMatch(str);
        }

        #endregion

        #region 判断是否网址

        /// <summary>
        ///  判断是否网址
        /// </summary>
        /// <param name="webUrl">网址</param>
        /// <returns></returns>
        public static bool IsUrl(this string webUrl)
        {
            if (string.IsNullOrEmpty(webUrl))
                return false;
            return new Regex(RegexConst.WebSite, RegexOptions.IgnoreCase).IsMatch(webUrl);
        }

        #endregion

        #region 判断是否中文

        /// <summary>
        /// 是否中文
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isAll">是否全部中文，默认有中文就可以，true：全部都是中文</param>
        /// <returns></returns>
        public static bool IsChinese(this string str, bool isAll = false)
        {
            if (string.IsNullOrEmpty(str)) return false;
            var regex = new Regex(RegexConst.Chinese, RegexOptions.IgnoreCase);
            if (!isAll)
            {
                return regex.IsMatch(str);
            }

            return regex.Match(str).Success && regex.Matches(str).Count == str.SafeString().Length;
        }

        #endregion

        #region 判断精度是否正确

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this string str, int maxScale)
        {
            if (double.TryParse(str, out double temp))
            {
                var numberArray = str.Split('.');
                if (numberArray.Length == 1)
                {
                    return maxScale >= 0;
                }

                var numberStr = numberArray[1];
                int index;
                do
                {
                    if (numberStr.Length == 1)
                    {
                        return 1 <= maxScale;
                    }

                    index = numberStr.Length - 1;
                    if (numberStr[index] == '0')
                    {
                        numberStr = numberStr.Substring(0, index);
                    }
                    else
                    {
                        return numberStr.Length <= maxScale;
                    }
                } while (index > 0);
            }

            return false;
        }

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this double str, int maxScale)
        {
            return str.ToString(CultureInfo.InvariantCulture).IsMaxScale(maxScale);
        }

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this int str, int maxScale)
        {
            return str.ToString(CultureInfo.InvariantCulture).IsMaxScale(maxScale);
        }

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this decimal str, int maxScale)
        {
            return str.ToString(CultureInfo.InvariantCulture).IsMaxScale(maxScale);
        }

        /// <summary>
        /// 判断精度是否正确
        /// </summary>
        /// <param name="str">带匹配的字符串</param>
        /// <param name="maxScale">最大保留小数位数</param>
        /// <returns></returns>
        public static bool IsMaxScale(this float str, int maxScale)
        {
            return str.ToString(CultureInfo.InvariantCulture).IsMaxScale(maxScale);
        }

        #endregion

        #region 是否内网ip

        /// <summary>
        /// 判断IP地址是否为内网IP地址
        /// </summary>
        /// <param name="ip">IP地址字符串</param>
        /// <returns></returns>
        public static bool IsInnerIp(this string ip)
        {
            var ipList = ip.Split('.');
            if (ipList.Length != 4 || ipList.Any(x => !x.IsNumber()))
            {
                return false;
            }

            long ipNum = GetIpNum(ip);

            long aBegin = GetIpNum("10.0.0.0");
            long aEnd = GetIpNum("10.255.255.255");

            long bBegin = GetIpNum("172.16.0.0");
            long bEnd = GetIpNum("172.31.255.255");

            long cBegin = GetIpNum("192.168.0.0");
            long cEnd = GetIpNum("192.168.255.255");
            var isInnerIp = IsInner(ipNum, aBegin, aEnd) || IsInner(ipNum, bBegin, bEnd) ||
                            IsInner(ipNum, cBegin, cEnd) ||
                            ip.Equals("127.0.0.1");
            return isInnerIp;
        }

        #region 把IP地址转换为Long型数字

        /// <summary>
        /// 把IP地址转换为Long型数字
        /// </summary>
        /// <param name="ipAddress">IP地址字符串</param>
        /// <returns></returns>
        private static long GetIpNum(string ipAddress)
        {
            string[] ip = ipAddress.Split('.');
            long a = int.Parse(ip[0]);
            long b = int.Parse(ip[1]);
            long c = int.Parse(ip[2]);
            long d = int.Parse(ip[3]);

            long ipNum = a * 256 * 256 * 256 + b * 256 * 256 + c * 256 + d;
            return ipNum;
        }

        #endregion

        #region 判断用户IP地址转换为Long型后是否在内网IP地址所在范围

        /// <summary>
        /// 判断用户IP地址转换为Long型后是否在内网IP地址所在范围
        /// </summary>
        /// <param name="userIp">用户ip</param>
        /// <param name="begin">开始</param>
        /// <param name="end">结束</param>
        /// <returns></returns>
        private static bool IsInner(long userIp, long begin, long end)
        {
            return userIp >= begin && userIp <= end;
        }

        #endregion

        #endregion

        #region 是否在指定列表内

        /// <summary>
        /// 是否在指定列表内（默认忽略大小写）
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsIn(this string source, params string[] list) =>
            source.IsIn(StringComparison.OrdinalIgnoreCase, list);

        /// <summary>
        /// 是否在指定列表内
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        /// <param name="stringComparison">匹配方式，默认忽略大小写</param>
        public static bool IsIn(this string source,
            StringComparison stringComparison, params string[] list) =>
            list.Any(x => string.Equals(source, x, stringComparison));

        #endregion

        #region 判断不在指定列表内

        /// <summary>
        /// 判断不在指定列表内（默认忽略大小写）
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        public static bool IsNotIn(this string source, params string[] list) =>
            source.IsNotIn(StringComparison.OrdinalIgnoreCase, list);

        /// <summary>
        /// 判断不在指定列表内
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="list">列表</param>
        /// <param name="stringComparison">匹配方式，默认忽略大小写</param>
        public static bool IsNotIn(this string source,
            StringComparison stringComparison, params string[] list) =>
            !source.IsIn(stringComparison, list);

        #endregion

        #region 判断是否包含英文字母、数字

        #region 判断是否全部为英文字母

        /// <summary>
        /// 判断是否全部为英文字母
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsOnlyLetters(this string str) => str.All(char.IsLetter);

        #endregion

        #region 包含 是否包含英文字母

        /// <summary>
        /// 包含 是否包含英文字母
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsLetters(this string str) => str.Any(char.IsDigit);

        #endregion

        #region 判断是否包含英文字母

        /// <summary>
        /// 判断是否包含英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        public static bool IncludeLetters(this string text) => text.IncludeLetters(1);

        #endregion

        #region 是否包含最小数量为minCount的英文字母

        /// <summary>
        /// 是否包含最小数量为minCount的英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeLetters(this string text, int minCount) => text.TotalLetters() >= minCount;

        #endregion

        #region 判断是否全部为大写英文字母

        /// <summary>
        /// 判断是否全部为大写英文字母
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsOnlyUpperLetters(this string str) =>
            str.All(x => char.IsLetter(x) && char.IsUpper(x));

        #endregion

        #region 包含 是否包含大写英文字母

        /// <summary>
        /// 包含 是否包含大写英文字母
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsUpperLetters(this string str) => str.Any(x => char.IsDigit(x) && char.IsUpper(x));

        #endregion

        #region 判断是否包含大写英文字母

        /// <summary>
        /// 判断是否包含大写英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        public static bool IncludeUpperLetters(this string text) => text.IncludeUpperLetters(1);

        #endregion

        #region 是否包含指定数量的大写英文字母

        /// <summary>
        /// 是否包含指定数量的大写英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeUpperLetters(this string text, int minCount) => text.TotalUpperLetters() >= minCount;

        #endregion

        #region 判断是否全部为小写英文字母

        /// <summary>
        /// 判断是否全部为小写英文字母
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsOnlyLowerLetters(this string str) =>
            str.All(x => char.IsLetter(x) && char.IsLower(x));

        #endregion

        #region 包含 是否包含小写英文字母

        /// <summary>
        /// 包含 是否包含小写英文字母
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsLowerLetters(this string str) => str.Any(x => char.IsDigit(x) && char.IsLower(x));

        #endregion

        #region 判断是否包含小写英文字母

        /// <summary>
        /// 判断是否包含小写英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        public static bool IncludeLowerLetters(this string text) => text.IncludeLowerLetters(1);

        #endregion

        #region 是否包含指定最小数量的小写英文字母

        /// <summary>
        /// 是否包含指定最小数量的小写英文字母
        /// </summary>
        /// <param name="text">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeLowerLetters(this string text, int minCount) => text.TotalLowerLetters() >= minCount;

        #endregion

        #region 判断是否全部为数字

        /// <summary>
        /// 判断是否全部为十进制数字字符
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsOnlyDigits(this string str) => str.All(char.IsDigit);

        #endregion

        #region 包含 是否包含十进制数字字符

        /// <summary>
        /// 包含 是否包含十进制数字字符
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsDigits(this string str) => str.Any(char.IsDigit);

        #endregion

        #region 是否包含十进制数字字符

        /// <summary>
        /// 是否包含十进制数字字符
        /// </summary>
        /// <param name="text">字符串</param>
        public static bool IncludeDigits(this string text) => text.IncludeDigits(1);

        #endregion

        #region 是否包含指定最小数量的十进制数字字符

        /// <summary>
        /// 是否包含指定最小数量的十进制数字字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeDigits(this string str, int minCount) => str.TotalDigits() >= minCount;

        #endregion

        #region 判断是否全部为数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)

        /// <summary>
        /// 判断是否全部为数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsOnlyNumber(this string str) => str.All(char.IsNumber);

        #endregion

        #region 包含 是否包含数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)

        /// <summary>
        /// 包含 是否包含数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool ContainsNumber(this string str) => str.Any(char.IsNumber);

        #endregion

        #region 是否包含数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)

        /// <summary>
        /// 是否包含数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)
        /// </summary>
        /// <param name="text">字符串</param>
        public static bool IncludeNumber(this string text) => text.IncludeNumber(1);

        #endregion

        #region 是否包含指定最小数量的数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)

        /// <summary>
        /// 是否包含指定最小数量的数字字符(判断的是数字类别，包括十进制数字 '0 '.. '9 '，还有用字母表示的数字，如表示罗马数字5的字母 'V '，还有表示其他数字的字符，如表示“1/2”的字符。)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeNumber(this string str, int minCount) => str.TotalNumber() >= minCount;

        #endregion

        #region 是否包含标点符号

        /// <summary>
        /// 是否包含标点符号
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool IncludePunctuation(this string str) => str.IncludePunctuation(1);

        /// <summary>
        /// 是否包含至少minCount个标点符号
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludePunctuation(this string str, int minCount) => str.TotalPunctuation() >= minCount;

        #endregion

        #region 是否包含分隔符号

        /// <summary>
        /// 是否包含分隔符号
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool IncludeSeparator(this string str) => str.IncludeSeparator(1);

        /// <summary>
        /// 是否包含至少minCount个分隔符号
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeSeparator(this string str, int minCount) => str.TotalSeparator() >= minCount;

        #endregion

        #region 是否包含符号字符

        /// <summary>
        /// 是否包含符号字符
        /// </summary>
        /// <param name="str">字符串</param>
        public static bool IncludeSymbol(this string str) => str.IncludeSymbol(1);

        /// <summary>
        /// 是否包含至少minCount个符号字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="minCount">最小数量</param>
        public static bool IncludeSymbol(this string str, int minCount) => str.TotalSymbol() >= minCount;

        #endregion

        #endregion

        #region Indicates whether the specified string is null or an

        /// <summary>
        /// Indicates whether the specified string is null or an
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Indicates whether the specified string is null or an
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        #endregion

        #endregion
    }
}
