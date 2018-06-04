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
        BackgroundWorker myBGWorker = new BackgroundWorker();
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, GlobalFunc.h / 2 - 330);
            this.FormClosing += Form1_Closing;

            versionLabel.Text = Application.ProductVersion;

            toolStripStatusLabel1.Text = "";

            myBGWorker.DoWork += myBGWorker_DoWork;
            myBGWorker.ProgressChanged += myBGWorker_ProgressChanged;
            myBGWorker.RunWorkerCompleted += myBGWorker_RunWorkerCompleted;
            myBGWorker.WorkerReportsProgress = true;

            GlobalFunc.mainFormHeight = GlobalFunc.h / 2 - 330;
            scsBtn.Enabled = false;
            quitBtn.Enabled = false;
            GlobalFunc.LoadProfile();
            GlobalFunc.LoadProfileDetail();
            SetProfile();
        }

        public void SetProfile()
        {
            profileCB.Items.Clear();
            for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
            {
                profileCB.Items.Add(GlobalFunc.profile.operationName[i]);
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

        int thisNoOfSample = 0;
        private void scsBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sampleNoCB.Text))
            {
                MessageBox.Show("Please select sample no.");
            }
            else
            {
                thisNoOfSample = Convert.ToInt32(sampleNoCB.Text);
                progressBar.Minimum = 0;
                progressBar.Maximum = thisNoOfSample;

                myBGWorker.RunWorkerAsync();

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

        }

        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            toolStripStatusLabel1.Text = "Start Generate Scripts";
            Operation.PrepareDirectory();
            myBGWorker.ReportProgress(1);
            for (int i = 0; i < thisNoOfSample; i++)
            {
                Operation.GenerateToFile(i);
                int percentage = (i + 1);
                myBGWorker.ReportProgress(percentage);
            }
        }

        void myBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        void myBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Generate Script finished";
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
                GlobalFunc.toggleProfileDetail = GlobalFunc.profileDetailList.Find(pd => pd.operationName == profileCB.Text);
                scsBtn.Enabled = true;
                quitBtn.Enabled = true;
                SelectionProfile(profileCB.Text);
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
            GlobalFunc.toggleProfile = profileName;
            profileCB.SelectedIndex = selectIndex;

            GlobalFunc.toggleProfileDetail = GlobalFunc.profileDetailList.Find(pd => pd.operationName == profileName);

            #region set sampleNo
            for (int i = 1; i <= GlobalFunc.toggleProfileDetail.sampleNo; i++)
            {
                sampleNoCB.Items.Add(i);
            }
            #endregion
        }
    }
}
