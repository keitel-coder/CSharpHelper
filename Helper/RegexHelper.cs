using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Helper
{
    public static class RegexHelper
    {
        /// <summary>
        /// 输入的字符串是否匹配正则表达式
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns>是否匹配</returns>
        public static bool IsMatch(string input, string pattern)
        {
            if (input == null || pattern == null)
            {
                return false;
            }
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 根据输入的字符串和正则表达式找到匹配的项
        /// </summary>
        /// <param name="input">要查找的字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns>符合条件的字符串</returns>
        public static string Match(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            if (match != null)
            {
                return match.Value;
            }
            else return null;
        }

        /// <summary>
        /// 匹配组
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Dictionary<int, string> MatchGroups(string input, string pattern)
        {
            if (input == null || pattern == null)
            {
                return null;
            }

            Match match = Regex.Match(input, pattern);
            GroupCollection groups = match.Groups;
            if (groups != null && groups.Count > 0)
            {
                Dictionary<int, string> list = new Dictionary<int, string>();
                int count = groups.Count;
                for (int i = 0; i < count; i++)
                {
                    if (groups[i].Success)
                    {
                        list[i] = groups[i].Value;
                    }
                }
                return list;
            }
            else return null;
        }

        /// <summary>
        /// 根据输入的字符串和正则表达式找到匹配的项
        /// </summary>
        /// <param name="input">要查找的字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns>符合条件的字符串集合</returns>
        public static IEnumerable<string> Matchs(string input, string pattern)
        {
            if (input == null || pattern == null)
            {
                return null;
            }

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            if (matches != null && matches.Count > 0)
            {
                List<string> list = new List<string>();
                for (int i = 0; i < matches.Count; i++)
                {
                    list.Add(matches[0].Value);
                }
                return list;
            }
            else return null;
        }


        /// <summary>
        /// 替换查找出的字符串
        /// </summary>
        /// <param name="input">原字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换的字符</param>
        /// <returns></returns>
        public static string Replace(string input, string pattern, string replacement)
        {
            if (input == null || pattern == null)
            {
                return null;
            }

            Regex regex = new Regex(pattern);
            return regex.Replace(input, replacement);
        }

        /// <summary>
        /// 替换查找出的字符串
        /// </summary>
        /// <param name="input">原字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换的字符</param>
        /// <param name="count">替换的个数</param>
        /// <returns></returns>
        public static string Replace(string input, string pattern, string replacement, int count)
        {
            if (input == null || pattern == null)
            {
                return null;
            }
            Regex regex = new Regex(pattern);
            return regex.Replace(input, replacement, count);
        }

        /// <summary>
        /// 查找字符串中的url地址
        /// </summary>
        /// <param name="input">要查找的字符串</param>
        /// <returns>符合条件的字符串</returns>
        public static string GetUrl(string input)
        {
            return Match(input, "(h|H)(r|R)(e|E)(f|F) *= *('|\")?(\\w|\\|\\/|\\.)+('|\"|  *|>)?");
        }

        /// <summary>
        /// 查找字符串中的IPV4地址
        /// </summary>
        /// <param name="input">要查找的字符串</param>
        /// <returns>符合条件的字符串</returns>
        public static string GetIP(string input)
        {
            return Match(input, @"(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})");
        }
    }
}