﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core.Internal.Security
{
    /// <summary>
    /// Js 加解密
    /// </summary>
    public class JsAesProvider : SecurityProvider
    {
        /// <summary>
        /// 加密方式
        /// </summary>
        public override int Type => (int) SecurityType.JsAes;

        #region JsAes加密

        /// <summary>
        /// JsAes加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回加密后的字符串</returns>
        public override string Encrypt(string str, string key, string iv, Encoding encoding)
        {
            Check(key, iv);
            var cryptoTransform = GetCryptoTransform(key, iv,
                CipherMode.CBC,
                PaddingMode.PKCS7, encoding, true);
            byte[] encrypted;
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, cryptoTransform, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(str);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }

            return ByteArrayToHex(encrypted);
        }

        #endregion

        #region JsAes解密

        /// <summary>
        /// JsAes解密
        /// </summary>
        /// <param name="str">待解密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回解密后的字符串</returns>
        public override string Decrypt(string str, string key, string iv, Encoding encoding)
        {
            Check(key, iv);
            var cryptoTransform = GetCryptoTransform(key, iv,
                CipherMode.CBC,
                PaddingMode.PKCS7, encoding, false);
            byte[] encrypted;
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, cryptoTransform, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(str);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return ByteArrayToHex(encrypted);
        }

        #endregion

        #region private methods

        #region 校验秘钥

        /// <summary>
        /// 校验秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        private void Check(string key, string iv)
        {
            if (key.IsNullOrWhiteSpace())
            {
                throw new BusinessException("The JsAes secret key cannot be empty");
            }

            if (key.Length != 32)
            {
                throw new BusinessException("JsAes secret key length must be 32 bits");
            }

            if (iv.IsNullOrWhiteSpace())
            {
                throw new BusinessException("The JsAes Iv cannot be empty");
            }
        }

        #endregion

        #region 得到ICryptoTransform

        /// <summary>
        /// 得到ICryptoTransform
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <param name="encoding"></param>
        /// <param name="isEncrypt">是否加密，加密：true，解密：false</param>
        /// <returns></returns>
        private ICryptoTransform GetCryptoTransform(string key, string iv, CipherMode cipherMode,
            PaddingMode paddingMode, Encoding encoding, bool isEncrypt)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged
            {
                Key = key.ConvertToByteArray(encoding),
                IV = iv.ConvertToByteArray(encoding),
                Mode = cipherMode,
                Padding = paddingMode,
                FeedbackSize = 128
            };

            return isEncrypt ? rijndaelManaged.CreateEncryptor() : rijndaelManaged.CreateDecryptor();
        }

        #endregion

        private byte[] HexToByteArray(string hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private string ByteArrayToHex(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        #region 得到结果

        /// <summary>
        /// 得到结果
        /// </summary>
        /// <param name="str">待加密/解密的字符串</param>
        /// <param name="cryptoTransform"></param>
        /// <param name="toEncryptArray"></param>
        /// <returns></returns>
        private byte[] GetResult(string str, ICryptoTransform cryptoTransform, byte[] toEncryptArray)
        {
            if (str.IsNullOrWhiteSpace())
            {
                return null;
            }

            return cryptoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        }

        #endregion

        #endregion
    }
}
