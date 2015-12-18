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
    /// 评论接口集合
    /// </summary>
    public static class Comments
    {
        private const string linkUrl = "https://api.weibo.com/2/comments/";

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
        /// 根据微博ID返回某条微博的评论列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要查询的微博ID。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <remarks>此接口最多只返回最新的2000条数据。</remarks>
        /// <returns></returns>
        public static CommentLineEntity Show(string accessToken, Int64 id, Int64 sinceId = 0, Int64 maxId = 0, int count = 50, int page = 1, int author = 0)
        {
            string url = GetUrl("show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}&since_id={3}&max_id={4}&count={5}&page={6}&filter_by_author={7}",
                url, accessToken, id, sinceId, maxId, count, page, author));
            return JsonHelper.Convert<CommentLineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户所发出的评论列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public static CommentLineEntity ByMe(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 50, int page = 1, int source = 0)
        {
            string url = GetUrl("by_me.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&filter_by_source={6}", url, accessToken, sinceId, maxId, count, page, source));
            return JsonHelper.Convert<CommentLineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户所接收到的评论列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <returns></returns>
        public static CommentLineEntity ToMe(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 50, int page = 1, int author = 0, int source = 0)
        {
            string url = GetUrl("to_me.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&filter_by_author={6}&filter_by_source={7}",
                url, accessToken, sinceId, maxId, count, page, author, source));
            return JsonHelper.Convert<CommentLineEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户的最新评论包括接收到的与发出的
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="trimUser">返回值中user字段开关，0：返回完整user字段、1：user字段仅返回user_id，默认为0。</param>
        /// <remarks>此接口最多只返回最新的2000条数据。</remarks>
        /// <returns></returns>
        public static CommentLineEntity TimeLine(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 50, int page = 1, int trimUser = 0)
        {
            string url = GetUrl("timeline.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&trimUser={6}", url, accessToken, sinceId, maxId, count, page, trimUser));
            return JsonHelper.Convert<CommentLineEntity>(value);
        }

        /// <summary>
        /// 获取最新的提到当前登录用户的评论，即@我的评论
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="sinceId">若指定此参数，则返回ID比since_id大的评论（即比since_id时间晚的评论），默认为0。</param>
        /// <param name="maxId">若指定此参数，则返回ID小于或等于max_id的评论，默认为0。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <param name="author">作者筛选类型，0：全部、1：我关注的人、2：陌生人，默认为0。</param>
        /// <param name="source">来源筛选类型，0：全部、1：来自微博的评论、2：来自微群的评论，默认为0。</param>
        /// <remarks>此接口最多只返回最新的2000条数据。</remarks>
        /// <returns></returns>
        public static CommentLineEntity Mentions(string accessToken, Int64 sinceId = 0, Int64 maxId = 0, int count = 50, int page = 1, int author = 0, int source = 0)
        {
            string url = GetUrl("mentions.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&since_id={2}&max_id={3}&count={4}&page={5}&filter_by_author={6}&filter_by_source={7}",
                url, accessToken, sinceId, maxId, count, page, author, source));
            return JsonHelper.Convert<CommentLineEntity>(value);
        }

        /// <summary>
        /// 根据评论ID批量返回评论信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="cids">需要查询的批量评论ID，用半角逗号分隔，最大50。</param>
        /// <returns></returns>
        public static IEnumerable<StatusEntity> ShowBatch(string accessToken, string cids)
        {
            string url = GetUrl("show_batch.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&cids={2}", url, accessToken, cids));
            return JsonHelper.Convert<IEnumerable<StatusEntity>>(value);
        }
        #endregion

        #region 写入接口
        /// <summary>
        /// 对一条微博进行评论
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="comment">评论内容,内容不超过140个汉字。</param>
        /// <param name="id">需要评论的微博ID。</param>
        /// <param name="comment_ori">当评论转发微博时，是否评论给原微博，0：否、1：是，默认为0。</param>
        /// <param name="rip">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <returns></returns>
        public static StatusEntity Create(string accessToken, Int64 id, string comment, int comment_ori = 0, string rip = null)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return null;
            }
            else
            {
                comment = HttpHelper.UrlEncode(comment);
            }
            string url = GetUrl("create.json");
            string value = HttpHelper.Post(url, string.Format("access_token={1}&comment={2}&id={3}&comment_ori={4}&rip={5}", url, accessToken, comment, id, comment_ori, rip));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 删除一条评论
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="cid">要删除的评论ID，只能删除登录用户自己发布的评论。</param>
        /// <returns></returns>
        public static StatusEntity Destroy(string accessToken, Int64 cid)
        {
            string url = GetUrl("destroy.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&cid={1}", accessToken, cid));
            return JsonHelper.Convert<StatusEntity>(value);
        }

        /// <summary>
        /// 根据评论ID批量删除评论
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="cids">需要删除的评论ID，用半角逗号隔开，最多20个。</param>
        /// <returns></returns>
        public static IEnumerable<StatusEntity> DestroyBatch(string accessToken, string cids)
        {
            string url = GetUrl("destroy_batch.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&cids={1}", accessToken, cids));
            return JsonHelper.Convert<IEnumerable<StatusEntity>>(value);
        }

        /// <summary>
        /// 对一条微博进行评论
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="comment">评论内容,内容不超过140个汉字。</param>
        /// <param name="id">需要评论的微博ID。</param>
        /// <param name="cid">需要评论的评论ID。</param>
        /// <param name="comment_ori">当评论转发微博时，是否评论给原微博，0：否、1：是，默认为0。</param>
        /// <param name="rip">开发者上报的操作用户真实IP，形如：211.156.0.1。</param>
        /// <returns></returns>
        public static StatusEntity Reply(string accessToken, Int64 id, Int64 cid, string comment, int comment_ori = 0, string rip = null)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return null;
            }
            else
            {
                comment = HttpHelper.UrlEncode(comment);
            }
            string url = GetUrl("reply.json");
            string value = HttpHelper.Post(url, string.Format("access_token={1}&comment={2}&id={3}&comment_ori={4}&rip={5}", url, accessToken, comment, id, comment_ori, rip));
            return JsonHelper.Convert<StatusEntity>(value);
        }
        #endregion
    }
}
