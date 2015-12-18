using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Enums
{
    /// <summary>
    /// 授权页面的终端类型
    /// </summary>
    public enum DisplayType
    {
        /// <summary>
        /// 默认的授权页面，适用于web浏览器。
        /// </summary>
        Default,
        /// <summary>
        /// 移动终端的授权页面，适用于支持html5的手机。
        /// </summary>
        Mobile,
        /// <summary>
        /// wap版授权页面，适用于非智能手机。
        /// </summary>
        Wap,
        /// <summary>
        /// 客户端版本授权页面，适用于PC桌面应用。
        /// </summary>
        Client,
        /// <summary>
        /// 默认的站内应用授权页，授权后不返回access_token，只刷新站内应用父框架。
        /// </summary>
        AppOnWeibo
    }
}
