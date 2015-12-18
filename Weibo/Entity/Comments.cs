using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
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
        public static string Show(string accessToken, Int64 id, Int64 sinceId = 0,
            Int64 maxId = 0, int count = 50, int page = 1, int author = 0)
        {
            string url = GetUrl("show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}",
                url, accessToken, id), Encoding.UTF8);
            return "";
            //return JsonHelper.Convert<BoolEntity>(value);
        }
    }
}
