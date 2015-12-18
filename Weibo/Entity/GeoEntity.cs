using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 地理信息
    /// </summary>
    public class GeoEntity
    {
        /// <summary>
        /// 经度坐标
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 维度坐标
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 所在城市的城市代码
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 所在省份的省份代码
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 所在城市的城市名称
        /// </summary>
        public string City_Name { get; set; }

        /// <summary>
        /// 所在省份的省份名称
        /// </summary>
        public string Province_Name { get; set; }

        /// <summary>
        /// 所在的实际地址，可以为空
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 地址的汉语拼音，不是所有情况都会返回该字段
        /// </summary>
        public string Pinyin { get; set; }

        /// <summary>
        /// 更多信息，不是所有情况都会返回该字段
        /// </summary>
        public string More { get; set; }
    }
}
