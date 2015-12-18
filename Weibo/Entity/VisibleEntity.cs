using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weibo.Enums;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博可见性
    /// </summary>
    public class VisibleEntity
    {
        /// <summary>
        /// 微博的可见性
        /// </summary>
        public VisableType Type { get; set; }

        /// <summary>
        /// 分组的组号
        /// </summary>
        public int List_Id { get; set; }
    }
}
