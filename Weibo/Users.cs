using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weibo.Entity;
using Weibo.Helper;

namespace Weibo
{
    /// <summary>
    /// 用户接口集合
    /// </summary>
    public static class Users
    {
        private const string linkUrl = "https://api.weibo.com/2/users/";

        /// <summary>
        /// 方法名
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private static string GetUrl(string method)
        {
            return linkUrl + method;
        }

        #region 用户

        #region 读取接口
        /// <summary>
        /// 根据微博ID返回某条微博的评论列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户ID。（当使用昵称查找时，此参数为0）</param>
        /// <param name="screenName">需要查询的用户昵称。（当指定了uid时，此参数应保持默认或设为null）</param>
        /// <remarks>参数uid与screen_name二者必选其一，且只能选其一；接口升级后，对未授权本应用的uid，将无法获取其个人简介、认证原因、粉丝数、关注数、微博数及最近一条微博内容。</remarks>
        /// <returns></returns>
        public static UserEntity Show(string accessToken, Int64 uid, string screenName = null)
        {
            string para = "";
            if (uid > 0)
            {
                para = "&uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "&screen_name=" + screenName;
            }
            else
            {
                return null;
            }
            string url = GetUrl("show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}", url, accessToken, para));
            return JsonHelper.Convert<UserEntity>(value);
        }

        /// <summary>
        /// 通过个性化域名获取用户资料以及用户最新的一条微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="domin">需要查询的个性化域名。</param>
        /// <remarks>接口升级后，对未授权本应用的uid，将无法获取其个人简介、认证原因、粉丝数、关注数、微博数及最近一条微博内容。</remarks>
        /// <returns></returns>
        public static UserEntity DomainShow(string accessToken, string domin)
        {
            string url = GetUrl("domain_show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&domin={2}", url, accessToken, domin));
            return JsonHelper.Convert<UserEntity>(value);
        }

        /// <summary>
        /// 批量获取用户的粉丝数、关注数、微博数
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uids">需要获取数据的用户UID，多个之间用逗号分隔，最多不超过100个。</param>
        /// <returns></returns>
        public static IEnumerable<UsersCountEntity> Counts(string accessToken, string uids)
        {
            string url = GetUrl("counts.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uids={2}", url, accessToken, uids));
            return JsonHelper.Convert<IEnumerable<UsersCountEntity>>(value);
        }
        #endregion

        #endregion

        #region 置顶微博

        #region 读取接口
        /// <summary>
        /// 获取用户主页置顶微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <returns></returns>
        public static TopStatusEntity GetTopStatus(string accessToken, Int64 uid)
        {
            string url = GetUrl("get_top_status.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}", url, accessToken, uid));
            return JsonHelper.Convert<TopStatusEntity>(value);
        }
        #endregion

        #region 写入接口
        /// <summary>
        /// 设置当前用户主页置顶微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要设置为置顶微博的微博ID。</param>
        /// <remarks>由于weibo.com个人页有1天缓存原因，
        /// 导致调用成功后界面仍看不到效果，后期会去掉此缓存；
        /// 只能操作当前登录用户；一个用户同时只能置顶一条微博；
        /// 普通用户有且仅有一次可置顶的试用机会，置顶时长为24小时；
        /// 当用户状态为会员时，使用置顶功能，不受次数、时间限制；</remarks>
        /// <returns></returns>
        public static bool SetTopStatus(string accessToken, Int64 id)
        {
            string url = GetUrl("set_top_status.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}", url, accessToken, id));
            var result = JsonHelper.Convert<ResultEntity>(value);
            return result.Result;
        }

        /// <summary>
        /// 取消当前用户主页置顶微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要取消设置为置顶微博的微博ID。</param>
        /// <remarks>由于weibo.com个人页有1天缓存原因，
        /// 导致调用成功后界面仍看不到效果，后期会去掉此缓存；
        /// 只能操作当前登录用户；一个用户同时只能置顶一条微博；
        /// 普通用户有且仅有一次可置顶的试用机会，置顶时长为24小时；
        /// 当用户状态为会员时，使用置顶功能，不受次数、时间限制；</remarks>
        /// <returns></returns>
        public static bool CancelTopStatus(string accessToken, Int64 id)
        {
            string url = GetUrl("cancel_top_status.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}", url, accessToken, id));
            var result = JsonHelper.Convert<ResultEntity>(value);
            return result.Result;
        }
        #endregion

        #endregion
    }
}
