using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class ImageHelper
    {
        /// <summary>
        /// 得到随机数，并将生成的随机数保存至Session中
        /// </summary>
        /// <param name="difficulty">验证码难度：<=0 仅数字 1仅字母 >=2字母和数字混合</param>
        /// <param name="count">验证码长度</param>
        /// <param name="vcode">生成的验证码</param>
        /// <returns>产生的随机数</returns>
        public static byte[] GenerateValidateCode(int difficulty, int length, out string vcode)
        {
            string checkCode = String.Empty;
            string str1 = "0123456789";
            string str2 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random r = new Random();
            string str = string.Empty;
            if (difficulty <= 0)
            {
                str = str1;
            }
            else if (difficulty == 1)
            {
                str = str2;
            }
            else
            {
                str = str1 + str2;
            }
            int count = str.Length;
            for (int i = 0; i < length; i++)
            {
                checkCode += str[r.Next(count)];
            }
            vcode = checkCode;
            return CreateValidateImage(checkCode, (int)12.5 * length, 20);
        }

        /// <summary>
        /// 根据验证码生成验证码图片
        /// </summary>
        /// <param name="checkCode">要生成验证码图片的文字</param>
        /// <param name="width">验证码图片的宽度</param>
        /// <param name="height">验证码图片的高度</param>
        public static byte[] CreateValidateImage(string checkCode, int width, int height)
        {
            //新建图像
            Bitmap image = new System.Drawing.Bitmap(width, height);
            //新建画布
            Graphics g = Graphics.FromImage(image);
            try
            {
                //清空图片背景色
                g.Clear(Color.White);
                //生成随机生成器
                Random random = new Random();
                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(width);
                    int x2 = random.Next(width);
                    int y1 = random.Next(height);
                    int y2 = random.Next(height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                //画图片的前景噪音点
                for (int i = 0; i < 200; i++)
                {
                    int x = random.Next(width);
                    int y = random.Next(height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                if (!string.IsNullOrWhiteSpace(checkCode))
                {
                    //新建字体
                    Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                    //新建画刷
                    System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, width, height), Color.Blue, Color.DarkRed, 1.2f, true);
                    //开始绘画
                    g.DrawString(checkCode, font, brush, 2, 2);
                }

                //新建内存流
                MemoryStream ms = new System.IO.MemoryStream();
                //将图片保存到内存流中
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            finally
            {
                //释放画布和图片资源
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// 从文件中读取图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>读取的图片类</returns>
        public static Image Load(string fileName)
        {
            if (!FileHelper.IsExists(fileName))
            {
                return null;
            }
            return Image.FromFile(fileName, true);
        }

        /// <summary>
        /// 从流中读取图片
        /// </summary>
        /// <param name="stream">流</param>
        /// <returns>读取的图片类</returns>
        public static Image Load(Stream stream)
        {
            if (stream == null)
            {
                return null;
            }
            return Image.FromStream(stream, true, true);
        }

        /// <summary>
        /// 得到图片的缩略图
        /// </summary>
        /// <param name="image">原图片</param>
        /// <param name="thumbWidth">请求的缩略图的宽度（以像素为单位）。</param>
        /// <param name="thumbHeight">请求的缩略图的高度（以像素为单位）。</param>
        /// <returns>缩放后的图片</returns>
        public static Image GetTumb(Image image, int thumbWidth, int thumbHeight)
        {
            if (image == null) return null;  //为null时

            return image.GetThumbnailImage(thumbWidth, thumbHeight, new System.Drawing.Image.GetThumbnailImageAbort(() => false), IntPtr.Zero); //对原图片进行缩放
        }

        /// <summary>
        /// 得到图片的缩略图
        /// </summary>
        /// <param name="oldFileName">图片文件名</param>
        /// <param name="tumbFileName">缩略图保存文件名</param>
        /// <param name="thumbWidth">请求的缩略图的宽度（以像素为单位）。</param>
        /// <param name="thumbHeight">请求的缩略图的高度（以像素为单位）。</param>
        public static bool GetTumb(string oldFileName, string tumbFileName, int thumbWidth, int thumbHeight)
        {
            Image orgImage = Load(oldFileName);
            if (orgImage == null)
            {
                return false;
            }
            Image img = GetTumb(orgImage, thumbWidth, thumbHeight);
            Save(img, tumbFileName);
            return true;
        }

        /// <summary>
        /// 将图片保存到文件
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="savePath">保存路径</param>
        public static void Save(Image image, string savePath)
        {
            image.Save(savePath);
        }

        /// <summary>
        /// 将突破保存到流
        /// </summary>
        /// <param name="image">图片</param>
        /// <param name="stream">流</param>
        /// <param name="format">图片格式</param>
        public static void Save(Image image, Stream stream, ImageFormat format)
        {
            image.Save(stream, format);
        }
    }
}
