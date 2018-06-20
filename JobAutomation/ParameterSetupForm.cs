using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace JobAutomation
{
    public partial class ParameterSetupForm : Form
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        OpenFileDialog ofd = new OpenFileDialog();
        public ParameterSetupForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 524, GlobalFunc.mainFormHeight);

            this.FormClosing += ParameterSetupForm_FormClosing;
            if (GlobalFunc.setup != null)
            {
                gammaVisionPath.Text = GlobalFunc.setup.gammamVisionPath;
                password.Text = GlobalFunc.Decrypt(GlobalFunc.setup.password);
            }
        }

        private void ParameterSetupForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void saveSetupBtn_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            setup.gammamVisionPath = gammaVisionPath.Text;
            setup.password = GlobalFunc.Encrypt(password.Text);
            string json = js.Serialize(setup);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
            GlobalFunc.LoadSetup();
            MessageBox.Show("Save setup parameter successful");
        }

        private void udpatePasswordBtn_Click(object sender, EventArgs e)
        {
            if (password.Text == verifyPassword.Text)
            {
                Setup setup = new Setup();
                setup.gammamVisionPath = gammaVisionPath.Text;
                setup.password = GlobalFunc.Encrypt(password.Text);
                string json = js.Serialize(setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
                MessageBox.Show("update Password successful");
            }
            else
            {
                MessageBox.Show("Verify Password not matched");
            }
        }


        private void gammaVisionPathBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gammaVisionPath.Text = ofd.FileName;
            }
        }


    }
}
