using System.IO;
using System.Text;

namespace Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 将字符串数组组合成一个路径
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>组合成的路径</returns>
        public static string PathCombine(params string[] paths)
        {
            return Path.Combine(paths);
        }

        /// <summary>
        /// 判断文件或文件夹是否存在
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否存在</returns>
        public static bool IsExists(string filePath, bool isFolder = false)
        {
            if (isFolder)
            {
                return Directory.Exists(filePath);
            }
            else
            {
                return File.Exists(filePath);
            }
        }

        /// <summary>
        /// 将流写入到文件
        /// </summary>
        /// <param name="stream">要保存的流</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="isAppand">是否追加 对文件已存在时有效</param>
        /// <returns>是否保存成功</returns>
        public static bool WriteFile(Stream stream, string savePath, bool isAppand = true, Encoding encoding = null)
        {
            if (stream == null)
            {
                return false;
            }
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            CreateFolder(GetFolder(savePath));
            using (StreamReader sr = new StreamReader(stream, encoding))
            {
                using (StreamWriter sw = new StreamWriter(savePath, isAppand, encoding))
                {
                    sw.Write(sr.ReadToEnd());
                    sw.Flush();
                    return true;
                }
            }
        }

        /// <summary>
        /// 将流保存到文件
        /// </summary>
        /// <param name="stream">要保存的流</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="isConver">是否覆盖</param>
        /// <returns>是否保存成功</returns>
        public static bool WriteFile(byte[] bytes, string savePath, bool isConver = true)
        {
            if (isConver == false && IsExists(savePath))
            {
                return false;
            }
            CreateFolder(GetFolder(savePath));
            //创建文件流保存文件
            using (FileStream fs = new FileStream(savePath, FileMode.Create))
            {
                int length = bytes.Length;
                //一次写入的最大长度
                int count = 1024 * 1024;
                //读取到的位置
                int offset = 0;
                if (length > count)
                {
                    while (offset < length)
                    {
                        fs.Write(bytes, offset, count);
                        offset += count;
                    }
                }
                else
                {
                    fs.Write(bytes, 0, length);
                }
                fs.Flush();
                return true;
            }
        }

        /// <summary>
        /// 保存文本到文件
        /// </summary>
        /// <param name="sb">字符串</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="isAppend">是否追加（仅对文件已存在有效）</param>
        public static void WriteText(StringBuilder sb, string savePath, bool isAppend = false)
        {
            CreateFolder(GetFolder(savePath));
            using (StreamWriter writer = new StreamWriter(savePath, isAppend))
            {
                writer.Write(sb);
                writer.Flush();
            }
        }

        /// <summary>
        /// 保存文本到文件
        /// </summary>
        /// <param name="content">字符串</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="isAppend">是否追加（仅对文件已存在有效）</param>
        public static void WriteText(string content, string savePath, bool isAppend = false)
        {
            CreateFolder(GetFolder(savePath));

            using (StreamWriter writer = new StreamWriter(savePath, isAppend))
            {
                writer.Write(content);
                writer.Flush();
            }
        }

        /// <summary>
        /// 读取文件为二进制流（最大100MB）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>读取后的二进制流</returns>
        public static byte[] ReadFile(string filePath)
        {
            if (!IsExists(filePath))
            {
                return null;
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                long length = fs.Length;
                //文件大于1000MB时不读取
                if (length > 100 * 1024 * 1024)
                {
                    return null;
                }
                byte[] bytes = new byte[length];
                //如果文件大于20M 则分段读取,一次读取20M
                int segmentLength = 20 * 1024 * 1024;
                if (length > segmentLength)
                {
                    //读取长度
                    int readLength = 1;
                    int offset = 0;
                    while (readLength != 0)
                    {
                        readLength = fs.Read(bytes, offset, segmentLength);
                        offset += readLength;
                    }
                }
                else
                {
                    fs.Read(bytes, 0, (int)length);
                }
                return bytes;
            }
        }

        /// <summary>
        /// 从文件中读取文本内容
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>读取的文本</returns>
        public static string ReadFile(string filePath, Encoding encoding)
        {
            if (!IsExists(filePath))
            {
                return null;
            }
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            using (StreamReader reader = new StreamReader(filePath, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 读取流为文本格式
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>读取的文本</returns>
        public static string ReadFile(Stream stream, Encoding encoding)
        {
            if (stream == null)
            {
                return null;
            }
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>是否成功删除</returns>
        public static bool DeleteFile(string filePath)
        {
            if (!IsExists(filePath))
            {
                return false;
            }
            File.Delete(filePath);
            return true;
        }

        public static string GetFolder(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public static DirectoryInfo CreateFolder(string folderPath)
        {
            return Directory.CreateDirectory(folderPath);
        }

        /// <summary>
        /// 删除指定的文件夹
        /// </summary>
        /// <param name="folderPath">文件夹名及路径</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteFolder(string folderPath)
        {
            if (!IsExists(folderPath, true))
            {
                return false;
            }
            Directory.Delete(folderPath);
            return true;
        }
    }
}
