using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo.Entity
{
    /// <summary>
    /// 错误信息实体
    /// </summary>
    public class ErrorEntity
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int Error_Code { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string Request { get; set; }
    }
}
