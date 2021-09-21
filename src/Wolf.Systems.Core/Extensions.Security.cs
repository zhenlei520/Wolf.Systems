// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Wolf.Systems.Core.Internal.Common;
using Wolf.Systems.Core.Internal.Configuration;
using Wolf.Systems.Enum;
using Wolf.Systems.Exceptions;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    public partial class Extensions
    {
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
            return provider?.Encrypt(str, key, Const.Empty, Encoding.UTF8) ??
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
            return provider?.Decrypt(str, key, Const.Empty, Encoding.UTF8) ??
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
            return provider?.Encrypt(str, key, Const.Empty, Encoding.UTF8) ??
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
            return provider?.Decrypt(str, key, Const.Empty, Encoding.UTF8) ??
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
            return provider?.Encrypt(str, key, Const.Empty, Encoding.UTF8) ??
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
            return provider?.Encrypt(str, key, Const.Empty, Encoding.UTF8) ??
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

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha1(this Stream stream, bool isUpper = true)
        {
            return SecurityCommon.Sha1(stream, isUpper);
        }

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha1(this byte[] bytes, bool isUpper = true)
        {
            return SecurityCommon.Sha1(bytes, isUpper);
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

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha256(this Stream stream, bool isUpper = true)
        {
            return SecurityCommon.Sha256(stream, isUpper);
        }

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha256(this byte[] bytes, bool isUpper = true)
        {
            return SecurityCommon.Sha256(bytes, isUpper);
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

        /// <summary>
        /// Sha384
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha384(this Stream stream, bool isUpper = true)
        {
            return SecurityCommon.Sha384(stream, isUpper);
        }

        /// <summary>
        /// Sha384
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha384(this byte[] bytes, bool isUpper = true)
        {
            return SecurityCommon.Sha384(bytes, isUpper);
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

        /// <summary>
        /// Sha512加密
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha512(this Stream stream, bool isUpper = true)
        {
            return SecurityCommon.Sha512(stream, isUpper);
        }

        /// <summary>
        /// Sha512加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha512(this byte[] bytes, bool isUpper = true)
        {
            return SecurityCommon.Sha512(bytes, isUpper);
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
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha1(this string str, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha1(str, key, encoding);
        }

        /// <summary>
        /// HMacSha1加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha1(this byte[] bytes, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha1(bytes, key, encoding);
        }

        /// <summary>
        /// HMacSha1加密
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha1(this Stream stream, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha1(stream, key, encoding);
        }

        #endregion

        #region HMacSha256

        /// <summary>
        /// HMacSha256
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha256(this string str, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha256(str, key, encoding);
        }

        /// <summary>
        /// HMacSha256
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha256(this byte[] bytes, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha256(bytes, key, encoding);
        }

        /// <summary>
        /// HMacSha256
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha256(this Stream stream, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha256(stream, key, encoding);
        }

        #endregion

        #region HMacSha384

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha384(this string str, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha384(str, key, encoding);
        }

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha384(this byte[] bytes, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha384(bytes, key, encoding);
        }

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="stream">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha384(this Stream stream, string key, Encoding encoding = null)
        {
            encoding = encoding ?? new UTF8Encoding();
            return SecurityCommon.HMacSha384(stream, key, encoding);
        }

        #endregion

        #region HMacSha512

        /// <summary>
        /// HMacSha512
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha512(this string str, string key, Encoding encoding = null)
        {
            return SecurityCommon.HMacSha512(str, key, encoding);
        }

        /// <summary>
        /// HMacSha512
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha512(this byte[] bytes, string key, Encoding encoding = null)
        {
            return SecurityCommon.HMacSha512(bytes, key, encoding);
        }

        /// <summary>
        /// HMacSha512
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha512(this Stream stream, string key, Encoding encoding = null)
        {
            return SecurityCommon.HMacSha512(stream, key, encoding);
        }

        #endregion

        #endregion

        #region Sha加密

        #region 得到sha系列加密信息

        /// <summary>
        /// 得到sha系列加密信息
        /// </summary>
        /// <param name="retval"></param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string GetSha(this byte[] retval, HashAlgorithm hashAlgorithm, bool isUpper)
        {
            var data = hashAlgorithm.ComputeHash(retval);
            StringBuilder sc = new StringBuilder();
            foreach (var t in data)
            {
                sc.Append(isUpper ? t.ToString("X2") : t.ToString("x2"));
            }

            return sc.ToString();
        }

        /// <summary>
        /// 得到sha系列加密信息
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="hashAlgorithm">加密方式</param>
        /// <param name="isUpper">是否大写</param>
        /// <returns></returns>
        public static string GetSha(this Stream stream, HashAlgorithm hashAlgorithm, bool isUpper = true)
        {
            if (stream == null)
            {
                throw new BusinessException("FileStream is Null", ErrorCode.ParamIsNullOrEmpty);
            }

            byte[] retval = hashAlgorithm.ComputeHash(stream);
            stream.Close();
            return GetSha(retval, hashAlgorithm, isUpper);
        }

        #endregion

        #endregion
    }
}
