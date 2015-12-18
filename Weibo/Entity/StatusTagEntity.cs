using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博标签实体
    /// </summary>
    public class StatusTagEntity
    {
        /// <summary>
        /// 标签名
        /// </summary>
        public string tag { get; set; }

        /// <summary>
        /// 属于此标签的微博数
        /// </summary>
        public int num { get; set; }
    }
}
