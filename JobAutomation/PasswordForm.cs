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
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "setup.txt"))
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.txt", GlobalFunc.Encrypt("admin"));
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string originText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.txt");
            string encrypt = GlobalFunc.Encrypt(password.Text);
            if (originText == encrypt)
            {
                GlobalFunc.loginStatus = 1;
            }
        }
    }
}
