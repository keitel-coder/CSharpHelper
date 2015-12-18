using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 获得id集合
    /// </summary>
    public class TimelineIdsEntity
    {
        /// <summary>
        /// 微博id集合
        /// </summary>
        public IEnumerable<Int64> Statuses { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        public Int64 previous_cursor { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        public Int64 next_cursor { get; set; }

        /// <summary>
        /// 总记录条数
        /// </summary>

        public int Total_Number { get; set; }
    }
}
