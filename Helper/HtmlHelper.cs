using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class HtmlHelper
    {
        /// <summary>
        /// 压缩网页内容
        /// </summary>
        /// <param name="content">原内容</param>
        /// <returns>压缩后内容</returns>
        public static string Compress(string content)
        {
            StringBuilder sb = new StringBuilder();
            int length = content.Length - 1;
            for (int i = 1; i < length; i++)
            {
                if (content[i] == ' ' || content[i] == '\n' || content[i] == '\t' || content[i] == '\r')
                {
                    char ch1 = content[i - 1];
                    char ch2 = content[i + 1];
                    if (!(ch1 == ';' || ch1 == '>' || ch1 == ' ' || ch2 == '<'))
                    {
                        sb.Append(" ");
                    }
                }
                else
                {
                    sb.Append(content[i]);
                }
            }
            return sb.ToString();
            //正则表达式 简洁、但效率低
            //return RegexHelper.Replace(content, @"\s\s\s*", " ").Replace(@">\s+<", "><");
        }

        /// <summary>
        /// 得到内容中的url链接
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>所有的链接</returns>
        public static IEnumerable<string> GetUrls(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return null;
            }
            return RegexHelper.Matchs(content, "(h|H)(r|R)(e|E)(f|F) ('|\")?(\\w|\\|\\/|\\.)+('|\"|  *|>)?");
        }
    }
}
