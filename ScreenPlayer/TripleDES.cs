using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ScreenPlayer
{
    ///<summary>
    /// 3DES加密类
    ///</summary>
    public class TripleDES
    {
        string key = "";//密钥,24位16进制数,超过24位的部分会被删除
        string iv = "";//偏移量,8位16进制数,超过8位的部分会被删除

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        public TripleDES(string Key, string Iv)
        {
            key = Key;
            iv = Iv;
        }
        /// <summary>
        /// 构造函数,重载
        /// </summary>
        public TripleDES()
        {
            key = "";
            iv = "";
        }

        #region 加密,外部
        /// <summary>
        /// stream方式加密,返回string
        /// </summary>
        /// <param name="cs">原文stream</param>
        /// <returns>string型密文</returns>
        public string EncryptToString(Stream s)
        {
            return (string)TripleDESEncrypt(null, s, true);
        }

        /// <summary>
        /// string方式加密,返回string
        /// </summary>
        /// <param name="s">原文string</param>
        /// <returns>string型密文</returns>
        public string EncryptToString(string s)
        {
            return (string)TripleDESEncrypt(s, null, true);
        }

        /// <summary>
        /// string方式加密,返回Byte[]
        /// </summary>
        /// <param name="s">原文string</param>
        /// <returns>Byte[]型密文</returns>
        public byte[] EncryptToByte(string s)
        {
            return (byte[])TripleDESEncrypt(s, null, false);
        }

        /// <summary>
        /// stream方式加密,返回Byte[]
        /// </summary>
        /// <param name="c">原文stream</param>
        /// <returns>Byte[]型密文</returns>
        public byte[] EncryptToByte(Stream s)
        {
            return (byte[])TripleDESEncrypt(null, s, false);
        }

        #endregion

        #region 解密,外部

        /// <summary>
        /// stream方式解密,返回string
        /// </summary>
        /// <param name="s">密文stream</param>
        /// <returns>string类型原文</returns>
        public string DecryptToString(Stream s)
        {
            return (string)TripleDESDecrypt(null, s, true);
        }

        /// <summary>
        /// stream方式解密,返回string
        /// </summary>
        /// <param name="s">密文string</param>
        /// <returns>string类型原文</returns>
        public string DecryptToString(string s)
        {
            return (string)TripleDESDecrypt(s, null, true);
        }

        /// <summary>
        /// stream方式解密,返回Byte[]
        /// </summary>
        /// <param name="s">密文stream</param>
        /// <returns>Byte[]类型原文</returns>
        public byte[] DecryptToByte(Stream s)
        {
            return (byte[])TripleDESDecrypt(null, s, false);
        }

        /// <summary>
        /// stream方式解密,返回Byte[]
        /// </summary>
        /// <param name="s">密文string</param>
        /// <returns>Byte[]类型原文</returns>
        public byte[] DecryptToByte(string s)
        {
            return (byte[])TripleDESDecrypt(s, null, false);
        }
        #endregion

        #region 属性
        /// <summary>
        /// 密钥,24位16进制数,超过24位的部分会被删除
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 偏移量,8位16进制数,超过8位的部分会被删除
        /// </summary>
        public string IV
        {
            get { return iv; }
            set { iv = value; }
        }

        #endregion

        #region 内部方法
        /// <summary>
        /// 3DES-CBCstring加密
        /// </summary>
        /// <param name="s">要加密的string</param>
        /// <param name="st">要加密的stream(如果传入了stream,则通过stream加密,否则将会读取string)</param>
        /// <param name="returnString">返回类型,true为string型,false为byte[]型</param>
        /// <returns>请根据returnString参数强制进行转换</returns>
        private object TripleDESEncrypt(string s, Stream st, bool returnString)
        {
            key = key.Substring(0, 24);
            iv = iv.Substring(0, 8);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            using (MemoryStream ms = new MemoryStream())
            {

                byte[] inData;
                if (st == null)//string加密
                {
                    inData = Encoding.UTF8.GetBytes(s);
                }
                else//Stream加密
                {
                    inData = new byte[st.Length];
                    st.Read(inData, 0, inData.Length);
                    //设置当前stream的位置为stream的开始
                    st.Seek(0, SeekOrigin.Begin);
                }
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    if (returnString)
                        return Convert.ToBase64String(ms.ToArray());
                    else
                        return ms.ToArray();
                }
                catch
                {
                    throw;
                }
            }
            return null;
        }

        /// <summary>
        /// 3DES-CBCstring解密
        /// </summary>
        /// <param name="s">要解密的string</param>
        /// <param name="st">要解密的stream(如果传入了stream,则通过stream解密,否则将会读取string)</param>
        /// <param name="returnString">返回类型,true为string型,false为byte[]型</param>
        /// <returns>请根据returnString参数强制进行转换</returns>
        private object TripleDESDecrypt(string s, Stream st, bool returnString)
        {
            key = key.Substring(0, 24);
            iv = iv.Substring(0, 8);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData;
                if (st == null)//string解密
                {
                    inData = Convert.FromBase64String(s);
                }
                else//Stream解密
                {
                    inData = new byte[st.Length];
                    st.Read(inData, 0, inData.Length);
                    // 设置当前stream的位置为stream的开始
                    st.Seek(0, SeekOrigin.Begin);
                }
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    if (returnString)//返回string
                        return Encoding.UTF8.GetString(ms.ToArray());
                    else//返回Byte[]
                        return ms.ToArray();
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion
    }
}
