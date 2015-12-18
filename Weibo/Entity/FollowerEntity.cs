using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 两个用户之间的关注情况
    /// </summary>
    public class FollowerEntity
    {
        /// <summary>
        /// 原用户
        /// </summary>
        public UserFollowerEntity source { get; set; }

        /// <summary>
        /// 目标用户
        /// </summary>
        public UserFollowerEntity target { get; set; }
    }
}