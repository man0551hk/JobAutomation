using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobAutomation
{
    public partial class EditSampleForm : Form
    {
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
                    calibrationTab.Controls.Add(calibrationFile);

                    Button selFileBtn = new Button();
                    Point selFileLocation = new Point(537, buttonY);
                    selFileBtn.Location = selFileLocation;
                    selFileBtn.Text = "...";
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
                    Point quantityLocation = new Point(150, textBoxY);
                    quantityTextBox.Location = quantityLocation;
                    quantityUnitTab.Controls.Add(quantityTextBox);

                    ComboBox unitComboBox = new ComboBox();
                    unitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    unitComboBox.Width = 75;
                    unitComboBox.Items.Add("g");
                    unitComboBox.Items.Add("ml");
                    unitComboBox.Items.Add("kg");
                    unitComboBox.Items.Add("L");
                    Point unitLocation = new Point(282, textBoxY);
                    unitComboBox.Location = unitLocation;
                    quantityUnitTab.Controls.Add(unitComboBox);

                    ComboBox activityUnitComboBox = new ComboBox();
                    activityUnitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    activityUnitComboBox.Width = 75;
                    activityUnitComboBox.Items.Add("Bq");
                    activityUnitComboBox.Items.Add("MCi");
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
                    countTimeTab.Controls.Add(countTimeTextBox);

                    labelY += 30;
                    textBoxY += 30;
                    buttonY += 30;

                }
            }
        }
    }
}
