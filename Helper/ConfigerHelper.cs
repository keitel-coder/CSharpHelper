using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class ConfigerHelper
    {
        /// <summary>
        /// 得到
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetAppSetting(string name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            ConnectionStringSettings connSetting = ConfigurationManager.ConnectionStrings[name];
            if (connSetting != null)
            {
                return connSetting.ConnectionString;
            }
            else return null;
        }
    }
}
