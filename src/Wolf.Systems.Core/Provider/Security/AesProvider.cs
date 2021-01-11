// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Security.Cryptography;
using System.Text;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core.Provider.Security
{
    /// <summary>
    /// Aes
    /// 加解密
    /// </summary>
    public class AesProvider : ISecurityProvider
    {
        /// <summary>
        /// 加密方式
        /// </summary>
        public int Type => (int) SecurityType.Aes;

        #region Aes加密

        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回加密后的字符串</returns>
        public string Encrypt(string str, string key, string iv, Encoding encoding)
        {
            Check(key);
            var cryptoTransform = GetCryptoTransform(key, iv,
                CipherMode.ECB,
                PaddingMode.PKCS7, encoding, true);
            var toEncryptArray = str.ConvertToByteArray(encoding);
            return GetResult(str, cryptoTransform, toEncryptArray).ConvertToBase64(0);
        }

        #endregion

        #region Aes解密

        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="str">待解密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回解密后的字符串</returns>
        public string Decrypt(string str, string key, string iv, Encoding encoding)
        {
            Check(key);
            var cryptoTransform = GetCryptoTransform(key, iv,
                CipherMode.ECB,
                PaddingMode.PKCS7, encoding, false);
            var toEncryptArray = str.ConvertToBase64ByteArray();
            return GetResult(str, cryptoTransform, toEncryptArray).ConvertToString(encoding);
        }

        #endregion

        #region private methods

        #region 校验秘钥

        /// <summary>
        /// 校验秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        private void Check(string key)
        {
            if (key.IsNullOrWhiteSpace() || key.Length != 32)
            {
                throw new BusinessException("The Aes secret key cannot be empty", ErrorCode.ParamError);
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
                Mode = cipherMode,
                Padding = paddingMode
            };
            if (!iv.IsNullOrWhiteSpace())
            {
                rijndaelManaged.IV = iv.ConvertToByteArray(encoding);
            }

            return isEncrypt ? rijndaelManaged.CreateEncryptor() : rijndaelManaged.CreateDecryptor();
        }

        #endregion

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
