using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ScreenPlayer
{
    ///<summary>
    /// 3DES������
    ///</summary>
    public class TripleDES
    {
        string key = "";//��Կ,24λ16������,����24λ�Ĳ��ֻᱻɾ��
        string iv = "";//ƫ����,8λ16������,����8λ�Ĳ��ֻᱻɾ��

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        public TripleDES(string Key, string Iv)
        {
            key = Key;
            iv = Iv;
        }
        /// <summary>
        /// ���캯��,����
        /// </summary>
        public TripleDES()
        {
            key = "";
            iv = "";
        }

        #region ����,�ⲿ
        /// <summary>
        /// stream��ʽ����,����string
        /// </summary>
        /// <param name="cs">ԭ��stream</param>
        /// <returns>string������</returns>
        public string EncryptToString(Stream s)
        {
            return (string)TripleDESEncrypt(null, s, true);
        }

        /// <summary>
        /// string��ʽ����,����string
        /// </summary>
        /// <param name="s">ԭ��string</param>
        /// <returns>string������</returns>
        public string EncryptToString(string s)
        {
            return (string)TripleDESEncrypt(s, null, true);
        }

        /// <summary>
        /// string��ʽ����,����Byte[]
        /// </summary>
        /// <param name="s">ԭ��string</param>
        /// <returns>Byte[]������</returns>
        public byte[] EncryptToByte(string s)
        {
            return (byte[])TripleDESEncrypt(s, null, false);
        }

        /// <summary>
        /// stream��ʽ����,����Byte[]
        /// </summary>
        /// <param name="c">ԭ��stream</param>
        /// <returns>Byte[]������</returns>
        public byte[] EncryptToByte(Stream s)
        {
            return (byte[])TripleDESEncrypt(null, s, false);
        }

        #endregion

        #region ����,�ⲿ

        /// <summary>
        /// stream��ʽ����,����string
        /// </summary>
        /// <param name="s">����stream</param>
        /// <returns>string����ԭ��</returns>
        public string DecryptToString(Stream s)
        {
            return (string)TripleDESDecrypt(null, s, true);
        }

        /// <summary>
        /// stream��ʽ����,����string
        /// </summary>
        /// <param name="s">����string</param>
        /// <returns>string����ԭ��</returns>
        public string DecryptToString(string s)
        {
            return (string)TripleDESDecrypt(s, null, true);
        }

        /// <summary>
        /// stream��ʽ����,����Byte[]
        /// </summary>
        /// <param name="s">����stream</param>
        /// <returns>Byte[]����ԭ��</returns>
        public byte[] DecryptToByte(Stream s)
        {
            return (byte[])TripleDESDecrypt(null, s, false);
        }

        /// <summary>
        /// stream��ʽ����,����Byte[]
        /// </summary>
        /// <param name="s">����string</param>
        /// <returns>Byte[]����ԭ��</returns>
        public byte[] DecryptToByte(string s)
        {
            return (byte[])TripleDESDecrypt(s, null, false);
        }
        #endregion

        #region ����
        /// <summary>
        /// ��Կ,24λ16������,����24λ�Ĳ��ֻᱻɾ��
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// ƫ����,8λ16������,����8λ�Ĳ��ֻᱻɾ��
        /// </summary>
        public string IV
        {
            get { return iv; }
            set { iv = value; }
        }

        #endregion

        #region �ڲ�����
        /// <summary>
        /// 3DES-CBCstring����
        /// </summary>
        /// <param name="s">Ҫ���ܵ�string</param>
        /// <param name="st">Ҫ���ܵ�stream(���������stream,��ͨ��stream����,���򽫻��ȡstring)</param>
        /// <param name="returnString">��������,trueΪstring��,falseΪbyte[]��</param>
        /// <returns>�����returnString����ǿ�ƽ���ת��</returns>
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
                if (st == null)//string����
                {
                    inData = Encoding.UTF8.GetBytes(s);
                }
                else//Stream����
                {
                    inData = new byte[st.Length];
                    st.Read(inData, 0, inData.Length);
                    //���õ�ǰstream��λ��Ϊstream�Ŀ�ʼ
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
        /// 3DES-CBCstring����
        /// </summary>
        /// <param name="s">Ҫ���ܵ�string</param>
        /// <param name="st">Ҫ���ܵ�stream(���������stream,��ͨ��stream����,���򽫻��ȡstring)</param>
        /// <param name="returnString">��������,trueΪstring��,falseΪbyte[]��</param>
        /// <returns>�����returnString����ǿ�ƽ���ת��</returns>
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
                if (st == null)//string����
                {
                    inData = Convert.FromBase64String(s);
                }
                else//Stream����
                {
                    inData = new byte[st.Length];
                    st.Read(inData, 0, inData.Length);
                    // ���õ�ǰstream��λ��Ϊstream�Ŀ�ʼ
                    st.Seek(0, SeekOrigin.Begin);
                }
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }
                    if (returnString)//����string
                        return Encoding.UTF8.GetString(ms.ToArray());
                    else//����Byte[]
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
