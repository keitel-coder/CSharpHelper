using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// Token信息
    /// </summary>
    public class AccessTokenEntity
    {
        /// <summary>
        /// 用于调用AccessToken，接口获取授权后的access token。
        /// </summary>
        public string Access_Token { get; set; }

        /// <summary>
        /// 当前授权用户的UID。
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// AccessToken的生命周期，单位是秒数。
        /// </summary>
        public int Expires_In { get; set; }

        /// <summary>
        /// AccessToken的生命周期（该参数即将废弃，开发者请使用expires）。
        /// </summary>
        public string Remind_In { get; set; }
    }
}
