using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Helper
{
    /// <summary>
    /// http请求帮助类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 请求响应状态码
        /// </summary>
        public static int StatusCode { get; set; }

        /// <summary>
        /// 发起url请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="paras">请求体(参数)</param>
        /// <returns>响应流</returns>
        public static string Post(string url, string paras)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "post";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";
            //添加请求参数
            if (!string.IsNullOrWhiteSpace(paras))
            {
                byte[] bytes = ToBytes(paras);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            try
            {
                WebResponse response = request.GetResponse();
                return StreamToString(response.GetResponseStream(), Encoding.UTF8);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    return StreamToString(ex.Response.GetResponseStream(), Encoding.UTF8);
                }
                else
                {
                    ResponseState.EX = ex;
                    return null;
                }
            }
        }

        /// <summary>
        /// 发起url请求上传多媒体内容
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="paras">请求体(参数)</param>
        /// <returns>响应流</returns>
        public static string PostMulti(string url, string paras)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "post";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.ContentType = "multipart/form-data";
            //添加请求参数
            if (!string.IsNullOrWhiteSpace(paras))
            {
                byte[] bytes = ToBytes(paras);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            try
            {
                WebResponse response = request.GetResponse();
                return StreamToString(response.GetResponseStream(), Encoding.UTF8);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    return StreamToString(ex.Response.GetResponseStream(), Encoding.UTF8);
                }
                else
                {
                    ResponseState.EX = ex;
                    return null;
                }
            }
        }

        /// <summary>
        /// 发起url请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns>响应流</returns>
        public static string Get(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "get";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";

            //取消捕捉异常
            try
            {
                WebResponse response = request.GetResponse();
                return StreamToString(response.GetResponseStream(), Encoding.UTF8);
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    return StreamToString(ex.Response.GetResponseStream(), Encoding.UTF8);
                }
                else
                {
                    ResponseState.EX = ex;
                    return null;
                }
            }
        }

        /// <summary>
        /// 生成参数
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static string CreateParas(Dictionary<string, string> paras)
        {
            StringBuilder sb = new StringBuilder();
            if (paras != null)
            {
                foreach (var item in paras)
                {
                    sb.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
                sb.Remove(0, sb.Length - 1);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将流转换为文本
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>响应内容</returns>
        public static string StreamToString(Stream stream, Encoding encoding = null)
        {
            if (stream == null) return null;
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            StreamReader reader = new StreamReader(stream, encoding);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// 将字符串转换为Byte数组类型 
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>转换后的值</returns>
        public static Byte[] ToBytes(string input, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            return encoding.GetBytes(input);
        }

        /// <summary>
        /// URLEncode
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static string UrlEncode(string content)
        {
            return System.Web.HttpUtility.UrlEncode(content);
        }

        /// <summary>
        /// URLDecode
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static string UrlDecode(string content)
        {
            return System.Web.HttpUtility.UrlDecode(content);
        }
    }
}
