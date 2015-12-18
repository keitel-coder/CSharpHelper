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
    /// 关系接口集合
    /// </summary>
    public static class Friendships
    {
        private const string linkUrl = "https://api.weibo.com/2/friendships/";

        /// <summary>
        /// 方法名
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private static string GetUrl(string method)
        {
            return linkUrl + method;
        }

        #region 关系

        #region 关注读取接口

        /// <summary>
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="screenName">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <param name="trimStatus">返回值中user字段中的status字段开关，0：返回完整status字段、1：status字段仅返回status_id，默认为1。</param>
        /// <remarks>参数uid与screen_name二者必选其一，且只能选其一；接口升级后：uid与screen_name只能为当前授权用户，第三方微博类客户端不受影响；最多可获得总关注量30%的用户，上限为500。</remarks>
        /// <returns></returns>
        public static UsersEntity Friends(string accessToken, Int64 uid, string screenName = null, int count = 50, int cursor = 0, int trimStatus = 1)
        {
            string url = GetUrl("friends.json");
            string para = "";
            if (uid > 0)
            {
                para = "uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "screen_name=" + screenName;
            }
            else
            {
                return null;
            }
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}&count={3}&cursor={4}&trim_status={5}", url, accessToken, para, count, cursor, trimStatus));
            return JsonHelper.Convert<UsersEntity>(value);
        }

        /// <summary>
        /// 获取用户的关注列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="screenName">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为500，最大不超过5000。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <remarks>参数uid与screen_name二者必选其一，且只能选其一；接口升级后：uid与screen_name只能为当前授权用户，第三方微博类客户端不受影响；最多可获得总关注量30%的用户，上限为500。</remarks>
        /// <returns></returns>
        public static IdsEntity FriendsIds(string accessToken, Int64 uid, string screenName = null, int count = 500, int cursor = 0)
        {
            string url = GetUrl("friends/ids.json");
            string para = "";
            if (uid > 0)
            {
                para = "uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "screen_name=" + screenName;
            }
            else
            {
                return null;
            }
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}&count={3}&cursor={4}&trim_status={5}", url, accessToken, para, count, cursor));
            return JsonHelper.Convert<IdsEntity>(value);
        }

        /// <summary>
        /// 批量获取当前登录用户的关注人的备注信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uids">需要获取备注的用户UID，用半角逗号分隔，最多不超过50个。</param>
        /// <returns></returns>
        public static IEnumerable<RemarkEntity> RemarkBatch(string accessToken, string uids)
        {
            if (string.IsNullOrWhiteSpace(uids))
            {
                return null;
            }
            string url = GetUrl("friends/remark_batch.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uids={2}", url, accessToken, uids));
            return JsonHelper.Convert<IEnumerable<RemarkEntity>>(value);
        }

        /// <summary>
        /// 获取两个用户之间的共同关注人列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">>需要获取共同关注关系的用户UID。</param>
        /// <param name="suid">需要获取共同关注关系的用户UID，默认为当前登录用户。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="trim_status">返回值中user字段中的status字段开关，0：返回完整status字段、1：status字段仅返回status_id，默认为1。</param>
        /// <returns></returns>
        public static UsersEntity CommonFriends(string accessToken, Int64 uid, Int64 suid = 0, int count = 50, int page = 1, int trim_status = 1)
        {
            string para = "";
            if (suid > 0)
            {
                para = "&suid=" + suid;
            }
            string url = GetUrl("friends/in_common.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&count={3}&page={4}&trim_status={5}{6}", url, accessToken, uid, count, page, trim_status, para));
            return JsonHelper.Convert<UsersEntity>(value);
        }

        /// <summary>
        /// 获取用户的双向关注列表，即互粉列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">>需要获取共同关注关系的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过2000。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
        /// <remarks>排序功能目前只支持一种；接口升级后：uid只能为当前授权用户，第三方微博类客户端不受影响；最多可获得双向关注总量30%的用户，上限为500。</remarks>
        /// <returns></returns>
        public static UsersEntity BilateralFriends(string accessToken, Int64 uid, int count = 50, int page = 1, int sort = 0)
        {
            string url = GetUrl("friends/bilateral.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&count={3}&page={4}&trim_status={5}", url, accessToken, uid, count, page, sort));
            return JsonHelper.Convert<UsersEntity>(value);
        }

        /// <summary>
        /// 获取用户双向关注的用户ID列表，即互粉UID列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">>需要获取共同关注关系的用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过2000。最多可获得双向关注总量30%的用户，上限为500。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="sort">排序类型，0：按关注时间最近排序，默认为0。</param>
        /// <remarks>排序功能目前只支持一种；接口升级后：uid只能为当前授权用户，第三方微博类客户端不受影响；最多可获得双向关注总量30%的用户，上限为500。</remarks>
        /// <returns></returns>
        public static IdsEntity BilateralFriendsIds(string accessToken, Int64 uid, int count = 50, int page = 1, int sort = 0)
        {
            string url = GetUrl("friends/bilateral/ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&count={3}&page={4}&trim_status={5}", url, accessToken, uid, count, page, sort));
            return JsonHelper.Convert<IdsEntity>(value);
        }

        #endregion

        #region 粉丝读取接口

        /// <summary>
        /// 获取用户的粉丝列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="screenName">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为50，最大不超过200。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <param name="trimStatus">返回值中user字段中的status字段开关，0：返回完整status字段、1：status字段仅返回status_id，默认为1。</param>
        /// <remarks>参数uid与screen_name二者必选其一，且只能选其一；接口升级后：uid与screen_name只能为当前授权用户，第三方微博类客户端不受影响；最多可获得总关注量30%的用户，上限为500。</remarks>
        /// <returns></returns>
        public static UsersEntity Followers(string accessToken, Int64 uid, string screenName = null, int count = 50, int cursor = 0, int trimStatus = 1)
        {
            string para = "";
            if (uid > 0)
            {
                para = "uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "screen_name=" + screenName;
            }
            else
            {
                return null;
            }
            string url = GetUrl("followers.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}&count={3}&cursor={4}&trim_status={5}", url, accessToken, para, count, cursor, trimStatus));
            return JsonHelper.Convert<UsersEntity>(value);
        }

        /// <summary>
        /// 获取用户粉丝的用户UID列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="screenName">需要查询的用户昵称。</param>
        /// <param name="count">单页返回的记录条数，默认为500，最大不超过5000。</param>
        /// <param name="cursor">返回结果的游标，下一页用返回值里的next_cursor，上一页用previous_cursor，默认为0。</param>
        /// <remarks>参数uid与screen_name二者必选其一，且只能选其一；最多返回总粉丝量30%，上限为500；接口升级后：uid与screen_name只能为当前授权用户，第三方微博类客户端不受影响；</remarks>
        /// <returns></returns>
        public static IdsEntity FollowersIds(string accessToken, Int64 uid, string screenName = null, int count = 500, int cursor = 0)
        {
            string url = GetUrl("friends/ids.json");
            string para = "";
            if (uid > 0)
            {
                para = "uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "screen_name=" + screenName;
            }
            else
            {
                return null;
            }
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}&count={3}&cursor={4}", url, accessToken, para, count, cursor));
            return JsonHelper.Convert<IdsEntity>(value);
        }

        /// <summary>
        ///获取用户的活跃粉丝列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户UID。</param>
        /// <param name="count">返回的记录条数，默认为20，最大不超过200。</param>
        /// <remarks>接口升级后：uid只能为当前授权用户，第三方微博类客户端不受影响；最多返回总粉丝量30%，上限为500。</remarks>
        /// <returns></returns>
        public static IdsEntity FollowersActive(string accessToken, Int64 uid, int count = 20)
        {
            string url = GetUrl("followers/active.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&count={3}", url, accessToken, uid, count));
            return JsonHelper.Convert<IdsEntity>(value);
        }

        #endregion

        #region 关系链读取接口

        /// <summary>
        /// 获取当前登录用户的关注人中又关注了指定用户的用户列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">指定的关注目标用户UID。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static UsersEntity FollowersChain(string accessToken, Int64 uid, int count = 50, int page = 1)
        {
            string url = GetUrl("friends_chain/followers.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&count={3}&page={4}", url, accessToken, uid, count, page));
            return JsonHelper.Convert<UsersEntity>(value);
        }

        #endregion

        #region 关系读取接口

        /// <summary>
        /// 获取两个用户之间的详细关注关系情况
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sourceId">源用户的UID。sourceId与sourceScreenName二者必选其一，且只能选其一;</param>
        /// <param name="sourceScreenName">源用户的微博昵称。sourceId与sourceScreenName二者必选其一，且只能选其一;</param>
        /// <param name="targetId">目标用户的UID。targetId与targetScreenName二者必选其一，且只能选其一;</param>
        /// <param name="targetScreenName">目标用户的微博昵称。targetId与targetScreenName二者必选其一，且只能选其一;</param>
        /// <remarks>参数source_id与source_screen_name二者必选其一，且只能选其一;参数target_id与target_screen_name二者必选其一，且只能选其一</remarks>
        public static FollowerEntity Show(string accessToken, Int64 sourceId, string sourceScreenName, Int64 targetId, string targetScreenName)
        {
            string sourcePara = "";
            if (sourceId > 0)
            {
                sourcePara = "source_id=" + sourceId;
            }
            else if (!string.IsNullOrWhiteSpace(sourceScreenName))
            {
                sourcePara = "source_screen_name=" + sourceScreenName;
            }
            else
            {
                return null;
            }

            string targetPara = "";
            if (targetId > 0)
            {
                targetPara = "target_id=" + targetId;
            }
            else if (!string.IsNullOrWhiteSpace(targetScreenName))
            {
                targetPara = "target_screen_name=" + targetScreenName;
            }
            else
            {
                return null;
            }

            string url = GetUrl("show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}&{3}", url, accessToken, sourcePara, targetPara));
            return JsonHelper.Convert<FollowerEntity>(value);
        }

        #endregion

        #region 写入接口

        /// <summary>
        /// 关注一个用户
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要关注的用户ID(使用screenName时传入0)。uid与screenName二者必选其一，且只能选其一;</param>
        /// <param name="screenName">需要关注的用户昵称。uid与screenName二者必选其一，且只能选其一;</param>
        /// <param name="rip">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <remarks>参数uid与screenName二者必选其一，且只能选其一;</remarks>
        public static UserEntity Create(string accessToken, Int64 uid, string screenName, string rip = null)
        {
            string para = "";
            if (uid > 0)
            {
                para = "uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "screen_name=" + screenName;
            }
            else
            {
                return null;
            }

            string url = GetUrl("create.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&{1}&rip={2}", accessToken, para, rip));
            return JsonHelper.Convert<UserEntity>(value);
        }

        /// <summary>
        /// 取消关注一个用户
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要取消关注的用户ID。(使用screenName时传入0)。uid与screenName二者必选其一，且只能选其一;</param>
        /// <param name="screenName">需要取消关注的用户昵称。uid与screenName二者必选其一，且只能选其一;</param>
        /// <remarks>参数uid与screenName二者必选其一，且只能选其一;</remarks>
        public static UserEntity Destroy(string accessToken, Int64 uid, string screenName)
        {
            string para = "";
            if (uid > 0)
            {
                para = "uid=" + uid;
            }
            else if (!string.IsNullOrWhiteSpace(screenName))
            {
                para = "screen_name=" + screenName;
            }
            else
            {
                return null;
            }

            string url = GetUrl("destroy.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&{1}", accessToken, para));
            return JsonHelper.Convert<UserEntity>(value);
        }

        /// <summary>
        /// 移除当前登录用户的粉丝
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要移除的粉丝用户的UID。</param>
        public static UserEntity FollowerDestroy(string accessToken, Int64 uid)
        {
            string url = GetUrl("followers/destroy.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&uid={1}", accessToken, uid));
            return JsonHelper.Convert<UserEntity>(value);
        }

        /// <summary>
        /// 更新当前登录用户所关注的某个好友的备注信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要修改备注信息的用户UID。</param>
        /// <param name="remark">备注信息。</param>
        /// <returns></returns>
        public static UserEntity UpdateRemark(string accessToken, Int64 uid, string remark)
        {
            if (string.IsNullOrWhiteSpace(remark))
            {
                return null;
            }
            remark = HttpHelper.UrlEncode(remark);
            string url = GetUrl("remark/update.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&uid={1}&remark={2}", accessToken, uid, remark));
            return JsonHelper.Convert<UserEntity>(value);
        }

        #endregion

        #endregion

        #region 好友分组

        #region 读取接口
        //待定

        #endregion

        #region 写入接口
        //待定
        #endregion

        #endregion

    }
}
