﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.Core
{
  /// <summary>
  /// Queue扩展
  /// </summary>
  public partial class Extensions
    {
        #region Queue转List

        /// <summary>
        /// Queue转List
        /// </summary>
        /// <param name="queues"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this Queue<T> queues)
        {
            List<T> list = new List<T>();
            while (queues.Count > 0)
            {
                list.Add(queues.Dequeue());
            }

            return list;
        }

        #endregion
    }
}
