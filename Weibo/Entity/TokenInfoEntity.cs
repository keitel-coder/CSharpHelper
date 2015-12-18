using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// AccessToken信息
    /// </summary>
    public class TokenInfoEntity
    {
        /// <summary>
        /// 授权用户的uid
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// access_token所属的应用appkey
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 用户授权的scope权限
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// access_token的创建时间，从1970年到创建时间的秒数。
        /// </summary>
        public string Create_at { get; set; }

        /// <summary>
        /// access_token的剩余时间，单位是秒数。
        /// </summary>
        public string Expire_in { get; set; }
    }
}
