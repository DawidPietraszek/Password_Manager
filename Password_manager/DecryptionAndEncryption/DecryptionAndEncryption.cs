using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Password_manager
{



    public class DecryptionAndEncryption
    {
        //Klucz do odszyfrowywania i odszyfrowywania danych
        private string key;

        /// <summary>
        /// Nadanie klucza.
        /// </summary>
        public DecryptionAndEncryption()
        {
            //Klucz głowny
            key = "awgoqkwd";

        }


        /// <summary>
        /// Szyfrowanie danych
        /// </summary>
        /// <param name="file Path">ścieżka pliku do szyfrowania</param>
        /// <param name="key">klucz</param>
        public void Decrypt(string filePath)
        {
            //Zaczytanie pliku w bytach
            byte[] plainContent = File.ReadAllBytes(filePath);


            //
            using (var DES = new DESCryptoServiceProvider())
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptoStream.Write(plainContent, 0, plainContent.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(filePath, memStream.ToArray());
                    Console.WriteLine("Koniec kodowania");
                }
            }


        }

        /// <summary>
        /// Odszyfrowanie danych
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        public void Encrypt(string filePath)
        {
            try
            {
                byte[] encrypted = File.ReadAllBytes(filePath);
                using (var DES = new DESCryptoServiceProvider())
                {
                    DES.IV = Encoding.UTF8.GetBytes(key);
                    DES.Key = Encoding.UTF8.GetBytes(key);
                    DES.Mode = CipherMode.CBC;
                    DES.Padding = PaddingMode.PKCS7;

                    using (var memStream = new MemoryStream())
                    {
                        CryptoStream cryptoStream = new CryptoStream(memStream, DES.CreateDecryptor(), CryptoStreamMode.Write);
                        cryptoStream.Write(encrypted, 0, encrypted.Length);
                        File.WriteAllBytes(filePath, memStream.ToArray());
                        Console.WriteLine("Koniec roz");
                    }
                }
            }
            catch (Exception)
            {

            }

        }


    }


}


