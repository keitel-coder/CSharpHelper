using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weibo.Entity;
using Weibo.Enums;
using Weibo.Helper;

namespace Weibo
{
    /// <summary>
    /// 账户接口集合
    /// </summary>
    public static class Account
    {
        private const string linkUrl = "https://api.weibo.com/2/account/";

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
        /// 获取当前登录用户的隐私设置
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <returns></returns>
        public static PrivacyEntity GetPrivacySet(string accessToken)
        {
            string url = GetUrl("get_privacy.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}", url, accessToken));
            return JsonHelper.Convert<PrivacyEntity>(value);
        }

        /// <summary>
        /// 获取所有的学校列表
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <param name="province">省份范围，省份ID。不允许小于0</param>
        /// <param name="city">城市范围，城市ID。</param>
        /// <param name="area">区域范围，区ID。</param>
        /// <param name="type">学校类型，1：大学、2：高中、3：中专技校、4：初中、5：小学，默认为1。</param>
        /// <param name="capital">学校首字母,默认为A。</param>
        /// <param name="keyword">学校名称关键字。</param>
        /// <param name="count">返回的记录条数，默认为10。</param>
        /// <returns></returns>
        public static IEnumerable<SchoolEntity> GetSchoolList(string accessToken, int province, int city, int area, SchoolType type = SchoolType.大学, char capital = 'A', string keyword = null, int count = 10)
        {
            if (province < 1)
            {
                return null;
            }

            string url = GetUrl("profile/school_list.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}&province={2}&city={3}&area={4}&type={5}&keyword={6}&count={7}",
                url, accessToken, province, city, area, type.GetHashCode(), keyword, count));
            return JsonHelper.Convert<IEnumerable<SchoolEntity>>(value);
        }

        /// <summary>
        /// 获取当前登录用户的API访问频率限制情况
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <returns></returns>
        public static RateLimitStatus RateLimitStatus(string accessToken)
        {
            string url = GetUrl("rate_limit_status.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}",
                url, accessToken));
            return JsonHelper.Convert<RateLimitStatus>(value);
        }

        /// <summary>
        /// 获取用户的联系邮箱
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <returns></returns>
        public static IEnumerable<EmailEntity> Email(string accessToken)
        {
            string url = GetUrl("profile/email.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}",
                url, accessToken));
            return JsonHelper.Convert<IEnumerable<EmailEntity>>(value);
        }

        /// <summary>
        /// OAuth授权之后，获取授权用户的UID
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <returns></returns>
        public static Int64 GetUId(string accessToken)
        {
            string url = GetUrl("get_uid.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}",
                url, accessToken));
            var result = JsonHelper.Convert<UIdEntity>(value);
            if (result != null)
            {
                return result.uid;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region 写入接口

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="accessToken">OAuth授权后获得。</param>
        /// <returns></returns>
        public static UserEntity LogOut(string accessToken)
        {
            string url = GetUrl("end_session.json");
            string value = HttpHelper.Get(string.Format("{0}?access_token={1}",
                url, accessToken));
            return JsonHelper.Convert<UserEntity>(value);
        }

        #endregion
    }
}
