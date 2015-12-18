using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 标签实体集
    /// </summary>
    public class TagsEntity
    {
        /// <summary>
        /// 标签集
        /// </summary>
        public IEnumerable<TagEntity> Tags { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int total_number { get; set; }
    }
}
