using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 评论列表
    /// </summary>
    public class CommentLineEntity
    {
        /// <summary>
        /// 微博集合
        /// </summary>
        public IEnumerable<StatusEntity> Comments { get; set; }

        /// <summary>
        /// 上一条ID
        /// </summary>
        public Int64 Previous_Cursor { get; set; }

        /// <summary>
        ///  下一条ID
        /// </summary>
        public Int64 Next_Cursor { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total_Number { get; set; }

        /// <summary>
        /// 是否支持可见性设置
        /// </summary>
        public bool HasVisible { get; set; }

        /// <summary>
        /// 更新间隔
        /// </summary>
        public int Interval { get; set; }
    }
}
