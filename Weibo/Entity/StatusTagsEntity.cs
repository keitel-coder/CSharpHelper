using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博标签实体集
    /// </summary>
    public class StatusTagsEntity
    {
        /// <summary>
        /// 总数量
        /// </summary>
        public int total_num { get; set; }

        /// <summary>
        /// 标签实体集合
        /// </summary>
        public IEnumerable<StatusTagEntity> tags { get; set; }
    }
}
