using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 备注实体
    /// </summary>
    public class RemarkEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string remark { get; set; }
    }
}
