// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core
{
    /// <summary>
    /// Byte数组扩展
    /// </summary>
    public partial class Extensions
    {
        #region 将 byte[] 转成 Stream

        /// <summary>
        /// 将 byte[] 转成 Stream
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns></returns>
        public static Stream ConvertToStream(this byte[] bytes) => new MemoryStream(bytes);

        #endregion

        #region byte数组转换为string

        /// <summary>
        /// byte数组转换为string
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns></returns>
        public static string ConvertToString(this byte[] bytes) => ConvertToString(bytes, Encoding.UTF8);

        /// <summary>
        /// byte数组转换为string
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ConvertToString(this byte[] bytes, Encoding encoding) => encoding.GetString(bytes);

        #endregion

        #region byte数组转换为base64

        /// <summary>
        /// byte数组转换为base64
        /// </summary>
        /// <param name="param">byte数组</param>
        /// <returns></returns>
        public static string ConvertToBase64(this byte[] param) => Convert.ToBase64String(param);

        /// <summary>
        /// byte数组转换为base64
        /// </summary>
        /// <param name="inArray"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static string ConvertToBase64(this byte[] inArray, int offset) => Convert.ToBase64String(inArray, offset, inArray.Length);

        #endregion

        #region 将byte[]数组保存成文件

        /// <summary>
        /// 将byte[]数组保存成文件
        /// </summary>
        /// <param name="byteArray">byte[]数组</param>
        /// <param name="localFilePath">保存至硬盘的文件路径</param>
        /// <returns></returns>
        public static bool SaveByteToFile(this byte[] byteArray, string localFilePath)
        {
            bool result;
            try
            {
                using (FileStream fs = new FileStream(localFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        #endregion
    }
}
