using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weibo;
using Weibo.Entity;
using Weibo.Helper;

namespace Weibo
{
    /// <summary>
    /// 标签方法集合
    /// </summary>
    public class Tags
    {
        private const string linkUrl = "https://api.weibo.com/2/tags/";

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
        /// 返回指定用户的标签列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="uid">要获取的标签列表所属的用户ID。</param>
        /// <param name="count">单页返回的记录条数，默认为20。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static StatusTagsEntity GetTags(string accessToken, Int64 uid, int count = 20, int page = 1)
        {
            string url = GetUrl(".json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uid={2}&count={3}&page={4}", url, accessToken, uid, count, page));
            return JsonHelper.Convert<StatusTagsEntity>(value);
        }

        /// <summary>
        /// 批量获取用户的标签列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="ids">要获取标签的用户ID。最大20，逗号分隔。</param>
        /// <returns></returns>
        public static IEnumerable<StatusTags> TagsBatch(string accessToken, string uids)
        {
            if (string.IsNullOrWhiteSpace(uids))
            {
                return null;
            }
            string url = GetUrl("tags_batch.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&uids={2}", url, accessToken, uids));
            JToken token = JsonHelper.Convert(value, "result");
            return JsonHelper.Convert<StatusTags>(token);
        }

        /// <summary>
        /// 获取系统推荐的标签列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="count">返回记录数，默认10，最大10。</param>
        /// <returns></returns>
        public static IEnumerable<SIdValueEntity> Suggestions(string accessToken, int count = 10)
        {
            string url = GetUrl("suggestions.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&count={2}", url, accessToken, count));
            return JsonHelper.Convert<IEnumerable<SIdValueEntity>>(value);
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
    }
}
