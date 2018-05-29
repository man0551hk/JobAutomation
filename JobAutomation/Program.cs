using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

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

            Operation.GenerateDefaultJobTemplate();
           
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setup.json"))
            {
                GlobalFunc.mainForm.ShowMessage("setup.json not existed");
            }
            else
            {
                GlobalFunc.LoadSetup();
            }
            Application.Run(GlobalFunc.mainForm);
        }
    }
}
