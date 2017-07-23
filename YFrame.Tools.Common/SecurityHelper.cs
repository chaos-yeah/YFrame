using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YFrame.Tools.Common
{
    /// <summary>
    /// 安全助手
    /// </summary>
    public class SecurityHelper
    {

        #region RSA

        /// <summary>
        /// RSA私钥
        /// </summary>
        private const string xmlPrivateKey = @"<RSAKeyValue><Modulus>vFdZIkCY0SIztPygZAoh0JfvYf95hh7LnQ4OxlpAx/hnFNtEUAZz9ugdDerxoL8tq1d+49CSmPabS5Ksi8eO8CFSrDexPiy/ScFVoZjXN9yO92O8Oekre6tpQDBK6PMb3JaGJ48ifAUcdCshRa1rx4OIw5oubMBqpOf7KlIQJZs=</Modulus><Exponent>AQAB</Exponent><P>27UDf2TEZuIKZJ9NxrTpYZpRBFayJKHL7/D/B8a05iVQBVZLCzUHq1rPJ726TsA1bdT6MaxaAphdnfZtHsxJLQ==</P><Q>23PuqW8ty6WVqJH71cTmj5vpdkSzQXv1tSJunLvLJV0w9zLDCs1nonGpPgMkoCAn3cJvECYTGB20H5bAYNlW5w==</Q><DP>yWSSAjKyPcSx1i6Ysq6ex5MW9K0rupx9PkJg5BXnOJe3VE0XmPxRPWeOQFWP9CQIVddGSEY+c+aK2gNLX1HPOQ==</DP><DQ>uMaDhDwtdhPE0DuirJpueyqOx1sPB6sk9k+4jNV+NcairPEb0mOix98l3iXtV7nbd1f4BcPZPev8tsBK2QEGrw==</DQ><InverseQ>Uwh8eEoB/6pxXoUOHuYSG7qspDgpFu2c3y84miHDhqx5M8Fug1BjEDV0A4/4rurYpzQGgemUYQPFAxuOPe4WsA==</InverseQ><D>jTghiWFONGGky6wwx1IhkLqbr6tTf5FPsu97fJbnxAkpoaXXTvnHsfbQ8kKb8p/mqnbsmf0mLrOaNcxAvH5hWbsYln3WyMVRP1nndmGv19/LpbpX94BcpoNhjoFpP9+ISfrooFUGBwLcYjfY1LFC794KhmeCc+nXwBEsb0mGvaE=</D></RSAKeyValue>";
        /// <summary>
        /// RSA公钥
        /// </summary>
        private const string xmlPublicKey = @"<RSAKeyValue><Modulus>vFdZIkCY0SIztPygZAoh0JfvYf95hh7LnQ4OxlpAx/hnFNtEUAZz9ugdDerxoL8tq1d+49CSmPabS5Ksi8eO8CFSrDexPiy/ScFVoZjXN9yO92O8Oekre6tpQDBK6PMb3JaGJ48ifAUcdCshRa1rx4OIw5oubMBqpOf7KlIQJZs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        /// <summary>  
        /// RSA产生密钥  
        /// </summary>  
        /// <param name="xmlKeys">私钥</param>  
        /// <param name="xmlPublicKey">公钥</param>  
        public static void RSAKey(out string xmlPrivateKey, out string xmlPublicKey)
        {
            var rsa = new RSACryptoServiceProvider();
            xmlPrivateKey = rsa.ToXmlString(true);
            xmlPublicKey = rsa.ToXmlString(false);
        }

        /// <summary>  
        /// RSA的加密函数  
        /// </summary>  
        /// <param name="xmlPublicKey">公钥</param>  
        /// <param name="encryptString">待加密的字符串</param>  
        /// <returns></returns>  
        public static string RSAEncrypt(string encryptString)
        {
            byte[] PlainTextBArray;
            byte[] CypherTextBArray;
            string Result;
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            PlainTextBArray = (new UnicodeEncoding()).GetBytes(encryptString);
            CypherTextBArray = rsa.Encrypt(PlainTextBArray, false);
            Result = Convert.ToBase64String(CypherTextBArray);
            return Result;
        }
        /// <summary>  
        /// RSA的加密函数   
        /// </summary>  
        /// <param name="xmlPublicKey">公钥</param>  
        /// <param name="EncryptString">待加密的字节数组</param>  
        /// <returns></returns>  
        public static string RSAEncrypt(byte[] EncryptString)
        {
            byte[] CypherTextBArray;
            string Result;
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            CypherTextBArray = rsa.Encrypt(EncryptString, false);
            Result = Convert.ToBase64String(CypherTextBArray);
            return Result;
        }

        /// <summary>  
        /// RSA的解密函数  
        /// </summary>  
        /// <param name="xmlPrivateKey">私钥</param>  
        /// <param name="decryptString">待解密的字符串</param>  
        /// <returns></returns>  
        public static string RSADecrypt(string decryptString)
        {
            byte[] PlainTextBArray;
            byte[] DypherTextBArray;
            string Result;
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            PlainTextBArray = Convert.FromBase64String(decryptString);
            DypherTextBArray = rsa.Decrypt(PlainTextBArray, false);
            Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
            return Result;

        }
        /// <summary>  
        /// RSA的解密函数   
        /// </summary>  
        /// <param name="xmlPrivateKey">私钥</param>  
        /// <param name="DecryptString">待解密的字节数组</param>  
        /// <returns></returns>  
        public static string RSADecrypt(byte[] DecryptString)
        {
            byte[] DypherTextBArray;
            string Result;
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            DypherTextBArray = rsa.Decrypt(DecryptString, false);
            Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
            return Result;
        }

        #endregion

        #region AES

        /// <summary>
        /// 对称密钥
        /// </summary>
        private const string key = "KLg644f84RG1p07634I1O5w8691D4X4G";

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="key">AES密钥，长度必须32位</param>
        /// <returns>加密后的字符串</returns>
        public static string AESEncrypt(string source)
        {
            using (var aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.Key = GetAesKey(key);
                aesProvider.Mode = CipherMode.ECB;
                aesProvider.Padding = PaddingMode.PKCS7;
                using (var cryptoTransform = aesProvider.CreateEncryptor())
                {
                    byte[] inputBuffers = Encoding.UTF8.GetBytes(source);
                    byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                    aesProvider.Clear();
                    aesProvider.Dispose();
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="key">AES密钥，长度必须32位</param>
        /// <returns>解密后的字符串</returns>
        public static string AESDecrypt(string source)
        {
            using (var aesProvider = new AesCryptoServiceProvider())
            {
                aesProvider.Key = GetAesKey(key);
                aesProvider.Mode = CipherMode.ECB;
                aesProvider.Padding = PaddingMode.PKCS7;
                using (var cryptoTransform = aesProvider.CreateDecryptor())
                {
                    byte[] inputBuffers = Convert.FromBase64String(source);
                    byte[] results = cryptoTransform.TransformFinalBlock(inputBuffers, 0, inputBuffers.Length);
                    aesProvider.Clear();
                    return Encoding.UTF8.GetString(results);
                }
            }
        }

        /// <summary>
        /// 获取AES加密key
        /// </summary>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        static byte[] GetAesKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key", "Aes密钥不能为空");
            }
            if (key.Length < 32)
            {
                // 不足32补全
                key = key.PadRight(32, '0');
            }
            if (key.Length > 32)
            {
                key = key.Substring(0, 32);
            }
            return Encoding.UTF8.GetBytes(key);
        }

        #endregion

        #region SHA&MD5

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public static string SHA256Encrypt(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            var algorithm = new SHA256Managed();
            return BitConverter.ToString(algorithm.ComputeHash(bytes)).Replace("-", "").ToUpper();
        }

        /// <summary>
        /// MD5加密字符串（32位小写）
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <returns>返回加密后的字符串</returns>
        public static string MD5Encrypt(string source)
        {
            string pwd = string.Empty;
            var md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(source));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x2");
            }
            return pwd;
        }

        #endregion

    }

}
