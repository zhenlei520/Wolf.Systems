// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Exception
{
    /// <summary>
    /// 异常
    /// </summary>
    public class Response<T> where T : struct
    {
        /// <summary>
        ///
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">提示信息</param>
        /// <param name="extend">扩展信息</param>
        public Response(T code, string message, object extend = null) : this()
        {
            this.Code = code;
            this.Message = message;
            this.Extend = extend;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        public virtual T Code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        public virtual object Extend { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{\"Code\":" + Code + ",\"Message\":\"" + (Message??"") + "\",\"Extend\":\"" + (Extend??"") +
                   "\"}";
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class Response
    {
        /// <summary>
        ///
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">提示信息</param>
        /// <param name="extend">扩展信息</param>
        public Response(string code, string message, object extend = null) : this()
        {
            this.Code = code;
            this.Message = message;
            this.Extend = extend;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        public virtual object Extend { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{\"Code\":" + Code + ",\"Content\":\"" + Message + "\",\"Extend\":\"" + Extend.ToString() +
                   "\"}";
        }
    }
}
