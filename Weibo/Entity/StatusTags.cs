using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博标签实体
    /// </summary>
    public class StatusTags
    {
        /// <summary>
        /// 微博id
        /// </summary>
        public Int64 status_id { get; set; }

        /// <summary>
        /// 属于此微博的此标签
        /// </summary>
        public IEnumerable<string> tags { get; set; }
    }
}
