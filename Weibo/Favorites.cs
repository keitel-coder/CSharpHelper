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
    /// 收藏接口集合
    /// </summary>
    public class Favorites
    {
        private const string linkUrl = "https://api.weibo.com/2/favorites/";

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
        /// 获取当前登录用户的收藏列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static FavoritesEntity GetFavorites(string accessToken, int count = 50, int page = 1)
        {
            string url = GetUrl(".json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&count={2}&page={3}", url, accessToken, count, page));
            return JsonHelper.Convert<FavoritesEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户的收藏列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static FavoriteIdsEntity GetFavoriteIds(string accessToken, int count = 50, int page = 1)
        {
            string url = GetUrl("ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&count={2}&page={3}", url, accessToken, count, page));
            return JsonHelper.Convert<FavoriteIdsEntity>(value);
        }

        /// <summary>
        /// 根据收藏ID获取指定的收藏信息
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要查询的收藏ID。</param>
        /// <returns></returns>
        public static FavoriteEntity Show(string accessToken, Int64 id)
        {
            string url = GetUrl("show.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&id={2}", url, accessToken, id));
            return JsonHelper.Convert<FavoriteEntity>(value);
        }

        /// <summary>
        /// 根据标签获取当前登录用户该标签下的收藏列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tid">需要查询的标签ID。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static FavoritesEntity GetFavoritesByTag(string accessToken, int tid, int count = 50, int page = 1)
        {
            string url = GetUrl("by_tags.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&tid={2}&count={3}&page={4}", url, accessToken, tid, count, page));
            return JsonHelper.Convert<FavoritesEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户的收藏列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tid">标签Id</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static FavoriteIdsEntity GetFavoriteIdsByTag(string accessToken, int tid, int count = 50, int page = 1)
        {
            string url = GetUrl("by_tags/ids.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&tid={2}&count={3}&page={4}", url, accessToken, tid, count, page));
            return JsonHelper.Convert<FavoriteIdsEntity>(value);
        }

        /// <summary>
        /// 获取当前登录用户的收藏标签列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="count">单页返回的记录条数，默认为50。</param>
        /// <param name="page">返回结果的页码，默认为1。</param>
        /// <returns></returns>
        public static TagsEntity GetTags(string accessToken, int count = 50, int page = 1)
        {
            string url = GetUrl("tags.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&count={2}&page={3}", url, accessToken, count, page));
            return JsonHelper.Convert<TagsEntity>(value);
        }

        #endregion

        #region 写入接口

        /// <summary>
        /// 添加一条微博到收藏里
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">要收藏的微博ID。</param>
        /// <returns></returns>
        public static FavoriteEntity Create(string accessToken, Int64 id)
        {
            string url = GetUrl("create.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}", accessToken, id));
            return JsonHelper.Convert<FavoriteEntity>(value);
        }

        /// <summary>
        /// 取消收藏一条微博
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">要取消收藏的微博ID。</param>
        /// <remarks>只能取消自己所收藏的微博</remarks>
        /// <returns></returns>
        public static FavoriteEntity Destroy(string accessToken, Int64 id)
        {
            string url = GetUrl("destroy.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}", accessToken, id));
            return JsonHelper.Convert<FavoriteEntity>(value);
        }
        
        /// <summary>
        /// 根据收藏ID批量取消收藏
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="ids">要取消收藏的收藏ID，用半角逗号分隔，最多不超过10个。</param>
        /// <remarks>只能取消自己所收藏的微博</remarks>
        /// <returns></returns>
        public static bool DestroyBatch(string accessToken, string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return false;
            }

            string url = GetUrl("destroy_batch.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&ids={1}", accessToken, ids));
            var result = JsonHelper.Convert<ResultEntity>(value);
            return result.Result;
        }

        /// <summary>
        /// 更新一条收藏的收藏标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="id">需要更新的收藏ID。</param>
        /// <param name="tags">需要更新的标签内容，用半角逗号分隔，最多不超过2条。</param>
        /// <remarks>只能取消自己所收藏的微博</remarks>
        /// <returns></returns>
        public static FavoriteEntity UpdateTags(string accessToken, Int64 id, string tags)
        {
            if (string.IsNullOrWhiteSpace(tags))
            {
                return Show(accessToken, id);
            }
            else
            {
                tags = HttpHelper.UrlEncode(tags);
            }

            string url = GetUrl("tags/update.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&id={1}&tags={2}", accessToken, id, tags));
            return JsonHelper.Convert<FavoriteEntity>(value);
        }

        /// <summary>
        /// 更新当前登录用户所有收藏下的指定标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tid">需要更新的标签ID。</param>
        /// <param name="tag">需要更新的标签内容。</param>
        /// <returns></returns>
        public static TagEntity UpdateTag(string accessToken, int tid, string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                return null;
            }
            tag = HttpHelper.UrlEncode(tag);
            string url = GetUrl("tags/update_batch.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&tid={1}&tag={2}", accessToken, tid, tag));
            return JsonHelper.Convert<TagEntity>(value);
        }

        /// <summary>
        /// 删除当前登录用户所有收藏下的指定标签
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="tid">需要删除的标签ID。</param>
        /// <returns></returns>
        public static TagEntity DestroyTag(string accessToken, int tid)
        {
            string url = GetUrl("tags/destroy_batch.json");
            string value = HttpHelper.Post(url, string.Format("access_token={0}&tid={1}", accessToken, tid));
            return JsonHelper.Convert<TagEntity>(value);
        }

        #endregion
    }
}
