using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Weibo.Entity;

namespace Weibo.Helper
{
    /// <summary>
    /// Json转换帮助类
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 将json格式字符串转换为特定类型的对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static T Convert<T>(string value) where T : class
        {
            //做异常处理
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            if (value.StartsWith("{\"error\""))
            {
                ResponseState.Error = JsonConvert.DeserializeObject<ErrorEntity>(value);
                return null;
            }
            if (value.StartsWith("Sorry,"))
            {
                ResponseState.Error.Error = value;
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
        }

        /// <summary>
        /// 将json字符串转换为json实体
        /// </summary>
        /// <param name="value">json格式字符串</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static JToken Convert(string value, string key)
        {
            JObject obj = JObject.Parse(value);
            if (obj != null)
            {
                return obj[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将json字符串转换为json实体
        /// </summary>
        /// <param name="value">json格式字符串</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string Convert(JToken token)
        {
            return token.ToString();
            //JObject obj = JObject.Parse(value);
            //if (obj[key] != null)
            //{
            //    return obj[key];
            //}
            //else
            //{
            //    return null;
            //}
        }

        ///// <summary>
        ///// 获取json实体中的某个值
        ///// </summary>
        ///// <param name="token">json实体</param>
        ///// <param name="key">键</param>
        ///// <returns></returns>
        //public static JToken Convert(JToken token, string key)
        //{
        //    if (token[key] != null)
        //    {
        //        return token[key];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 获取json实体中的某个值
        /// </summary>
        /// <param name="token">json实体</param>
        /// <param name="i">从0开始的记录数</param>
        /// <returns></returns>
        public static JToken Convert(JToken token, int i)
        {
            if (token == null)
            {
                return null;
            }
            else
            {
                return token.Values().ToList()[i];
            }
        }

        /// <summary>
        /// 获得实体集合
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="token">json</param>
        /// <returns></returns>
        public static IEnumerable<T> Convert<T>(JToken token)
        {
            if (token != null)
            {
                string s = token.ToString(Formatting.None);
                return Convert<IEnumerable<T>>(s);
            }
            else
            {
                return null;
            }
        }
    }
}