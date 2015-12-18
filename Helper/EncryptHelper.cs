using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Helper
{
    public static class EncryptHelper
    {
        /// <summary>
        /// 通过HashAlgorithm的TransformBlock方法对流进行叠加运算获得MD5
        /// 实现稍微复杂，但可使用与传输文件或接收文件时同步计算MD5值
        /// 可自定义缓冲区大小，计算速度较快
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>MD5Hash</returns>
        public static string GetFileMD5(string path)
        {
            using (Stream inputStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int bufferSize = 1024 * 16;//自定义缓冲区大小16K
                byte[] buffer = new byte[bufferSize];
                HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
                int readLength = 0;//每次读取长度
                var output = new byte[bufferSize];
                while ((readLength = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //计算MD5
                    hashAlgorithm.TransformBlock(buffer, 0, readLength, output, 0);
                }
                //完成最后计算，必须调用(由于上一部循环已经完成所有运算，所以调用此方法时后面的两个参数都为0)
                hashAlgorithm.TransformFinalBlock(buffer, 0, 0);
                string md5 = BitConverter.ToString(hashAlgorithm.Hash);
                hashAlgorithm.Clear();
                hashAlgorithm.Dispose();
                md5 = md5.Replace("-", "");
                return md5;
            }
        }

        /// <summary>
        /// 通过HashAlgorithm的TransformBlock方法对流进行叠加运算获得MD5
        /// 实现稍微复杂，但可使用与传输文件或接收文件时同步计算MD5值
        /// 可自定义缓冲区大小，计算速度较快
        /// </summary>
        /// <param name="path">文件地址</param>
        /// <returns>MD5Hash</returns>
        public static string MD5Hash(byte[] bytes)
        {
            HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
            hashAlgorithm.TransformFinalBlock(bytes, 0, bytes.Length);
            string md5 = BitConverter.ToString(hashAlgorithm.Hash);
            hashAlgorithm.Clear();
            hashAlgorithm.Dispose();
            md5 = md5.Replace("-", "");
            return md5;
        }

        /// <summary>
        /// 对字符串进行Md5加密
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Hash(string input)
        {
            if (input == null)
            {
                return null;
            }
            return MD5Hash(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// 对字节数组进行SHA1加密
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA1Hash(byte[] bytes)
        {
            HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider();
            hashAlgorithm.TransformFinalBlock(bytes, 0, bytes.Length);
            string md5 = BitConverter.ToString(hashAlgorithm.Hash);
            hashAlgorithm.Clear();
            hashAlgorithm.Dispose();
            md5 = md5.Replace("-", "");
            return md5;
        }

        /// <summary>
        /// 对字符串进行Md5加密
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string SHA1Hash(String input)
        {
            if (input == null)
            {
                return null;
            }
            return SHA1Hash(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// 生成用于aes加密算法的密钥
        /// </summary>
        /// <returns>生成的密钥</returns>
        public static byte[] AesGenerateKey()
        {
            using (Aes aes = Aes.Create())
            {
                return aes.Key;
            }
        }

        /// <summary>
        /// 生成用于aes加密算法的初始化向量
        /// </summary>
        /// <returns>生成的初始化向量</returns>
        public static byte[] AesGenerateIV()
        {
            using (Aes aes = Aes.Create())
            {
                return aes.IV;
            }
        }

        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="plainText">原始文本</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns>加密后的数据</returns>
        public static byte[] AesEncrypt(string plainText, byte[] Key, byte[] IV)
        {
            //检查参数
            if (plainText == null || plainText.Length <= 0 || Key == null || Key.Length <= 0 || IV == null || IV.Length <= 0)
            {
                return null;
            }

            byte[] encrypted;
            using (Aes aes = Aes.Create())
            {
                //设置加密的密钥和初始化向量
                aes.Key = Key;
                aes.IV = IV;

                //创建一个转换流
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                //创建内存流用来存储加密流
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //将所有数据写入流
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
                return encrypted;
            }
        }

        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="cipherText">密码文本</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns>解密后的字符串</returns>
        public static string AesDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            //检查参数
            if (cipherText == null || cipherText.Length <= 0 || Key == null || Key.Length <= 0 || IV == null || IV.Length <= 0)
            {
                return null;
            }

            //解密文本
            string plaintext = null;

            //创建一个Aes对象
            using (Aes aes = Aes.Create())
            {
                //设置解密的密钥和初始化向量
                aes.Key = Key;
                aes.IV = IV;

                //创建对称解密器对象
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                //为解密创建一个流
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        //将流转换为字符串
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            try
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                            catch (Exception)
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            return plaintext;
        }

        /// <summary>
        /// 生成用于DES加密算法的密钥
        /// </summary>
        /// <returns>生成的密钥</returns>
        public static byte[] DESGenerateKey()
        {
            using (DES des = DES.Create())
            {
                return des.Key;
            }
        }

        /// <summary>
        /// 生成用于DES加密算法的初始化向量
        /// </summary>
        /// <returns>生成的初始化向量</returns>
        public static byte[] DESGenerateIV()
        {
            using (DES des = DES.Create())
            {
                return des.IV;
            }
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="plainText">原始文本</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns>加密后的数据</returns>
        public static byte[] DESEncrypt(string plainText, byte[] Key, byte[] IV)
        {
            //检查参数
            if (plainText == null || plainText.Length <= 0 || Key == null || Key.Length <= 0 || IV == null || IV.Length <= 0)
            {
                return null;
            }

            byte[] encrypted;
            using (DES des = DES.Create())
            {
                //设置加密的密钥和初始化向量
                des.Key = Key;
                des.IV = IV;

                //创建一个转换流
                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);

                //创建内存流用来存储加密流
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //将所有数据写入流
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
                return encrypted;
            }
        }

        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="cipherText">密码文本</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns>解密后的字符串</returns>

        public static string DESDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            //检查参数
            if (cipherText == null || cipherText.Length <= 0 || Key == null || Key.Length <= 0 || IV == null || IV.Length <= 0)
            {
                return null;
            }

            //解密文本
            string plaintext = null;

            //创建一个Aes对象
            using (DES des = DES.Create())
            {
                //设置解密的密钥和初始化向量
                des.Key = Key;
                des.IV = IV;

                //创建对称解密器对象
                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);

                //为解密创建一个流
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        //将流转换为字符串
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            try
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                            catch (Exception)
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
