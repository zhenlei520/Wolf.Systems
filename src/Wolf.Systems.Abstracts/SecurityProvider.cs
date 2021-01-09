// Copyright (c) zhenlei520 All rights reserved.

using System.Text;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    ///
    /// </summary>
    public abstract class SecurityProvider
    {
        /// <summary>
        /// 加密方式
        /// </summary>
        public abstract int Type { get; }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回加密后的字符串</returns>
        public abstract string Encrypt(string str, string key,string iv,Encoding encoding);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">待解密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <param name="iv">向量</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>返回解密后的字符串</returns>
        public abstract string Decrypt(string str, string key,string iv,Encoding encoding);
    }
}
