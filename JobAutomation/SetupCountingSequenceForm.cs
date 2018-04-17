﻿using System;
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
    public partial class SetupCountingSequenceForm : Form
    {
        OpenFileDialog sdfOFD = new OpenFileDialog();
        OpenFileDialog gammaOFD = new OpenFileDialog();
        Analysis toggleAnalysis = new Analysis();
        JavaScriptSerializer js = new JavaScriptSerializer();
        SaveFileDialog saveTemplateDialog = new SaveFileDialog();

        public SetupCountingSequenceForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 250, GlobalFunc.mainFormHeight);
            DefaultFormSetup();
            LoadCountSequenceIndex();
        }

        private void DefaultFormSetup()
        {
            csListComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            saveTemplateDialog.Filter = "GV Automation Files (*.gva)|*.gva";
            saveTemplateDialog.DefaultExt = "gva";
            saveTemplateDialog.AddExtension = true;
            saveTemplateDialog.FileOk += saveTemplateDialog_FileOk;
            analysisSettingsPanel.Enabled = false;
            loadAnalysisSettingTemplateBtn.Enabled = false;
            saveAnalysisSettingTemplateBtn.Enabled = false;

            sampleQuantityTxt.KeyPress += CheckISNumber_KeyPress;
            liveTimePresetTxt.KeyPress += CheckISNumber_KeyPress;
            realTimePresetTxt.KeyPress += CheckISNumber_KeyPress;
            activityMultiperTxt.KeyPress += CheckISNumber_KeyPress;
            activityDivisorTxt.KeyPress += CheckISNumber_KeyPress;
            randomSummingFactorTxt.KeyPress += CheckISNumber_KeyPress;
            randomErrorTxt.KeyPress += CheckISNumber_KeyPress;
            systematicErrorTxt.KeyPress += CheckISNumber_KeyPress;
            attenuationSizeTxt.KeyPress += CheckISNumber_KeyPress;
        }


        public void ShowMessage(string msg)
        { 
            MessageBox.Show(msg);
        }

        public void CtrlCSElement(bool display)
        {
            groupBox1.Visible = display;
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
            analysisSettingsPanel.Enabled = true;
            loadAnalysisSettingTemplateBtn.Enabled = true;
            saveAnalysisSettingTemplateBtn.Enabled = true;
            LoadAnalysisSettingItem(settingName);
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