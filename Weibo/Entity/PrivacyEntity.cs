using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class PrivacyEntity
    {
        /// <summary>
        /// 勋章是否可见，0：不可见、1：可见
        /// </summary>
        public int badge { get; set; }

        /// <summary>
        /// 是否可以评论我的微博，0：所有人、1：关注的人、2：可信用户
        /// </summary>
        public int comment { get; set; }

        /// <summary>
        /// 是否开启地理信息，0：不开启、1：开启
        /// </summary>
        public int geo { get; set; }

        /// <summary>
        /// 是否可以给我发私信，0：所有人、1：我关注的人、2：可信用户
        /// </summary>
        public int message { get; set; }

        /// <summary>
        /// 是否可以通过手机号码搜索到我，0：不可以、1：可以
        /// </summary>
        public int mobile { get; set; }

        /// <summary>
        /// 是否可以通过真名搜索到我，0：不可以、1：可以
        /// </summary>
        public int realname { get; set; }

        /// <summary>
        /// 是否开启webim， 0：不开启、1：开启
        /// </summary>
        public int weiim { get; set; }
    }
}
