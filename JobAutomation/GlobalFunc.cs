using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Windows.Forms;
namespace JobAutomation
{
    public static class GlobalFunc
    {
        public static int loginStatus;
        public static MainForm mainForm;
        public static PasswordForm passwordForm;
        public static ParameterSetupForm parameterSetupForm;
        public static MeasurementSetupForm measurementSetupForm;
        public static EditSampleForm editSampleForm;

        public static int w = Screen.PrimaryScreen.Bounds.Width;
        public static int h = Screen.PrimaryScreen.Bounds.Height;
        public static int mainFormHeight;

        public static Setup setup;
        static bool useHashing = true;
        static string securityKey = "ficom2018";
        public static string passwordFormToggle = "";
        public static Profile profile;
        public static List<ProfileDetail> profileDetailList;
        public static string toggleProfile = "";
        public static ProfileDetail toggleProfileDetail;
        public static bool finishEditSample = false;
        public static int toggleTotalSample = 0;

        public static void LoadSetup()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setup.json"))
            {
                setup = new Setup();
                JavaScriptSerializer js = new JavaScriptSerializer();

                string setupText = File.ReadAllText( AppDomain.CurrentDomain.BaseDirectory + "setup.json");
                setup = (Setup)js.Deserialize<Setup>(setupText);
            }
        }

        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = securityKey;
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = securityKey;

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);            
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

    }
}
