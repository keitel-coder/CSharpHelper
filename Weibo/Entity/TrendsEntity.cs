using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 话题集合实体
    /// </summary>
    public class TrendsEntity
    {
        /// <summary>
        /// 话题集合
        /// </summary>
        public IEnumerable<TrendEntity> trends { get; set; }

        /// <summary>
        /// 从..开始
        /// </summary>
        public Int64 as_of { get; set; }
    }
}
