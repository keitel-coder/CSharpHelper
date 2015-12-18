using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weibo
{
    /// <summary>
    /// 验证是否通过
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Field, AllowMultiple = false)]
    public class Author : ValidationAttribute
    {
        private string AccessToken { get; set; }
        public override bool IsValid(object value)
        {
            var phoneNumber = (String)value;
            bool result = true;
            //if (this.Mask != null)
            //{
            //    result = MatchesMask(this.Mask, phoneNumber);
            //}
            return result;
        }
    }
}
