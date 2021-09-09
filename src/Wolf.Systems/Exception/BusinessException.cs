// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
        /// <param name="msg">错误原因</param>
        public BusinessException(string msg) :
            base(msg, (int)ErrorCode.CustomerError)
        {
        }

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="msg">错误原因</param>
        /// <param name="code">状态码</param>
        public BusinessException(string msg, int code) :
            base(msg, code)
        {
        }

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="msg">错误原因</param>
        /// <param name="code">状态码</param>
        public BusinessException(string msg, ErrorCode code) :
            base(msg, (int)code)
        {
        }
        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="msg">错误原因</param>
        /// <param name="error">错误扩展信息</param>
        public BusinessException(string msg,  object error) :
            this(msg, ErrorCode.CustomerError, error)
        {
        }

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="msg">错误原因</param>
        /// <param name="code">状态码</param>
        /// <param name="error">错误扩展信息</param>
        public BusinessException(string msg, ErrorCode code, object error) :
            base(msg, (int)code, error)
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
        /// 错误状态码
        /// </summary>
        public T Code { get; set; }

        /// <summary>
        /// 错误扩展信息
        /// </summary>
        public object Error { get; set; }

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="msg">异常详情</param>
        /// <param name="code">状态码</param>
        public BusinessException(string msg, T code = default(T)) :
            base(msg) => Code = code;

        /// <summary>
        /// 业务异常
        /// </summary>
        /// <param name="msg">异常详情</param>
        /// <param name="code">状态码</param>
        /// <param name="error">错误扩展信息</param>
        public BusinessException(string msg, T code, object error) :
            this(msg) => Error = error;
    }
}
