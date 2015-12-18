using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class ConvertHelper
    {
        #region ToString
        public static string ToString(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }
            return Encoding.UTF8.GetString(bytes);
        }

        public static string ToString(IEnumerable<object> list, string firtStr, string endStr)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                if (item != null)
                {
                    sb.AppendFormat("{0}{1}{2}", firtStr, item.ToString(), endStr);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将流转换为文本
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string ToString(Stream stream, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            StreamReader reader = new StreamReader(stream, encoding);
            return reader.ReadToEnd();
        }
        #endregion

        #region ToRMB
        public static string ToRMB(string input)
        {
            decimal value;
            if (!decimal.TryParse(input, out value))
            {
                return "无效的数值";
            }
            return ToRMB(value);
        }

        public static string ToRMB(decimal value)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";
            //string[] str1 = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 15
            byte[] segs = { 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1 };  //为1时相应为为0可设为零，为0则不设置
            StringBuilder sb = new StringBuilder();//存储结果
            if (value >= 0x9184E72A000)//0x9184E72A000=10000000000000
            {
                return "溢出";
            }
            if (value == 0)
            {
                return "零元整";
            }
            //处理负数
            if (value < 0)
            {
                value = value * -1;
                sb.Append("负");
            }
            string str = value.ToString("0000000000000.00").Replace(".", "");    //15位有效数字

            int length = str.Length;
            int end = str.Length - 1;
            int first = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] != '0')
                {
                    break;
                }
                first++;
            }
            for (int i = length - 1; i >= 0; i--)
            {
                if (str[i] != '0')
                {
                    break;
                }
                end--;
            }
            //设置结束位
            if (end < 4)
            {
                end = 4;
            }
            else if (end < 8)
            {
                end = 8;
            }
            else if (end < 12)
            {
                end = 12;
            }
            //bool flag = false; //标识前一位是否为0 为0 true
            bool hasValue = false;  //标志前一段落是否有值
            for (int i = first; i <= end; i++)
            {
                int j = ToInt16(str[i]);
                if (j != 0)
                {
                    sb.Append(str1[j].ToString() + str2[i]);
                    //if (flag && segs[i] == 1 && !sb.ToString().EndsWith("零"))
                    //{
                    //    sb.Append(str1[j].ToString() + str2[i]);
                    //}
                    //else
                    //{
                    //    sb.Append(str1[j].ToString() + str2[i]);
                    //}
                    //flag = false;
                    hasValue = true;
                }
                else
                {
                    //当前位为0 且下一位不为0时，添加零
                    if (segs[i] == 1 && (str[i + 1] != '0'))
                    {
                        sb.Append("零");
                        //flag = true;
                    }
                    //当是段尾时，且段前有值，添加单位
                    if (segs[i] == 0 && hasValue)
                    {
                        sb.Append(str2[i]);
                        hasValue = false;
                        //flag = false;
                    }
                }
            }

            string result = sb.ToString();
            //处理无角分时显示“元整”
            if (str[13] == '0' && str[14] == '0')
            {
                if (result.EndsWith("元"))
                {
                    result += "整";
                }
                else
                {
                    result += "元整";
                }
            }
            return result;
        }

        public static string DecimalToRMB(decimal num)
        {
            string str4 = "零壹贰叁肆伍陆柒捌玖";
            string str5 = "万仟佰拾亿仟佰拾万仟佰拾元角分";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str = "";
            string str2 = "";
            int num4 = 0;
            num = Math.Round(Math.Abs(num), 2);
            str7 = Convert.ToInt64(Math.Truncate(decimal.Multiply(num, 100M))).ToString();
            int length = str7.Length;
            if (length > 15)
            {
                return "溢出";
            }
            str5 = str5.Substring(15 - length);
            int num7 = length - 1;
            for (int i = 0; i <= num7; i++)
            {
                str6 = str7.Substring(i, 1);
                int num5 = Convert.ToInt32(str6);
                if (((i != (length - 3)) && (i != (length - 7))) && ((i != (length - 11)) && (i != (length - 15))))
                {
                    if (str6 == "0")
                    {
                        str = "";
                        str2 = "";
                        num4++;
                    }
                    else if ((str6 != "0") && (num4 != 0))
                    {
                        str = "零" + str4.Substring(num5 * 1, 1);
                        str2 = str5.Substring(i, 1);
                        num4 = 0;
                    }
                    else
                    {
                        str = str4.Substring(num5 * 1, 1);
                        str2 = str5.Substring(i, 1);
                        num4 = 0;
                    }
                }
                else if ((str6 != "0") && (num4 != 0))
                {
                    str = "零" + str4.Substring(num5 * 1, 1);
                    str2 = str5.Substring(i, 1);
                    num4 = 0;
                }
                else if ((str6 != "0") && (num4 == 0))
                {
                    str = str4.Substring(num5 * 1, 1);
                    str2 = str5.Substring(i, 1);
                    num4 = 0;
                }
                else if ((str6 == "0") && (num4 >= 3))
                {
                    str = "";
                    str2 = "";
                    num4++;
                }
                else if (length >= 11)
                {
                    str = "";
                    num4++;
                }
                else
                {
                    str = "";
                    str2 = str5.Substring(i, 1);
                    num4++;
                }
                if ((i == (length - 11)) || (i == (length - 3)))
                {
                    str2 = str5.Substring(i, 1);
                }
                str8 = str8 + str + str2;
                if ((i == (length - 1)) && (str6 == "0"))
                {
                    str8 = str8 + "整";
                }
            }
            if (decimal.Compare(num, decimal.Zero) == 0)
            {
                str8 = "零元整";
            }
            return str8;
        }
        #endregion

        /// <summary>
        /// 将字符串转换为Base64编码格式的字符串
        /// </summary>
        /// <param name="input">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>编码后的字符串</returns>
        public static string ToBase64String(string input, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            byte[] bytes = encoding.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将字节数组转换为Base64编码格式的字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>编码后的字符串</returns>
        public static string ToBase64String(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将Base64为编码格式的字符串中转换为等效的8为无符号字节数组
        /// </summary>
        /// <param name="s">要转换的字符串</param>
        /// <returns>与 s 等效的 8 位无符号整数数组。</returns>
        public static byte[] FromBase64String(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }
            return Convert.FromBase64String(s);
        }

        #region 整数转换
        /// <summary>
        /// 将字符串转换为Byte类型
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>转换后的值</returns>
        public static Byte ToByte(string input)
        {
            Byte bt = 0;
            byte.TryParse(input, out bt);
            return bt;
        }

        /// <summary>
        /// 将字符串转换为ToInt16类型
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>转换后的值</returns>
        public static Int16 ToInt16(String input)
        {
            Int16 result = 0;
            Int16.TryParse(input, out result);
            return result;
        }

        /// <summary>
        /// 将字符串转换为ToInt16类型
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>转换后的值</returns>
        public static Int16 ToInt16(Char input)
        {
            Int16 result = 0;
            Int16.TryParse(input.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 将字符串转换为Int32类型
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>转换后的值</returns>
        public static Int32 ToInt32(String input)
        {
            Int32 result = 0;
            Int32.TryParse(input, out result);
            return result;
        }

        /// <summary>
        /// 将字符串转换为Int64类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns>转换后的值</returns>
        public static Int64 ToInt64(String input)
        {
            Int64 result = 0;
            Int64.TryParse(input, out result);
            return result;
        }
        #endregion

        public static Decimal ToDecimal(string input)
        {
            decimal result = 0;
            decimal.TryParse(input, out result);
            return result;
        }

        /// <summary>
        /// 将字符串转换为DateTime类型
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>转换后的值</returns>
        public static DateTime ToDateTime(this String input)
        {
            DateTime dateTime = new DateTime();
            DateTime.TryParse(input, out dateTime);
            return dateTime;
        }

        /// <summary>
        /// 将字符串转换为Byte数组类型 
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>转换后的值</returns>
        public static Byte[] ToBytes(string input, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            return encoding.GetBytes(input);
        }
    }
}
