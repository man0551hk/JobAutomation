﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            sampleQtyTxt.KeyPress += CheckISDecimal_KeyPress;
            countingTime.KeyPress += CheckISNumber_KeyPress;
            SetProfile();

            if (GlobalFunc.setup != null)
            {
                gammaVisionPath.Text = GlobalFunc.setup.gammamVisionPath;
                password.Text = GlobalFunc.Decrypt(GlobalFunc.setup.password);
                hardwareCB.SelectedIndex = hardwareCB.FindString(GlobalFunc.setup.hardware);
                laboratory.Text = GlobalFunc.setup.laboratory;
                _operator.Text = GlobalFunc.setup._operator;
            }
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        #region profile
        private void SetProfile()
        {
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
                ShowMessage("Add operation successful");
                GlobalFunc.toggleProfile = "";
                GlobalFunc.toggleProfileDetail = null;

                GlobalFunc.LoadProfile(); //reload profile.json
                GlobalFunc.mainForm.SetProfile(); //set the profile list to main combo
                this.SetProfile(); //set the profile list to measurement combo
            }
            else
            {
                if (GlobalFunc.toggleProfile != profileCB.Text)
                {
                    ShowMessage("The opertaion name existed");
                }
            }


            //reload
           
            
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalFunc.mainForm.SelectionProfile(profileCB.Text);

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
                    GlobalFunc.toggleTotalSample = GlobalFunc.profileDetailList[i].sampleNo;
                    
                    sdfCommonCB.Checked = GlobalFunc.profileDetailList[i].commonSDF;
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
                    libraryCommonCB.Checked = GlobalFunc.profileDetailList[i].commonLibrary;


                    decayCorrectionCommonCB.Checked = GlobalFunc.profileDetailList[i].commonDecayCorrection;
                    decayCorrectionCB.Checked = GlobalFunc.profileDetailList[i].decayCorrection;

                    decayCorrectionDTPicker.Value = DateTime.Parse( GlobalFunc.profileDetailList[i].decayCorrectionDate.ToString());
                    decayDateCommonCB.Checked = GlobalFunc.profileDetailList[i].commonDecayDate;
                    break;
                }
            }
        }

        private void SaveProfileMasterDetail()
        {
            ProfileDetail thisPD = new ProfileDetail();
            thisPD.operationName = profileCB.Text;
            thisPD.dataFoleder = dataFolderTxt.Text;
            thisPD.prefix = prefixTxt.Text;
            thisPD.sampleNo = noOfSampleCB.Text != "" ? Convert.ToInt32(noOfSampleCB.Text) : 0;
            thisPD.sampleDefinitionFile = sampleDefinitionFileTxt.Text;
            thisPD.commonSDF = sdfCommonCB.Checked;
            thisPD.calibrationFile = calibrationFileTxt.Text;
            thisPD.commonCalibrationFile = calibrarionCommonCB.Checked;
            thisPD.qtyUnit = sampleQtyUnitCB.Text;
            thisPD.commonQtyUnit = sampleQtyUnitCommonCB.Checked;
            thisPD.qty = sampleQtyTxt.Text != "" ? Convert.ToDouble(sampleQtyTxt.Text) : 0;
            thisPD.commonQty = sampleQtyCommonCB.Checked;
            thisPD.countingTime = countingTime.Text != "" ? Convert.ToInt32(countingTime.Text) : 0;
            thisPD.commonCountingTime = countingTimeCommonCB.Checked;
            thisPD.activityUnit = activityUnitCB.Text;
            thisPD.commonActivityUnit = activityUnitCommonCB.Checked;
            thisPD.libraryFile = libraryFileTxt.Text;
            thisPD.commonLibrary = libraryCommonCB.Checked;
            thisPD.decayCorrection = decayCorrectionCB.Checked;
            thisPD.commonDecayCorrection = decayCorrectionCommonCB.Checked;
            thisPD.decayCorrectionDate = decayCorrectionDTPicker.Value.ToString();
            thisPD.commonDecayDate = decayDateCommonCB.Checked;
            thisPD.sampleDetailList = SaveProfileSamplesDetail(); //each sample
            string json = js.Serialize(thisPD);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + thisPD.operationName + ".json", json);
            MessageBox.Show("Save " + profileCB.Text + " successful");
            GlobalFunc.LoadProfileDetail(); //load each profile json
        }

        private List<SampleDetail> SaveProfileSamplesDetail()
        {
            List<SampleDetail> sampleDetailList = new List<SampleDetail>();
            if (noOfSampleCB.Text != "")
            {
                for (int i = 1; i <= Convert.ToInt32(noOfSampleCB.Text); i++)
                {
                    SampleDetail sampleDetail = new SampleDetail();
                    if (GlobalFunc.toggleProfileDetail != null)
                    {
                        if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1] != null)
                        {
                            sampleDetail = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1];
                        }
                    }
                    sampleDetail.index = i;
                    sampleDetail.sampleDescription = "";
                    sampleDetail.sampleDefinationFilePath = sampleDefinitionFileTxt.Text;
                    if (calibrarionCommonCB.Checked || sampleDetail.calibrationFilePath == "")
                    {
                        sampleDetail.calibrationFilePath = calibrationFileTxt.Text;
                    }
                    else if (string.IsNullOrEmpty(sampleDetail.calibrationFilePath))
                    {
                        sampleDetail.calibrationFilePath = "";
                    }
                    sampleDetail.decayCorrectionDate = decayCorrectionDTPicker.Value.ToString();
                    if (sampleQtyCommonCB.Checked || sampleDetail.sampleQuantity == 0)
                    {
                        sampleDetail.sampleQuantity = sampleQtyTxt.Text != "" ? Convert.ToInt32(sampleQtyTxt.Text) : 0;
                    }
                    else if (sampleDetail.sampleQuantity == 0) {
                        sampleDetail.sampleQuantity = 0;
                    }
                    if (sampleQtyUnitCommonCB.Checked || sampleDetail.units == "")
                    {
                        sampleDetail.units = sampleQtyUnitCB.Text;
                    }
                    else if (string.IsNullOrEmpty(sampleDetail.units))
                    {
                        sampleDetail.units = "";
                    }
                    if (activityUnitCommonCB.Checked || sampleDetail.activityUnits == "")
                    {
                        sampleDetail.activityUnits = activityUnitCB.Text;
                    }
                    else if (string.IsNullOrEmpty(sampleDetail.activityUnits))
                    {
                        sampleDetail.activityUnits = "";
                    }
                    if (countingTimeCommonCB.Checked || sampleDetail.countingTime == 0)
                    {
                        sampleDetail.countingTime = countingTime.Text != "" ? Convert.ToInt32(countingTime.Text) : 0;
                    }
                    else if ( sampleDetail.countingTime == 0)
                    {
                        sampleDetail.countingTime = 0;
                    }
                    sampleDetailList.Add(sampleDetail);
                }
            }
            return sampleDetailList;
        }
        #endregion

        #region form element control
        private void CheckISNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CheckISDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.Count(x => x == '.') == 1)
                {
                    e.Handled = true;
                }
            }


            //else if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d\d"))
            //{
            //    e.Handled = true;
            //}


            //if (e.KeyChar == 46)
            //{
            //    if ((sender as TextBox).Text.Count(x => x == '.') == 1)
            //    {
            //        e.Handled = true;
            //        return;
            //    }
            //}
            //else if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            //{
            //    e.Handled = true;
            //    return;
            //}
            //else if (char.IsDigit(e.KeyChar))
            //{
            //    TextBox thisTextBox = sender as TextBox;
            //    string thisText = thisTextBox.Text;
            //    if (thisText.IndexOf(".") > 0)
            //    {
            //        if (thisText.Substring(thisText.IndexOf(".") + 1, thisText.Length - (thisText.IndexOf(".") + 1)).Length > 3)
            //        {
            //            e.Handled = true;
            //            return;
            //        }
            //    }

            //    return;
            //}

        }

        private void editSampleBtn_Click(object sender, EventArgs e)
        {
            if (SaveCurrent())
            {
                GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
                LoadProfileDetail();

                if (GlobalFunc.editSampleForm == null || GlobalFunc.editSampleForm.IsDisposed)
                {
                    GlobalFunc.editSampleForm = new EditSampleForm();
                }
                GlobalFunc.editSampleForm.Show();
            }
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (SaveCurrent())
            {
                this.Close();
            }
        }

        private bool SaveCurrent()
        {
            bool saveOk = false;
            if (string.IsNullOrEmpty(noOfSampleCB.Text))
            {
                ShowMessage("Please select no. of sample first");
            }
            else if (string.IsNullOrEmpty(profileCB.Text) || profileCB.Text == "")
            {
                ShowMessage("Please input or select Profile Name first");
            }
            else if (sdfCommonCB.Checked && string.IsNullOrEmpty(sampleDefinitionFileTxt.Text))
            {
                ShowMessage("Please input or select Sample Definition File");
            }
            else if (calibrarionCommonCB.Checked && string.IsNullOrEmpty(calibrationFileTxt.Text))
            {
                ShowMessage("Please input or select Calibration File");
            }
            else if (sampleQtyUnitCommonCB.Checked && string.IsNullOrEmpty(sampleQtyUnitCB.Text))
            {
                ShowMessage("Please select Sample Quantity Unit");
            }
            else if (sampleQtyCommonCB.Checked && string.IsNullOrEmpty(sampleQtyTxt.Text))
            {
                ShowMessage("Please input Sample Quantity");
            }
            else if (countingTimeCommonCB.Checked && string.IsNullOrEmpty(countingTime.Text))
            {
                ShowMessage("Please input Counting Time");
            }
            else if (activityUnitCommonCB.Checked && string.IsNullOrEmpty(activityUnitCB.Text))
            {
                ShowMessage("Please select Activity Unit");
            }
            else if (libraryCommonCB.Checked && string.IsNullOrEmpty(libraryFileTxt.Text))
            {
                ShowMessage("Please input or Library File");
            }
            else
            {
                SaveProfile();
                SaveProfileMasterDetail();
                //GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
                //LoadProfileDetail();
                saveOk = true;
            }
            return saveOk;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(profileCB.Text) && profileCB.Text != "")
            {
                string operationName = profileCB.Text;
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + operationName + ".json"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"CountingSequence\" + operationName + ".json");
                }

                for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
                {
                    if (operationName == GlobalFunc.profile.operationName[i])
                    {
                        GlobalFunc.profile.operationName.RemoveAt(i);
                        break;
                    }
                }

                string json = js.Serialize(GlobalFunc.profile);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json", json);
                SetProfile();
                ShowMessage("Remove Profile successful");
            }
        }

        private void calibrarionCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
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

        private void sdfCommonCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void libraryCommonCb_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void decayCorrectionCommon_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void decayDateCommon_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

        private void CheckboxControl()
        {
            //commonAllCB.Checked = false;
            if (sdfCommonCB.Checked &&
                calibrarionCommonCB.Checked && sampleQtyUnitCommonCB.Checked && sampleQtyCommonCB.Checked && countingTimeCommonCB.Checked && activityUnitCommonCB.Checked
                && libraryCommonCB.Checked
                && decayCorrectionCommonCB.Checked
                && decayDateCommonCB.Checked
                )
            {
                editSampleBtn.Enabled = false;
                //commonAllCB.Checked = true;
                doneBtn.Enabled = true;
            }
            else
            {
                editSampleBtn.Enabled = true;
            }
        }

        private void noOfSampleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noOfSampleCB.Text != "")
            {
                GlobalFunc.toggleTotalSample = Convert.ToInt32(noOfSampleCB.Text);
            }
        }

        #endregion

        public void EnableDoneBtn()
        {
            doneBtn.Enabled = true;
        }

        private void saveMasterSetupBtn_Click(object sender, EventArgs e)
        {
            if (laboratory.Text != "" && _operator.Text != "")
            {
                Setup setup = new Setup();
                setup.gammamVisionPath = gammaVisionPath.Text;
                setup.hardware = hardwareCB.Text;
                setup.password = GlobalFunc.Encrypt(password.Text);
                setup.laboratory = laboratory.Text;
                setup._operator = _operator.Text;
                string json = js.Serialize(setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
                MessageBox.Show("Save master file parameter successful");
            }
        }

        private void saveSetupBtn_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            setup.gammamVisionPath = gammaVisionPath.Text;
            setup.hardware = hardwareCB.Text;
            setup.password = GlobalFunc.Encrypt(password.Text);
            setup.laboratory = laboratory.Text;
            setup._operator = _operator.Text;
            
            string json = js.Serialize(setup);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
            GlobalFunc.LoadSetup();
            MessageBox.Show("Save system setup parameter successful");
        }

        private void udpatePasswordBtn_Click(object sender, EventArgs e)
        {
            if (password.Text == verifyPassword.Text)
            {
                Setup setup = new Setup();
                setup.gammamVisionPath = gammaVisionPath.Text;
                setup.hardware = hardwareCB.Text;
                setup.password = GlobalFunc.Encrypt(password.Text);
                setup.laboratory = laboratory.Text;
                setup._operator = _operator.Text;
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
