using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JobAutomation
{
    public partial class MainForm : Form
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, GlobalFunc.h / 2 - 330);
            this.FormClosing += Form1_Closing;
            GlobalFunc.mainFormHeight = GlobalFunc.h / 2 - 330;
            scsBtn.Enabled = false;
            quitBtn.Enabled = false;
            SetProfile();
        }

        public void SetProfile()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "profile.json"))
            {
                GlobalFunc.profile = (Profile)js.Deserialize<Profile>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json"));
                profileCB.Items.Clear();
                for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
                {
                    profileCB.Items.Add(GlobalFunc.profile.operationName[i]);
                }
            }
            else
            {
                GlobalFunc.profile = new Profile();
                GlobalFunc.profile.operationName = new List<string>();
            }
        }

        private void psBtn_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "ParameterSetup";
            if (CheckLoginStatus())
            {
                if (GlobalFunc.parameterSetupForm == null || GlobalFunc.parameterSetupForm.IsDisposed)
                {
                    GlobalFunc.parameterSetupForm = new ParameterSetupForm();
                }
                GlobalFunc.parameterSetupForm.Show();

                if (GlobalFunc.measurementSetupForm != null)
                {
                    GlobalFunc.measurementSetupForm.Hide();
                    GlobalFunc.measurementSetupForm.Dispose();
                }
            }
        }

        private void cssBtn_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "MeasurementSetupForm";
            if (CheckLoginStatus())
            {
                if (GlobalFunc.measurementSetupForm == null || GlobalFunc.measurementSetupForm.IsDisposed)
                {
                    GlobalFunc.measurementSetupForm = new MeasurementSetupForm();
                }
                GlobalFunc.measurementSetupForm.Show();

                if (GlobalFunc.parameterSetupForm != null)
                {
                    GlobalFunc.parameterSetupForm.Hide();
                    GlobalFunc.parameterSetupForm.Dispose();
                }
            }
        }

        private void scsBtn_Click(object sender, EventArgs e)
        {
            //GlobalFunc.passwordFormToggle = "StartCountingSequence";

            //if (GlobalFunc.startCountingSequenceForm == null || GlobalFunc.startCountingSequenceForm.IsDisposed)
            //{
            //    GlobalFunc.startCountingSequenceForm = new StartCountingSequenceForm();
            //}
            //GlobalFunc.startCountingSequenceForm.Show();


            //if (GlobalFunc.parameterSetupForm != null)
            //{
            //    GlobalFunc.parameterSetupForm.Hide();
            //    GlobalFunc.parameterSetupForm.Dispose();
            //}

        }

        private bool CheckLoginStatus()
        {
            if (GlobalFunc.loginStatus == 1)
            {
                return true;
            }
            else
            {
                GlobalFunc.passwordForm.Dispose();
                GlobalFunc.passwordForm = new PasswordForm();
                GlobalFunc.passwordForm.Show();
                return false;
            }
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(profileCB.Text))
            {
                GlobalFunc.toggleProfile = profileCB.Text;
                
                scsBtn.Enabled = true;
                quitBtn.Enabled = true;
                if (GlobalFunc.measurementSetupForm != null && !GlobalFunc.measurementSetupForm.IsDisposed)
                {
                    GlobalFunc.measurementSetupForm.SelectionProfile(profileCB.Text);
                }
            }            
        }

        public void SelectionProfile(string profileName)
        {
            int selectIndex = 0;
            for (int i = 0; i < profileCB.Items.Count; i++)
            {
                if (profileCB.Items[i].ToString() == profileName)
                {
                    selectIndex = i;
                    break;
                }
            }
            profileCB.SelectedIndex = selectIndex;
        }
    }
}
