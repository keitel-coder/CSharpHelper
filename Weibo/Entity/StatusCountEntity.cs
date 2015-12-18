using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博数量实体
    /// </summary>
    public class StatusCountEntity
    {
        /// <summary>
        /// 微博id
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        public int Comments { get; set; }

        /// <summary>
        /// 转发数
        /// </summary>
        public int Reposts { get; set; }
    }
}
