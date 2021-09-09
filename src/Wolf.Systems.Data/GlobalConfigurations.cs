// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;
using Wolf.Systems.Core.Provider.Unique;
using Wolf.Systems.Data.Provider.Unique;

namespace Wolf.Systems.Data
{
    /// <summary>
    ///
    /// </summary>
    public class GlobalConfigurations : Wolf.Systems.Core.GlobalConfigurations
    {
        /// <summary>
        ///
        /// </summary>
        public GlobalConfigurations()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            ResetGuidGeneratorProviders();
        }

        #region 重置唯一标识提供者为初始状态

        /// <summary>
        /// 重置唯一标识提供者为初始状态
        /// </summary>
        /// <returns></returns>
        protected override void ResetGuidGeneratorProviders()
        {
            GuidGenerators = new List<IGuidGeneratorProvider>()
            {
                new GuidProvider(),
                new SequentialAsStringProvider(),
                new SequentialAsBinaryProvider(),
                new SequentialAtEndProvider()
            };
        }

        #endregion
    }
}
