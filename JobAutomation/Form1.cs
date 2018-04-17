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
        SaveFileDialog saveTemplateDialog = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
            DefaultFormSetup();
            this.FormClosing += Form1_Closing;
           
            LoadCountSequenceIndex();
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void DefaultFormSetup()
        {
            csListComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            exitSetupBtn.Visible = false;
            saveTemplateDialog.Filter = "GV Automation Files (*.gva)|*.gva";
            saveTemplateDialog.DefaultExt = "gva";
            saveTemplateDialog.AddExtension = true;
            saveTemplateDialog.FileOk += saveTemplateDialog_FileOk;
            //sampleDefaultFilePathTxt.TextChanged += TextBox_TextChanged;
            //sampleDefaultFilePathCB.CheckedChanged += CheckBox_CheckedChanged;

            //spectrumFilePathTxt.TextChanged += TextBox_TextChanged;
            //spectrumFilePatbCB.CheckedChanged += CheckBox_CheckedChanged;

            //jobTemplatePathTxt.TextChanged += TextBox_TextChanged;
            //jobTemplatePathCB.CheckedChanged += CheckBox_CheckedChanged;

            //sampleDefaultFilePathTxt.TextChanged += TextBox_TextChanged;
            //sampleDefaultFilePathCB.CheckedChanged += CheckBox_CheckedChanged;

            //calibrationFilePathTxt.TextChanged += TextBox_TextChanged;
            //calibrationFilePathCB.CheckedChanged += CheckBox_CheckedChanged;

            //libraryFilePathTxt.TextChanged += TextBox_TextChanged;
            //libraryFilePathCB.CheckedChanged += CheckBox_CheckedChanged;

            //collectionStartDatePicker.TextChanged += TextBox_TextChanged;
            //collectionStartDateCB.CheckedChanged += CheckBox_CheckedChanged;

            //collectionStopDatePicker.TextChanged += TextBox_TextChanged;
            //collectionStopDateCB.CheckedChanged += CheckBox_CheckedChanged;

            //decayCorrectionStopDateTimeCB.CheckedChanged += CheckBox_CheckedChanged;

            //decayCorrectionDatePicker.TextChanged += TextBox_TextChanged;
            //decayCorrectionDateCB.CheckedChanged += CheckBox_CheckedChanged;

            sampleQuantityTxt.KeyPress += CheckISNumber_KeyPress;
            //sampleQuantityTxt.TextChanged += TextBox_TextChanged;
            //sampleQuantityCB.CheckedChanged += CheckBox_CheckedChanged;

            //unitsTxt.TextChanged += TextBox_TextChanged;
            //unitsCB.CheckedChanged += CheckBox_CheckedChanged;

            //activityUnitsTxt.TextChanged += TextBox_TextChanged;
            //activityUnitsCB.CheckedChanged += CheckBox_CheckedChanged;

            liveTimePresetTxt.KeyPress += CheckISNumber_KeyPress;
            //liveTimePresetTxt.TextChanged += TextBox_TextChanged;
            //liveTimePresetCB.CheckedChanged += CheckBox_CheckedChanged;

            realTimePresetTxt.KeyPress += CheckISNumber_KeyPress;
            //realTimePresetTxt.TextChanged += TextBox_TextChanged;
            //realTimePresetCB.CheckedChanged += CheckBox_CheckedChanged;

            activityMultiperTxt.KeyPress += CheckISNumber_KeyPress;
            //activityMultiperTxt.TextChanged += TextBox_TextChanged;
            //activityMultiperCB.CheckedChanged += CheckBox_CheckedChanged;

            activityDivisorTxt.KeyPress += CheckISNumber_KeyPress;
            //activityDivisorTxt.TextChanged += TextBox_TextChanged;
            //activityDivisorCB.CheckedChanged += CheckBox_CheckedChanged;

            randomSummingFactorTxt.KeyPress += CheckISNumber_KeyPress;
            //randomSummingFactorTxt.TextChanged += TextBox_TextChanged;
            //randomSummingFactorCB.CheckedChanged += CheckBox_CheckedChanged;

            randomErrorTxt.KeyPress += CheckISNumber_KeyPress;
            //randomErrorTxt.TextChanged += TextBox_TextChanged;
            //randomErrorCB.CheckedChanged += CheckBox_CheckedChanged;

            systematicErrorTxt.KeyPress += CheckISNumber_KeyPress;
            //systematicErrorTxt.TextChanged += TextBox_TextChanged;
            //systematicErrorCB.CheckedChanged += CheckBox_CheckedChanged;

            attenuationSizeTxt.KeyPress += CheckISNumber_KeyPress;
            //attenuationSizeTxt.TextChanged += TextBox_TextChanged;
            //attenuationSizeCB.CheckedChanged += CheckBox_CheckedChanged;

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
            exitSetupBtn.Visible = display;
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

            SaveAnalysisToFile();
        }

        private void analysisListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string settingName = analysisListBox.SelectedItem.ToString();
            if (analysisSettingsPanel.Visible) //setup operation
            {
                analysisSettingsPanel.Enabled = true;
                LoadAnalysisSettingItem(settingName);
            }
            else //normal opertation
            {
                
            }
        }

        public void LoadNomalOpertationItem(string name)
        {
            for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
            {
                if (name == toggleAnalysis.analysisList[i].name)
                {

                }
            }
        }

        public void LoadAnalysisSettingItem(string name)
        {
            for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
            {
                if (name == toggleAnalysis.analysisList[i].name)
                {
                    sampleDescriptionTxt.Text = toggleAnalysis.analysisList[i].sampleDefaultFilePath;
                    sampleDescriptionCB.Checked = toggleAnalysis.analysisList[i].allowSampleDefaultFilePath;

                    spectrumFilePathTxt.Text = toggleAnalysis.analysisList[i].spectrumFilePath;
                    spectrumFilePatbCB.Checked = toggleAnalysis.analysisList[i].allowSpectrumFilePath;

                    jobTemplatePathTxt.Text = toggleAnalysis.analysisList[i].jobTemplatePath;
                    jobTemplatePathCB.Checked = toggleAnalysis.analysisList[i].allowJobTemplatePath;

                    sampleDefaultFilePathTxt.Text = toggleAnalysis.analysisList[i].sampleDefaultFilePath;
                    sampleDefaultFilePathCB.Checked = toggleAnalysis.analysisList[i].allowSampleDefaultFilePath;

                    calibrationFilePathTxt.Text = toggleAnalysis.analysisList[i].calibrationFilePath;
                    calibrationFilePathCB.Checked = toggleAnalysis.analysisList[i].allowCalibrationFilePath;

                    libraryFilePathTxt.Text = toggleAnalysis.analysisList[i].libraryFilePath;
                    libraryFilePathCB.Checked = toggleAnalysis.analysisList[i].allowLibraryFilePath;

                    collectionStartDatePicker.Text = toggleAnalysis.analysisList[i].collectionStartDate;
                    collectionStartDateCB.Checked = toggleAnalysis.analysisList[i].allowCollectionStartDate;

                    collectionStopDatePicker.Text = toggleAnalysis.analysisList[i].collectionStopDate;
                    collectionStopDateCB.Checked = toggleAnalysis.analysisList[i].allowCollectionStopDate;

                    decayCorrectionStopDateTimeCB.Checked = toggleAnalysis.analysisList[i].decayCorrectionStopDateTime;

                    decayCorrectionDatePicker.Text = toggleAnalysis.analysisList[i].decayCorrectionDate;
                    decayCorrectionDateCB.Checked = toggleAnalysis.analysisList[i].allowDecayCorrectionDate;

                    sampleQuantityTxt.Text = toggleAnalysis.analysisList[i].sampleQuantity != 0 ? toggleAnalysis.analysisList[i].sampleQuantity.ToString() : "";
                    sampleQuantityCB.Checked = toggleAnalysis.analysisList[i].allowSampleQuantity;

                    unitsTxt.Text = toggleAnalysis.analysisList[i].units;
                    unitsCB.Checked = toggleAnalysis.analysisList[i].allowUnits;

                    activityUnitsTxt.Text = toggleAnalysis.analysisList[i].activityUnits;
                    activityUnitsCB.Checked = toggleAnalysis.analysisList[i].allowActivityUnits;

                    liveTimePresetTxt.Text = toggleAnalysis.analysisList[i].liveTimePreset != 0 ? toggleAnalysis.analysisList[i].liveTimePreset.ToString() : "";
                    liveTimePresetCB.Checked = toggleAnalysis.analysisList[i].allowLiveTimePreset;

                    realTimePresetTxt.Text = toggleAnalysis.analysisList[i].realTimePreset != 0 ? toggleAnalysis.analysisList[i].realTimePreset.ToString() : "";
                    realTimePresetCB.Checked = toggleAnalysis.analysisList[i].allowRealTimePreset;

                    activityMultiperTxt.Text = toggleAnalysis.analysisList[i].activityMultiper != 0 ? toggleAnalysis.analysisList[i].activityMultiper.ToString() : "";
                    activityMultiperCB.Checked = toggleAnalysis.analysisList[i].allowActivityMultiper;

                    activityDivisorTxt.Text = toggleAnalysis.analysisList[i].activityDivisor != 0 ? toggleAnalysis.analysisList[i].activityDivisor.ToString() : "";
                    activityDivisorCB.Checked = toggleAnalysis.analysisList[i].allowActivityDivisor;

                    randomSummingFactorTxt.Text = toggleAnalysis.analysisList[i].randomSummingFactor != 0 ? toggleAnalysis.analysisList[i].randomSummingFactor.ToString() : "";
                    randomSummingFactorCB.Checked = toggleAnalysis.analysisList[i].allowRandomSummingFactor;

                    randomErrorTxt.Text = toggleAnalysis.analysisList[i].randomError != 0 ? toggleAnalysis.analysisList[i].randomError.ToString() : "";
                    randomErrorCB.Checked = toggleAnalysis.analysisList[i].allowRandomError;

                    systematicErrorTxt.Text = toggleAnalysis.analysisList[i].systematicError != 0 ? toggleAnalysis.analysisList[i].systematicError.ToString() : "";
                    systematicErrorCB.Checked = toggleAnalysis.analysisList[i].allowSystematicError;

                    attenuationSizeTxt.Text = toggleAnalysis.analysisList[i].attenuationSize != 0 ? toggleAnalysis.analysisList[i].attenuationSize.ToString() : "";
                    attenuationSizeCB.Checked = toggleAnalysis.analysisList[i].allowAttenuationSize;


                    break;
                }
            }
        }

        private void spectrumFilePathBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            {
                spectrumFilePathTxt.Text = sdfOFD.FileName;
            }
        }

        private void jobTemplatePathBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            {
                jobTemplatePathTxt.Text = sdfOFD.FileName;
            }
        }

        private void sampleDefaultFilePathBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            {
                sampleDefaultFilePathTxt.Text = sdfOFD.FileName;
            }
        }

        private void calibrationFilePathBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            {
                calibrationFilePathTxt.Text = sdfOFD.FileName;
            }
        }

        private void libraryFilePathBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            {
                libraryFilePathTxt.Text = sdfOFD.FileName;
            }
        }

        public void SaveAnalysisToFile()
        {
            string operationName = csListComboBox.Text;
            string json = js.Serialize(toggleAnalysis);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence/" + operationName + ".json", json);
            LoadAnalysisList(operationName);
        }

        public void AutoSaveSetting()
        {
            string settingName = analysisListBox.SelectedItem.ToString();
            for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
            {
                if (settingName == toggleAnalysis.analysisList[i].name)
                {
                    toggleAnalysis.analysisList[i].sampleDefaultFilePath = sampleDefaultFilePathTxt.Text;
                    toggleAnalysis.analysisList[i].allowSampleDefaultFilePath = sampleDefaultFilePathCB.Checked;

                    toggleAnalysis.analysisList[i].spectrumFilePath = spectrumFilePathTxt.Text;
                    toggleAnalysis.analysisList[i].allowSpectrumFilePath = spectrumFilePatbCB.Checked;

                    toggleAnalysis.analysisList[i].jobTemplatePath = jobTemplatePathTxt.Text;
                    toggleAnalysis.analysisList[i].allowJobTemplatePath = jobTemplatePathCB.Checked;

                    toggleAnalysis.analysisList[i].sampleDefaultFilePath = sampleDefaultFilePathTxt.Text;
                    toggleAnalysis.analysisList[i].allowSampleDefaultFilePath = sampleDefaultFilePathCB.Checked;

                    toggleAnalysis.analysisList[i].calibrationFilePath = calibrationFilePathTxt.Text;
                    toggleAnalysis.analysisList[i].allowCalibrationFilePath = calibrationFilePathCB.Checked;

                    toggleAnalysis.analysisList[i].libraryFilePath = libraryFilePathTxt.Text;
                    toggleAnalysis.analysisList[i].allowLibraryFilePath = libraryFilePathCB.Checked;

                    toggleAnalysis.analysisList[i].collectionStartDate = collectionStartDatePicker.Text;
                    toggleAnalysis.analysisList[i].allowCollectionStartDate = collectionStartDateCB.Checked;

                    toggleAnalysis.analysisList[i].collectionStopDate = collectionStopDatePicker.Text;
                    toggleAnalysis.analysisList[i].allowCollectionStopDate = collectionStopDateCB.Checked;

                    toggleAnalysis.analysisList[i].decayCorrectionStopDateTime = decayCorrectionStopDateTimeCB.Checked;

                    toggleAnalysis.analysisList[i].decayCorrectionDate = decayCorrectionDatePicker.Text;
                    toggleAnalysis.analysisList[i].allowDecayCorrectionDate = decayCorrectionDateCB.Checked;

                    toggleAnalysis.analysisList[i].sampleQuantity = Convert.ToInt32(sampleQuantityTxt.Text);
                    toggleAnalysis.analysisList[i].allowSampleQuantity = sampleQuantityCB.Checked;

                    toggleAnalysis.analysisList[i].units = unitsTxt.Text;
                    toggleAnalysis.analysisList[i].allowUnits = unitsCB.Checked;

                    toggleAnalysis.analysisList[i].activityUnits = activityUnitsTxt.Text;
                    toggleAnalysis.analysisList[i].allowActivityUnits = activityUnitsCB.Checked;

                    toggleAnalysis.analysisList[i].liveTimePreset = Convert.ToInt32(liveTimePresetTxt.Text);
                    toggleAnalysis.analysisList[i].allowLiveTimePreset = liveTimePresetCB.Checked;

                    toggleAnalysis.analysisList[i].realTimePreset = Convert.ToInt32(realTimePresetTxt.Text);
                    toggleAnalysis.analysisList[i].allowRealTimePreset = realTimePresetCB.Checked;

                    toggleAnalysis.analysisList[i].activityMultiper = Convert.ToInt32(activityMultiperTxt.Text);
                    toggleAnalysis.analysisList[i].allowActivityMultiper = activityMultiperCB.Checked;

                    toggleAnalysis.analysisList[i].activityDivisor = Convert.ToInt32(activityDivisorTxt.Text);
                    toggleAnalysis.analysisList[i].allowActivityDivisor = activityDivisorCB.Checked;

                    toggleAnalysis.analysisList[i].randomSummingFactor = Convert.ToInt32(randomSummingFactorTxt.Text);
                    toggleAnalysis.analysisList[i].allowRandomSummingFactor = randomSummingFactorCB.Checked;

                    toggleAnalysis.analysisList[i].randomError = Convert.ToInt32(randomErrorTxt.Text);
                    toggleAnalysis.analysisList[i].allowRandomError = randomErrorCB.Checked;

                    toggleAnalysis.analysisList[i].systematicError = Convert.ToInt32(systematicErrorTxt.Text);
                    toggleAnalysis.analysisList[i].allowSystematicError = systematicErrorCB.Checked;

                    toggleAnalysis.analysisList[i].attenuationSize = Convert.ToInt32(attenuationSizeTxt.Text);
                    toggleAnalysis.analysisList[i].allowAttenuationSize = attenuationSizeCB.Checked;
                    break;
                }
            }
            SaveAnalysisToFile();
        }

        private void CheckISNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    
        //private void TextBox_TextChanged(object sender, EventArgs e)
        //{
        //    AutoSaveSetting();
        //}

        //private void CheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    AutoSaveSetting();
        //}

        private void saveSettingBtn_Click(object sender, EventArgs e)
        {
            AutoSaveSetting();
        }

        private void exitSetupBtn_Click(object sender, EventArgs e)
        {
            CtrlCSElement(false);
            groupBox1.Visible = true;
            this.parameterSetupPanel.Visible = false;
            this.analysisSettingsPanel.Visible = false;
        }

        private void saveAnalysisSettingTemplateBtn_Click(object sender, EventArgs e)
        {
            saveTemplateDialog.ShowDialog();
        }

        private void saveTemplateDialog_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveTemplateDialog.FileName;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SampleDescription: " + sampleDescriptionTxt.Text);
            sb.AppendLine("SJobTemplatePath: " + jobTemplatePathTxt.Text);
            sb.AppendLine("SDFPath: " + sampleDefaultFilePathTxt.Text);
            sb.AppendLine("CollectionStart: " + collectionStartDatePicker.Text);
            sb.AppendLine("CollectionEnd: " + collectionStopDatePicker.Text);
            sb.AppendLine("DecayDateTime:" + decayCorrectionDatePicker.Text);
            sb.AppendLine("Weight: " + sampleQuantityTxt.Text);
            sb.AppendLine("QuantityUnits: " + unitsTxt.Text);
            sb.AppendLine("ActivityUnits: " + activityUnitsTxt.Text);
            sb.AppendLine("LiveTime: " + liveTimePresetTxt.Text);
            sb.AppendLine("RealTime: " + realTimePresetTxt.Text);
            sb.AppendLine("Multiplier: " + activityMultiperTxt.Text);
            sb.AppendLine("Divisor:  " + activityDivisorTxt.Text);
            sb.AppendLine("SpectrumFilePath: " + spectrumFilePathTxt.Text);
            sb.AppendLine("CalFileName: " + calibrationFilePathTxt.Text);
            sb.AppendLine("LibFileName: " + libraryFilePathTxt.Text);
            sb.AppendLine("ABSConfigID: -1");
            sb.AppendLine("ABSTypeID: -1");
            sb.AppendLine("ABSMaterialID: -1");
            sb.AppendLine("ABSLength: " + attenuationSizeTxt.Text);
            sb.AppendLine("RandomError: " + randomErrorTxt.Text);
            sb.AppendLine("SystematicError: " + systematicErrorTxt.Text);
            sb.AppendLine("RandomSummingFactor: " + randomSummingFactorTxt.Text);
            File.WriteAllText(name, sb.ToString());
        }

        private void loadAnalysisSettingTemplateBtn_Click(object sender, EventArgs e)
        {
            if (sdfOFD.ShowDialog() == DialogResult.OK)
            {
                 StreamReader file = new  StreamReader(sdfOFD.FileName);
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("SampleDescription: "))
                    { 
                        sampleDescriptionTxt.Text = line.Replace("SampleDescription: ", "");
                    }
                    else if (line.Contains("SJobTemplatePath: "))
                    { 
                        jobTemplatePathTxt.Text = line.Replace("SJobTemplatePath: ", "");
                    }
                    else if (line.Contains("SDFPath: "))
                    {
                        sampleDefaultFilePathTxt.Text = line.Replace("SDFPath: ", "");
                    }
                    else if (line.Contains("CollectionStart: "))
                    {
                        collectionStartDatePicker.Text = line.Replace("CollectionStart: ", "");
                    }
                    else if (line.Contains("CollectionEnd: "))
                    {
                        collectionStopDatePicker.Text = line.Replace("CollectionEnd: ", "");
                    }
                    else if (line.Contains("DecayDateTime: "))
                    {
                        decayCorrectionDatePicker.Text = line.Replace("DecayDateTime: ", "");
                    }
                    else if (line.Contains("Weight: "))
                    {
                        sampleQuantityTxt.Text = line.Replace("Weight: ", "");
                    }
                    else if (line.Contains("QuantityUnits: "))
                    {
                        unitsTxt.Text = line.Replace("QuantityUnits: ", "");
                    }
                    else if (line.Contains("ActivityUnits: "))
                    {
                        activityUnitsTxt.Text = line.Replace("ActivityUnits: ", "");
                    }
                    else if (line.Contains("LiveTime: "))
                    {
                        liveTimePresetTxt.Text = line.Replace("LiveTime: ", "");
                    }
                    else if (line.Contains("RealTime: "))
                    {
                        realTimePresetTxt.Text = line.Replace("RealTime: ", "");
                    }
                    else if (line.Contains("Multiplier: "))
                    {
                        activityMultiperTxt.Text = line.Replace("Multiplier: ", "");
                    }
                    else if (line.Contains("Divisor: "))
                    {
                        activityDivisorTxt.Text = line.Replace("Divisor: ", "");
                    }
                    else if (line.Contains("SpectrumFilePath: "))
                    {
                        spectrumFilePathTxt.Text = line.Replace("SpectrumFilePath: ", "");
                    }
                    else if (line.Contains("CalFileName: "))
                    {
                        calibrationFilePathTxt.Text = line.Replace("CalFileName: ", "");
                    }
                    else if (line.Contains("LibFileName: "))
                    {
                        libraryFilePathTxt.Text = line.Replace("LibFileName: ", "");
                    }
                    else if (line.Contains("ABSLength: "))
                    {
                        attenuationSizeTxt.Text = line.Replace("ABSLength: ", "");
                    }
                    else if (line.Contains("RandomError: "))
                    {
                        randomErrorTxt.Text = line.Replace("RandomError: ", "");
                    }
                    else if (line.Contains("SystematicError: "))
                    {
                        systematicErrorTxt.Text = line.Replace("SystematicError: ", "");
                    }
                    else if (line.Contains("RandomSummingFactor: "))
                    {
                        randomSummingFactorTxt.Text = line.Replace("RandomSummingFactor: ", "");
                    }
                }
                file.Close();  
              
            }
        }
    
    }
}
