using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace JobAutomation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalFunc.loginStatus = 0;

            GlobalFunc.passwordForm = new PasswordForm();
            GlobalFunc.mainForm = new MainForm();

        
           
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setup.json"))
            {
                GlobalFunc.mainForm.ShowMessage("setup.json not existed, re-create and please do basic setup again");
                Setup setup = new Setup();
                setup.gammamVisionPath = "";
                setup.password = GlobalFunc.Encrypt("admin");
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
            }
            else
            {
                GlobalFunc.LoadSetup();
            }

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefSample.Job".ToLower()))
            {
                GlobalFunc.mainForm.ShowMessage("DefSample.Job file not found");
            }

            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "DefOptions.Txt".ToLower()))
            {
                GlobalFunc.mainForm.ShowMessage("DefOptions.Txt file not found");
            }
                

            Application.Run(GlobalFunc.mainForm);
        }
    }
}
