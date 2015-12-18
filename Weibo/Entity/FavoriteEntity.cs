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
    public class FavoriteEntity
    {
        /// <summary>
        /// 微博实体
        /// </summary>
        public StatusEntity Status { get; set; }

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
