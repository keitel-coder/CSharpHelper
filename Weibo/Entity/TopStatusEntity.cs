using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 置顶微博实体
    /// </summary>
    public class TopStatusEntity
    {
        /// <summary>
        /// 微博id
        /// </summary>
        public Int64 uid { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        public Int64 mid { get; set; }

        /// <summary>
        /// 转发数
        /// </summary>
        public bool is_use { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_at { get; set; }
    }
}
