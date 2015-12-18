using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博实体（包括微博和评论）
    /// </summary>
    public class StatusEntity
    {
        /// <summary>
        /// 微博创建时间
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// 微博ID
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// 微博MID
        /// </summary>
        public Int64 mid { get; set; }

        /// <summary>
        /// 字符串型的微博ID
        /// </summary>
        public string idstr { get; set; }

        /// <summary>
        /// 微博信息内容
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 微博来源
        /// </summary>
        public string source { get; set; }

        /// <summary>
        /// 元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，字串长度不超过512个字符，具体内容可以自定。
        /// </summary>
        public IEnumerable<object> annotations { get; set; }

        /// <summary>
        /// 是否已收藏，true：是，false：否
        /// </summary>
        public bool favorited { get; set; }

        /// <summary>
        /// 是否被截断，true：是，false：否
        /// </summary>
        public bool truncated { get; set; }

        /// <summary>
        /// （暂未支持）回复ID
        /// </summary>
        public string In_Reply_To_Status_Id { get; set; }

        /// <summary>
        /// （暂未支持）回复人UID
        /// </summary>
        public string In_Reply_To_User_Id { get; set; }

        /// <summary>
        /// （暂未支持）回复人昵称
        /// </summary>
        public string In_Reply_To_Screen_Name { get; set; }

        /// <summary>
        /// 缩略图片地址，没有时为null
        /// </summary>
        public string thumbnail_pic { get; set; }

        /// <summary>
        /// 中等尺寸图片地址，没有时不返回此字段
        /// </summary>
        public string Bmiddle_Pic { get; set; }

        /// <summary>
        /// 原始图片地址，没有时不返回此字段
        /// </summary>
        public string original_pic { get; set; }

        /// <summary>
        /// 地理信息
        /// </summary>
        public GeoEntity Geo { get; set; }

        /// <summary>
        /// 微博作者的用户信息
        /// </summary>

        public UserEntity User { get; set; }

        /// <summary>
        /// 被转发的原微博信息字段，当该微博为转发微博时返回
        /// </summary>

        public StatusEntity Retweeted_status { get; set; }

        /// <summary>
        /// 转发数
        /// </summary>
        public int reposts_count { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        public int comments_count { get; set; }

        /// <summary>
        /// 表态数
        /// </summary>
        public int attitudes_count { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        public int mlevel { get; set; }

        /// <summary>
        /// 微博的可见性及指定可见分组信息。
        /// </summary>
        public VisibleEntity Visible { get; set; }

        /// <summary>
        /// 微博配图地址。多图时返回多图链接。无配图返回“[]”
        /// </summary>
        public IEnumerable<PictureEntity> pic_urls { get; set; }

        /// <summary>
        /// 微博流内的推广微博ID
        /// </summary>
        public IEnumerable<int> ad { get; set; }
    }
}
