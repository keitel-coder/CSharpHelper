using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 用户关注实体
    /// </summary>
    public class UserFollowerEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// 用户的微博昵称。
        /// </summary>
        public string screen_name { get; set; }

        /// <summary>
        /// 是否被关注（对方）
        /// </summary>
        public bool followed_by { get; set; }

        /// <summary>
        /// 是否关注（对方）
        /// </summary>
        public bool following { get; set; }

        /// <summary>
        /// 通知是否启用
        /// </summary>
        public bool notifications_enabled { get; set; }
    }
}