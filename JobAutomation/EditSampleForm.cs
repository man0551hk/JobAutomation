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
            Construct();
            ConstructCalibrationTab();
            ConstructQuantityUnitTab();
            ConstructCountTimeTab();
        }

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
                    quantityUnitTab.Controls.Add(quantityTextBox);
                    quantityTextBox.Text = GlobalFunc.toggleProfileDetail.sampleDetailList[i - 1].sampleQuantity.ToString();

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
                    activityUnitComboBox.Items.Add("MCi");
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
            Save();
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
            GlobalFunc.mainForm.SetProfileDetail();
            GlobalFunc.measurementSetupForm.EnableDoneBtn();
            this.Close();
        }
    }
}
