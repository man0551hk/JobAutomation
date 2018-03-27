using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            Application.Run(new Form1());
            
        }
    }
}
