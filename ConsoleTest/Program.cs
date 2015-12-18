using Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string fileName = @"D:\测试.txt";
            //byte[] bytes = FileHelper.ReadFile(fileName);
            //string base64Data = Convert.ToBase64String(bytes);
            //string md5 = EncryptHelper.MD5Hash(bytes);
            //string base64Encode = System.Web.HttpUtility.UrlEncode(base64Data);
            //int length = bytes.Length;

            string fileName = @"D:\快传.MP4";
            DateTime now1 = DateTime.Now;
            string md5 = EncryptHelper.GetFileMD5(fileName);
            DateTime now2 = DateTime.Now;
            double sec = (now2 - now1).TotalSeconds;

            //string str = null;

            #region XML
            //str = XmlHelper.AddNode();
            //Console.WriteLine(str);
            #endregion

            #region 图片
            //ImageHelper.GetTumb(@"D:\Tulips.jpg", @"D:\Tulips1.jpg", 100, 100);
            #endregion

            #region 验证码
            //string vcode = null;
            //FileHelper.WriteFile(ImageHelper.GenerateValidateCode(2, 4, out vcode), @"D:\1.jpg");
            //FileHelper.WriteText(vcode, @"D:\1.txt"); 
            #endregion

            #region FileHelper
            //FileHelper.CreateFolder(@"D:\search");            
            //Console.WriteLine(FileHelper.GetFolder(@"http://www.baidu.com/1.txt"));

            //FileHelper
            #endregion

            #region http请求
            //str = HtmlHelper.Request("http://www.baidu.com", "get", null);
            //FileHelper.WriteFile();
            //FileHelper.SaveText(str, @"D:\index.htm", false); 
            #endregion

            #region html压缩
            //str = FileHelper.ReadText(@"D:\Index.html");
            //FileHelper.SaveText("451231425", @"D:\1.txt", true);
            //FileHelper.SaveText(HtmlHelper.Compress(null), @"D:\index.htm", false);
            //Console.WriteLine(str);
            #endregion

            #region 金额转换
            //decimal value = (decimal)-1100100100011;
            //Console.WriteLine("转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //value = (decimal)9000000000000;
            //Console.WriteLine("\n转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //value = (decimal)1022041230536;
            //Console.WriteLine("\n转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //value = (decimal)1924802101.11;
            //Console.WriteLine("\n转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //value = (decimal)928002000000;
            //Console.WriteLine("\n转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //value = (decimal)9999999999999.99;
            //Console.WriteLine("\n转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //value = (decimal)9000900090909.09;
            //Console.WriteLine("\n转换值：" + value);
            //Console.WriteLine("旧:" + ConvertHelper.CmycurD(value));
            //Console.WriteLine("新:" + ConvertHelper.ToRMB(value));
            //Console.WriteLine("VB:" + ConvertRmb.ToRMB(value));

            //DateTime now = DateTime.Now;
            //for (int i = 0; i < 1000000; i++)
            //{
            //    str = ConvertHelper.ToRMB(i);
            //}
            //TimeSpan span = DateTime.Now - now;
            //Console.WriteLine(span.TotalSeconds);

            //now = DateTime.Now;
            //for (int i = 0; i < 1000000; i++)
            //{
            //    str = ConvertHelper.DecimalToRMB(i);
            //}
            //span = DateTime.Now - now;
            //Console.WriteLine(span.TotalSeconds);
            #endregion

            //if ((0.1 + 0.2) == 0.3)
            //{
            //    Console.WriteLine(1);
            //}

            #region 测试ToString
            //List<string> list = new List<string>();
            //list.Add("张山");
            //list.Add("张三");
            //list.Add("李四");
            //str = ConvertHelper.ToString(list, "-", "."); 
            #endregion

            #region 加密测试
            //生成和保存密钥和向量
            //byte[] Key = EncryptHelper.DESGenerateKey();
            //byte[] IV = EncryptHelper.DESGenerateIV();
            //FileHelper.SaveFile(Key, @"D:\Key.txt");
            //FileHelper.SaveFile(IV, @"D:\IV.txt");

            ////加密字符串并保存
            //byte[] encrys = EncryptHelper.DESEncrypt("这是一段加密的字符串", Key, IV);
            //FileHelper.SaveFile(encrys, @"D:\1.txt");

            ////读取密钥和加密后的字符串
            //byte[] Key2 = FileHelper.ReadFile(@"D:\Key.txt");
            //byte[] IV2 = FileHelper.ReadFile(@"D:\IV.txt");
            //byte[] encrys2 = FileHelper.ReadFile(@"D:\1.txt");

            ////解密
            //string input = EncryptHelper.DESDecrypt(encrys2, Key2, IV2); 
            #endregion

            Console.ReadKey();
        }
    }
}
