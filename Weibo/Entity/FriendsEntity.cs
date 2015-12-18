using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博列表
    /// </summary>
    public class UsersEntity
    {
        /// <summary>
        /// 微博集合
        /// </summary>
        public IEnumerable<UserEntity> users { get; set; }

        /// <summary>
        /// 上一条ID
        /// </summary>
        public Int64 previous_cursor { get; set; }

        /// <summary>
        ///  下一条ID
        /// </summary>
        public Int64 next_cursor { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int total_number { get; set; }
    }
}
