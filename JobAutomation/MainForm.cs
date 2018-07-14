using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JobAutomation
{
    public partial class MainForm : Form
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        BackgroundWorker myBGWorker = new BackgroundWorker();
        BackgroundWorker skipBGWorker = new BackgroundWorker();
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, GlobalFunc.h / 2 - 330);
            this.FormClosing += Form1_Closing;

            versionLabel.Text = Application.ProductVersion;

            myBGWorker.DoWork += myBGWorker_DoWork;
            myBGWorker.ProgressChanged += myBGWorker_ProgressChanged;
            myBGWorker.RunWorkerCompleted += myBGWorker_RunWorkerCompleted;
            myBGWorker.WorkerReportsProgress = true;

            skipBGWorker.DoWork += skipBGWorker_DoWork;
            skipBGWorker.RunWorkerCompleted += skipBGWorker_RunWorkerCompleted;

            GlobalFunc.mainFormHeight = GlobalFunc.h / 2 - 330;
            scsBtn.Enabled = false;
            //quitBtn.Enabled = false;
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

            }
        }

        int thisNoOfSample = 0;
        private void scsBtn_Click(object sender, EventArgs e)
        {
            if (scsBtn.Text == "Run")
            {
                quitBtn.Enabled = false;
                scsBtn.Text = "Skip";
                thisNoOfSample = GlobalFunc.toggleProfileDetail.sampleNo;
                myBGWorker.RunWorkerAsync();
            }
            else if (scsBtn.Text == "Skip")
            {
                skipBGWorker.RunWorkerAsync();
                scsBtn.Enabled = false;
            }
        }

        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SetStatusLabel("Start Generate Scripts", 2);
            Operation.jobFileList = new List<string>();
            Operation.PrepareDirectory();
            myBGWorker.ReportProgress(1);
            for (int i = 0; i < thisNoOfSample; i++)
            {
                Operation.GenerateToFile(i);
                int percentage = (i + 1);
                myBGWorker.ReportProgress(percentage);
            }

            Operation.GenerateMasterFile();
            SetStatusLabel("Generate Script finished", 1);
            myBGWorker.ReportProgress(thisNoOfSample + 1);
            SetStatusLabel("Running Scripts...", 2);
            try
            {
                Operation.RunScript();
                Thread.Sleep(1000);
                string status = GetStatus();
            }
            catch (Exception ex)
            {
                SetStatusLabel("Error on running scripts" + ex.Message, 3);
                LogManager.WriteLog("Error on running scripts" + ex.Message);
            }
            if (InvokeRequired)
            {
                quitBtn.Enabled = true;
                scsBtn.Text = "Run";
                scsBtn.Enabled = true;
                SetStatusLabel("Completed", 1);
            }
            else
            {
                quitBtn.Enabled = true;
                scsBtn.Text = "Run";
                scsBtn.Enabled = true;
                SetStatusLabel("Completed", 1);
            }
        }

        private void skipBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SkipFunction();
                //Thread t = new Thread(GetShowActive);
                //t.Start();
            }
            catch (Exception ex)
            {
                SetStatusLabel("Error on skip" + ex.Message, 3);
                LogManager.WriteLog("Error on skip" + ex.Message);
            }
        }

        void myBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void myBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        void skipBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    quitBtn.Enabled = true;
            //    scsBtn.Text = "Run";
            //    scsBtn.Enabled = true;
            //}
            //else
            //{
            //    quitBtn.Enabled = true;
            //    scsBtn.Text = "Run";
            //    scsBtn.Enabled = true;
            //}
        }

        public string GetStatus()
        {
            string activeStatus = "";
            try
            {
                while (true)
                {
                    activeStatus = Operation.SendCommand("SHOW_ACTIVE");

                    if (activeStatus == "$C00001088\n") // is active
                    {
                        activeStatus = "active";
                    }
                    else
                    {
                        activeStatus = "inactive";
                    }

                    int intReturnValue = 0;
                    string returnValue = "";
                    if (GlobalFunc.setup.hardware == "DSPec50")
                    {
                        returnValue = Operation.SendCommand("SHOW_ID");
                    }
                    else if (GlobalFunc.setup.hardware == "DigiBASE")
                    {
                        returnValue = Operation.SendCommand("SHOW_LLD");
                    }
                    returnValue = returnValue.Replace("$C", "");
                    returnValue = returnValue.Substring(0, returnValue.Length - 4);
                    intReturnValue = Convert.ToInt32(returnValue);
                    if (activeStatus == "active")
                    {
                        SetSampleLabel(intReturnValue.ToString());
                        SetStatusLabel(returnValue, 2);
                    }

                    if (activeStatus == "inactive" && (intReturnValue == thisNoOfSample))
                    {
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.Message);
            }
            return activeStatus;
        }

        public string SkipFunction()
        {
            string returnValue = "";
            try
            {
                //int i = 0;
                //while (i < 20)
                //{

                if (GlobalFunc.setup.hardware == "DSPec50")
                {
                    returnValue = Operation.SendCommand("SHOW_ID");
                }
                else if (GlobalFunc.setup.hardware == "DigiBASE")
                {
                    returnValue = Operation.SendCommand("SHOW_LLD");
                }
                returnValue = returnValue.Replace("$C", "");
                returnValue = returnValue.Substring(0, returnValue.Length - 4);
                int intReturnValue = Convert.ToInt32(returnValue);
                SetStatusLabel(returnValue + " skipping...", 2);

                returnValue = Operation.SendCommand("STOP");
                //if (returnValue == "$C00001088\n") // is active
                //{
                //    returnValue = "active";
                //}
                //string setPresetLive = Operation.SendCommand("SET_PRESET_LIVE 1");
                //    i++;
                //    Thread.Sleep(5000);
                //}
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.Message);
            }
            return returnValue;
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
            Application.ExitThread();
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
            //sampleNoCB.Items.Clear();
            //for (int i = 1; i <= GlobalFunc.toggleProfileDetail.sampleNo; i++)
            //{
            //    sampleNoCB.Items.Add(i);
            //}
            #endregion
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SetStatusLabel(string text, int type)
        {
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    statusLabel.Text = text;
                    switch (type)
                    {
                        case 1: statusLabel.BackColor = Color.Yellow; break; // ready
                        case 2: statusLabel.BackColor = Color.Green; break; // running
                        case 3: statusLabel.BackColor = Color.Red; break; // error
                    }
                }));
                return;
            }
            else
            {
                statusLabel.Text = text;
                switch (type)
                {
                    case 1: statusLabel.BackColor = Color.Yellow; break; // ready
                    case 2: statusLabel.BackColor = Color.Green; break; // running
                    case 3: statusLabel.BackColor = Color.Red; break; // error
                }
            }
        }

        private void SetSampleLabel(string text)
        {
            if (InvokeRequired)
            {
                // after we've done all the processing, 
                this.Invoke(new MethodInvoker(delegate
                {
                    currentSampleNo.Text = text;
                }));
                return;
            }
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Quit?", "Delete Sequence", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.ExitThread();
                Application.Exit();

            }

        }

    }
}
