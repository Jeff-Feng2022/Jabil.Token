using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Jabil.Token
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    public class Encryption
    {
        /// <summary>
        /// 字符串MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(result).Replace("-", "");
        }

        /// <summary>
        /// DES加密KEY
        /// </summary>
        private static readonly string encryptKey = "4h!@w$rn";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <returns></returns>
        public static string DESEncrypt(string encryptString)
        {
            try
            {

                var des = DES.Create();
                byte[] inputByteArray;
                inputByteArray = Encoding.Default.GetBytes(encryptString);
                string md5SKey = encryptKey;
                des.Key = Encoding.ASCII.GetBytes(md5SKey);
                des.IV = Encoding.ASCII.GetBytes(md5SKey);
                MemoryStream ms = new();
                CryptoStream cs = new(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <returns></returns>
        public static string DESDecrypt(string decryptString)
        {
            try
            {
                var des = DES.Create();
                int len;
                len = decryptString.Length / 2;
                byte[] inputByteArray = new byte[len];
                int x, i;
                for (x = 0; x < len; x++)
                {
                    i = Convert.ToInt32(decryptString.Substring(x * 2, 2), 16);
                    inputByteArray[x] = (byte)i;
                }
                string md5SKey = encryptKey;
                des.Key = Encoding.ASCII.GetBytes(md5SKey);
                des.IV = Encoding.ASCII.GetBytes(md5SKey);
                MemoryStream ms = new();
                CryptoStream cs = new(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Encoding.Default.GetString(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static string GetSHA256HashFromString(string strData)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(strData);
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] retVal = sha256.ComputeHash(bytValue);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
