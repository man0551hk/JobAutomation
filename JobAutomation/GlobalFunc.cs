using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
using System.Windows.Forms;
using AxUMCBILib;
namespace JobAutomation
{
    public static class GlobalFunc
    {
        public static int loginStatus;
        public static MainForm mainForm;
        public static PasswordForm passwordForm;
        public static MeasurementSetupForm measurementSetupForm;
        public static EditSampleForm editSampleForm;
        public static TestConnection tc; 

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

        public static AxUCONN2 axUCONN21 ;

        public static void LoadSetup()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setup.json"))
            {
                setup = new Setup();
                JavaScriptSerializer js = new JavaScriptSerializer();

                string setupText = File.ReadAllText( AppDomain.CurrentDomain.BaseDirectory + "setup.json");
                setup = (Setup)js.Deserialize<Setup>(setupText);
                if (setup.defaultData == "")
                {
                    setup.defaultData = @"C:\User\Reports";
                }
                if (setup.defaultSdf == "")
                {
                    setup.defaultSdf = @"C:\User\Sample Types";
                }
                if (setup.defaultLib == "")
                {
                    setup.defaultLib = @"C:\User\Libraries";
                }
                if (setup.defaultCal == "")
                {
                    setup.defaultCal = @"C:\User\Calibrations";
                }
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

        public static void LoadProfile()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "ProfileDetail"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "ProfileDetail");
            }
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "profile.json"))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                GlobalFunc.profile = (Profile)js.Deserialize<Profile>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json"));
            }
            else
            {
                GlobalFunc.profile = new Profile();
                GlobalFunc.profile.operationName = new List<string>();
            }
        }

        public static void LoadProfileDetail()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            GlobalFunc.profileDetailList = new List<ProfileDetail>();
            for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.profile.operationName[i] + ".json"))
                {
                    ProfileDetail profileDetail = (ProfileDetail)js.Deserialize<ProfileDetail>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.profile.operationName[i] + ".json"));
                    GlobalFunc.profileDetailList.Add(profileDetail);
                }
                else
                {
                    #region default profile
                    ProfileDetail profileDetail = new ProfileDetail();
                    profileDetail.operationName = GlobalFunc.profile.operationName[i];
                    profileDetail.CreateDate = DateTime.Now.ToString();
                    profileDetail.sampleDetailList = new List<SampleDetail>();
                    profileDetail.dataFoleder = "";
                    profileDetail.prefix = "";
                    profileDetail.sampleNo = 0;
                    profileDetail.sampleDefinitionFile = "";
                    profileDetail.calibrationFile = "";
                    profileDetail.commonCalibrationFile = true;
                    profileDetail.qtyUnit = "";
                    profileDetail.commonQtyUnit = true;
                    profileDetail.qty = 0;
                    profileDetail.commonQty = true;
                    profileDetail.countingTime = 0;
                    profileDetail.commonCountingTime = true;
                    profileDetail.activityUnit = "";
                    profileDetail.commonActivityUnit = true;
                    profileDetail.libraryFile = "";
                    profileDetail.decayCorrection = false;
                    profileDetail.decayCorrectionDate = DateTime.Now.ToString();
                    GlobalFunc.profileDetailList.Add(profileDetail);
                    #endregion
                }
            }
        }
    }
}
