using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 表情实体类
    /// </summary>
    public class EmotionEntity
    {
        /// <summary>
        /// 分类
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// 是否公用
        /// </summary>
        public bool common { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public bool hot { get; set; }

        /// <summary>
        /// 表情
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 表情措辞
        /// </summary>
        public string phrase { get; set; }

        /// <summary>
        /// 待定
        /// </summary>
        public string picid { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }
    }
}
