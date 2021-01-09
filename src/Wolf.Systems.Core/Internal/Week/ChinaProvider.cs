// Copyright (c) zhenlei520 All rights reserved.

using System.Collections.Generic;
using System.Linq;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;
using Wolf.Systems.Exception;

namespace Wolf.Systems.Core.Internal.Week
{
    /// <summary>
    ///
    /// </summary>
    public class ChinaProvider : WeekProvider
    {
        private readonly List<KeyValuePair<int, string>> _map = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>(1,"星期一"),
            new KeyValuePair<int, string>(2,"星期二"),
            new KeyValuePair<int, string>(3,"星期三"),
            new KeyValuePair<int, string>(4,"星期四"),
            new KeyValuePair<int, string>(5,"星期五"),
            new KeyValuePair<int, string>(6,"星期六"),
            new KeyValuePair<int, string>(7,"星期日")
        };

        /// <summary>
        /// 国家
        /// </summary>
        public override int Nationality => (int) Wolf.Systems.Enum.Nationality.China;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public override string GetName(int serialNumber)
        {
            var res = _map.Where(x => x.Key == serialNumber).Select(x => x.Value).FirstOrDefault();
            if (res.IsNullOrWhiteSpace())
            {
                throw new BusinessException("不支持的日期", ErrorCode.ParamError);
            }

            return res;
        }
    }
}
