// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core.Provider.Security;

/// <summary>
/// Des加解密
/// </summary>
public class DesProvider : ISecurityProvider
{
    /// <summary>
    /// 默认Iv
    /// </summary>
    private static byte[] Iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

    /// <summary>
    /// 加密方式
    /// </summary>
    public int Type => (int)SecurityType.Des;

    /// <summary>
    /// Des加密
    /// </summary>
    /// <param name="str">待加密的字符串</param>
    /// <param name="key">秘钥</param>
    /// <param name="iv">向量</param>
    /// <param name="encoding">编码方式</param>
    /// <returns>返回加密后的字符串</returns>
    public string Encrypt(string str, string key, string iv, Encoding encoding)
    {
        Check(key, iv);
        var cryptoTransform = GetCryptoTransform(key.SafeString(), iv.SafeString(),
            CipherMode.CBC,
            PaddingMode.PKCS7, encoding, true);
        var toEncryptArray = str.ConvertToByteArray(encoding);
        return GetResult(str, cryptoTransform, toEncryptArray).ConvertToBase64();
    }

    /// <summary>
    /// Des解密
    /// </summary>
    /// <param name="str">待解密的字符串</param>
    /// <param name="key">秘钥</param>
    /// <param name="iv">向量</param>
    /// <param name="encoding">编码方式</param>
    /// <returns>返回解密后的字符串</returns>
    public string Decrypt(string str, string key, string iv, Encoding encoding)
    {
        Check(key, iv);
        var cryptoTransform = GetCryptoTransform(key, iv,
            CipherMode.CBC,
            PaddingMode.PKCS7, encoding, false);
        var toEncryptArray = str.ConvertToBase64ByteArray();
        return GetResult(str, cryptoTransform, toEncryptArray).ConvertToString(encoding);
    }


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
            throw new BusinessException("The Des secret key cannot be empty", ErrorCode.ParamError);
        }

        if (key.Length != 8)
        {
            throw new BusinessException("Des secret key length must be 8 bits", ErrorCode.ParamError);
        }

        if (!iv.IsNullOrWhiteSpace() && iv.Length != 8)
        {
            throw new BusinessException("Des Iv Is Empty Or Iv length must be 8 bits", ErrorCode.ParamError);
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
        DESCryptoServiceProvider des = new DESCryptoServiceProvider()
        {
            Key = key.ConvertToByteArray(encoding),
            IV = iv.IsNullOrWhiteSpace() ? Iv : iv.ConvertToByteArray(encoding),
            Mode = cipherMode,
            Padding = paddingMode
        };
        if (!iv.IsNullOrWhiteSpace())
        {
            des.IV = iv.ConvertToByteArray(encoding);
        }

        return isEncrypt ? des.CreateEncryptor() : des.CreateDecryptor();
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

        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cs.Write(toEncryptArray, 0, toEncryptArray.Length);
                cs.FlushFinalBlock();
            }

            return ms.ToArray();
        }
    }

    #endregion

    #endregion
}
