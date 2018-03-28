using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OnionNetCore.Core.Util
{
    public static class Encryption
    {
        private static readonly string EncryptionKey = "C8blnr1t";

        static readonly byte[] Iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };

        public static string Decrypt(string stringToDecrypt)
        {
            var key = Encoding.UTF8.GetBytes(EncryptionKey);
            var des = new DESCryptoServiceProvider();
            var inputByteArray = Convert.FromBase64String(stringToDecrypt);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateDecryptor(key, Iv), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        public static string Encrypt(string stringToEncrypt)
        {
            var key = Encoding.UTF8.GetBytes(EncryptionKey);
            var des = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(key, Iv), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}