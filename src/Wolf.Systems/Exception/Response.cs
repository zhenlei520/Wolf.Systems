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
        /// <param name="code">异常码</param>
        /// <param name="content">异常描述</param>
        /// <param name="extend">扩展信息</param>
        public Response(T code, string content, object extend = null) : this()
        {
            this.Code = code;
            this.Content = content;
            this.Extend = extend;
        }

        /// <summary>
        /// 异常码
        /// </summary>
        protected virtual T Code { get; set; }

        /// <summary>
        /// 异常响应内容
        /// </summary>
        protected virtual string Content { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        protected virtual object Extend { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{\"Code\":{" + Code + "},\"Content\":{\"" + Content + "\"}";
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
        /// <param name="code">异常码</param>
        /// <param name="content">异常描述</param>
        /// <param name="extend">扩展信息</param>
        public Response(string code, string content, object extend = null) : this()
        {
            this.Code = code;
            this.Content = content;
            this.Extend = extend;
        }

        /// <summary>
        /// 异常码
        /// </summary>
        protected virtual string Code { get; set; }

        /// <summary>
        /// 异常响应内容
        /// </summary>
        protected virtual string Content { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        protected virtual object Extend { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{\"Code\":{\"" + Code + "\"},\"Content\":{\"" + Content + "\"}";
        }
    }
}
