using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// OAuth2的authorize接口
    /// </summary>
    public class AuthorizeEntity
    {
        /// <summary>
        /// 用于调用access_token，接口获取授权后的access token。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 如果传递参数，会回传该参数。
        /// </summary>
        public string State { get; set; }
    }
}
