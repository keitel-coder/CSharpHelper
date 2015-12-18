using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helper
{
    public static class HttpHelper
    {
        /// <summary>
        /// 发起url请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="method">请求方法</param>
        /// <param name="paras">请求体(参数)</param>
        /// <param name="heads">请求头,可为null</param>
        /// <returns>响应流</returns>
        public static Stream Request(string url, string method, string paras, IDictionary<string, string> heads = null, IEnumerable<Cookie> cookies = null)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }
            string url1 = url.ToLower();
            if (url1.StartsWith("http://") && url1.StartsWith("https://"))
            {
                url = "http://" + url;
            }
            if (heads == null)
            {
                heads = new Dictionary<string, string>();
                heads["DNT"] = "1";
                heads["ContentType"] = "application/x-www-form-urlencoded";
            }
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //添加请求参数
            if (!string.IsNullOrWhiteSpace(paras))
            {
                byte[] bytes = ConvertHelper.ToBytes(paras);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            //添加cookie
            if (request.SupportsCookieContainer && cookies != null)
            {
                Dictionary<int, string> groups = RegexHelper.MatchGroups(url, @"^https?://([^/]+)?.*");
                string domain = null;
                if (groups != null)
                {
                    domain = groups[groups.Count];
                }
                request.CookieContainer = new CookieContainer();
                foreach (var item in cookies)
                {
                    if (item != null)
                    {
                        item.Domain = domain;
                        request.CookieContainer.Add(item);
                    }
                }
            }
            //添加请求头
            foreach (var item in heads)
            {
                request.Headers.Add(item.Key + ":" + item.Value);
            }
            WebResponse response = request.GetResponse();
            
            return response.GetResponseStream();
        }

        public static string Request(string url, string method, string paras, Encoding encoding)
        {
            Stream stream = Request(url, method, paras);
            return ConvertHelper.ToString(stream, encoding);
        }

        public static string GetPara(string name)
        {
            return System.Web.HttpContext.Current.Request[name];
        }

        /// <summary>
        /// 添加cookie
        /// </summary>
        /// <param name="name">cookie名</param>
        /// <param name="value">cookie值</param>
        public static void AddCookie(string name, string value)
        {
            AddCookie(new HttpCookie(name, value));
        }

        /// <summary>
        /// 添加cookie
        /// </summary>
        /// <param name="cookie">cookie</param>
        public static void AddCookie(HttpCookie cookie)
        {
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 移除cookie
        /// </summary>
        /// <param name="name">cookie名</param>
        public static void RemoveCookie(string name)
        {
            System.Web.HttpContext.Current.Response.Cookies.Remove(name);
        }
    }
}
