using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
namespace JobAutomation
{
    public partial class Form1 : Form
    {
        OpenFileDialog sdfOFD = new OpenFileDialog();
        OpenFileDialog gammaOFD = new OpenFileDialog();
        Analysis toggleAnalysis = new Analysis();
        JavaScriptSerializer js = new JavaScriptSerializer();
        
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_Closing;
            DefaultFormSetup();
            LoadCountSequenceIndex();
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void DefaultFormSetup()
        {
            csListComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.parameterSetupPanel.Visible = false;
            this.analysisSettingsPanel.Visible = false;
        }

        private void openLoopFileBtn_Click(object sender, EventArgs e)
        {
            //openLoopJobFileDialog.InitialDirectory = "c:\\";
            //openLoopJobFileDialog.Filter = "job files (*.job)|*.job";
            //openLoopJobFileDialog.FilterIndex = 2;
            //openLoopJobFileDialog.Title = "Select Job File";

            //openLoopJobFileDialog.RestoreDirectory = true;

            //if (openLoopJobFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        loopJobFilePath.Text = openLoopJobFileDialog.FileName;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            //    }
            //}
        }
        
        private void parameterSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "ParameterSetup";
            if (CheckLoginStatus())
            {
                DisplayParameterSetupPanel();
            }
        }

        private void setupCountingSequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "CountingSequence";
            if (CheckLoginStatus())
            {
                DisplayCountingSequencePanel();
            }
        }

        public void ShowMessage(string msg)
        { 
            MessageBox.Show(msg);
        }

        public void DisplayParameterSetupPanel()
        {
            this.parameterSetupPanel.Visible = true;
            this.analysisSettingsPanel.Visible = false;
            CtrlCSElement(false);
            if (GlobalFunc.setup != null)
            {
                updateSDFFilePath.Text = GlobalFunc.setup.sdfFilePath;
                gammaVisionPath.Text = GlobalFunc.setup.gammamVisionPath;
                analysisListPrefix.Text = GlobalFunc.setup.analysisListPrefix;
                password.Text = GlobalFunc.Decrypt(GlobalFunc.setup.password);
                verifyPassword.Text = GlobalFunc.Decrypt(GlobalFunc.setup.password);
            }
        }

        public void DisplayCountingSequencePanel()
        {
            this.parameterSetupPanel.Visible = false;
            this.analysisSettingsPanel.Visible = true;
            csListComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            CtrlCSElement(true);
            analysisSettingsPanel.Enabled = false;
        }

        public void CtrlCSElement(bool display)
        {
            groupBox1.Visible = display;
            addCsBtn.Visible = display;
            exitSetupBtn.Visible = display;
            removeCsBtn.Visible = display;

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

        private void updateSDFFilePathBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            { 
                updateSDFFilePath.Text = sdfOFD.FileName;
            }
        }

        private void gammaVisionPathBtn_Click(object sender, EventArgs e)
        {
            if (gammaOFD.ShowDialog() == DialogResult.OK)
            {
                gammaVisionPath.Text = sdfOFD.FileName;
            }
        }

        private void saveSetupBtn_Click(object sender, EventArgs e)
        {
            if (password.Text != verifyPassword.Text)
            {
                ShowMessage("Verify Password not matched");
            }
            else
            {
                Setup setup = new Setup();
                setup.sdfFilePath = updateSDFFilePath.Text;
                setup.gammamVisionPath = gammaVisionPath.Text;
                setup.analysisListPrefix = analysisListPrefix.Text;
                setup.password = GlobalFunc.Encrypt(password.Text);

                string json = js.Serialize(setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
                ShowMessage("Save setup parameter successful");
            }
        }

        public void LoadCountSequenceIndex()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "countingSequenceIndex.json"))
            {
                GlobalFunc.countingSequenceIndex = (CountingSequenceIndex)js.Deserialize<CountingSequenceIndex>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "countingSequenceIndex.json"));
                csListComboBox.Items.Clear();
                for (int i = 0; i < GlobalFunc.countingSequenceIndex.operationName.Count; i++)
                {
                    csListComboBox.Items.Add(GlobalFunc.countingSequenceIndex.operationName[i]);
                }
            }
            else
            {
                GlobalFunc.countingSequenceIndex = new CountingSequenceIndex();
                GlobalFunc.countingSequenceIndex.operationName = new List<string>();
            }
        }

        private void addCsBtn_Click(object sender, EventArgs e)
        {
            string name = csListComboBox.Text;
            bool allow = true;
            for (int i = 0; i < GlobalFunc.countingSequenceIndex.operationName.Count; i++)
            {
                if (name == GlobalFunc.countingSequenceIndex.operationName[i])
                {
                    allow = false;
                    break;
                }
            }
            if (allow)
            {
                GlobalFunc.countingSequenceIndex.operationName.Add(name);
                string json = js.Serialize(GlobalFunc.countingSequenceIndex);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "countingSequenceIndex.json", json);
                LoadCountSequenceIndex();
            }
            else
            {
                ShowMessage("The opertaion name existed");
            }
        }

        private void csListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleAnalysis = new Analysis();
            string operationName = csListComboBox.Text;
            removeAnalysisBtn.Enabled = true;
            addAnalysisBtn.Enabled = true;
            LoadAnalysisList(operationName);

        }

        public void LoadAnalysisList(string operationName)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence/" + operationName + ".json"))
            {
                analysisListBox.Items.Clear();
                toggleAnalysis = (Analysis)js.Deserialize<Analysis>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence/" + operationName + ".json"));
                if (toggleAnalysis.CreateDate == null)
                {
                    toggleAnalysis.CreateDate = DateTime.Now.ToString();
                }
                for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
                {
                    analysisListBox.Items.Add(toggleAnalysis.analysisList[i].name);
                }
            }
        }

        private void addAnalysisBtn_Click(object sender, EventArgs e)
        {
            int maxIndex = 0;
            if (toggleAnalysis.analysisList != null && toggleAnalysis.analysisList.Count > 0)
            {
                maxIndex = toggleAnalysis.analysisList.Max(t => t.index);
            }
            else
            {
                toggleAnalysis.analysisList = new List<AnalysisSetting>();
            }
            maxIndex += 1;
            AnalysisSetting analysisSetting = new AnalysisSetting();
            analysisSetting.index = maxIndex;
           
            analysisSetting.name = GlobalFunc.setup.analysisListPrefix + maxIndex.ToString("000");
            toggleAnalysis.analysisList.Add(analysisSetting);

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence");
            }

            string operationName = csListComboBox.Text;
            string json = js.Serialize(toggleAnalysis);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence/" + operationName + ".json", json);
            LoadAnalysisList(operationName);
        }

        private void analysisListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string settingName = analysisListBox.SelectedItem.ToString();
            if (analysisSettingsPanel.Visible) //setup operation
            {
                analysisSettingsPanel.Enabled = true;
            }
            else //normal opertation
            { }
        }

        public void LoadAnalysisSettingItem(string name)
        {
            for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
            {
                if (name == toggleAnalysis.analysisList[i].name)
                {

                    break;
                }
            }
        }


    }
}
