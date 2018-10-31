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
    public partial class EditSampleForm : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        JavaScriptSerializer js = new JavaScriptSerializer();

        public EditSampleForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 524, GlobalFunc.mainFormHeight);
            this.ControlBox = false; 
            sampleQty.KeyPress += CheckISDecimal_KeyPress;
            sampleCountTime.KeyPress += CheckISNumber_KeyPress;
            sampleCB.MouseDown += sampleCB__MouseDown;
            sampleCorrectionDate.Format = DateTimePickerFormat.Custom;
            sampleCorrectionDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            
            ConstructLayout();
            Construct();
            ConstructDescriptionTab();
            ConstructSampleDefinitionTab();
            ConstructCalibrationTab();
            ConstructQuantityUnitTab();
            ConstructCountTimeTab();
            ConstructLibraryTab();
            ConstructDecay();

            sampleCB.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            this.FormClosing += Form_Closing;
            

        }
        int toggleTabControlIndex = 0;
        bool allowShowError = true;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Save())
            {
                allowShowError = true;
                toggleTabControlIndex = tabControl1.SelectedIndex;
                if (tabControl1.SelectedIndex == 0)
                {
                    SampleCBSelect();
                }
            } 
            else {
                allowShowError = false;
                tabControl1.SelectedIndex = toggleTabControlIndex;
            }
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Dispose();
        }

        #region construct layout
        public void ConstructLayout()
        {
            if (GlobalFunc.toggleProfileDetail.commonSDF == true)
            {
                sampleDefinitionFile.Enabled = false;
                sampleDefinitionFileBtn.Enabled = false;
            }

            if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == true)
            {
                sampleCalibrationFile.Enabled = false;
                sampleCalibrationFileBtn.Enabled = false;
                //calibrationDoneBtn.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonQtyUnit == true)
            {
                sampleQtyUnitCB.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonQty == true)
            {
                sampleQty.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonActivityUnit == true)
            {
                sampleActivityUnit.Enabled = false;
            }

            if (GlobalFunc.toggleProfileDetail.commonQtyUnit && GlobalFunc.toggleProfileDetail.commonQty && GlobalFunc.toggleProfileDetail.commonActivityUnit)
            {
                //quantityDoneBtn.Enabled = false;
            }

            if (GlobalFunc.toggleProfileDetail.commonCountingTime == true)
            {
                sampleCountTime.Enabled = false;
                //countTimeDoneBtn.Enabled = false;
            }

            if (GlobalFunc.toggleProfileDetail.commonLibrary == true)
            {
                //libraryDoneBtn.Enabled = false;
                sampleLibraryFile.Enabled = false;
                sampleLibraryFileBtn.Enabled = false;
            }

            
            //if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == true)
            //{
            //    sampleDecayCorrectionCB.Enabled = false;
            //    sampleCorrectionDate.Enabled = false;
            //}
            
        }
        #endregion

        #region construct control
        public void Construct()
        {
            if (GlobalFunc.toggleTotalSample > 0)
            {
                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    sampleCB.Items.Add(i.ToString());
                }
            }
        }

        public void ConstructDescriptionTab()
        {

            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;
                int buttonY = 22;

                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(103, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    descriptionTab.Controls.Add(sampleLabel);

                    TextBox description = new TextBox();
                    Point descriptionLocation = new Point(220, textBoxY);
                    description.Location = descriptionLocation;
                    description.Width = 311;
                    description.Name = "description@" + i;
                    if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1] != null)
                    {
                        description.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDescription;
                        if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDescription == "")
                        {
                            description.Text = i.ToString();
                        }
                    }
  
                    descriptionTab.Controls.Add(description);


                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;

                }
            }
        }


        public void ConstructSampleDefinitionTab()
        {

            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;
                int buttonY = 22;

                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(103, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    sampleDefinitionTab.Controls.Add(sampleLabel);

                    TextBox sampleDefinitionFile = new TextBox();
                    Point sampleDefinitionFileLocation = new Point(220, textBoxY);
                    sampleDefinitionFile.Location = sampleDefinitionFileLocation;
                    sampleDefinitionFile.Width = 311;
                    sampleDefinitionFile.Name = "sampleDefinitionFilePath@" + i;
                    if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1] != null)
                    {
                        sampleDefinitionFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDefinitionFilePath;
                        if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDefinitionFilePath == "")
                        {
                            sampleDefinitionFile.Text = GlobalFunc.setup.defaultSdf;
                        }
                    }
                    if (GlobalFunc.toggleProfileDetail.commonSDF == true)
                    {
                        sampleDefinitionFile.Enabled = false;
                    }
                    sampleDefinitionTab.Controls.Add(sampleDefinitionFile);

                    Button selFileBtn = new Button();
                    Point selFileLocation = new Point(537, buttonY);
                    selFileBtn.Location = selFileLocation;
                    selFileBtn.Name = "openSF@" + i;
                    selFileBtn.Text = "...";
                    selFileBtn.Click += OpenSampleDefinitionFileBtnClick;
                    selFileBtn.Width = 28;
                    if (GlobalFunc.toggleProfileDetail.commonSDF == true)
                    {
                        selFileBtn.Enabled = false;
                    }
                    sampleDefinitionTab.Controls.Add(selFileBtn);

                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;
                }
            }
        }


        public void ConstructCalibrationTab()
        {

            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;
                int buttonY = 22;

                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(103, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    calibrationTab.Controls.Add(sampleLabel);

                    TextBox calibrationFile = new TextBox();
                    Point calibrationFileLocation = new Point(220, textBoxY);
                    calibrationFile.Location = calibrationFileLocation;
                    calibrationFile.Width = 311;
                    calibrationFile.Name = "calibrartionFilePath@" + i;
                    if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1] != null)
                    {
                        calibrationFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].calibrationFilePath;
                        if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].calibrationFilePath == "")
                        {
                            calibrationFile.Text = GlobalFunc.setup.defaultCal;
                        }
                    }
                    if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == true)
                    {
                        calibrationFile.Enabled = false;
                    }
                    calibrationTab.Controls.Add(calibrationFile);

                    Button selFileBtn = new Button();
                    Point selFileLocation = new Point(537, buttonY);
                    selFileBtn.Location = selFileLocation;
                    selFileBtn.Name = "openCB@" + i;
                    selFileBtn.Text = "...";
                    selFileBtn.Click += OpenCalibrationFileBtnClick;
                    selFileBtn.Width = 28;
                    if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == true)
                    {
                        selFileBtn.Enabled = false;
                    }
                    calibrationTab.Controls.Add(selFileBtn);

                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;
                    
                }
            }
        }

        public void ConstructQuantityUnitTab()
        {
            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;

                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(49, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    quantityUnitTab.Controls.Add(sampleLabel);

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox.Width = 61;
                    quantityTextBox.Name = "quantity@" + i;
                    Point quantityLocation = new Point(150, textBoxY);
                    quantityTextBox.Location = quantityLocation;
                    quantityTextBox.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleQuantity.ToString();
                    if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleQuantity == 0)
                    {
                        quantityTextBox.Text = "1.000";
                    }
                    quantityTextBox.KeyPress += CheckISDecimal_KeyPress;
                    if (GlobalFunc.toggleProfileDetail.commonQty == true)
                    {
                        quantityTextBox.Enabled = false;
                    }
                    quantityUnitTab.Controls.Add(quantityTextBox);
                   

                    ComboBox unitComboBox = new ComboBox();
                    unitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    unitComboBox.Width = 75;
                    unitComboBox.Items.Add("kg");
                    unitComboBox.Items.Add("L");
                    unitComboBox.Items.Add("g");
                    unitComboBox.Items.Add("mL");

                    unitComboBox.Name = "unitComboBox@" + i;
                    unitComboBox.SelectedIndex = unitComboBox.FindString(GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].units);
                    Point unitLocation = new Point(282, textBoxY);
                    unitComboBox.Location = unitLocation;
                    if (GlobalFunc.toggleProfileDetail.commonQtyUnit == true)
                    {
                        unitComboBox.Enabled = false;
                    }
                    quantityUnitTab.Controls.Add(unitComboBox);

                    ComboBox activityUnitComboBox = new ComboBox();
                    activityUnitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    activityUnitComboBox.Width = 75;
                    activityUnitComboBox.Items.Add("Bq");
                    activityUnitComboBox.Items.Add("μCi");
                    activityUnitComboBox.Name = "activityUnitComboBox@" + i;
                    activityUnitComboBox.SelectedIndex = activityUnitComboBox.FindString(GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].activityUnits);
                    Point activityUnitLocation = new Point(425, textBoxY);
                    activityUnitComboBox.Location = activityUnitLocation;
                    if (GlobalFunc.toggleProfileDetail.commonActivityUnit == true)
                    {
                        activityUnitComboBox.Enabled = false;
                    }
                    quantityUnitTab.Controls.Add(activityUnitComboBox);


                    labelY += 30;
                    textBoxY += 30;

                }
            }


        }

        public void ConstructCountTimeTab()
        {
            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;
                int buttonY = 22;


                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(103, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    countTimeTab.Controls.Add(sampleLabel);

                    TextBox countTimeTextBox = new TextBox();
                    Point countTimeLocation = new Point(290, textBoxY);
                    countTimeTextBox.Location = countTimeLocation;
                    countTimeTextBox.Width = 70;
                    countTimeTextBox.Name = "countTimeTextBox@" + i;
                    countTimeTextBox.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].countingTime.ToString();
                    countTimeTextBox.KeyPress += CheckISNumber_KeyPress;
                    if (GlobalFunc.toggleProfileDetail.commonCountingTime)
                    {
                        countTimeTextBox.Enabled = false;
                    }
                    countTimeTab.Controls.Add(countTimeTextBox);

                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;

                }
            }
        }

        public void ConstructLibraryTab()
        {

            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;
                int buttonY = 22;

                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(103, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    libraryTab.Controls.Add(sampleLabel);

                    TextBox libraryFile = new TextBox();
                    Point libraryFileLocation = new Point(220, textBoxY);
                    libraryFile.Location = libraryFileLocation;
                    libraryFile.Width = 311;
                    libraryFile.Name = "libraryFilePath@" + i;
                    if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1] != null)
                    {
                        libraryFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].libraryFile;
                        if (GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].libraryFile == "")
                        {
                            libraryFile.Text = GlobalFunc.setup.defaultLib;
                        }
                    }
                    if (GlobalFunc.toggleProfileDetail.commonLibrary == true)
                    {
                        libraryFile.Enabled = false;
                    }
                    libraryTab.Controls.Add(libraryFile);

                    Button selFileBtn = new Button();
                    Point selFileLocation = new Point(537, buttonY);
                    selFileBtn.Location = selFileLocation;
                    selFileBtn.Name = "openLibraryCB@" + i;
                    selFileBtn.Text = "...";
                    selFileBtn.Click += OpenLibraryFileBtnClick;
                    selFileBtn.Width = 28;
                    if (GlobalFunc.toggleProfileDetail.commonLibrary == true)
                    {
                        selFileBtn.Enabled = false;
                    }
                    libraryTab.Controls.Add(selFileBtn);

                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;

                }
            }
        }


        public void ConstructDecay()
        {
            if (GlobalFunc.toggleTotalSample > 0)
            {
                int labelY = 25;
                int textBoxY = 22;
                int buttonY = 22;


                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    Label sampleLabel = new Label();
                    Point sampleLocation = new Point(70, labelY);
                    sampleLabel.Text = i.ToString();
                    sampleLabel.Location = sampleLocation;
                    decayTab.Controls.Add(sampleLabel);

                    DateTimePicker decayDate = new DateTimePicker();
                    decayDate.Format = DateTimePickerFormat.Custom;
                    decayDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                    decayDate.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].decayCorrectionDate;
                    Point decayDateLocation = new Point(430, textBoxY);
                    decayDate.Location = decayDateLocation;
                    decayDate.Name = "decayCorrectionDate@" + i;
                    //if (GlobalFunc.toggleProfileDetail.commonDecayCorrection)
                    //{
                    //    decayDate.Enabled = false;
                    //}

                    decayTab.Controls.Add(decayDate);

                    CheckBox decayCB = new CheckBox();
                    Point decayCBLocation = new Point(250, textBoxY);
                    decayCB.Location = decayCBLocation;
                    decayCB.Name = "decayCorrectionCB@" + i;
                    decayCB.CheckedChanged +=decayCB_CheckedChanged;
                    decayCB.Checked = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].disableDecayCorrection;
                    decayCB.Text = "";


                    if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == false &&
                         GlobalFunc.toggleProfileDetail.disableDecayCorrection == false)
                    {
                        decayCB.Enabled = true;
                    }
                    else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == false &&
                       GlobalFunc.toggleProfileDetail.disableDecayCorrection == true)
                    {
                        decayCB.Enabled = true;
                    }
                    else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == true &&
                            GlobalFunc.toggleProfileDetail.disableDecayCorrection == false)
                    {
                        decayCB.Enabled = false;
                    }
                    else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == true &&
                        GlobalFunc.toggleProfileDetail.disableDecayCorrection == true)
                    {
                        decayCB.Enabled = false;
                    }

                    if (!decayCB.Checked)
                    {
                        decayDate.Enabled = true;
                    }
                    else {
                        decayDate.Enabled = false;
                    }

                    //if (GlobalFunc.toggleProfileDetail.commonDecayCorrection && GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].disableDecayCorrection == false)
                    //{
                    //    decayCB.Enabled = true;
                    //    decayDate.Enabled = true;

                    //}
                    //else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == false)
                    //{
                    //    decayCB.Enabled = true;
                    //    decayDate.Enabled = true;
                    //}
                    //else
                    //{
                    //    decayCB.Enabled = false;
                    //}
                    decayTab.Controls.Add(decayCB);




                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;

                }
            }
        }
        
        #endregion

        #region
        private void decayCB_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox btn = sender as CheckBox;
            string name = btn.Name.Replace("decayCorrectionCB@", "decayCorrectionDate@");
            if (decayTab.Controls.Find(name, true) != null)
            {
                DateTimePicker thisDT = decayTab.Controls.Find(name, true)[0] as DateTimePicker;
                if (btn.Checked)
                {
                    thisDT.Enabled = false;
                }
                else
                {
                    thisDT.Enabled = true;
                }
            }
        }

        private void OpenSampleDefinitionFileBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name.Replace("openSF@", "sampleDefinitionFilePath@");
            if (sampleDefinitionTab.Controls.Find(name, true)[0] != null)
            {
                TextBox sampleDefinitionFilePath = sampleDefinitionTab.Controls.Find(name, true)[0] as TextBox;
                if (Directory.Exists(@"C:\User\Sample Types"))
                {
                    ofd.InitialDirectory = @"C:\User\Sample Types";
                }
                else
                {
                    ofd.InitialDirectory = @"C:\";
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ofd.FileName.ToLower().Contains(".sdf"))
                    {
                        sampleDefinitionFilePath.Text = ofd.FileName;
                    }
                    else 
                    {
                        MessageBox.Show("Invalid sample Definition file");
                    }
                    
                }
            }

        }

        private void OpenCalibrationFileBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name.Replace("openCB@", "calibrartionFilePath@");
            if (calibrationTab.Controls.Find(name, true)[0] != null)
            {
                TextBox calibrartionFilePath = calibrationTab.Controls.Find(name, true)[0] as TextBox;
                if (Directory.Exists(@"C:\User\Calibrations"))
                {
                    ofd.InitialDirectory = @"C:\User\Calibrations";
                }
                else
                {
                    ofd.InitialDirectory = @"C:\";
                }
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ofd.FileName.ToLower().Contains(".clb"))
                    {
                        calibrartionFilePath.Text = ofd.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Invalid calibration file");
                    }

                }
            }

        }

        private void OpenLibraryFileBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name.Replace("openLibraryCB@", "libraryFilePath@");
            if (libraryTab.Controls.Find(name, true)[0] != null)
            {
                TextBox libraryFilePath = libraryTab.Controls.Find(name, true)[0] as TextBox;
                if (Directory.Exists(@"C:\User\Libraries"))
                {
                    ofd.InitialDirectory = @"C:\User\Libraries";
                }
                else
                {
                    ofd.InitialDirectory = @"C:\";
                } 
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
     
                    if (ofd.FileName.ToLower().Contains(".lib"))
                    {
                        libraryFilePath.Text = ofd.FileName;
                    }
                    else 
                    {
                        MessageBox.Show("Invalid library file");
                    }
                }
            }
        }
        #endregion

        #region done btn
        private void sampleDoneBtn_Click(object sender, EventArgs e)
        {
            bool save = Save();
            bool saveCurrent = false;
            if (sampleCB.Text != "")
            {
                if (GlobalFunc.toggleProfileDetail.commonSDF == false && string.IsNullOrEmpty(sampleDefinitionFile.Text))
                {
                    MessageBox.Show("Please select or input Sample Definition File");
                }
                if (GlobalFunc.toggleProfileDetail.commonSDF == false && !File.Exists(sampleDefinitionFile.Text))
                {
                    MessageBox.Show("Sample Definition File not existed");
                }
                else if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == false && string.IsNullOrEmpty(sampleCalibrationFile.Text))
                {
                    MessageBox.Show("Please select or input Calibration File");
                }
                else if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == false && !File.Exists(sampleCalibrationFile.Text))
                {
                    MessageBox.Show("Calibration File not existed");
                }
                else if (GlobalFunc.toggleProfileDetail.commonQtyUnit == false && string.IsNullOrEmpty(sampleQtyUnitCB.Text))
                {
                    MessageBox.Show("Please select Sample Quantity Unit");
                }
                else if (GlobalFunc.toggleProfileDetail.commonQty == false && string.IsNullOrEmpty(sampleQty.Text))
                {
                    MessageBox.Show("Please input Sample Quantity");
                }
                else if (GlobalFunc.toggleProfileDetail.commonCountingTime == false && string.IsNullOrEmpty(sampleCountTime.Text))
                {
                    MessageBox.Show("Please input Counting Time");
                }
                else if (GlobalFunc.toggleProfileDetail.commonActivityUnit == false && string.IsNullOrEmpty(sampleActivityUnit.Text))
                {
                    MessageBox.Show("Please select Activity Unit");
                }
                else if (GlobalFunc.toggleProfileDetail.commonLibrary == false && string.IsNullOrEmpty(sampleLibraryFile.Text))
                {
                    MessageBox.Show("Please select or input Library File");
                }
                else if (GlobalFunc.toggleProfileDetail.commonLibrary == false && !File.Exists(sampleLibraryFile.Text))
                {
                    MessageBox.Show(" Library File not existed");
                }
                else
                {
                    UpdateSampleDataOnTemp();
                    string json = js.Serialize(GlobalFunc.toggleProfileDetail);
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName + ".json", json);


                    //Operation.GenerateToFile(Convert.ToInt32(sampleCB.Text));
                    //Operation.GenerateMasterFile();
                    //GlobalFunc.editSampleForm.Dispose();
                    //this.Close();
                    saveCurrent = true;
                }
            }

            if (save && saveCurrent)
            {
                MessageBox.Show("Save " + GlobalFunc.toggleProfileDetail.operationName + " successful");
                GlobalFunc.LoadProfileDetail();
                GlobalFunc.measurementSetupForm.EnableDoneBtn();

                GlobalFunc.editSampleForm.Dispose();
                this.Close();
                GlobalFunc.measurementSetupForm.Show();
            }
        }

        private void UpdateSampleDataOnTemp()
        {
            for (int i = 0; i < GlobalFunc.toggleProfileDetail.sampleDetailList.Count; i++)
            {
                if (GlobalFunc.toggleProfileDetail.sampleDetailList[i].index.ToString() == sampleCB.Text)
                {
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDescription = sampleDescription.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDefinitionFilePath = sampleDefinitionFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].calibrationFilePath = sampleCalibrationFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].units = sampleQtyUnitCB.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleQuantity = Convert.ToDouble(sampleQty.Text != "" ? sampleQty.Text : "0");
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].countingTime = Convert.ToInt32(sampleCountTime.Text != "" ? sampleCountTime.Text : "0");
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].activityUnits = sampleActivityUnit.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].libraryFile = sampleLibraryFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].disableDecayCorrection = sampleDecayCorrectionCB.Checked;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].decayCorrectionDate = sampleCorrectionDate.Text;
                    Operation.GenerateToFile(i);
                    break;
                }
            }
        }

        private void calibrationDoneBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void quantityDoneBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void countTimeDoneBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void libraryDoneBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void decayCorrectionDoneBtn_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        private bool Save()
        {
            bool noError = false;
            string descriptionError = "";
            string sampleDFError = "";
            string sampleDFNoteExistCountError = "";
            string calCountError = "";
            string calNotExistCountError = "";
            string sampleQtyError = "";
            string sampleUnitError = "";
            string activityUnitError = "";
            string countTimeError = "";
            string libraryFileError = "";
            string libraryNotExistFileError = "";
            
            for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
            {
                TextBox description = descriptionTab.Controls.Find("description@" + i, true)[0] as TextBox;
                TextBox sampleDefinitionFile = sampleDefinitionTab.Controls.Find("sampleDefinitionFilePath@" + i, true)[0] as TextBox;
                TextBox calibrationFile = calibrationTab.Controls.Find("calibrartionFilePath@" + i, true)[0] as TextBox;
                TextBox quantityTextBox = quantityUnitTab.Controls.Find("quantity@" + i, true)[0] as TextBox;
                ComboBox unitComboBox = quantityUnitTab.Controls.Find("unitComboBox@" + i, true)[0] as ComboBox ;
                ComboBox activityUnitComboBox = quantityUnitTab.Controls.Find("activityUnitComboBox@" + i, true)[0] as ComboBox;
                TextBox countTimeTextBox = countTimeTab.Controls.Find("countTimeTextBox@" + i, true)[0] as TextBox;
                TextBox libraryFile = libraryTab.Controls.Find("libraryFilePath@" + i, true)[0] as TextBox;
                CheckBox decayCB = decayTab.Controls.Find("decayCorrectionCB@" + i, true)[0] as CheckBox;
                DateTimePicker decayDate = decayTab.Controls.Find("decayCorrectionDate@" + i, true)[0] as DateTimePicker;

                if (string.IsNullOrEmpty(description.Text))
                {
                    descriptionError += i + ",";
                }

                if (GlobalFunc.toggleProfileDetail.commonSDF == false && string.IsNullOrEmpty(sampleDefinitionFile.Text))
                {
                    sampleDFError += i + ",";
                }

                if (GlobalFunc.toggleProfileDetail.commonSDF == false && !File.Exists(sampleDefinitionFile.Text))
                {
                    sampleDFNoteExistCountError += i + ",";
                }

                if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == false && string.IsNullOrEmpty(calibrationFile.Text))
                {
                    calCountError += i + ",";
                }
                if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == false && !File.Exists(calibrationFile.Text))
                {
                    calNotExistCountError += i + ",";
                }
                if (GlobalFunc.toggleProfileDetail.commonQtyUnit == false && string.IsNullOrEmpty(quantityTextBox.Text))
                {
                    sampleQtyError += i + ",";
                }

                if (GlobalFunc.toggleProfileDetail.commonQty == false && string.IsNullOrEmpty(unitComboBox.Text))
                {
                    sampleUnitError += i + ",";
                }
                if (GlobalFunc.toggleProfileDetail.commonCountingTime == false && string.IsNullOrEmpty(countTimeTextBox.Text))
                {
                    countTimeError += i + ",";
                }
                if (GlobalFunc.toggleProfileDetail.commonActivityUnit == false && string.IsNullOrEmpty(activityUnitComboBox.Text))
                {
                    activityUnitError += i + ",";
                }
                if (GlobalFunc.toggleProfileDetail.commonLibrary == false && string.IsNullOrEmpty(libraryFile.Text))
                {
                    libraryFileError += i + ",";
                }
                if (GlobalFunc.toggleProfileDetail.commonLibrary == false && !File.Exists(libraryFile.Text))
                {
                    libraryNotExistFileError += i + ",";
                }
            }

            
            if (descriptionError != "" && allowShowError)
            {
                MessageBox.Show("Please Input Description for Sample " + descriptionError.Substring(0, descriptionError.Length - 1));
            }
            else if (sampleDFError != "" && allowShowError)
            {
                MessageBox.Show("Select Sample Definition File for Sample " + sampleDFError.Substring(0, sampleDFError.Length - 1));
            }

            else if (sampleDFNoteExistCountError != "" && allowShowError)
            {
                MessageBox.Show("Sample Definition File not existed on sample " + sampleDFNoteExistCountError.Substring(0, sampleDFNoteExistCountError.Length - 1));
            }

            else if (calCountError != "" && allowShowError)
            {
                MessageBox.Show("Select Calibration File for Sample " + calCountError.Substring(0, calCountError.Length - 1));
            }
            else if (calNotExistCountError != "" && allowShowError)
            {
                MessageBox.Show("Calibration File for Sample " + calNotExistCountError.Substring(0, calNotExistCountError.Length - 1) + " not existed");
            }
            else if (sampleQtyError != "" && allowShowError)
            {
                MessageBox.Show("Select Sample Quantity Unit for Sample " + sampleQtyError.Substring(0, sampleQtyError.Length - 1));
            }
            else if (sampleUnitError != "" && allowShowError)
            {
                MessageBox.Show("Select Sample Quantity for Sample " + sampleUnitError.Substring(0, sampleUnitError.Length - 1));
            }
            else if (countTimeError != "" && allowShowError)
            {
                MessageBox.Show("Input Counting Time for Sample " + countTimeError.Substring(0, countTimeError.Length - 1));
            }
            else if (activityUnitError != "" && allowShowError)
            {
                MessageBox.Show("Select Activity Unit for Sample " + activityUnitError.Substring(0, activityUnitError.Length - 1));
            }
            else if (libraryFileError != "" && allowShowError)
            {
                MessageBox.Show("Select Library File for Sample " + libraryFileError.Substring(0, libraryFileError.Length - 1));
            }
            else if (libraryNotExistFileError != "" && allowShowError)
            {
                MessageBox.Show("Library File for Sample " + libraryNotExistFileError.Substring(0, libraryNotExistFileError.Length - 1) + " not existed");
            }
            else
            {
                for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
                {
                    TextBox description = descriptionTab.Controls.Find("description@" + i, true)[0] as TextBox;
                    TextBox sampleDefinitionFile = sampleDefinitionTab.Controls.Find("sampleDefinitionFilePath@" + i, true)[0] as TextBox;
                    TextBox calibrationFile = calibrationTab.Controls.Find("calibrartionFilePath@" + i, true)[0] as TextBox;
                    TextBox quantityTextBox = quantityUnitTab.Controls.Find("quantity@" + i, true)[0] as TextBox;
                    ComboBox unitComboBox = quantityUnitTab.Controls.Find("unitComboBox@" + i, true)[0] as ComboBox;
                    ComboBox activityUnitComboBox = quantityUnitTab.Controls.Find("activityUnitComboBox@" + i, true)[0] as ComboBox;
                    TextBox countTimeTextBox = countTimeTab.Controls.Find("countTimeTextBox@" + i, true)[0] as TextBox;
                    TextBox libraryFile = libraryTab.Controls.Find("libraryFilePath@" + i, true)[0] as TextBox;
                    CheckBox decayCB = decayTab.Controls.Find("decayCorrectionCB@" + i, true)[0] as CheckBox;
                    DateTimePicker decayDate = decayTab.Controls.Find("decayCorrectionDate@" + i, true)[0] as DateTimePicker;

                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDescription = description.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleDefinitionFilePath = sampleDefinitionFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].calibrationFilePath = calibrationFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleQuantity = quantityTextBox.Text != "" ? Convert.ToDouble(quantityTextBox.Text) : 0;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].units = unitComboBox.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].activityUnits = activityUnitComboBox.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].countingTime = countTimeTextBox.Text != "" ? Convert.ToInt32(countTimeTextBox.Text) : 0;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].libraryFile = libraryFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].disableDecayCorrection = decayCB.Checked;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].decayCorrectionDate = decayDate.Text;
                }
                string json = js.Serialize(GlobalFunc.toggleProfileDetail);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName + ".json", json);
                //MessageBox.Show("Save " + GlobalFunc.toggleProfileDetail.operationName + " successful");
                GlobalFunc.LoadProfileDetail();
                GlobalFunc.measurementSetupForm.EnableDoneBtn();
                //this.Close();
                noError = true;
            }
            return noError;
        }

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

        }

        private void sampleCB__MouseDown(object sender, MouseEventArgs e)
        {
            UpdateSampleDataOnTemp();
        }


        private void SampleCBSelect()
        {
            for (int i = 0; i < GlobalFunc.toggleProfileDetail.sampleDetailList.Count; i++)
            {
                if (GlobalFunc.toggleProfileDetail.sampleDetailList[i].index.ToString() == sampleCB.Text)
                {
                    sampleDefinitionFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDefinitionFilePath != null ? GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDefinitionFilePath : "";
                    if (sampleDefinitionFile.Text == "")
                    {
                        sampleDefinitionFile.Text = GlobalFunc.setup.defaultSdf;
                    }
                    sampleCalibrationFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].calibrationFilePath != null ? GlobalFunc.toggleProfileDetail.sampleDetailList[i].calibrationFilePath : "";
                    if (sampleCalibrationFile.Text == "")
                    {
                        sampleCalibrationFile.Text = GlobalFunc.setup.defaultCal;
                    }
                    sampleQtyUnitCB.SelectedIndex = sampleQtyUnitCB.FindString(GlobalFunc.toggleProfileDetail.sampleDetailList[i].units);
                    sampleQty.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleQuantity.ToString();
                    sampleCountTime.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].countingTime.ToString();
                    sampleDescription.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDescription;
                    if (sampleDescription.Text == "")
                    {
                        sampleDescription.Text = (i + 1).ToString();
                    }
                    //sampleDefinitionFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDefinitionFilePath;

                    if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == false &&
                        GlobalFunc.toggleProfileDetail.disableDecayCorrection == false)
                    {
                        sampleDecayCorrectionCB.Enabled = true;
                    }
                    else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == false &&
                       GlobalFunc.toggleProfileDetail.disableDecayCorrection == true)
                    {
                        sampleDecayCorrectionCB.Enabled = true;
                    }
                    else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == true &&
                            GlobalFunc.toggleProfileDetail.disableDecayCorrection == false)
                    {
                        sampleDecayCorrectionCB.Enabled = false;
                        sampleCorrectionDate.Enabled = true;
                    }
                    else if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == true &&
                        GlobalFunc.toggleProfileDetail.disableDecayCorrection == true)
                    {
                        sampleDecayCorrectionCB.Enabled = false;
                    }

                    sampleDecayCorrectionCB.Checked = GlobalFunc.toggleProfileDetail.sampleDetailList[i].disableDecayCorrection;
                    try
                    {
                        sampleCorrectionDate.Value = Convert.ToDateTime(GlobalFunc.toggleProfileDetail.sampleDetailList[i].decayCorrectionDate);
                    }
                    catch (Exception ex)
                    { 
                    }
                    sampleActivityUnit.SelectedIndex = sampleActivityUnit.FindString(GlobalFunc.toggleProfileDetail.sampleDetailList[i].activityUnits);
                    sampleLibraryFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].libraryFile != null ?  GlobalFunc.toggleProfileDetail.sampleDetailList[i].libraryFile : "";

                    if (sampleLibraryFile.Text == "")
                    {
                        sampleLibraryFile.Text = GlobalFunc.setup.defaultLib;
                    }
                    break;
                }
            }
        }

        private void sampleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleCBSelect();

        }

        private void sampleDefinitionFileBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Sample Types"))
            {
                ofd.InitialDirectory = @"C:\User\Sample Types";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            }
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".sdf"))
                {
                    sampleDefinitionFile.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Invalid sdf file");
                }
            }
        }

        private void sampleCalibrationFileBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Calibrations"))
            {
                ofd.InitialDirectory = @"C:\User\Calibrations";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".clb"))
                {
                    sampleCalibrationFile.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Invalid calibration file");
                }
            }
        }



        private void sampleLibraryFileBtn_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\User\Libraries"))
            {
                ofd.InitialDirectory = @"C:\User\Libraries";
            }
            else
            {
                ofd.InitialDirectory = @"C:\";
            } 
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.FileName.ToLower().Contains(".lib"))
                {
                    sampleLibraryFile.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Invalid library file");
                }
            }
        }

        private void sampleCalibrationFile_TextChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            TextBox calibrationFile = calibrationTab.Controls.Find("calibrartionFilePath@" + currentSample, true)[0] as TextBox;
            if (calibrationFile != null)
            {
                calibrationFile.Text = sampleCalibrationFile.Text;
            }
        }

        private void sampleQtyUnitCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            ComboBox unitComboBox = quantityUnitTab.Controls.Find("unitComboBox@" + currentSample, true)[0] as ComboBox;
            if (unitComboBox != null)
            {
                unitComboBox.Text = sampleQtyUnitCB.Text;
            }
        }

        private void sampleQty_TextChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            TextBox quantityTextBox = quantityUnitTab.Controls.Find("quantity@" + currentSample, true)[0] as TextBox;
            if (quantityTextBox != null)
            {
                quantityTextBox.Text = sampleQty.Text;
            }
        }

        private void sampleActivityUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            ComboBox activityUnitComboBox = quantityUnitTab.Controls.Find("activityUnitComboBox@" + currentSample, true)[0] as ComboBox;
            if (activityUnitComboBox != null)
            {
                activityUnitComboBox.Text = sampleActivityUnit.Text;
            }
        }

        private void sampleLibraryFile_TextChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            TextBox libraryFile = libraryTab.Controls.Find("libraryFilePath@" + currentSample, true)[0] as TextBox;
            if (libraryFile != null)
            {
                libraryFile.Text = sampleLibraryFile.Text;
            }
        }

        private void sampleCountTime_TextChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            TextBox countTimeTextBox = countTimeTab.Controls.Find("countTimeTextBox@" + currentSample, true)[0] as TextBox;
            if (countTimeTextBox != null)
            {
                countTimeTextBox.Text = sampleCountTime.Text;
            }
        }

        private void sampleDecayCorrectionCB_CheckedChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            if (sampleDecayCorrectionCB.Checked)
            {
                sampleCorrectionDate.Enabled = false;
            }
            else
            {
                sampleCorrectionDate.Enabled = true;
            }
            CheckBox decayCB = decayTab.Controls.Find("decayCorrectionCB@" + currentSample, true)[0] as CheckBox;
            DateTimePicker decayDate = decayTab.Controls.Find("decayCorrectionDate@" + currentSample, true)[0] as DateTimePicker;
            if(decayCB != null)
            {
                decayCB.Checked = sampleDecayCorrectionCB.Checked;
            }

            if (sampleDecayCorrectionCB.Checked == false && decayDate != null)
            {
                decayDate.Enabled = true;
            }
            else
            {
                decayDate.Enabled = false;
            }
        }

        private void sampleCorrectionDate_ValueChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            DateTimePicker decayDate = decayTab.Controls.Find("decayCorrectionDate@" + currentSample, true)[0] as DateTimePicker;
            if (decayDate != null)
            {
                decayDate.Value = sampleCorrectionDate.Value;
            }
        }

        private void sampleDefinitionFile_TextChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            TextBox tabSampleDefinitionFile = sampleDefinitionTab.Controls.Find("sampleDefinitionFilePath@" + currentSample, true)[0] as TextBox;
            if (tabSampleDefinitionFile != null)
            {
                tabSampleDefinitionFile.Text = sampleDefinitionFile.Text;
            }
        }

        private void sampleDescription_TextChanged(object sender, EventArgs e)
        {
            string currentSample = sampleCB.Text;
            TextBox descriptionTabText = descriptionTab.Controls.Find("description@" + currentSample, true)[0] as TextBox;
            if (descriptionTabText != null)
            {
                descriptionTabText.Text = sampleDescription.Text;
            }
        }




    }
}
