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
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(150, GlobalFunc.h / 2 - 330);
            this.ControlBox = false; 
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
            //if (GlobalFunc.measurementSetupForm != null)
            //{
            //    GlobalFunc.measurementSetupForm.Dispose();
            //}
            if (CheckLoginStatus())
            {
                DisableRunSetupBtn();
                if (GlobalFunc.measurementSetupForm == null || GlobalFunc.measurementSetupForm.IsDisposed)
                {
                    GlobalFunc.measurementSetupForm = new MeasurementSetupForm();
                }

                
                GlobalFunc.measurementSetupForm.Show();
            }
        }

        public void DisableRunSetupBtn()
        {
            cssBtn.Enabled = false;
            scsBtn.Enabled = false;
        }

        public void EnablenSetupBtn()
        {
            cssBtn.Enabled = true;
            scsBtn.Enabled = true;
        }

        int thisNoOfSample = 0;
        List<int> skippedSample = new List<int>();
        private void scsBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GlobalFunc.toggleProfileDetail.dataFolder))
            {
                MessageBox.Show("Please setup data folder");
            }
            else
            {
                scsBtn.Enabled = false;
                cssBtn.Enabled = false;
                profileCB.Enabled = false;

                if (scsBtn.Text == "Run")
                {
                    skippedSample = new List<int>();
                    sampleNo = 0;
                    SetSampleLabel("0");
                    quitBtn.Enabled = false;
                    scsBtn.Text = "Skip";
                    thisNoOfSample = GlobalFunc.toggleProfileDetail.sampleNo;
                    runTime = DateTime.Now;
                    LogManager.WriteLog("Start running sequence: " + profileCB.Text);
                    myBGWorker.RunWorkerAsync();
                }
                else if (scsBtn.Text == "Skip")
                {
                    DialogResult dialogResult = MessageBox.Show("Confirm Skip?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        LogManager.WriteLog("Skip sequence " + profileCB.Text + " sample: " + sampleNo);
                        skipBGWorker.RunWorkerAsync();
                        scsBtn.Enabled = false;
                        skippedSample.Add(sampleNo);
                    }
                }
            }
        }

        public int sampleNo = 0;
        public DateTime runTime = DateTime.Now;
        private void myBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SetStatusLabel("Start Generate Scripts", 2);
            Operation.jobFileList = new List<string>();
            string prepareResult = Operation.PrepareDirectory();

            if (prepareResult != "")
            {
                MessageBox.Show(prepareResult);
            }

            for (int i = 0; i < thisNoOfSample; i++)
            {
                Operation.GenerateToFile(i);
            }

            Operation.GenerateMasterFile();
            SetStatusLabel("Generate Script finished", 1);
            //Thread.Sleep(1000); //wait the script is done.

            SetStatusLabel("Running Scripts...", 2);
            try
            {
                Operation.RunScript();
                Thread.Sleep(8000); // wait for gv32 open, and first script passed

                while (true)
                {
                    string activeStatus = GetRunningStatus();
                    sampleNo = GetRunningSampleNo();
                    if (activeStatus == "active")
                    {
                        scsBtn.Invoke(new Action(() => scsBtn.Enabled = true));
                        SetSampleLabel(sampleNo.ToString() + " / " + thisNoOfSample);
                        SetStatusLabel("Running Script...", 2);
                    }
                    Thread.Sleep(500);
                    if (activeStatus == "inactive" && sampleNo == thisNoOfSample)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusLabel("Error on running scripts" + ex.Message, 3);
                LogManager.WriteLog("Error on running scripts" + ex.Message);
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
            //while (GetStatus() == "")
            UpdateSkippedSample();
            if (InvokeRequired)
            {
                Thread.Sleep(2000);
                quitBtn.Enabled = true;
                scsBtn.Text = "Run";
                scsBtn.Enabled = true;
                LogManager.WriteLog("Completed sequence: " + profileCB.Text);
                SetStatusLabel("Completed", 1);
                SetSampleLabel("0");
                cssBtn.Enabled = true ;
                profileCB.Enabled = true;
            }
            else
            {
                Thread.Sleep(2000);
                quitBtn.Enabled = true;
                scsBtn.Text = "Run";
                scsBtn.Enabled = true;
                SetStatusLabel("Completed", 1);
                SetSampleLabel("0");
                cssBtn.Enabled = true;
                profileCB.Enabled = true;
            }
            
        }



        public void UpdateSkippedSample()
        {
            Thread.Sleep(5000);//wait the report file complete
            for (int i = 1; i <= thisNoOfSample; i++)
            {
                string path = GlobalFunc.toggleProfileDetail.dataFolder;
                string fileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + ".RPT";
                string AN1FileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + ".AN1";
                string UFOFileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + ".UFO";
                string SPCFileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + ".SPC";
                
                string datefileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00")+runTime.Hour.ToString("00")+runTime.Minute.ToString("00")+runTime.Second.ToString("00") + ".RPT";
                string dateAN1FileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + ".AN1";
                string dateUFOFileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + ".UFO";
                string dateSPCFileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + ".SPC";

                string skippedfileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + "_skipped.RPT";
                string skippedAN1fileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + "_skipped.AN1";
                string skippedUFOfileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + "_skipped.UFO";
                string skippedSPCfileName = GlobalFunc.toggleProfileDetail.prefix + "_" + i.ToString("000") + "_" + runTime.Year.ToString() + runTime.Month.ToString("00") + runTime.Day.ToString("00") + runTime.Hour.ToString("00") + runTime.Minute.ToString("00") + runTime.Second.ToString("00") + "_skipped.SPC";


                fileName = fileName.Replace("__", "_");
                AN1FileName = AN1FileName.Replace("__", "_");
                UFOFileName = UFOFileName.Replace("__", "_");
                SPCFileName = SPCFileName.Replace("__", "_");

                datefileName = datefileName.Replace("__", "_");
                dateAN1FileName = dateAN1FileName.Replace("__", "_");
                dateUFOFileName = dateUFOFileName.Replace("__", "_");
                dateSPCFileName = dateSPCFileName.Replace("__", "_");

                skippedfileName = skippedfileName.Replace("__", "_");
                skippedAN1fileName = skippedAN1fileName.Replace("__", "_");
                skippedUFOfileName = skippedUFOfileName.Replace("__", "_");
                skippedSPCfileName = skippedSPCfileName.Replace("__", "_");

                bool isSkipped = skippedSample.Exists(x => x == i);
                deleteMove(path, isSkipped, fileName, skippedfileName, datefileName);
                deleteMove(path, isSkipped, AN1FileName, skippedAN1fileName, dateAN1FileName);
                deleteMove(path, isSkipped, UFOFileName, skippedUFOfileName, dateUFOFileName);
                deleteMove(path, isSkipped, SPCFileName, skippedSPCfileName, dateSPCFileName);
            }
        }

        void deleteMove(string path, bool isSkipped, string source, string skipDesitnation, string destination)
        {
            if (File.Exists(path + @"\" + source))
            {
                if (isSkipped)
                {
                    if (File.Exists(path + @"\" + skipDesitnation))
                    {
                        File.Delete(path + @"\" + skipDesitnation);
                    }
                    File.Move(path + @"\" + source, path + @"\" + skipDesitnation);
                    File.Delete(path + @"\" + source);
                }
                else
                {
                    if (File.Exists(path + @"\" + destination))
                    {
                        File.Delete(path + @"\" + destination);
                    }
                    File.Move(path + @"\" + source, path + @"\" + destination);
                    File.Delete(path + @"\" + source);
                }
            }
        }

        void skipBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            while (true)
            {
                string activeStatus = Operation.SendCommand("SHOW_ACTIVE");

                if (activeStatus == "$C00001088\n") // is active
                {
                    activeStatus = "active";
                }
                else
                {
                    activeStatus = "inactive";
                }
                Thread.Sleep(400);
                if (activeStatus == "active")
                {
                    break;
                }

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
                int intReturnValue = Convert.ToInt32(returnValue);
                if (activeStatus == "inactive" && intReturnValue == thisNoOfSample)
                {
                    Thread.Sleep(1200);
                    break;
                }
            }
            if (InvokeRequired)
            {
                scsBtn.Enabled = true;
            }
            else
            {
                scsBtn.Enabled = true;
            }
        }

        public int GetRunningSampleNo()
        {
            int intReturnValue = 0;
            try
            {
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
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.Message);
            }
            return intReturnValue;
        }

        public string GetRunningStatus()
        {
            string runningStatus = "";
            try
            {
                runningStatus = Operation.SendCommand("SHOW_ACTIVE");

                if (runningStatus == "$C00001088\n") // is active
                {
                    runningStatus = "active";
                }
                else
                {
                    runningStatus = "inactive";
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex.Message);
            }
            return runningStatus;
        }

        public string SkipFunction()
        {
            string returnValue = "";
            try
            {


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
            else
            {
                currentSampleNo.Text = text;
            }
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Quit?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                LogManager.WriteLog("Quit");
                Application.ExitThread();
                Application.Exit();

            }

        }

    }
}
