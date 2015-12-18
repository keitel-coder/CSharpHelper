using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// 从结束位置倒序查找字符首次出现的位置
        /// </summary>
        /// <param name="strs">待查找的字符串</param>
        /// <param name="ch">查找的字符</param>
        /// <param name="IsDistinct">是否包含重复项</param>
        /// <returns>在原字符串字符的首次位置 未找到返回-1</returns>
        public static int FindEnd(string strs, char ch, bool IsDistinct = false)
        {
            int result = strs.Length - 1;
            int length = strs.Length;
            if (!IsDistinct)
            {
                for (int i = length; i >= 0; i--)
                {
                    if (strs[i] == ch)
                    {
                        return result;
                    }
                    result--;
                }
                return -1;
            }
            else
            {
                for (int i = length; i >= 0; i--)
                {
                    if (strs[i] == ch && ((i > 0 && strs[i - 1] != ch) || i == 0))
                    {
                        return result;
                    }
                    result--;
                }
                return -1;
            }
        }

        /// <summary>
        /// 从结束位置倒序查找首次不为该字符的位置
        /// </summary>
        /// <param name="strs">待查找的字符串</param>
        /// <param name="ch">查找的字符</param>
        /// <returns>在原字符串中不为该字符的首次位置 未找到返回-1</returns>
        public static int FindEndNot(string strs, char ch)
        {
            int result = strs.Length - 1;
            int length = strs.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (strs[i] != ch)
                {
                    return result;
                }
                result--;
            }
            return -1;
        }

        /// <summary>
        /// 从开始位置开始查找字符首次出现的位置
        /// </summary>
        /// <param name="strs">待查找的字符串</param>
        /// <param name="ch">查找的字符</param>
        /// <param name="IsDistinct">是否包含重复项</param>
        /// <returns>在原字符串字符的首次位置 未找到返回-1</returns>
        public static int FindFirst(string strs, char ch, bool IsDistinct = false)
        {
            int result = 0;
            int length = strs.Length;
            if (!IsDistinct)
            {
                for (int i = 0; i < length; i++)
                {
                    if (strs[i] == ch)
                    {
                        return result;
                    }
                    result++;
                }
                return -1;
            }
            else
            {
                bool flag = strs.StartsWith(ch.ToString());//标志是否为首字符串
                for (int i = 0; i < length; i++)
                {
                    if (strs[i] == ch && ((i < length - 1 && strs[i + 1] != ch) || i == length - 1))
                    {
                        return result;
                    }
                    result++;
                }
                return -1;
            }
        }

        /// <summary>
        /// 从开始位置开始查找首次不为该字符的位置
        /// </summary>
        /// <param name="strs">待查找的字符串</param>
        /// <param name="ch">查找的字符</param>
        /// <returns>在字符串中的位置 未找到返回-1</returns>
        public static int FindFirstNot(string strs, char ch)
        {
            int result = 0;
            int length = strs.Length;

            for (int i = 0; i < length; i++)
            {
                if (strs[i] != ch)
                {
                    return result;
                }
                result++;
            }
            return -1;
        }

        /// <summary>
        /// 判断字符串是否是合法url地址
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否合法</returns>
        public static bool IsUrl(string input)
        {
            //匹配本地网址
            if (RegexHelper.IsMatch(input, @"((http|https)://)?localhost(:\d)?.*"))
            {
                return true;
            }

            return RegexHelper.IsMatch(input, @"((http|https)://)?[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?");
        }

        /// <summary>
        /// 判断字符串是否是合法的手机号码
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否合法</returns>
        public static bool IsMobileNo(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            //string regex = @"^(130|131|132|133|134|135|136|137|138|139|145|147|150|151|152|153|157|
            //158|159|180|181|182|183|184|186|187|188|189|170|171|172)\d{8}$";
            string regex = "^1[3|5|7|8|][0-9]{9}$";
            return Regex.IsMatch(input, regex);
        }

        /// <summary>
        /// 判断字符串是否是合法的电话号码
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否合法</returns>
        public static bool IsTelPhoneNo(string input)
        {
            return RegexHelper.IsMatch(input, @"(^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
        }

        /// <summary>
        /// 是否是合法emil地址
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否合法</returns>
        public static bool IsEmail(string input)
        {
            return RegexHelper.IsMatch(input, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        /// <summary>
        /// 是否是合法的IPv4地址
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>是否合法</returns>
        public static bool IsIPv4(string input)
        {
            if (RegexHelper.IsMatch(input, @"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$"))
            {
                string[] segments = input.Split('.');
                foreach (var item in segments)
                {
                    int value = Convert.ToInt32(item);
                    if (value > 255)
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }

        public static bool IsZipCode(string input)
        {
            return RegexHelper.IsMatch(input, @"[1-9]{1}(\d+){5}");
        }

        public static bool IsIDCardNo(string input)
        {
            return RegexHelper.IsMatch(input, @"^[1-9](\d{16}|\d{13})(x|X|\d)$");
        }

        /// <summary>
        /// 移除字符串前后的某个字符串
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="trimString">要移除的字符串</param>
        /// <returns>移除后的字符串</returns>
        public static string Trim(string input, string trimString)
        {
            input = TrimStart(input, trimString);
            input = TrimEnd(input, trimString);
            return input;
        }

        /// <summary>
        /// 移除字符串前的某个字符串
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="trimString">要移除的字符串</param>
        /// <returns>移除后的字符串</returns>
        public static string TrimStart(string input, string trimString)
        {
            if (input == null)
            {
                return null;
            }
            if (trimString == null && trimString != "")
            {
                return input;
            }
            StringBuilder sb = new StringBuilder(input);
            int length = trimString.Length;
            while (sb.ToString().StartsWith(trimString))
            {
                sb.Remove(0, length);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 移除字符串前后的某个字符串
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <param name="trimString">要移除的字符串</param>
        /// <returns>移除后的字符串</returns>
        public static string TrimEnd(string input, string trimString)
        {
            if (input == null)
            {
                return null;
            }
            if (trimString == null && trimString != "")
            {
                return input;
            }
            StringBuilder sb = new StringBuilder(input);
            int length = trimString.Length;
            while (sb.ToString().EndsWith(trimString))
            {
                sb.Remove(sb.Length - length, length);
            }
            return sb.ToString();
        }
    }
}
