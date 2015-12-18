using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 获取当前登录用户的API访问频率限制情况
    /// </summary>
    public class RateLimitStatus
    {
        /// <summary>
        /// ip限制
        /// </summary>
        public int ip_limit { get; set; }

        /// <summary>
        /// 超时单位
        /// </summary>
        public string limit_time_unit { get; set; }

        /// <summary>
        /// 剩余ip限制
        /// </summary>
        public int remaining_ip_hits { get; set; }

        /// <summary>
        /// 用户限制
        /// </summary>
        public int user_limit { get; set; }

        /// <summary>
        /// 剩余用户数
        /// </summary>
        public int remaining_user_hits { get; set; }

        /// <summary>
        /// 重置时间
        /// </summary>
        public DateTime reset_time { get; set; }

        /// <summary>
        /// 重置时间秒数
        /// </summary>
        public int reset_time_in_seconds { get; set; }
    }
}
