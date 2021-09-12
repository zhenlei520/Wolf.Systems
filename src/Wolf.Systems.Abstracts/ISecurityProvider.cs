// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Abstracts;

/// <summary>
///
/// </summary>
public interface ISecurityProvider
{
    /// <summary>
    /// 加密方式
    /// </summary>
    int Type { get; }

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="str">待加密的字符串</param>
    /// <param name="key">秘钥</param>
    /// <param name="iv">向量</param>
    /// <param name="encoding">编码方式</param>
    /// <returns>返回加密后的字符串</returns>
    string Encrypt(string str, string key, string iv, Encoding encoding);

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="str">待解密的字符串</param>
    /// <param name="key">秘钥</param>
    /// <param name="iv">向量</param>
    /// <param name="encoding">编码方式</param>
    /// <returns>返回解密后的字符串</returns>
    string Decrypt(string str, string key, string iv, Encoding encoding);
}
