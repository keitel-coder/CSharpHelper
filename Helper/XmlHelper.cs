using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Helper
{
    public static class XmlHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string AddNode()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"D:\rss_newstop.xml");
            XmlNode node = xml.SelectSingleNode("title");
            return node.Name;
        }
    }
}
