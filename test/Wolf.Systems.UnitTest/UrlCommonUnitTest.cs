using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolf.Systems.Core.Configuration.Url;
using Xunit;

namespace Wolf.Systems.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class UrlCommonUnitTest
    {
        /// <summary>
        ///
        /// </summary>
        [Fact]
        public void GetTypeTest()
        {
            var url = new Url("http://192.168.6.32:18070/apps/uuptcommon/envs/DEV/clusters/default/namespaces/UUPT.DbConnectConfig/item");
            string path =  url.GetQueryPath(false, false) ;
        }
    }
}
