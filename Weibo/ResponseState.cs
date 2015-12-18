using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weibo.Entity;

namespace Weibo
{
    /// <summary>
    /// 返回状态实体
    /// </summary>
    public class ResponseState
    {
        /// <summary>
        /// 错误信息 当有错误信息时
        /// </summary>
        public static ErrorEntity Error { get; set; }

        /// <summary>
        /// 程序执行过程中发生的异常
        /// </summary>
        public static Exception EX { get; set; }
    }
}
