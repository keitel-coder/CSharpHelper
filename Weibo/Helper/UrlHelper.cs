using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Helper
{
    public class UrlHelper
    {
        public static string BuildQueryString(Dictionary<string, string> parameters)
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    string introduced3 = Uri.EscapeDataString(pair.Key);
                    list.Add(string.Format("{0}={1}", introduced3, Uri.EscapeDataString(pair.Value)));
                }
            }
            return string.Join("&", list.ToArray());
        }
    }
}
