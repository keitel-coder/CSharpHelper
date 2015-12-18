using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博id集合
    /// </summary>
    public class StatuseIdsEntity
    {
        /// <summary>
        /// ID集合
        /// </summary>
        public IEnumerable<string> statuses { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int total_number { get; set; }

        /// <summary>
        /// 上一个游标
        /// </summary>
        public int previous_cursor { get; set; }

        /// <summary>
        /// 下一个游标
        /// </summary>
        public int next_cursor { get; set; }
    }
}
