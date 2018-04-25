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
    public partial class MeasurementSetupForm : Form
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        OpenFileDialog ofd = new OpenFileDialog();
        public MeasurementSetupForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 524, GlobalFunc.mainFormHeight);
            editSampleBtn.Enabled = false;
            SetProfile();
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        #region profile
        private void SetProfile()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "profile.json"))
            {
                GlobalFunc.profile = (Profile)js.Deserialize<Profile>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json"));
                profileCB.Items.Clear();
                for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
                {
                    profileCB.Items.Add(GlobalFunc.profile.operationName[i]);
                }

                if ( GlobalFunc.toggleProfile != "")
                {
                    profileCB.SelectedIndex = profileCB.FindString(GlobalFunc.toggleProfile);
                }
            }
            else
            {
                GlobalFunc.profile = new Profile();
                GlobalFunc.profile.operationName = new List<string>();
            }
        }

        private void SaveProfile()
        {
            bool existed = false;
            for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
            {
                if (profileCB.Text == GlobalFunc.profile.operationName[i])
                {
                    existed = true;
                    break;
                }
            }

            if (!existed)
            {
                GlobalFunc.profile.operationName.Add(profileCB.Text);
                string json = js.Serialize(GlobalFunc.profile);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json", json);
                SetProfile();
                ShowMessage("Add operation successful");
                GlobalFunc.mainForm.SetProfile();
                GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
            }
            else
            {
                if (GlobalFunc.toggleProfile != profileCB.Text)
                {
                    ShowMessage("The opertaion name existed");
                }
            }
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
            sampleQtyTxt.KeyPress += CheckISNumber_KeyPress;
            countingTime.KeyPress += CheckISNumber_KeyPress;
            LoadProfileDetail();
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
        #endregion

        #region open folder/file control
        private void dataFolderSelBtn_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    dataFolderTxt.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void sampleDefinitionFileSelBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sampleDefinitionFileTxt.Text = ofd.FileName;
            }
        }

        private void calibrationFileSelBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                calibrationFileTxt.Text = ofd.FileName;
            }
        }
        
        private void libraryFileSelBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                libraryFileTxt.Text = ofd.FileName;
            }
        }
        
        #endregion

        #region Profile Detail
        private void LoadProfileDetail()
        {
            for (int i = 0; i < GlobalFunc.profileDetailList.Count; i++)
            {
                if (GlobalFunc.profileDetailList[i].operationName == profileCB.Text)
                {
                    dataFolderTxt.Text = GlobalFunc.profileDetailList[i].dataFoleder;
                    prefixTxt.Text = GlobalFunc.profileDetailList[i].prefix;
                    noOfSampleCB.SelectedIndex = noOfSampleCB.FindString(GlobalFunc.profileDetailList[i].sampleNo.ToString());
                    sampleDefinitionFileTxt.Text = GlobalFunc.profileDetailList[i].sampleDefinitionFile;
                    calibrationFileTxt.Text = GlobalFunc.profileDetailList[i].calibrationFile;
                    calibrarionCommonCB.Checked = GlobalFunc.profileDetailList[i].commonCalibrationFile;
                    sampleQtyUnitCB.SelectedIndex = sampleQtyUnitCB.FindString(GlobalFunc.profileDetailList[i].qtyUnit);
                    sampleQtyUnitCommonCB.Checked = GlobalFunc.profileDetailList[i].commonQtyUnit;
                    sampleQtyTxt.Text = GlobalFunc.profileDetailList[i].qty.ToString() != "0" ? GlobalFunc.profileDetailList[i].qty.ToString() : "";
                    sampleQtyCommonCB.Checked = GlobalFunc.profileDetailList[i].commonQty;
                    countingTime.Text = GlobalFunc.profileDetailList[i].countingTime.ToString() != "0" ? GlobalFunc.profileDetailList[i].countingTime.ToString() : "";
                    countingTimeCommonCB.Checked = GlobalFunc.profileDetailList[i].commonCountingTime;
                    activityUnitCB.SelectedIndex = activityUnitCB.FindString(GlobalFunc.profileDetailList[i].activityUnit);
                    activityUnitCommonCB.Checked = GlobalFunc.profileDetailList[i].commonActivityUnit;
                    libraryFileTxt.Text = GlobalFunc.profileDetailList[i].libraryFile;
                    decayCorrectionCB.Checked = GlobalFunc.profileDetailList[i].decayCorrection;
                    decayCorrectionDTPicker.Value = DateTime.Parse( GlobalFunc.profileDetailList[i].decayCorrectionDate.ToString());
                    break;
                }
            }
        }

        private void SaveProfileMasterDetail()
        {
            for (int i = 0; i < GlobalFunc.profileDetailList.Count; i++)
            {
                if (GlobalFunc.profileDetailList[i].operationName == profileCB.Text)
                {
                    GlobalFunc.profileDetailList[i].dataFoleder = dataFolderTxt.Text;
                    GlobalFunc.profileDetailList[i].prefix = prefixTxt.Text;
                    GlobalFunc.profileDetailList[i].sampleNo = noOfSampleCB.Text != "" ? Convert.ToInt32(noOfSampleCB.Text) : 0;
                    GlobalFunc.profileDetailList[i].sampleDefinitionFile = sampleDefinitionFileTxt.Text;
                    GlobalFunc.profileDetailList[i].calibrationFile = calibrationFileTxt.Text;
                    GlobalFunc.profileDetailList[i].commonCalibrationFile = calibrarionCommonCB.Checked;
                    GlobalFunc.profileDetailList[i].qtyUnit = sampleQtyUnitCB.Text;
                    GlobalFunc.profileDetailList[i].commonQtyUnit = sampleQtyUnitCommonCB.Checked;
                    GlobalFunc.profileDetailList[i].qty = sampleQtyTxt.Text != "" ? Convert.ToInt32(sampleQtyTxt.Text) : 0;
                    GlobalFunc.profileDetailList[i].commonQty = sampleQtyCommonCB.Checked;
                    GlobalFunc.profileDetailList[i].countingTime = countingTime.Text != "" ? Convert.ToInt32(countingTime.Text) : 0;
                    GlobalFunc.profileDetailList[i].commonCountingTime = countingTimeCommonCB.Checked;
                    GlobalFunc.profileDetailList[i].activityUnit = activityUnitCB.Text;
                    GlobalFunc.profileDetailList[i].commonActivityUnit = activityUnitCommonCB.Checked;
                    GlobalFunc.profileDetailList[i].libraryFile = libraryFileTxt.Text;
                    GlobalFunc.profileDetailList[i].decayCorrection = decayCorrectionCB.Checked;
                    GlobalFunc.profileDetailList[i].decayCorrectionDate = decayCorrectionDTPicker.Value.ToString();

                    string json = js.Serialize(GlobalFunc.profileDetailList[i]);
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.profileDetailList[i].operationName + ".json", json);
                    MessageBox.Show("Save " + profileCB.Text + " successful");
                    break;
                }
            }
        }
        #endregion

        #region form element control
        private void CheckISNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void commonAllCB_CheckedChanged(object sender, EventArgs e)
        {
            if (commonAllCB.Checked || GlobalFunc.finishEditSample)
            {
                doneBtn.Enabled = true;
                editSampleBtn.Enabled = false;
            }
            else 
            {
                doneBtn.Enabled = false;
            }
            if (commonAllCB.Checked)
            {
                calibrarionCommonCB.Checked = true;
                sampleQtyUnitCommonCB.Checked = true;
                sampleQtyCommonCB.Checked = true;
                countingTimeCommonCB.Checked = true;
                activityUnitCommonCB.Checked = true;
            }
        }

        private void editSampleBtn_Click(object sender, EventArgs e)
        {

        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (profileCB.Text != "")
            {
                SaveProfile();
                SaveProfileMasterDetail();
            }
        }



        #endregion

        private void calibrarionCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            commonAllCB.Checked = false;
            if (commonAllCB.Checked && sampleQtyUnitCommonCB.Checked && sampleQtyCommonCB.Checked && countingTimeCommonCB.Checked && activityUnitCommonCB.Checked)
            {
                editSampleBtn.Enabled = false;
            }
            else 
            {
                editSampleBtn.Enabled = true;
            }
        }

        private void sampleQtyUnitCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void sampleQtyCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void countingTimeCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void activityUnitCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void CheckboxControl()
        {
            commonAllCB.Checked = false;
            if (commonAllCB.Checked && sampleQtyUnitCommonCB.Checked && sampleQtyCommonCB.Checked && countingTimeCommonCB.Checked && activityUnitCommonCB.Checked)
            {
                editSampleBtn.Enabled = false;
            }
            else
            {
                editSampleBtn.Enabled = true;
            }
        }

    }
}
