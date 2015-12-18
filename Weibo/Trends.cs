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
    /// 话题接口集合
    /// </summary>
    public class Trends
    {
        private const string linkUrl = "https://api.weibo.com/2/trends/";

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
        /// 返回最近一小时内的热门话题
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="baseapp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <returns></returns>
        public static TrendsEntity Hourly(string accessToken, int baseapp = 0)
        {
            string url = GetUrl("hourly.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&baseapp={2}", url, accessToken, baseapp));
            JToken trends = JsonHelper.Convert(value, "trends");    //话题集合
            JToken as_of = JsonHelper.Convert(value, "as_of");  //as_of
            JToken time = JsonHelper.Convert(trends, 0);
            TrendsEntity entity = new TrendsEntity();
            entity.trends = JsonHelper.Convert<TrendEntity>(time);
            entity.as_of = Convert.ToInt64(as_of);
            JsonHelper.Convert<FavoritesEntity>(value);
            return entity;
        }

        /// <summary>
        /// 返回最近一天内的热门话题
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="baseapp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <returns></returns>
        public static TrendsEntity Daily(string accessToken, int baseapp = 0)
        {
            string url = GetUrl("daily.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&baseapp={2}", url, accessToken, baseapp));
            JToken trends = JsonHelper.Convert(value, "trends");    //话题集合
            JToken as_of = JsonHelper.Convert(value, "as_of");  //as_of
            JToken time = JsonHelper.Convert(trends, 0);
            TrendsEntity entity = new TrendsEntity();
            entity.trends = JsonHelper.Convert<TrendEntity>(time);
            entity.as_of = Convert.ToInt64(as_of);
            JsonHelper.Convert<FavoritesEntity>(value);
            return entity;
        }

        /// <summary>
        /// 返回最近一周内的热门话题
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="baseapp">是否只获取当前应用的数据。0为否（所有数据），1为是（仅当前应用），默认为0。</param>
        /// <returns></returns>
        public static TrendsEntity Weekly(string accessToken, int baseapp = 0)
        {
            string url = GetUrl("weekly.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&baseapp={2}", url, accessToken, baseapp));
            JToken trends = JsonHelper.Convert(value, "trends");    //话题集合
            JToken as_of = JsonHelper.Convert(value, "as_of");  //as_of
            JToken time = JsonHelper.Convert(trends, 0);
            TrendsEntity entity = new TrendsEntity();
            entity.trends = JsonHelper.Convert<TrendEntity>(time);
            entity.as_of = Convert.ToInt64(as_of);
            JsonHelper.Convert<FavoritesEntity>(value);
            return entity;
        }
    }
}
