﻿using System;
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
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void CheckLogin()
        {
            string originText = GlobalFunc.setup.password;
            string encrypt = GlobalFunc.Encrypt(password.Text);
            if (originText == encrypt)
            {
                GlobalFunc.loginStatus = 1;
                if (GlobalFunc.passwordFormToggle == "ParameterSetup")
                {
                    if (GlobalFunc.parameterSetupForm == null || GlobalFunc.parameterSetupForm.IsDisposed)
                    {
                        GlobalFunc.parameterSetupForm = new ParameterSetupForm();
                    }
                    GlobalFunc.parameterSetupForm.Show();
                }
                else if(GlobalFunc.passwordFormToggle == "MeasurementSetupForm")
                {
                    if (GlobalFunc.measurementSetupForm == null || GlobalFunc.measurementSetupForm.IsDisposed)
                    {
                        GlobalFunc.measurementSetupForm = new MeasurementSetupForm();
                    }
                    GlobalFunc.measurementSetupForm.Show();
                }
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
