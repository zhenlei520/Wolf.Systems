// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core
{
    /// <summary>
    /// DataSet扩展
    /// </summary>
    public partial class Extensions
    {
        #region DataSet转换为Json

        /// <summary>
        /// DataSet转换为Json
        /// </summary>
        /// <param name="dataSet">DataSet对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(this DataSet dataSet)
        {
            StringBuilder stringBuilder = new StringBuilder("{");
            foreach (DataTable table in dataSet.Tables)
            {
                stringBuilder.Append("\"" + table.TableName + "\":" + table.ConvertToJson() + ",");
            }

            return stringBuilder.ToString().TrimEnd(',') + "}";
        }

        #endregion
    }
}
