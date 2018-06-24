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
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 524, GlobalFunc.mainFormHeight);
            sampleQty.KeyPress += CheckISNumber_KeyPress;
            sampleCountTime.KeyPress += CheckISNumber_KeyPress;
            sampleCB.MouseDown += sampleCB__MouseDown;


            ConstructLayout();

            Construct();
            ConstructCalibrationTab();
            ConstructQuantityUnitTab();
            ConstructCountTimeTab();
        }

        #region construct layout
        public void ConstructLayout()
        {
            if (GlobalFunc.toggleProfileDetail.commonCalibrationFile == true)
            {
                sampleCalibrationFile.Enabled = false;
                sampleCalibrationFileBtn.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonQtyUnit == true)
            {
                sampleQtyUnitCB.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonQty == true)
            {
                sampleQty.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonCountingTime == true)
            {
                sampleCountTime.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonDecayCorrection == true)
            {
                sampleDecayCorrectionCB.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonDecayDate == true)
            {
                sampleCorrectionDate.Enabled = false;
            }
            if (GlobalFunc.toggleProfileDetail.commonSDF == true)
            {
                sampleDefinationFile.Enabled = false;
                sampleDefinationFileBtn.Enabled = false;
            }
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
                    }
                    calibrationTab.Controls.Add(calibrationFile);

                    Button selFileBtn = new Button();
                    Point selFileLocation = new Point(537, buttonY);
                    selFileBtn.Location = selFileLocation;
                    selFileBtn.Name = "openCB@" + i;
                    selFileBtn.Text = "...";
                    selFileBtn.Click += OpenCalibrationFileBtnClick;
                    selFileBtn.Width = 28;
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
                    quantityTextBox.KeyPress += CheckISNumber_KeyPress;
                    quantityUnitTab.Controls.Add(quantityTextBox);
                   

                    ComboBox unitComboBox = new ComboBox();
                    unitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    unitComboBox.Width = 75;
                    unitComboBox.Items.Add("g");
                    unitComboBox.Items.Add("ml");
                    unitComboBox.Items.Add("kg");
                    unitComboBox.Items.Add("L");
                    unitComboBox.Name = "unitComboBox@" + i;
                    unitComboBox.SelectedIndex = unitComboBox.FindString(GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].units);
                    Point unitLocation = new Point(282, textBoxY);
                    unitComboBox.Location = unitLocation;
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
                    countTimeTab.Controls.Add(countTimeTextBox);

                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;

                }
            }
        }
        #endregion

        #region 
        private void OpenCalibrationFileBtnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name.Replace("openCB@", "calibrartionFilePath@");
            if (calibrationTab.Controls.Find(name, true)[0] != null)
            {
                TextBox calibrartionFilePath = calibrationTab.Controls.Find(name, true)[0] as TextBox;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    calibrartionFilePath.Text = ofd.FileName;
                }
            }
        }
        #endregion
        private void sampleDoneBtn_Click(object sender, EventArgs e)
        {
            //Save();
            UpdateSampleDataOnTemp();
            string json = js.Serialize(GlobalFunc.toggleProfileDetail);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName + ".json", json);
            MessageBox.Show("Save " + GlobalFunc.toggleProfileDetail.operationName + " successful");
            GlobalFunc.LoadProfileDetail();
            GlobalFunc.measurementSetupForm.EnableDoneBtn();
            this.Close();
        }

        private void UpdateSampleDataOnTemp()
        {
            for (int i = 0; i < GlobalFunc.toggleProfileDetail.sampleDetailList.Count; i++)
            {
                if (GlobalFunc.toggleProfileDetail.sampleDetailList[i].index.ToString() == sampleCB.Text)
                {
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].calibrationFilePath = sampleCalibrationFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].units = sampleQtyUnitCB.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleQuantity = Convert.ToInt32(sampleQty.Text != "" ? sampleQty.Text : "0");
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].countingTime = Convert.ToInt32(sampleCountTime.Text != "" ? sampleCountTime.Text : "0");
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDescription = sampleDescription.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDefinationFilePath = sampleDefinationFile.Text;
                    GlobalFunc.toggleProfileDetail.sampleDetailList[i].decayCorrectionDate = sampleCorrectionDate.Text;
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

        private void Save()
        {
            for (int i = 1; i <= GlobalFunc.toggleTotalSample; i++)
            {
                TextBox calibrationFile = calibrationTab.Controls.Find("calibrartionFilePath@" + i, true)[0] as TextBox;
                TextBox quantityTextBox = quantityUnitTab.Controls.Find("quantity@" + i, true)[0] as TextBox;
                ComboBox unitComboBox = quantityUnitTab.Controls.Find("unitComboBox@" + i, true)[0] as ComboBox ;
                ComboBox activityUnitComboBox = quantityUnitTab.Controls.Find("activityUnitComboBox@" + i, true)[0] as ComboBox;
                TextBox countTimeTextBox = countTimeTab.Controls.Find("countTimeTextBox@" + i, true)[0] as TextBox;
                
                GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].calibrationFilePath = calibrationFile.Text;
                GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleQuantity = quantityTextBox.Text != "" ? Convert.ToInt32(quantityTextBox.Text) : 0;
                GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].units = unitComboBox.Text;
                GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].activityUnits = activityUnitComboBox.Text;
                GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].countingTime = countTimeTextBox.Text != "" ? Convert.ToInt32(countTimeTextBox.Text) : 0;
            }

            string json = js.Serialize(GlobalFunc.toggleProfileDetail);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"ProfileDetail\" + GlobalFunc.toggleProfileDetail.operationName + ".json", json);
            MessageBox.Show("Save " + GlobalFunc.toggleProfileDetail.operationName + " successful");
            GlobalFunc.LoadProfileDetail();
            GlobalFunc.measurementSetupForm.EnableDoneBtn();
            this.Close();
        }

        private void CheckISNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void sampleCB__MouseDown(object sender, MouseEventArgs e)
        {
            UpdateSampleDataOnTemp();
        }

        private void sampleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GlobalFunc.toggleProfileDetail.sampleDetailList.Count; i++)
            {
                if (GlobalFunc.toggleProfileDetail.sampleDetailList[i].index.ToString() == sampleCB.Text)
                {
                    sampleCalibrationFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].calibrationFilePath != null ? GlobalFunc.toggleProfileDetail.sampleDetailList[i].calibrationFilePath : "";
                    sampleQtyUnitCB.SelectedIndex = sampleQtyUnitCB.FindString(GlobalFunc.toggleProfileDetail.sampleDetailList[i].units);
                    sampleQty.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleQuantity.ToString();
                    sampleCountTime.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].countingTime.ToString();
                    sampleDescription.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDescription;
                    sampleDefinationFile.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].sampleDefinationFilePath;
                    sampleDecayCorrectionCB.Checked = GlobalFunc.toggleProfileDetail.sampleDetailList[i].decayCorrection;
                    sampleCorrectionDate.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i].decayCorrectionDate;
                    break;
                }
            }
        }

        private void sampleCalibrationFileBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sampleCalibrationFile.Text = ofd.FileName;
            }
        }

        private void sampleDefinationFileBtn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sampleDefinationFile.Text = ofd.FileName;
            }
        }
    }
}
