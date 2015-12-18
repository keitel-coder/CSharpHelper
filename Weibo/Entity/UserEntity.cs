using System;

namespace Weibo.Entity
{
    /// <summary>
    /// 微博用户信息实体
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// 用户UID
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// 字符串型的用户UID
        /// </summary>
        public string IdStr { get; set; }

        /// <summary>
        /// 用户创建（注册）时间
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string screen_Name { get; set; }

        /// <summary>
        /// 友好显示名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 用户所在省级ID
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 用户所在城市ID
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 用户所在地
        /// </summary>
        public string location { get; set; }

        /// <summary>
        /// 用户个人描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 用户博客地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 用户头像地址（中图），50×50像素
        /// </summary>
        public string profile_image_url { get; set; }

        /// <summary>
        /// 用户的微博统一URL地址
        /// </summary>
        public string profile_url { get; set; }

        /// <summary>
        /// 用户的个性化域名
        /// </summary>
        public string domain { get; set; }

        /// <summary>
        /// 用户的微号
        /// </summary>
        public string weihao { get; set; }

        /// <summary>
        /// 性别，m：男、f：女、n：未知
        /// </summary>
        public string gender { get; set; }

        /// <summary>
        /// 粉丝数
        /// </summary>
        public int followers_count { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        public int friends_count { get; set; }

        /// <summary>
        /// 微博数
        /// </summary>
        public int statuses_count { get; set; }

        /// <summary>
        /// 收藏数
        /// </summary>
        public int favourites_count { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        public bool following { get; set; }

        /// <summary>
        /// 是否允许所有人给我发私信，true：是，false：否
        /// </summary>
        public bool allow_all_act_msg { get; set; }

        /// <summary>
        /// 是否允许标识用户的地理位置，true：是，false：否
        /// </summary>
        public bool get_enabled { get; set; }

        /// <summary>
        /// 是否是微博认证用户，即加V用户，true：是，false：否
        /// </summary>
        public bool verified { get; set; }

        /// <summary>
        /// 暂未支持
        /// </summary>
        public int verified_type { get; set; }

        /// <summary>
        /// 认证原因
        /// </summary>
        public string verified_reason { get; set; }

        /// <summary>
        /// 认证联系邮箱
        /// </summary>
        public string verified_contact_email { get; set; }

        /// <summary>
        /// 认证联系电话
        /// </summary>
        public string verified_contact_mobile { get; set; }

        /// <summary>
        /// 认证级别
        /// </summary>
        public int verified_level { get; set; }

        /// <summary>
        /// 认证状态 0：正常
        /// </summary>
        public int verified_state { get; set; }

        /// <summary>
        /// 用户备注信息，只有在查询用户关系时才返回此字段
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 用户最近一条微博的id
        /// </summary>
        public Int64 status_id { get; set; }

        /// <summary>
        /// 用户的最近一条微博信息字段
        /// </summary>
        public StatusEntity Status { get; set; }

        /// <summary>
        /// 是否允许所有人对我的微博进行评论，true：是，false：否
        /// </summary>
        public bool allow_all_comment { get; set; }

        /// <summary>
        /// 用户头像地址（大图），180×180像素
        /// </summary>
        public string avatar_large { get; set; }

        /// <summary>
        /// 用户头像地址（高清），高清头像原图
        /// </summary>
        public string avatar_hd { get; set; }

        /// <summary>
        /// 该用户是否关注当前登录用户，true：是，false：否
        /// </summary>
        public bool follow_me { get; set; }

        /// <summary>
        /// 用户的在线状态，0：不在线、1：在线
        /// </summary>
        public int online_status { get; set; }

        /// <summary>
        /// 用户的互粉数
        /// </summary>
        public int bi_followers_count { get; set; }

        /// <summary>
        /// 用户当前的语言版本，zh-cn：简体中文，zh-tw：繁体中文，en：英语
        /// </summary>
        public string lang { get; set; }
    }
}
