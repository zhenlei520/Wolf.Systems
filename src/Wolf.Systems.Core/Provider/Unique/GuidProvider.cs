// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Abstracts;

namespace Wolf.Systems.Core.Provider.Unique
{
    /// <summary>
    ///
    /// </summary>
    public class GuidProvider:IUniqueProvider
    {
        /// <summary>
        ///
        /// </summary>
        public int Type => (int) Wolf.Systems.Enum.SequentialGuidType.Guid;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }
}
