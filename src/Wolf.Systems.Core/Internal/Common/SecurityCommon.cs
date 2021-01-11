// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Wolf.Systems.Core.Internal.Common
{
    /// <summary>
    /// 加密帮助类
    /// </summary>
    internal class SecurityCommon
    {
        #region MD5加密

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="encoding">编码方式（默认Utf-8）</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        public static string GetMd5HashBy16(string str, Encoding encoding, bool isUpper = true)
        {
            return GetMd5Hash(str, true, encoding, isUpper);
        }

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        public static string GetMd5HashBy16(byte[] bytes, bool isUpper = true)
        {
            return GetMd5Hash(bytes, true, isUpper);
        }

        /// <summary>
        /// Md5加密，返回16位结果
        /// </summary>
        /// <param name="stream">待加密字符串</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        public static string GetMd5HashBy16(Stream stream, bool isUpper = true)
        {
            return GetMd5Hash(stream, true, isUpper);
        }

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="encoding">编码方式（默认Utf-8）</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        /// <returns></returns>
        public static string GetMd5Hash(string str, Encoding encoding = null, bool isUpper = true)
        {
            return GetMd5Hash(str, false, encoding, isUpper);
        }

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="bytes">待加密字符串</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        /// <returns></returns>
        public static string GetMd5Hash(byte[] bytes, bool isUpper = true)
        {
            return GetMd5Hash(bytes, false, isUpper);
        }

        /// <summary>
        /// MD5加密(32位)
        /// </summary>
        /// <param name="stream">待加密字符串</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        /// <returns></returns>
        public static string GetMd5Hash(Stream stream,  bool isUpper = true)
        {
            return GetMd5Hash(stream, false, isUpper);
        }

        /// <summary>
        /// 得到md5加密结果
        /// </summary>
        /// <param name="input">待加密字符串</param>
        /// <param name="is16">是否16位加密，是否32位加密</param>
        /// <param name="encoding">编码方式（默认Utf-8）</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        /// <returns></returns>
        private static string GetMd5Hash(string input, bool is16, Encoding encoding, bool isUpper = true)
        {
            var signed = Md5CryptoServiceProvider.ComputeHash(encoding.GetBytes(input));
            string signResult = is16 ? GetSignResult(signed, 4, 8) : GetSignResult(signed);
            return isUpper ? signResult.ToUpper() : signResult.ToLower();
        }

        /// <summary>
        /// 得到md5加密结果
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="is16">是否16位加密，是否32位加密</param>
        /// <param name="isUpper">是否转大写,默认：true</param>
        /// <returns></returns>
        private static string GetMd5Hash(byte[] bytes, bool is16, bool isUpper)
        {
            var signed = Md5CryptoServiceProvider.ComputeHash(bytes);
            string signResult = is16 ? GetSignResult(signed, 4, 8) : GetSignResult(signed);
            return isUpper ? signResult.ToUpper() : signResult.ToLower();
        }

        /// <summary>
        /// 得到md5加密结果
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="is16">是否16位加密，是否32位加密</param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        private static string GetMd5Hash(Stream stream, bool is16, bool isUpper)
        {
            var signed = Md5CryptoServiceProvider.ComputeHash(stream);
            string signResult = is16 ? GetSignResult(signed, 4, 8) : GetSignResult(signed);
            return isUpper ? signResult.ToUpper() : signResult.ToLower();
        }

        /// <summary>
        /// MD5加密方法
        /// startIndex为空为32位加密
        /// </summary>
        /// <param name="signed"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetSignResult(byte[] signed, int? startIndex = null, int? length = null)
        {
            return (startIndex == null
                ? BitConverter.ToString(signed)
                : BitConverter.ToString(signed, (int) startIndex, length ?? default(int))).Replace("-", string.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        private static readonly MD5 Md5CryptoServiceProvider = MD5.Create();

        #endregion

        #region Sha加密

        #region Sha1加密

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha1(string str, bool isUpper = true)
        {
            var enc = new ASCIIEncoding(); //将str转换成byte[]
            using (var hashAlgorithm = new SHA1Managed())
            {
                return enc.GetBytes(str).GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha1(Stream stream, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA1Managed())
            {
                return stream.ConvertToByteArray().GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha1
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha1(byte[] bytes, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA1Managed())
            {
                return bytes.GetSha(hashAlgorithm, isUpper);
            }
        }

        #endregion

        #region Sha256加密

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha256(string str, bool isUpper = true)
        {
            var enc = new ASCIIEncoding(); //将mystr转换成byte[]
            using (var hashAlgorithm = new SHA256Managed())
            {
                return enc.GetBytes(str).GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha256(Stream stream, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA256Managed())
            {
                return stream.ConvertToByteArray().GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha256
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha256(byte[] bytes, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA256Managed())
            {
                return bytes.GetSha(hashAlgorithm, isUpper);
            }
        }

        #endregion

        #region Sha384加密

        /// <summary>
        /// Sha384
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha384(string str, bool isUpper = true)
        {
            var enc = new ASCIIEncoding(); //将mystr转换成byte[]
            using (var hashAlgorithm = new SHA384Managed())
            {
                return enc.GetBytes(str).GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha384
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha384(Stream stream, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA384Managed())
            {
                return stream.ConvertToByteArray().GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha384
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha384(byte[] bytes, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA384Managed())
            {
                return bytes.GetSha(hashAlgorithm, isUpper);
            }
        }

        #endregion

        #region Sha512加密

        /// <summary>
        /// Sha512加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha512(string str, bool isUpper = true)
        {
            var enc = new ASCIIEncoding(); //将mystr转换成byte[]
            using (var hashAlgorithm = new SHA512Managed())
            {
                return enc.GetBytes(str).GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha512加密
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha512(Stream stream, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA512Managed())
            {
                return stream.ConvertToByteArray().GetSha(hashAlgorithm, isUpper);
            }
        }

        /// <summary>
        /// Sha512加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper">是否转大写</param>
        /// <returns></returns>
        public static string Sha512(byte[] bytes, bool isUpper = true)
        {
            using (var hashAlgorithm = new SHA512Managed())
            {
                return bytes.GetSha(hashAlgorithm, isUpper);
            }
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
        public static string HMacSha1(string str, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA1(keyByte), str, encoding);
        }

        /// <summary>
        /// HMacSha1加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha1(byte[] bytes, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA1(keyByte), bytes);
        }

        /// <summary>
        /// HMacSha1加密
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha1(Stream stream, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA1(keyByte), stream);
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
        public static string HMacSha256(string str, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA256(keyByte), str, encoding);
        }

        /// <summary>
        /// HMacSha256
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha256(byte[] bytes, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA256(keyByte), bytes);
        }

        /// <summary>
        /// HMacSha256
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha256(Stream stream, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA256(keyByte), stream);
        }

        #endregion

        #region HMacSha384

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <param name="key">盐</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HMacSha384(string str, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA384(keyByte), str, encoding);
        }

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HMacSha384(byte[] bytes, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA384(keyByte), bytes);
        }

        /// <summary>
        /// HMacSha384
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HMacSha384(Stream stream, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA384(keyByte), stream);
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
        public static string HMacSha512(string str, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA512(keyByte), str, encoding);
        }

        /// <summary>
        /// HMacSha512
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha512(byte[] bytes, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA512(keyByte), bytes);
        }

        /// <summary>
        /// HMacSha512
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="key">盐</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        public static string HMacSha512(Stream stream, string key, Encoding encoding)
        {
            byte[] keyByte = encoding.GetBytes(key);
            return GetHMacSha(new HMACSHA512(keyByte), stream);
        }

        #endregion

        #region private methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="hmac"></param>
        /// <param name="str">待价密的字符串</param>
        /// <param name="encoding">编码格式，默认UTF-8</param>
        /// <returns></returns>
        private static string GetHMacSha(HMAC hmac, string str, Encoding encoding)
        {
            byte[] messageBytes = encoding.GetBytes(str);
            byte[] hashmessage = hmac.ComputeHash(messageBytes);
            string res = hashmessage.ConvertToBase64();
            hmac.Dispose();
            return res;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="hmac"></param>
        /// <param name="messageBytes">待加密的数组集合</param>
        /// <returns></returns>
        private static string GetHMacSha(HMAC hmac, byte[] messageBytes)
        {
            byte[] hashmessage = hmac.ComputeHash(messageBytes);
            string res = hashmessage.ConvertToBase64();
            hmac.Dispose();
            return res;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="hmac"></param>
        /// <param name="stream">待加密的流</param>
        /// <returns></returns>
        private static string GetHMacSha(HMAC hmac, Stream stream)
        {
            byte[] hashmessage = hmac.ComputeHash(stream);
            string res = hashmessage.ConvertToBase64();
            hmac.Dispose();
            return res;
        }

        #endregion

        #endregion
    }
}
