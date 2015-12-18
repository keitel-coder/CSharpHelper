using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 收藏实体集合
    /// </summary>
    public class FavoritesEntity
    {
        /// <summary>
        /// 收藏实体
        /// </summary>
        public IEnumerable<FavoriteEntity> Favorites { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int total_number { get; set; }
    }
}
