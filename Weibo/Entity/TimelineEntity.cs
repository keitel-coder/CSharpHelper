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
    public class TimelineEntity
    {
        /// <summary>
        /// 微博集合
        /// </summary>
        public IEnumerable<StatusEntity> Statuses { get; set; }

        /// <summary>
        /// 上一条ID
        /// </summary>
        public Int64 Previous_Cursor { get; set; }

        /// <summary>
        ///  下一条ID
        /// </summary>
        public Int64 Next_Cursor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64 Since_Id { get; set; }

        /// <summary>
        /// 最大id
        /// </summary>
        public Int64 Max_Id { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Total_Number { get; set; }

        /// <summary>
        /// 微博暂未支持
        /// </summary>
        public bool HasVisible { get; set; }

        /// <summary>
        /// 更新间隔
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 微博流内的推广微博ID
        /// </summary>
        public ADEntity AD { get; set; }
    }
}
