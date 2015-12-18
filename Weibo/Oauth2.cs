using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Weibo.Entity;
using Weibo.Enums;
using Weibo.Helper;

namespace Weibo
{
    /// <summary>
    /// WeiboApiOauth2接口
    /// </summary>
    public class Oauth2
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        private const string linkUrl = "https://api.weibo.com/oauth2/";

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
        /// OAuth2的authorize接口
        /// </summary>
        /// <param name="clientId">申请应用时分配的AppKey。</param>
        /// <param name="redirectUri">授权回调地址，站外应用需与设置的回调地址一致，站内应用需填写canvas page的地址。</param>
        /// <param name="scope">申请scope权限所需参数，可一次申请多个scope权限，用逗号分隔。</param>
        /// <param name="state">用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数。开发者可以用这个参数验证请求有效性，也可以记录用户请求授权页前的位置。这个参数可用于防止跨站请求伪造（CSRF）攻击</param>
        /// <param name="display">授权页面的终端类型，取值见下面的说明。</param>
        /// <param name="forceLogin">是否强制用户重新登录，true：是，false：否。默认false。></param>
        /// <param name="language">授权页语言，缺省为中文简体版，en为英文版。英文版测试中，开发者任何意见可反馈至 @微博API</param>
        /// <returns>返回授权页</returns>
        public static string Authorize(string clientId, string redirectUri, string scope, string state, DisplayType display, bool forceLogin = false, string language = null)
        {
            //string url = GetUrl("authorize");
            string url = "https://api.weibo.com/oauth2/authorize";
            return HttpHelper.Post(url, string.Format("client_id={0}&redirect_uri={1}&scope={2}&state={3}&display={4}&forceLogin={5}&language={6}", clientId, redirectUri, scope, state, display.ToString(), forceLogin, language));
            //return JsonHelper.Convert<AuthorizeEntity>(value);
        }

        /// <summary>
        /// 客户端登录
        /// </summary>
        /// <param name="passport">通行证（用户名、手机号、邮箱等）</param>
        /// <param name="password">密码</param>
        /// <param name="appKey">申请的appKey</param>
        /// <param name="callBackUrl">回调地址</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static AccessTokenEntity ClientLogin(string passport, string password, string appKey, string callBackUrl)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            CookieContainer container = new CookieContainer();
            HttpWebRequest request = WebRequest.Create("https://api.weibo.com/oauth2/authorize") as HttpWebRequest;
            request.Referer = GetAuthorizeURL(appKey, callBackUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = true;
            request.KeepAlive = true;
            request.CookieContainer = container;
            string s = string.Format("action=submit&withOfficalFlag=0&ticket=&isLoginSina=&response_type=token&regCallback=&redirect_uri={0}&client_id={1}&state=&from=&userId={2}&passwd={3}&display=js",
                new object[] { Uri.EscapeDataString(string.IsNullOrEmpty(callBackUrl) ? "" : callBackUrl), Uri.EscapeDataString(appKey), Uri.EscapeDataString(passport), Uri.EscapeDataString(password) });
            byte[] bytes = Encoding.Default.GetBytes(s);
            request.ContentLength = bytes.Length;
            using (Stream stream = request.GetRequestStream())
            {
                try
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    stream.Close();
                }
            }
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            try
                            {
                                string str2 = reader.ReadToEnd();
                                string pattern = "\\{\"access_token\":\"(?<token>.{0,32})\",\"remind_in\":\"(?<remind>\\d+)\",\"expires_in\":(?<expires>\\d+),\"uid\":\"(?<uid>\\d+)\"\\}";
                                string str4 = "\\{\"access_token\":\"(?<token>.{0,32})\",\"remind_in\":\"(?<remind>\\d+)\",\"expires_in\":(?<expires>\\d+),\"refresh_token\":\"(?<refreshtoken>.{0,32})\",\"uid\":\"(?<uid>\\d+)\"\\}";
                                if (!string.IsNullOrEmpty(str2) && (Regex.IsMatch(str2, pattern) || Regex.IsMatch(str2, str4)))
                                {
                                    Match match = Regex.IsMatch(str2, "refresh_token") ? Regex.Match(str2, str4) : Regex.Match(str2, pattern);
                                    AccessTokenEntity token = new AccessTokenEntity();
                                    token.Access_Token = match.Groups["token"].Value;
                                    if (token != null)
                                    {
                                        token.Expires_In = Convert.ToInt32(match.Groups["expires"].Value);
                                        token.Access_Token = match.Groups["token"].Value;
                                        token.UID = match.Groups["uid"].Value;
                                    }
                                    return token;
                                }
                            }
                            catch
                            {
                            }
                            finally
                            {
                                reader.Close();
                            }
                        }
                    }
                    response.Close();
                }
            }
            catch (WebException)
            {
                throw;
            }
            return null;
        }

        private static string GetAuthorizeURL(string appKey, string callbackUrl)
        {
            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
            dictionary2.Add("client_id", appKey);
            dictionary2.Add("redirect_uri", callbackUrl);
            dictionary2.Add("response_type", "code");
            dictionary2.Add("state", "");
            dictionary2.Add("display", "default");
            Dictionary<string, string> parameters = dictionary2;
            UriBuilder builder = new UriBuilder("https://api.weibo.com/oauth2/authorize")
            {
                Query = UrlHelper.BuildQueryString(parameters)
            };
            return builder.ToString();
        }

        /// <summary>
        /// OAuth2的access_token接口
        /// </summary>
        /// <param name="clientId">申请应用时分配的AppKey。</param>
        /// <param name="clientSecret">申请应用时分配的AppSecret。</param>
        /// <param name="grantType">请求的类型，填写authorization_code</param>
        /// <param name="code">调用authorize获得的code值。</param>
        /// <param name="redirectUri">回调地址，需与注册应用里的回调地址一致。</param>
        /// <returns></returns>
        public static AccessTokenEntity AccessToken(string clientId, string clientSecret, string grantType, string code, string redirectUri)
        {
            string url = GetUrl("access_token");
            string value = HttpHelper.Post(url, string.Format("access_token={0}", clientId));
            return JsonHelper.Convert<AccessTokenEntity>(value);
        }

        /// <summary>
        /// 查询用户access_token的授权相关信息，包括授权时间，过期时间和scope权限。
        /// </summary>
        /// <param name="AccessToken">用户授权时生成的access_token</param>
        /// <returns></returns>
        public static TokenInfoEntity GetTokenInfo(string AccessToken)
        {
            string url = GetUrl("get_token_info");
            string value = HttpHelper.Post(url, string.Format("access_token={0}", AccessToken));
            return JsonHelper.Convert<TokenInfoEntity>(value);
        }

        /// <summary>
        /// 授权回收接口，帮助开发者主动取消用户的授权。
        /// </summary>
        /// <param name="AccessToken">用户授权应用的access_token</param>
        /// <returns>是否成功</returns>
        public static bool RevokeOauth2(string AccessToken)
        {
            string url = GetUrl("revokeoauth2");
            string value = HttpHelper.Post(url, string.Format("access_token={0}", AccessToken));
            var result = JsonHelper.Convert<ResultEntity>(value);
            return result.Result;
        }
    }
}
