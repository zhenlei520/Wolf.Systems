// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Enum;

namespace Wolf.Systems.Exception
{
    /// <summary>
    /// 业务异常,可以将Exception消息直接返回给用户
    /// </summary>
    public class BusinessException : BusinessException<int>
    {
        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="content">异常详情</param>
        public BusinessException(string content) :
            base(content, (int)ErrorCode.CustomerError)
        {
        }

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="content">异常详情</param>
        public BusinessException(string content, int? code = null) :
            base(content, code ?? (int)ErrorCode.CustomerError)
        {
        }

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="errorCode">状态码</param>
        /// <param name="content">异常详情</param>
        public BusinessException(string content, ErrorCode errorCode) :
            base(content, (int)errorCode)
        {
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessException<T> : System.Exception
        where T : struct
    {
        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="content">异常详情</param>
        public BusinessException(string content, T code = default(T)) :
            base(new Response<T>(code, content).ToString())
        {
        }
    }
}
