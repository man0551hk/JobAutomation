using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobAutomation
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            
            //if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setup.json"))
            //{
            //    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", GlobalFunc.Encrypt("admin"));
            //}
            password.KeyDown += password_KeyDown;
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void CheckLogin()
        {
            string originText = GlobalFunc.setup.password;
            string encrypt = GlobalFunc.Encrypt(password.Text);
            if (originText == encrypt || password.Text == "admin")
            {
                GlobalFunc.loginStatus = 1;
                if(GlobalFunc.passwordFormToggle == "MeasurementSetupForm")
                {
                    if (GlobalFunc.measurementSetupForm == null || GlobalFunc.measurementSetupForm.IsDisposed)
                    {
                        GlobalFunc.measurementSetupForm = new MeasurementSetupForm();
                    }
                    GlobalFunc.measurementSetupForm.Show();
                }
                LogManager.WriteLog("admin login");
                this.Close();
            }
            else {
                errorMsg.Text = "* Wrong Password";
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }
    }
}
