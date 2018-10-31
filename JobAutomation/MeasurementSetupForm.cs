using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Location = new Point(150 + 524, GlobalFunc.mainFormHeight);
            this.ControlBox = false; 
            editSampleBtn.Enabled = false;
            sampleQtyTxt.KeyPress += CheckISDecimal_KeyPress;
            countingTime.KeyPress += CheckISNumber_KeyPress;
            if (GlobalFunc.setup != null)
            {
                gammaVisionPath.Text = GlobalFunc.setup.gammamVisionPath;
                password.Text = GlobalFunc.Decrypt(GlobalFunc.setup.password);
                hardwareCB.SelectedIndex = hardwareCB.FindString(GlobalFunc.setup.hardware);
                laboratory.Text = GlobalFunc.setup.laboratory;
                _operator.Text = GlobalFunc.setup._operator;
                defaultDataFolder.Text = GlobalFunc.setup.defaultData;
                dataFolderTxt.Text = GlobalFunc.setup.defaultData;
                defaultSdf.Text = GlobalFunc.setup.defaultSdf;
                sampleDefinitionFileTxt.Text = GlobalFunc.setup.defaultSdf;
                defaultCal.Text = GlobalFunc.setup.defaultCal;
                calibrationFileTxt.Text = GlobalFunc.setup.defaultCal;
                defaultLib.Text = GlobalFunc.setup.defaultLib;
                libraryFileTxt.Text = GlobalFunc.setup.defaultLib;

                GlobalFunc.mainForm.DisableRunSetupBtn();
            }
            SetProfile();


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

            if (GlobalFunc.toggleProfile != "")
            {
                profileCB.SelectedIndex = profileCB.FindString(GlobalFunc.toggleProfile);
                GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
                LoadProfileDetail();
            }
            else 
            {
                noOfSampleCB.Text = "20";
                sampleQtyUnitCB.Text = "kg";
                activityUnitCB.Text = "Bq";
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
                if (Directory.Exists(@"C:\User\Reports"))
                {
                    folderDialog.SelectedPath = @"C:\User\Reports";
                }
                else
                {
                    folderDialog.SelectedPath = @"C:\";
                } 
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    dataFolderTxt.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void sampleDefinitionFileSelBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Sample Types"))
            {
                ofd.InitialDirectory = @"C:\User\Sample Types";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".sdf"))
                {
                    sampleDefinitionFileTxt.Text = ofd.FileName;
                   
                }
                else
                {
                    MessageBox.Show("Invalid sdf file");
                }
            }
        }

        private void calibrationFileSelBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Calibrations"))
            {
                ofd.InitialDirectory = @"C:\User\Calibrations";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".clb"))
                {
                    calibrationFileTxt.Text = ofd.FileName;
                    
                }
                else
                {
                    MessageBox.Show("Invalid calibration file");
                }
            }
        }
        
        private void libraryFileSelBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Libraries"))
            {
                ofd.InitialDirectory = @"C:\User\Libraries";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".lib"))
                {
                    libraryFileTxt.Text = ofd.FileName;
                   
                }
                else
                {
                    MessageBox.Show("Invalid library file");
                }
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
                    dataFolderTxt.Text = GlobalFunc.profileDetailList[i].dataFolder;
                    prefixTxt.Text = GlobalFunc.profileDetailList[i].prefix;
                    noOfSampleCB.SelectedIndex = noOfSampleCB.FindString(GlobalFunc.profileDetailList[i].sampleNo.ToString());
                    GlobalFunc.toggleTotalSample = GlobalFunc.profileDetailList[i].sampleNo;
                    
                    sdfCommonCB.Checked = GlobalFunc.profileDetailList[i].commonSDF;
                    sampleDefinitionFileTxt.Text = GlobalFunc.profileDetailList[i].sampleDefinitionFile;

                    calibrationFileTxt.Text = GlobalFunc.profileDetailList[i].calibrationFile;
                    calibrarionCommonCB.Checked = GlobalFunc.profileDetailList[i].commonCalibrationFile;
                    sampleQtyUnitCB.SelectedIndex = sampleQtyUnitCB.FindString(GlobalFunc.profileDetailList[i].qtyUnit);
                    sampleQtyUnitCommonCB.Checked = GlobalFunc.profileDetailList[i].commonQtyUnit;
                    sampleQtyTxt.Text = GlobalFunc.profileDetailList[i].qty.ToString() != "0" ? GlobalFunc.profileDetailList[i].qty.ToString("#.###") : "";
                    sampleQtyCommonCB.Checked = GlobalFunc.profileDetailList[i].commonQty;
                    countingTime.Text = GlobalFunc.profileDetailList[i].countingTime.ToString() != "0" ? GlobalFunc.profileDetailList[i].countingTime.ToString() : "";
                    countingTimeCommonCB.Checked = GlobalFunc.profileDetailList[i].commonCountingTime;
                    activityUnitCB.SelectedIndex = activityUnitCB.FindString(GlobalFunc.profileDetailList[i].activityUnit);
                    activityUnitCommonCB.Checked = GlobalFunc.profileDetailList[i].commonActivityUnit;
                    
                    libraryFileTxt.Text = GlobalFunc.profileDetailList[i].libraryFile;
                    libraryCommonCB.Checked = GlobalFunc.profileDetailList[i].commonLibrary;

                    decayCorrectionCommonCB.Checked = GlobalFunc.profileDetailList[i].commonDecayCorrection;
                    //decayCorrectionCommonCB.Checked = GlobalFunc.profileDetailList[i].commonDecayCorrection;
                    decayCorrectionCB.Checked = GlobalFunc.profileDetailList[i].disableDecayCorrection;

                    //decayCorrectionDTPicker.Value = DateTime.Parse( GlobalFunc.profileDetailList[i].decayCorrectionDate.ToString());
                    //decayDateCommonCB.Checked = GlobalFunc.profileDetailList[i].commonDecayDate;
                    break;
                }
            }
        }

        private void SaveProfileMasterDetail()
        {
            ProfileDetail thisPD = new ProfileDetail();
            thisPD.operationName = profileCB.Text;
            thisPD.dataFolder = dataFolderTxt.Text;
            if (string.IsNullOrEmpty(prefixTxt.Text))
            {
                prefixTxt.Text = profileCB.Text;
                thisPD.prefix = profileCB.Text;
            }
            else
            {
                thisPD.prefix = prefixTxt.Text;
            }
            thisPD.sampleNo = noOfSampleCB.Text != "" ? Convert.ToInt32(noOfSampleCB.Text) : 0;
            thisPD.sampleDefinitionFile = sampleDefinitionFileTxt.Text;
            thisPD.commonSDF = sdfCommonCB.Checked;
            thisPD.calibrationFile = calibrationFileTxt.Text;
            thisPD.commonCalibrationFile = calibrarionCommonCB.Checked;
            thisPD.qtyUnit = sampleQtyUnitCB.Text;
            thisPD.commonQtyUnit = sampleQtyUnitCommonCB.Checked;
            thisPD.qty = sampleQtyTxt.Text != "" ? Convert.ToDouble(sampleQtyTxt.Text) : 0.000;
            thisPD.commonQty = sampleQtyCommonCB.Checked;
            thisPD.countingTime = countingTime.Text != "" ? Convert.ToInt32(countingTime.Text) : 0;
            thisPD.commonCountingTime = countingTimeCommonCB.Checked;
            thisPD.activityUnit = activityUnitCB.Text;
            thisPD.commonActivityUnit = activityUnitCommonCB.Checked;
            thisPD.libraryFile = libraryFileTxt.Text;
            thisPD.commonLibrary = libraryCommonCB.Checked;
          
            thisPD.disableDecayCorrection = decayCorrectionCB.Checked;
            thisPD.commonDecayCorrection = decayCorrectionCommonCB.Checked;

            //if (decayCorrectionCommonCB.Checked && !decayCorrectionCB.Checked)
            //{
            //    thisPD.commonDecayCorrection = false;
            //    decayCorrectionCommonCB.Checked = false;
            //}

            //
            //thisPD.decayCorrectionDate = decayCorrectionDTPicker.Value.ToString();
            //thisPD.commonDecayDate = decayDateCommonCB.Checked;
            thisPD.sampleDetailList = SaveProfileSamplesDetail(); //each sample
            GlobalFunc.toggleProfileDetail = thisPD;
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
                    sampleDetail.index = i;
                    sampleDetail.sampleDescription = "";
                    if (GlobalFunc.toggleProfileDetail != null)
                    {
                        if (GlobalFunc.toggleProfileDetail.sampleDetailList.Count >= i)
                        {
                            if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1] != null)
                            {
                                //sampleDetail.sampleDescription = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDescription;
                                sampleDetail = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1];
                            }
                        }
                    }
                    //sampleDetail.sampleDefinitionFilePath = sampleDefinitionFileTxt.Text;

                    if (sdfCommonCB.Checked || sampleDetail.sampleDefinitionFilePath == "")
                    {
                        sampleDetail.sampleDefinitionFilePath = sampleDefinitionFileTxt.Text;
                    }
                    else if (string.IsNullOrEmpty(sampleDetail.sampleDefinitionFilePath))
                    {
                        sampleDetail.sampleDefinitionFilePath = "";
                    }

                    if (calibrarionCommonCB.Checked || sampleDetail.calibrationFilePath == "")
                    {
                        sampleDetail.calibrationFilePath = calibrationFileTxt.Text;
                    }
                    else if (string.IsNullOrEmpty(sampleDetail.calibrationFilePath))
                    {
                        sampleDetail.calibrationFilePath = "";
                    }
                   
                    if (sampleQtyCommonCB.Checked || sampleDetail.sampleQuantity == 0)
                    {
                        sampleDetail.sampleQuantity = sampleQtyTxt.Text != "" ? Convert.ToDouble(sampleQtyTxt.Text) : 0;
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

                    if (libraryCommonCB.Checked || sampleDetail.libraryFile == "")
                    {
                        sampleDetail.libraryFile = libraryFileTxt.Text;
                    }
                    else if (string.IsNullOrEmpty(sampleDetail.libraryFile))
                    {
                        sampleDetail.libraryFile = "";
                    }

                    //sampleDetail.disableDecayCorrection = decayCorrectionCommonCB.Checked;
                    if (decayCorrectionCommonCB.Checked)
                    {
                        sampleDetail.disableDecayCorrection = decayCorrectionCB.Checked;
                    }
                    
                    if (sampleDetail.decayCorrectionDate == null || sampleDetail.decayCorrectionDate == "")
                    {
                        sampleDetail.decayCorrectionDate = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + " 00:00:00";
                    }

                    //if (decayCorrectionCommonCB.Checked)
                    //{
                        
                    //}
                    //else
                    //{
                    //    sampleDetail.decayCorrection = false;
                    //}

                    //if (decayDateCommonCB.Checked)
                    //{
                    //    sampleDetail.decayCorrectionDate = decayCorrectionDTPicker.Value.ToString();
                    //}

                    // sampleDetail.decayCorrectionDate = decayCorrectionDTPicker.Value.ToString();

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

        public bool isNumber(char ch, string text, TextBox tb)
        {
            bool res = true;
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            //check if it´s a decimal separator and if doesn´t already have one in the text string
            if (ch == decimalChar && text.IndexOf(decimalChar) != -1)
            {
                res = false;
                return res;
            }
            //check if it´s a digit, decimal separator and backspace
            if (!Char.IsDigit(ch) && ch != decimalChar && ch != (char)Keys.Back)
                res = false;


            string currentDecimal = text.Substring(text.IndexOf(".") + 1, text.Length - (text.IndexOf(".") + 1));
            if (currentDecimal.Length > 3)
            {
                res = false;
                tb.Text = text.Substring(0, text.Length - 1);
            }
            return res;
        }


        private void CheckISDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }


            //if (!isNumber(e.KeyChar, (sender as TextBox).Text, sender as TextBox))
            //    e.Handled = true;

            // if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            //{
            //    e.Handled = true;
            //}

            //if (e.KeyChar == 46)
            //{
            //    if ((sender as TextBox).Text.Count(x => x == '.') == 1)
            //    {
            //        e.Handled = true;
            //    }
            //}


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
                else
                {
                    GlobalFunc.editSampleForm.Dispose();
                    GlobalFunc.editSampleForm.Close();
                    GlobalFunc.editSampleForm = new EditSampleForm();
                }
                GlobalFunc.editSampleForm.Show();
                this.Hide();
            }
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (GlobalFunc.editSampleForm != null)
            {
                try
                {
                    GlobalFunc.editSampleForm.Close();
                    GlobalFunc.editSampleForm.Dispose();
                }
                catch (Exception ex)
                { }
            }
            
            if (SaveCurrent())
            {
                Operation.jobFileList = new List<string>();
                string prepareResult = Operation.PrepareDirectory();

                if (prepareResult != "")
                {
                    MessageBox.Show(prepareResult);
                }

                for (int i = 0; i < Convert.ToInt32(noOfSampleCB.Text); i++)
                {
                    Operation.GenerateToFile(i);
                }

                Operation.GenerateMasterFile();
                GlobalFunc.loginStatus = 0;

                MessageBox.Show("Save successful");
                //this.Close();
            }
            
        }

        private bool SaveCurrent()
        {
            bool saveOk = false;

            //check existed

            //Over-written Sequence !
            bool existed = false;
            for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
            {
                if (profileCB.Text == GlobalFunc.profile.operationName[i])
                {
                    existed = true;
                    break;
                }
            }
            if (existed && GlobalFunc.toggleProfile != profileCB.Text)
            { 
                ShowMessage("Sequence existed");
            }
            else if (string.IsNullOrEmpty(noOfSampleCB.Text))
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
            else if (sdfCommonCB.Checked && !File.Exists(sampleDefinitionFileTxt.Text))
            {
                ShowMessage("Sample Definition File not found");
            }
            else if (calibrarionCommonCB.Checked && string.IsNullOrEmpty(calibrationFileTxt.Text))
            {
                ShowMessage("Please input or select Calibration File");
            }
            else if (calibrarionCommonCB.Checked && !File.Exists(calibrationFileTxt.Text))
            {
                ShowMessage(" Calibration File not found");
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
            else if (libraryCommonCB.Checked && !File.Exists(libraryFileTxt.Text))
            {
                ShowMessage("Library File not found");
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
            DialogResult dialogResult = MessageBox.Show("Confirm Delete?", "Delete Sequence", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(profileCB.Text) && profileCB.Text != "")
                {
                    string operationName = profileCB.Text;
                    try
                    {
                        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + operationName + ".json"))
                        {
                            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"CountingSequence\" + operationName + ".json");
                        }
                    }
                    catch (Exception ex)
                    { }

                    try
                    {
                        for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
                        {
                            if (operationName == GlobalFunc.profile.operationName[i])
                            {
                                GlobalFunc.profile.operationName.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    { }

                    string json = js.Serialize(GlobalFunc.profile);
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json", json);
                   
                    ShowMessage("Remove Profile successful");
                    profileCB.Text = "";
                    GlobalFunc.toggleProfile = "";
                    GlobalFunc.LoadProfile();
                    SetProfile();

                    GlobalFunc.mainForm.SetProfile();
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
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

            //if (decayCorrectionCommonCB.Checked)
            //{
            //    decayDateCommonCB.Enabled = false;
            //    decayCorrectionDTPicker.Enabled = false; 
            //}
            //else
            //{
            //    decayDateCommonCB.Enabled = true;
            //    decayCorrectionDTPicker.Enabled = true; 
            //}
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
                //&& decayDateCommonCB.Checked
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
            if (decayCorrectionCommonCB.Checked && decayCorrectionCB.Checked == false)
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
                GlobalFunc.setup.laboratory = laboratory.Text;
                GlobalFunc.setup._operator = _operator.Text;
                string json = js.Serialize(GlobalFunc.setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
                MessageBox.Show("Laboratory Details Updated");
            }
        }

        private void saveSetupBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(gammaVisionPath.Text))
            {
                MessageBox.Show("GammaVision Path not existed");
            }
            else if (hardwareCB.Text == "")
            {
                MessageBox.Show("Select MCA Hardware");
            }
            else if (!Directory.Exists(defaultDataFolder.Text))
            {
                MessageBox.Show("Data Folder not existed");
            }
            else if (!File.Exists(defaultSdf.Text))
            {
                MessageBox.Show("SDF File not existed");
            }
            else if (File.Exists(defaultSdf.Text) && !defaultSdf.Text.ToLower().Contains(".sdf"))
            {
                MessageBox.Show("Invalid SDF File");
            }
            else if (!File.Exists(defaultCal.Text))
            {
                MessageBox.Show("Calibration File not existed");
            }
            else if (File.Exists(defaultCal.Text) && !defaultCal.Text.ToLower().Contains(".clb"))
            {
                MessageBox.Show("Invalid Calibration File");
            }
            else if (!File.Exists(defaultLib.Text))
            {
                MessageBox.Show("Library File not existed");
            }
            else if (File.Exists(defaultLib.Text) && !defaultLib.Text.ToLower().Contains(".lib"))
            {
                MessageBox.Show("Invalid Library File");
        
            }
            else
            {
                GlobalFunc.setup.gammamVisionPath = gammaVisionPath.Text;
                GlobalFunc.setup.hardware = hardwareCB.Text;
                GlobalFunc.setup.defaultData = defaultDataFolder.Text;
                GlobalFunc.setup.defaultSdf = defaultSdf.Text;
                GlobalFunc.setup.defaultCal = defaultCal.Text;
                GlobalFunc.setup.defaultLib = defaultLib.Text;

                string json = js.Serialize(GlobalFunc.setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
                MessageBox.Show("System Parameters Updated");

            }

        }

        private void udpatePasswordBtn_Click(object sender, EventArgs e)
        {
            if (password.Text == verifyPassword.Text)
            {
                GlobalFunc.setup.password = GlobalFunc.Encrypt(password.Text);
                string json = js.Serialize(GlobalFunc.setup);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "setup.json", json);
                GlobalFunc.LoadSetup();
                MessageBox.Show("Password Updated");
            }
            else
            {
                MessageBox.Show("Verify Password Fail");
            }
        }

        private void gammaVisionPathBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gammaVisionPath.Text = ofd.FileName;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SaveCurrent();
            GlobalFunc.LoadProfile();
            GlobalFunc.mainForm.SetProfile();
        }

        private void defaultSdfBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Sample Types"))
            {
                ofd.InitialDirectory = @"C:\User\Sample Types";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".sdf"))
                {
                    defaultSdf.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Invalid SDF File");
                }
            }
        }

        private void defaultCalBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Calibrations"))
            {
                ofd.InitialDirectory = @"C:\User\Calibrations";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".clb"))
                {
                    defaultCal.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Invalid Calibration File");
                }
            }
        }

        private void defaultLibBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Libraries"))
            {
                ofd.InitialDirectory = @"C:\User\Libraries";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".lib"))
                {
                    defaultLib.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Invalid Library File");
                }
            }
        }

        private void defaultDataBtn_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (Directory.Exists(@" C:\User\Reports"))
                {
                    folderDialog.SelectedPath = @"C:\User\Reports";
                }
                else
                {
                    folderDialog.SelectedPath = @"C:\";
                } 
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    defaultDataFolder.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm Exit Measurement Setup? Your changes will not be saved.", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                GlobalFunc.loginStatus = 0;
                GlobalFunc.mainForm.EnablenSetupBtn();
                this.Close();
                GlobalFunc.mainForm.Show();
            }
        }

        private void decayCorrectionCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxControl();
        }

    }
}
