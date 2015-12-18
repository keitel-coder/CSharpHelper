using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 用户统计信息实体
    /// </summary>
    public class UsersCountEntity
    {
        /// <summary>
        /// 微博id
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// 粉丝数
        /// </summary>
        public int followers_count { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        public int friends_count { get; set; }

        /// <summary>
        /// 微博数
        /// </summary>
        public int statuses_count { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        public int private_friends_count { get; set; }
    }
}
