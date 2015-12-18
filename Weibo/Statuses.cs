using Newtonsoft.Json.Linq;
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
    /// 微博方法集合
    /// </summary>
    public class Statuses
    {
        private string AccessToken = null;

        public Statuses(string accessToken)
        {
            AccessToken = accessToken;
        }

        /// <summary>
        /// 接口地址
        /// </summary>
        private const string linkUrl = "https://api.weibo.com/2/statuses/";

        /// <summary>
        /// 方法名
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private static string GetUrl(string method)
        {
            return linkUrl + method;
        }

        #region 读取接口
        /// <summary>
        /// 返回最新的最大200条公共微博，返回结果非完全实时
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="count">单页返回的记录条数，最大不超过200，默认为20。</param>
        /// <returns></returns>
        public static TimelineEntity PublicTimeLine(string accessToken, int count = 20)
        {
            string url = GetUrl("public_timeline.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&count={2}", url, accessToken, count));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static TimelineEntity FriendsTimeline(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int baseApp = 0, int feature = 0, int trimUser = 0)
        {
            string url = GetUrl("friends_timeline.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&base_app={6}&feature={7}&trim_user={8}",
                url, accessToken, sinceId, maxId, count, page, baseApp, feature, trimUser));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static TimelineEntity HomeTimeline(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int baseApp = 0, int feature = 0, int trimUser = 0)
        {
            string url = GetUrl("home_timeline.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&base_app={6}&feature={7}&trim_user={8}",
                url, accessToken, sinceId, maxId, count, page, baseApp, feature, trimUser));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博的ID
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <returns></returns>
        public static TimelineIdsEntity FriendsTimelineIds(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int baseApp = 0, int feature = 0)
        {
            string url = GetUrl("friends_timeline/ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&base_app={6}&feature={7}",
                url, accessToken, sinceId, maxId, count, page, baseApp, feature));
            return JsonHelper.Convert<TimelineIdsEntity>(value);
        }

        /// <summary>
        /// 获取某个用户最新发表的微博列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户ID。（当使用昵称查找时，此参数为0）</param>
        /// <param name="screenName">需要查询的用户昵称。（当指定了uid时，此参数应保持默认或设为null）</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <remarks>uid和screenName只能为一个赋值，如果均不赋值，则返回null</remarks>
        /// <returns></returns>
        public static TimelineEntity UserTimeline(string accessToken, Int64 uid, string screenName = null, Int64 sinceId = 0,
            Int64 maxId = 0, int count = 20, int page = 1, int baseApp = 0, int feature = 0, int trimUser = 0)
        {
            string url = GetUrl("user_timeline.json");
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
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&{2}&since_id={3}&max_id={4}&count={5}&page={6}&base_app={7}&feature={8}&trim_user={9}",
                url, accessToken, para, sinceId, maxId, count, page, baseApp, feature, trimUser));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取用户发布的微博的ID
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要查询的用户ID。（当使用昵称查找时，此参数为0）</param>
        /// <param name="screenName">需要查询的用户昵称。（当指定了uid时，此参数应保持默认或设为null）</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <returns></returns>
        public static TimelineEntity UserTimelineIds(string accessToken, Int64 uid, string screenName = null, Int64 sinceId = 0,
            Int64 maxId = 0, int count = 20, int page = 1, int baseApp = 0, int feature = 0)
        {
            string url = GetUrl("user_timeline/ids.json");
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
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}{2}&since_id={3}&max_id={4}&count={5}&page={6}&base_app={7}&feature={8}",
                url, accessToken, para, sinceId, maxId, count, page, baseApp, feature));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 批量获取指定的一批用户的微博列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uids">需要查询的用户ID，用半角逗号分隔，一次最多20个。</param>
        /// <param name="screenNames">需要查询的用户昵称，用半角逗号分隔，一次最多20个。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <remarks>参数uids与screen_name二者必选其一，且只能选其一</remarks>
        /// <returns></returns>
        public static TimelineEntity TimelineBatch(string accessToken, string uids, string screenNames = null, int count = 20, int page = 1, int baseApp = 0, int feature = 0)
        {
            string url = GetUrl("timeline_batch.json");
            string para = "";
            if (!string.IsNullOrWhiteSpace(uids))
            {
                para = "&uids=" + uids;
            }
            else if (!string.IsNullOrWhiteSpace(screenNames))
            {
                para = "&screen_names=" + screenNames;
            }
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}{2}&count={3}&page={4}&base_app={5}&feature={6}", url, accessToken, para, count, page, baseApp, feature));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取指定微博的转发微博列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <returns></returns>
        public static TimelineEntity RepostTimeline(string accessToken, Int64 id, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int author = 0)
        {
            string url = GetUrl("repost_timeline.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}&since_id={3}&max_id={4}&count={5}&page={6}&author={7}", url, accessToken, id, sinceId, maxId, count, page, author));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取指定微博的转发微博ID列
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <remarks>此接口最多只返回最新的2000条数据；</remarks>
        /// <returns></returns>
        public static TimelineIdsEntity RepostTimelineIds(string accessToken, Int64 id, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int author = 0)
        {
            string url = GetUrl("repost_timeline/ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}&since_id={3}&max_id={4}&count={5}&page={6}&author={7}", url, accessToken, id, sinceId, maxId, count, page, author));
            return JsonHelper.Convert<TimelineIdsEntity>(value);
        }

        /// <summary>
        /// 获取最新的提到登录用户的微博列表，即@我的微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="source">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。</param>
        /// <param name="type">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
        /// <returns></returns>
        public static TimelineEntity Mentions(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int author = 0, int source = 0, int type = 0)
        {
            string url = GetUrl("mentions.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&filter_by_author={2}&filter_by_source={3}&filter_by_type={4}&since_id={5}&max_id={6}&count={7}&page={8}",
                url, accessToken, author, source, type, sinceId, maxId, count, page));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取@当前用户的最新微博的ID
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="source">来源筛选类型，0：全部、1：来自微博、2：来自微群，默认为0。</param>
        /// <param name="type">原创筛选类型，0：全部微博、1：原创的微博，默认为0。</param>
        /// <returns></returns>
        public static TimelineIdsEntity MentionsIds(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int author = 0, int source = 0, int type = 0)
        {
            string url = GetUrl("mentions.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&filter_by_author={2}&filter_by_source={3}&filter_by_type={4}&since_id={5}&max_id={6}&count={7}&page={8}",
                url, accessToken, author, source, type, sinceId, maxId, count, page));
            return JsonHelper.Convert<TimelineIdsEntity>(value);
        }

        /// <summary>
        /// 获取双向关注用户的最新微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="baseApp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <param name="feature">过滤类型ID，0：全部、1：原创、2：图片、3：视频、4：音乐，默认为0。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <returns></returns>
        public static TimelineEntity BilateralTimeline(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int baseApp = 0, int feature = 0, int trimUser = 0)
        {
            string url = GetUrl("bilateral_timeline.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&base_app={6}&feature={7}&trim_user={8}",
                url, accessToken, sinceId, maxId, count, page, baseApp, feature, trimUser));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 根据ID获取单条微博信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要获取的微博ID。</param>
        /// <returns></returns>
        public static StatusEntity Show(string accessToken, Int64 id)
        {
            string url = GetUrl("show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}", url, accessToken, id));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 需要查询的微博ID，用半角逗号分隔，最多不超过50个。
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="ids">需要获取的微博ID。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <remarks>当微博已经被删除时，返回的微博ID以及text字段，text字段值为：“此微博已被原作者删除。”其余字段置为空值
        /// 部分微博ID出错时，仅返回成功获取的微博，全部微博ID出错，则返回错误信息</remarks>
        /// <returns></returns>
        public static StatusEntity ShowBatch(string accessToken, string ids, int trimUser = 0)
        {
            string url = GetUrl("show_batch.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&ids={2}&trimUser={3}", url, accessToken, ids, trimUser));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 通过微博（评论、私信）ID获取其MID
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要查询的微博（评论、私信）ID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
        /// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
        /// <param name="isBatch">是否使用批量模式，0：否、1：是，默认为0。</param>
        /// <returns></returns>
        public static string QueryMid(string accessToken, string id, int type = 1, int isBatch = 0)
        {
            string url = GetUrl("querymid.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}&type={3}&isBatch={4}", url, accessToken, id, type, isBatch));
            MIdEntity entity = JsonHelper.Convert<MIdEntity>(value);
            if (entity != null)
            {
                return entity.mid;
            }
            else return null;
        }

        /// <summary>
        /// 通过微博（评论、私信）ID获取其MID
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="mid">需要查询的微博（评论、私信）MID，批量模式下，用半角逗号分隔，最多不超过20个。</param>
        /// <param name="type">获取类型，1：微博、2：评论、3：私信，默认为1。</param>
        /// <param name="isBatch">是否使用批量模式，0：否、1：是，默认为0。</param>
        /// <param name="inBox">仅对私信有效，当MID类型为私信时用此参数，0：发件箱、1：收件箱，默认为0 。</param>
        /// <param name="inBase62">MID是否是base62编码，0：否、1：是，默认为0。</param>
        /// <returns></returns>
        public static string QueryId(string accessToken, string mid, int type = 1, int isBatch = 0, int inBox = 0, int inBase62 = 0)
        {
            string url = GetUrl("queryid.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&mid={2}&type={3}&isBatch={4}&inbox={5}&inBase62={6}", url, accessToken, mid, type, isBatch, inBox, inBase62));
            return JsonHelper.Convert(JsonHelper.Convert(value, "id"));
        }

        /// <summary>
        /// 批量获取指定微博的转发数评论数
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="ids">需要获取数据的微博ID，多个之间用逗号分隔，最多不超过100个。</param>
        /// <returns></returns>
        public static IEnumerable<StatusCountEntity> Count(string accessToken, string ids)
        {
            string url = GetUrl("count.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&ids={2}", url, accessToken, ids));
            return JsonHelper.Convert<IEnumerable<StatusCountEntity>>(value);
        }

        /// <summary>
        /// 获取双向关注用户的最新微博[高级接口]
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <remarks>A与B互相关注，B在A的分组G中，A发送定向微博S到G，则，在B的【发给我的微博中】会包括S这条微博；</remarks>
        /// <returns></returns>
        public static TimelineEntity ToMe(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1, int trimUser = 0)
        {
            string url = GetUrl("to_me.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&trim_user={6}", url, accessToken, sinceId, maxId, count, page, trimUser));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户关注的人发给其的定向微博ID列表[高级接口]
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的微博（即比since_id时间晚的微博），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博，默认为0。</param>
        /// <param name="count">单页返回的记录条数，最大不超过100，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <remarks>A与B互相关注，B在A的分组G中，A发送定向微博S到G，则，在B的【发给我的微博中】会包括S这条微博；</remarks>
        /// <returns></returns>
        public static TimelineIdsEntity ToMeIds(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 20, int page = 1)
        {
            string url = GetUrl("to_me/ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}}", url, accessToken, sinceId, maxId, count, page));
            return JsonHelper.Convert<TimelineIdsEntity>(value);
        }

        /// <summary>
        /// 根据ID跳转到单条微博页
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">需要跳转的用户ID。</param>
        /// <param name="id">需要跳转的微博ID。</param>
        /// <returns>成功：跳转到指定的单条微博页；失败：跳转到微博首页。</returns>
        public static TimelineEntity Go(string accessToken, Int64 uid, Int64 id)
        {
            string url = GetUrl("go");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&id={3}", url, accessToken, uid, id));
            return JsonHelper.Convert<TimelineEntity>(value);
        }

        /// <summary>
        /// 获取微博官方表情的详细信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// /<param name="type">表情类别，face：普通表情、ani：魔法表情、cartoon：动漫表情，默认为face。</param>
        /// <param name="language">语言类别，cnname：简体、twname：繁体，默认为cnname。</param>
        /// <returns>成功：跳转到指定的单条微博页；失败：跳转到微博首页。</returns>
        public static IEnumerable<EmotionEntity> Emotions(string accessToken, string type = "face", string language = "cnname")
        {
            string url = "https://api.weibo.com/2/emotions.json";
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&type={2}&id={3}", url, accessToken, type, language));
            return JsonHelper.Convert<IEnumerable<EmotionEntity>>(value);
        }

        #endregion

        #region 写入接口

        /// <summary>
        /// 转发一条微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">要转发的微博ID。</param>
        /// <param name="status">添加的转发文本，内容不超过140个汉字，不填则默认为“转发微博”。</param>
        /// <param name="isComment">是否在转发的同时发表评论，0：否、1：评论给当前微博、2：评论给原微博、3：都评论，默认为0 。</param>
        /// <param name="realIP">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <returns></returns>
        public static StatusEntity Repost(string accessToken, Int64 id, string status, int isComment = 0, string realIP = null)
        {
            string url = GetUrl("repost.json");
            status = HttpHelper.UrlEncode(status);
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}&status={2}&is_comment{3}&rip={4}", accessToken, id, status, isComment, realIP));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 根据微博ID删除指定微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要删除的微博ID。</param>
        /// <remarks>只能删除自己发布的微博</remarks>
        /// <returns></returns>
        public static StatusEntity Destroy(string accessToken, Int64 id)
        {
            string url = GetUrl("destroy.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}", accessToken, id));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 发布一条新微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="status">要发布的微博文本内容，内容不超过140个汉字。</param>
        /// <param name="visible">微博的可见性，0：所有人能看，1：仅自己可见，2：密友可见，3：指定分组可见，默认为0。</param>
        /// <param name="listId">微博的保护投递指定分组ID，只有当visible参数为3时生效且必选。</param>
        /// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="lon">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。</param>
        /// <param name="realIP">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <remarks>连续两次发布的微博不可以重复；非会员发表定向微博，分组成员数最多200。</remarks>
        /// <returns></returns>
        public static StatusEntity Update(string accessToken, string status, int visible = 0, int listId = 0,
            double lat = 0.0, double lon = 0.0, string annotations = null, string realIP = null)
        {
            string url = GetUrl("update.json");
            status = HttpHelper.UrlEncode(status);
            string para = null;
            //设置可见性参数
            if (visible == 3)
            {
                para = string.Format("visible={0}&list_id={1}", visible, listId);
            }
            else
            {
                para = string.Format("visible={0}", visible);
            }
            string value = HttpHelper.Post(url,
                string.Format("access_token={0}&status={1}&{2}&lat={3}&long={4}&annotations={5}&realIP={6}", accessToken, status, para, lat, lon, annotations, realIP));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 发布一条新微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="status">要发布的微博文本内容，内容不超过140个汉字。</param>
        /// <param name="pic">要上传的图片，仅支持JPEG、GIF、PNG格式，图片大小小于5M。</param>
        /// <param name="visible">微博的可见性，0：所有人能看，1：仅自己可见，2：密友可见，3：指定分组可见，默认为0。</param>
        /// <param name="listId">微博的保护投递指定分组ID，只有当visible参数为3时生效且必选。</param>
        /// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="lon">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。</param>
        /// <param name="realIP">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <remarks>请求必须用POST方式提交，并且注意采用multipart/form-data编码方式；非会员发表定向微博，分组成员数最多200。</remarks>
        /// <returns></returns>
        public static StatusEntity Upload(string accessToken, string status, string pic, int visible = 0, int listId = 0,
            double lat = 0.0, double lon = 0.0, string annotations = null, string realIP = null)
        {
            string url = "https://upload.api.weibo.com/2/statuses/upload.json";
            status = HttpHelper.UrlEncode(status);
            string para = null;
            //设置可见性参数
            if (visible == 3)
            {
                para = string.Format("visible={0}&list_id={1}", visible, listId);
            }
            else
            {
                para = string.Format("visible={0}", visible);
            }
            string value = HttpHelper.PostMulti(url,
                string.Format("access_token={0}&status={1}&pic={2}&{3}&lat={4}&long={5}&annotations={6}&rip={7}", accessToken, status, pic, para, lat, lon, annotations, realIP));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 指定一个图片URL地址抓取后上传并同时发布一条新微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="status">要发布的微博文本内容，内容不超过140个汉字。</param>
        /// <param name="imgUrl">图片的URL地址，必须以http开头。</param>
        /// <param name="picId">已经上传的图片pid，多个时使用英文半角逗号符分隔，最多不超过9个。</param>
        /// <param name="visible">微博的可见性，0：所有人能看，1：仅自己可见，2：密友可见，3：指定分组可见，默认为0。</param>
        /// <param name="listId">微博的保护投递指定分组ID，只有当visible参数为3时生效且必选。</param>
        /// <param name="lat">纬度，有效范围：-90.0到+90.0，+表示北纬，默认为0.0。</param>
        /// <param name="lon">经度，有效范围：-180.0到+180.0，+表示东经，默认为0.0。</param>
        /// <param name="annotations">元数据，主要是为了方便第三方应用记录一些适合于自己使用的信息，每条微博可以包含一个或者多个元数据，必须以json字串的形式提交，字串长度不超过512个字符，具体内容可以自定。</param>
        /// <param name="realIP">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <remarks>请求必须用POST方式提交，并且注意采用multipart/form-data编码方式；非会员发表定向微博，分组成员数最多200。</remarks>
        /// <returns></returns>
        public static StatusEntity UploadUrlText(string accessToken, string status, string imgUrl, string picId = null, int visible = 0, int listId = 0,
            double lat = 0.0, double lon = 0.0, string annotations = null, string realIP = null)
        {
            string url = GetUrl("upload_url_text.json");
            status = HttpHelper.UrlEncode(status);
            string para = null;
            //设置可见性参数
            if (visible == 3)
            {
                para = string.Format("visible={0}&list_id={1}", visible, listId);
            }
            else
            {
                para = string.Format("visible={0}", visible);
            }
            string value = HttpHelper.PostMulti(url,
                string.Format("access_token={0}&status={1}&url={2}&pic_id={3}&{4}&lat={5}&long={6}&annotations={7}&rip={8}", accessToken, status, imgUrl, picId, para, lat, lon, annotations, realIP));
            return JsonHelper.Convert<StatusEntity>(value);

        }

        /// <summary>
        /// 屏蔽某条微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">微博id。</param>
        /// <returns></returns>
        public static StatusEntity Filter(string accessToken, Int64 id)
        {
            string url = GetUrl("filter/create.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}", accessToken, id));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 屏蔽某个@到我的微博以及后续由对其转发引起的@提及
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要屏蔽的@提到我的微博ID。此ID必须在statuses/mentions列表中。</param>
        /// <param name="followUp">是否仅屏蔽当前微博。0：仅屏蔽当前@提到我的微博；1：屏蔽当前@提到我的微博，以及后续对其转发而引起的@提到我的微博。默认1。</param>
        /// <returns></returns>
        public static bool Shield(string accessToken, Int64 id, int followUp = 0)
        {
            string url = GetUrl("mentions/shield.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}&follow_up={2}", accessToken, id, followUp));
            var result = JsonHelper.Convert<ResultEntity>(value);
            return result.Result;
        }
        #endregion

        #region 微博标签

        #region 读取接口
        /// <summary>
        /// 获取当前用户的微博标签列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="count">返回结果的条数数量，最大不超过200，默认为20。</param>
        /// <returns></returns>
        public static StatusTagsEntity Tags(string accessToken, int count = 20)
        {
            string url = GetUrl("tags.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&count={2}", url, accessToken, count));
            return JsonHelper.Convert<StatusTagsEntity>(value);
        }

        /// <summary>
        /// 根据提供的微博ID批量获取此微博的标签信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="ids">根据指定id返回微博的相应标签信息。一次最多传入50个id，英文逗号分隔。</param>
        /// <returns></returns>
        public static IEnumerable<StatusTags> ShowBatch(string accessToken, string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return null;
            }

            string url = GetUrl("tags/show_batch.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&ids={2}", url, accessToken, ids));
            JToken token = JsonHelper.Convert(value, "result");
            return JsonHelper.Convert<StatusTags>(token);
        }

        /// <summary>
        /// 获取当前用户某个标签的微博ID列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tag">要获取的表情</param>
        /// <param name="sinceId">若指定此参数，则只返回ID比since_id大的微博消息（即比since_id发表时间晚的微博消息），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的微博消息，默认为0。</param>
        /// <param name="count">返回结果的条数数量，最大不超过200，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static StatuseIdsEntity GetStatusByTag(string accessToken, string tag, Int64 sinceId = 0, Int64 maxId = 0, int count = 50, int page = 1)
        {
            string url = GetUrl("tag_timeline/ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&tag={2}&since_id={3}&max_id={4}&count={5}&page={6}", url, accessToken, tag, sinceId, maxId, count, page));
            return JsonHelper.Convert<StatuseIdsEntity>(value);
        }

        #endregion

        #region 写入接口
        /// <summary>
        /// 创建当前登陆用户微博的标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tag">要创建标签名字。长度不可超过7个汉字，14个半角字符，不能包含空格。</param>
        /// <returns></returns>
        public static IdEntity CreateTag(string accessToken, string tag)
        {
            string url = GetUrl("tags/create.json");
            string value = HttpHelper.Post(url, string.Format("{0}?access_token={1}&tag={2}", url, accessToken, tag));
            return JsonHelper.Convert<IdEntity>(value);
        }

        /// <summary>
        /// 删除当前登陆用户微博的标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tag">要删除的标签名字。</param>
        /// <returns></returns>
        public static bool DestroyTag(string accessToken, string tag)
        {
            string url = GetUrl("tags/destroy.json");
            string value = HttpHelper.Post(url, string.Format("{0}?access_token={1}&tag={2}", url, accessToken, tag));
            var result = JsonHelper.Convert<ResultEntity>(value);
            if (result != null && result.Result == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新当前登陆用户微博的标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tag">要删除的标签名字。</param>
        /// <param name="newTag">用户微博的新标签。长度不可超过7个汉字，14个半角字符，不能包含空格。</param>
        /// <returns></returns>
        public static TagEntity UpdateTag(string accessToken, string tag, string newTag)
        {
            string url = GetUrl("tags/update.json");
            string value = HttpHelper.Post(url, string.Format("{0}?access_token={1}&old_tag={2}&new_tag={3}", url, accessToken, tag, newTag));
            return JsonHelper.Convert<TagEntity>(value);
        }

        /// <summary>
        /// 更新当前登陆用户某个微博的标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">微博ID。</param>
        /// <param name="tag">要删除的标签名字。</param>
        /// <param name="tags">需要修改成的标签内容。最多5条，逗号分隔。为空或指定了不存在的标签，即删除该微博的标签。</param>
        /// <returns></returns>
        public static TagEntity UpdateStatusTag(string accessToken, Int64 id, string tags)
        {
            tags = HttpHelper.UrlEncode(tags);
            string url = GetUrl("tags/update.json");
            string value = HttpHelper.Post(url, string.Format("{0}?access_token={1}&id={2}&tags={3}", url, accessToken, id, tags));
            return JsonHelper.Convert<TagEntity>(value);
        }

        #endregion

        #endregion
    }
}