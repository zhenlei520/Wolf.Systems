// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections;
using System.Text;

namespace Wolf.Systems.Core
{
    /// <summary>
    /// Exception扩展
    /// </summary>
    public partial class Extensions
    {
        #region 提取异常及其内部异常堆栈跟踪

        /// <summary>
        /// 提取异常及其内部异常堆栈跟踪
        /// </summary>
        /// <param name="exception">提取的例外</param>
        /// <returns>Syste.String</returns>
        public static string ExtractAllStackTrace(this System.Exception exception) => ExtractAllStackTrace(exception, null, 1);

        /// <summary>
        /// 提取异常及其内部异常堆栈跟踪
        /// </summary>
        /// <param name="exception">提取的例外</param>
        /// <param name="lastStackTrace">最后提取的堆栈跟踪（对于递归）， String.Empty or null</param>
        /// <param name="exCount">提取的堆栈数（对于递归）</param>
        /// <returns>Syste.String</returns>
        private static string ExtractAllStackTrace(this System.Exception exception, string lastStackTrace,
            int exCount)
        {
            var ex = exception;
            const string entryFormat = "#{0}: {1}\r\n{2}";
            //修复最后一个堆栈跟踪参数
            StringBuilder stringBuilder = new StringBuilder(lastStackTrace.SafeString());
            //添加异常的堆栈跟踪
            stringBuilder.Append(string.Format(entryFormat, exCount, ex.Message, ex.StackTrace));
            if (exception.Data.Count > 0)
            {
                stringBuilder.Append("\r\n    Data: ");
                foreach (var item in exception.Data)
                {
                    var entry = (DictionaryEntry)item;
                    stringBuilder.Append($"\r\n\t{entry.Key}: {exception.Data[entry.Key]}");
                }
            }

            lastStackTrace = stringBuilder.ToString();
            //递归添加内部异常
            if ((ex = ex.InnerException) != null)
                return ex.ExtractAllStackTrace($"{lastStackTrace}\r\n\r\n", ++exCount);
            return lastStackTrace;
        }

        #endregion
    }
}