using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 话题实体
    /// </summary>
    public class TrendEntity
    {
        /// <summary>
        /// 话题名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 话题查询名
        /// </summary>
        public string query { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 未知
        /// </summary>
        public int delta { get; set; }
    }
}
