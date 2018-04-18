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
    public partial class StartCountingSequenceForm : Form
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Analysis toggleAnalysis = new Analysis();

        public StartCountingSequenceForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 250, GlobalFunc.mainFormHeight);
            DefaultElement();
            LoadCountSequenceIndex();
        }

        public void DefaultElement()
        {
            foreach (Control ctrl in analysisSettingsPanel.Controls)
            {
                if (ctrl is TextBox || ctrl is Button || ctrl is CheckBox || ctrl is DateTimePicker)
                {
                    ctrl.Enabled = false;
                }
            }
            maxNumberTxt.KeyPress += CheckISNumber_KeyPress;
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

        private void CheckISNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void RefreshElement()
        {
            LoadCountSequenceIndex();
            if (!string.IsNullOrEmpty(currentOperationName))
            {
                LoadAnalysisList(currentOperationName);
            }
            if (analysisListBox.SelectedItem != null)
            {
                string settingName = analysisListBox.SelectedItem.ToString();
                LoadAnalysisSettingItem(settingName);
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
                if (currentOperationName != "")
                {
                    csListComboBox.SelectedIndex = csListComboBox.FindString(currentOperationName);
                }
            }
            else
            {
                GlobalFunc.countingSequenceIndex = new CountingSequenceIndex();
                GlobalFunc.countingSequenceIndex.operationName = new List<string>();
            }
        }

        string currentOperationName = "";
        string currentSequenceName = "";
        private void csListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleAnalysis = new Analysis();
            string operationName = csListComboBox.Text;
            currentOperationName = operationName;
            LoadAnalysisList(operationName);
        }

        public void LoadAnalysisList(string operationName)
        {
            analysisListBox.Items.Clear();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence/" + operationName + ".json"))
            {

                toggleAnalysis = (Analysis)js.Deserialize<Analysis>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "CountingSequence/" + operationName + ".json"));
                if (toggleAnalysis.CreateDate == null)
                {
                    toggleAnalysis.CreateDate = DateTime.Now.ToString();
                }
                for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
                {
                    analysisListBox.Items.Add(toggleAnalysis.analysisList[i].name);
                }
                if (!string.IsNullOrEmpty(currentSequenceName))
                {
                    analysisListBox.SelectedIndex = analysisListBox.FindString(currentSequenceName);
                }
            }
        }

        private void analysisListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string settingName = analysisListBox.SelectedItem.ToString();
            currentSequenceName = settingName;
            LoadAnalysisSettingItem(settingName);
        }

        public void LoadAnalysisSettingItem(string name)
        {
            for (int i = 0; i < toggleAnalysis.analysisList.Count; i++)
            {
                if (name == toggleAnalysis.analysisList[i].name)
                {
                    sampleDescriptionTxt.Text = toggleAnalysis.analysisList[i].sampleDescription;
                    sampleDescriptionTxt.Enabled = toggleAnalysis.analysisList[i].allowSampleDescription;

                    spectrumFilePathTxt.Text = toggleAnalysis.analysisList[i].spectrumFilePath;
                    spectrumFilePathTxt.Enabled = toggleAnalysis.analysisList[i].allowSpectrumFilePath;

                    jobTemplatePathTxt.Text = toggleAnalysis.analysisList[i].jobTemplatePath;
                    jobTemplatePathTxt.Enabled = toggleAnalysis.analysisList[i].allowJobTemplatePath;

                    sampleDefaultFilePathTxt.Text = toggleAnalysis.analysisList[i].sampleDefaultFilePath;
                    sampleDefaultFilePathTxt.Enabled = toggleAnalysis.analysisList[i].allowSampleDefaultFilePath;

                    calibrationFilePathTxt.Text = toggleAnalysis.analysisList[i].calibrationFilePath;
                    calibrationFilePathTxt.Enabled = toggleAnalysis.analysisList[i].allowCalibrationFilePath;
                   
                    libraryFilePathTxt.Text = toggleAnalysis.analysisList[i].libraryFilePath;
                    libraryFilePathTxt.Enabled = toggleAnalysis.analysisList[i].allowLibraryFilePath;

                    collectionStartDatePicker.Text = toggleAnalysis.analysisList[i].collectionStartDate;
                    collectionStartDatePicker.Enabled = toggleAnalysis.analysisList[i].allowCollectionStartDate;

                    collectionStopDatePicker.Text = toggleAnalysis.analysisList[i].collectionStopDate;
                    collectionStopDatePicker.Enabled = toggleAnalysis.analysisList[i].allowCollectionStopDate;

                    decayCorrectionStopDateTimeCB.Checked = toggleAnalysis.analysisList[i].decayCorrectionStopDateTime;

                    decayCorrectionDatePicker.Text = toggleAnalysis.analysisList[i].decayCorrectionDate;
                    decayCorrectionDatePicker.Enabled = toggleAnalysis.analysisList[i].allowDecayCorrectionDate;

                    sampleQuantityTxt.Text = toggleAnalysis.analysisList[i].sampleQuantity != 0 ? toggleAnalysis.analysisList[i].sampleQuantity.ToString() : "";
                    sampleQuantityTxt.Enabled = toggleAnalysis.analysisList[i].allowSampleQuantity;

                    unitsTxt.Text = toggleAnalysis.analysisList[i].units;
                    unitsTxt.Enabled = toggleAnalysis.analysisList[i].allowUnits;

                    activityUnitsTxt.Text = toggleAnalysis.analysisList[i].activityUnits;
                    activityUnitsTxt.Enabled = toggleAnalysis.analysisList[i].allowActivityUnits;

                    liveTimePresetTxt.Text = toggleAnalysis.analysisList[i].liveTimePreset != 0 ? toggleAnalysis.analysisList[i].liveTimePreset.ToString() : "";
                    liveTimePresetTxt.Enabled = toggleAnalysis.analysisList[i].allowLiveTimePreset;

                    realTimePresetTxt.Text = toggleAnalysis.analysisList[i].realTimePreset != 0 ? toggleAnalysis.analysisList[i].realTimePreset.ToString() : "";
                    realTimePresetTxt.Enabled = toggleAnalysis.analysisList[i].allowRealTimePreset;

                    activityMultiperTxt.Text = toggleAnalysis.analysisList[i].activityMultiper != 0 ? toggleAnalysis.analysisList[i].activityMultiper.ToString() : "";
                    activityMultiperTxt.Enabled = toggleAnalysis.analysisList[i].allowActivityMultiper;

                    activityDivisorTxt.Text = toggleAnalysis.analysisList[i].activityDivisor != 0 ? toggleAnalysis.analysisList[i].activityDivisor.ToString() : "";
                    activityDivisorTxt.Enabled = toggleAnalysis.analysisList[i].allowActivityDivisor;

                    randomSummingFactorTxt.Text = toggleAnalysis.analysisList[i].randomSummingFactor != 0 ? toggleAnalysis.analysisList[i].randomSummingFactor.ToString() : "";
                    randomSummingFactorTxt.Enabled = toggleAnalysis.analysisList[i].allowRandomSummingFactor;

                    randomErrorTxt.Text = toggleAnalysis.analysisList[i].randomError != 0 ? toggleAnalysis.analysisList[i].randomError.ToString() : "";
                    randomErrorTxt.Enabled = toggleAnalysis.analysisList[i].allowRandomError;

                    systematicErrorTxt.Text = toggleAnalysis.analysisList[i].systematicError != 0 ? toggleAnalysis.analysisList[i].systematicError.ToString() : "";
                    systematicErrorTxt.Enabled = toggleAnalysis.analysisList[i].allowSystematicError;

                    attenuationSizeTxt.Text = toggleAnalysis.analysisList[i].attenuationSize != 0 ? toggleAnalysis.analysisList[i].attenuationSize.ToString() : "";
                    attenuationSizeTxt.Enabled = toggleAnalysis.analysisList[i].allowAttenuationSize;
                    break;
                }
            }
        }


    }
}
