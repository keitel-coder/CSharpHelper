using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Enums
{
    /// <summary>
    /// 微博的可见性
    /// </summary>
    public enum VisableType
    {
        /// <summary>
        /// 普通微博
        /// </summary>
        Common = 1,
        /// <summary>
        /// 私密微博
        /// </summary>
        Private = 2,
        /// <summary>
        /// 指定分组微博
        /// </summary>
        Group = 3,
        /// <summary>
        /// 密友微博
        /// </summary>
        Friends = 4
    }
}
