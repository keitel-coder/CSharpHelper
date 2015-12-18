using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 收藏实体
    /// </summary>
    public class FavoriteIdEntity
    {
        /// <summary>
        /// 微博ID
        /// </summary>
        public Int64 status { get; set; }

        /// <summary>
        /// 标签实体集
        /// </summary>
        public IEnumerable<TagEntity> Tags { get; set; }

        /// <summary>
        /// 收藏时间
        /// </summary>
        public string favorited_time { get; set; }
    }
}
