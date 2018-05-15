namespace JobAutomation
{
    partial class EditSampleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sampleTab = new System.Windows.Forms.TabPage();
            this.sampleDefinationFileBtn = new System.Windows.Forms.Button();
            this.sampleCalibrationFileBtn = new System.Windows.Forms.Button();
            this.sampleCorrectionDate = new System.Windows.Forms.DateTimePicker();
            this.sampleDefinationFile = new System.Windows.Forms.TextBox();
            this.sampleDescription = new System.Windows.Forms.TextBox();
            this.sampleCountTime = new System.Windows.Forms.TextBox();
            this.sampleQty = new System.Windows.Forms.TextBox();
            this.sampleQtyUnitCB = new System.Windows.Forms.ComboBox();
            this.sampleCalibrationFile = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sampleDoneBtn = new System.Windows.Forms.Button();
            this.sampleCB = new System.Windows.Forms.ComboBox();
            this.calibrationTab = new System.Windows.Forms.TabPage();
            this.calibrationDoneBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quantityUnitTab = new System.Windows.Forms.TabPage();
            this.quantityDoneBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.countTimeTab = new System.Windows.Forms.TabPage();
            this.countTimeDoneBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.sampleTab.SuspendLayout();
            this.calibrationTab.SuspendLayout();
            this.quantityUnitTab.SuspendLayout();
            this.countTimeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sampleTab);
            this.tabControl1.Controls.Add(this.calibrationTab);
            this.tabControl1.Controls.Add(this.quantityUnitTab);
            this.tabControl1.Controls.Add(this.countTimeTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(759, 647);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // sampleTab
            // 
            this.sampleTab.Controls.Add(this.sampleDefinationFileBtn);
            this.sampleTab.Controls.Add(this.sampleCalibrationFileBtn);
            this.sampleTab.Controls.Add(this.sampleCorrectionDate);
            this.sampleTab.Controls.Add(this.sampleDefinationFile);
            this.sampleTab.Controls.Add(this.sampleDescription);
            this.sampleTab.Controls.Add(this.sampleCountTime);
            this.sampleTab.Controls.Add(this.sampleQty);
            this.sampleTab.Controls.Add(this.sampleQtyUnitCB);
            this.sampleTab.Controls.Add(this.sampleCalibrationFile);
            this.sampleTab.Controls.Add(this.label15);
            this.sampleTab.Controls.Add(this.label14);
            this.sampleTab.Controls.Add(this.label13);
            this.sampleTab.Controls.Add(this.label12);
            this.sampleTab.Controls.Add(this.label11);
            this.sampleTab.Controls.Add(this.label10);
            this.sampleTab.Controls.Add(this.label9);
            this.sampleTab.Controls.Add(this.sampleDoneBtn);
            this.sampleTab.Controls.Add(this.sampleCB);
            this.sampleTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleTab.Location = new System.Drawing.Point(4, 22);
            this.sampleTab.Name = "sampleTab";
            this.sampleTab.Padding = new System.Windows.Forms.Padding(3);
            this.sampleTab.Size = new System.Drawing.Size(751, 621);
            this.sampleTab.TabIndex = 0;
            this.sampleTab.Text = "Sample";
            this.sampleTab.UseVisualStyleBackColor = true;
            // 
            // sampleDefinationFileBtn
            // 
            this.sampleDefinationFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefinationFileBtn.Location = new System.Drawing.Point(624, 185);
            this.sampleDefinationFileBtn.Name = "sampleDefinationFileBtn";
            this.sampleDefinationFileBtn.Size = new System.Drawing.Size(28, 23);
            this.sampleDefinationFileBtn.TabIndex = 19;
            this.sampleDefinationFileBtn.Text = "...";
            this.sampleDefinationFileBtn.UseVisualStyleBackColor = true;
            this.sampleDefinationFileBtn.Click += new System.EventHandler(this.sampleDefinationFileBtn_Click);
            // 
            // sampleCalibrationFileBtn
            // 
            this.sampleCalibrationFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleCalibrationFileBtn.Location = new System.Drawing.Point(624, 41);
            this.sampleCalibrationFileBtn.Name = "sampleCalibrationFileBtn";
            this.sampleCalibrationFileBtn.Size = new System.Drawing.Size(28, 23);
            this.sampleCalibrationFileBtn.TabIndex = 18;
            this.sampleCalibrationFileBtn.Text = "...";
            this.sampleCalibrationFileBtn.UseVisualStyleBackColor = true;
            this.sampleCalibrationFileBtn.Click += new System.EventHandler(this.sampleCalibrationFileBtn_Click);
            // 
            // sampleCorrectionDate
            // 
            this.sampleCorrectionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleCorrectionDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sampleCorrectionDate.Location = new System.Drawing.Point(177, 213);
            this.sampleCorrectionDate.Name = "sampleCorrectionDate";
            this.sampleCorrectionDate.Size = new System.Drawing.Size(200, 20);
            this.sampleCorrectionDate.TabIndex = 17;
            // 
            // sampleDefinationFile
            // 
            this.sampleDefinationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefinationFile.Location = new System.Drawing.Point(177, 187);
            this.sampleDefinationFile.Name = "sampleDefinationFile";
            this.sampleDefinationFile.Size = new System.Drawing.Size(441, 20);
            this.sampleDefinationFile.TabIndex = 16;
            // 
            // sampleDescription
            // 
            this.sampleDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDescription.Location = new System.Drawing.Point(177, 159);
            this.sampleDescription.Name = "sampleDescription";
            this.sampleDescription.Size = new System.Drawing.Size(441, 20);
            this.sampleDescription.TabIndex = 15;
            // 
            // sampleCountTime
            // 
            this.sampleCountTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleCountTime.Location = new System.Drawing.Point(177, 132);
            this.sampleCountTime.Name = "sampleCountTime";
            this.sampleCountTime.Size = new System.Drawing.Size(100, 20);
            this.sampleCountTime.TabIndex = 14;
            // 
            // sampleQty
            // 
            this.sampleQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleQty.Location = new System.Drawing.Point(177, 101);
            this.sampleQty.Name = "sampleQty";
            this.sampleQty.Size = new System.Drawing.Size(100, 20);
            this.sampleQty.TabIndex = 13;
            // 
            // sampleQtyUnitCB
            // 
            this.sampleQtyUnitCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleQtyUnitCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleQtyUnitCB.FormattingEnabled = true;
            this.sampleQtyUnitCB.Items.AddRange(new object[] {
            "g",
            "ml",
            "kg",
            "L"});
            this.sampleQtyUnitCB.Location = new System.Drawing.Point(177, 74);
            this.sampleQtyUnitCB.Name = "sampleQtyUnitCB";
            this.sampleQtyUnitCB.Size = new System.Drawing.Size(121, 21);
            this.sampleQtyUnitCB.TabIndex = 12;
            // 
            // sampleCalibrationFile
            // 
            this.sampleCalibrationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleCalibrationFile.Location = new System.Drawing.Point(177, 44);
            this.sampleCalibrationFile.Name = "sampleCalibrationFile";
            this.sampleCalibrationFile.Size = new System.Drawing.Size(441, 20);
            this.sampleCalibrationFile.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(165, 16);
            this.label15.TabIndex = 10;
            this.label15.Text = "Decay Correction Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(165, 16);
            this.label14.TabIndex = 9;
            this.label14.Text = "Sample Defination File";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Sample Description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Count Time";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Sample Quantity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Sample Quantity Unit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Calibration File";
            // 
            // sampleDoneBtn
            // 
            this.sampleDoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDoneBtn.Location = new System.Drawing.Point(657, 587);
            this.sampleDoneBtn.Name = "sampleDoneBtn";
            this.sampleDoneBtn.Size = new System.Drawing.Size(88, 28);
            this.sampleDoneBtn.TabIndex = 3;
            this.sampleDoneBtn.Text = "Done";
            this.sampleDoneBtn.UseVisualStyleBackColor = true;
            this.sampleDoneBtn.Click += new System.EventHandler(this.sampleDoneBtn_Click);
            // 
            // sampleCB
            // 
            this.sampleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sampleCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleCB.FormattingEnabled = true;
            this.sampleCB.Location = new System.Drawing.Point(6, 6);
            this.sampleCB.Name = "sampleCB";
            this.sampleCB.Size = new System.Drawing.Size(163, 21);
            this.sampleCB.TabIndex = 0;
            this.sampleCB.SelectedIndexChanged += new System.EventHandler(this.sampleCB_SelectedIndexChanged);
            // 
            // calibrationTab
            // 
            this.calibrationTab.Controls.Add(this.calibrationDoneBtn);
            this.calibrationTab.Controls.Add(this.label2);
            this.calibrationTab.Controls.Add(this.label1);
            this.calibrationTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationTab.Location = new System.Drawing.Point(4, 22);
            this.calibrationTab.Name = "calibrationTab";
            this.calibrationTab.Padding = new System.Windows.Forms.Padding(3);
            this.calibrationTab.Size = new System.Drawing.Size(751, 621);
            this.calibrationTab.TabIndex = 1;
            this.calibrationTab.Text = "Calibration";
            this.calibrationTab.UseVisualStyleBackColor = true;
            // 
            // calibrationDoneBtn
            // 
            this.calibrationDoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationDoneBtn.Location = new System.Drawing.Point(657, 587);
            this.calibrationDoneBtn.Name = "calibrationDoneBtn";
            this.calibrationDoneBtn.Size = new System.Drawing.Size(88, 28);
            this.calibrationDoneBtn.TabIndex = 2;
            this.calibrationDoneBtn.Text = "Done";
            this.calibrationDoneBtn.UseVisualStyleBackColor = true;
            this.calibrationDoneBtn.Click += new System.EventHandler(this.calibrationDoneBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Calibration File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample";
            // 
            // quantityUnitTab
            // 
            this.quantityUnitTab.Controls.Add(this.quantityDoneBtn);
            this.quantityUnitTab.Controls.Add(this.label6);
            this.quantityUnitTab.Controls.Add(this.label5);
            this.quantityUnitTab.Controls.Add(this.label4);
            this.quantityUnitTab.Controls.Add(this.label3);
            this.quantityUnitTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityUnitTab.Location = new System.Drawing.Point(4, 22);
            this.quantityUnitTab.Name = "quantityUnitTab";
            this.quantityUnitTab.Size = new System.Drawing.Size(751, 621);
            this.quantityUnitTab.TabIndex = 2;
            this.quantityUnitTab.Text = "Quantity / Unit";
            this.quantityUnitTab.UseVisualStyleBackColor = true;
            // 
            // quantityDoneBtn
            // 
            this.quantityDoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityDoneBtn.Location = new System.Drawing.Point(660, 590);
            this.quantityDoneBtn.Name = "quantityDoneBtn";
            this.quantityDoneBtn.Size = new System.Drawing.Size(88, 28);
            this.quantityDoneBtn.TabIndex = 5;
            this.quantityDoneBtn.Text = "Done";
            this.quantityDoneBtn.UseVisualStyleBackColor = true;
            this.quantityDoneBtn.Click += new System.EventHandler(this.quantityDoneBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(423, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Activity Unit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(300, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sample";
            // 
            // countTimeTab
            // 
            this.countTimeTab.Controls.Add(this.countTimeDoneBtn);
            this.countTimeTab.Controls.Add(this.label8);
            this.countTimeTab.Controls.Add(this.label7);
            this.countTimeTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countTimeTab.Location = new System.Drawing.Point(4, 22);
            this.countTimeTab.Name = "countTimeTab";
            this.countTimeTab.Size = new System.Drawing.Size(751, 621);
            this.countTimeTab.TabIndex = 3;
            this.countTimeTab.Text = "Count Time";
            this.countTimeTab.UseVisualStyleBackColor = true;
            // 
            // countTimeDoneBtn
            // 
            this.countTimeDoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countTimeDoneBtn.Location = new System.Drawing.Point(660, 590);
            this.countTimeDoneBtn.Name = "countTimeDoneBtn";
            this.countTimeDoneBtn.Size = new System.Drawing.Size(88, 28);
            this.countTimeDoneBtn.TabIndex = 3;
            this.countTimeDoneBtn.Text = "Done";
            this.countTimeDoneBtn.UseVisualStyleBackColor = true;
            this.countTimeDoneBtn.Click += new System.EventHandler(this.countTimeDoneBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(263, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Count Time (sec)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(82, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Sample";
            // 
            // EditSampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 672);
            this.Controls.Add(this.tabControl1);
            this.Name = "EditSampleForm";
            this.Text = "Sample Setup";
            this.tabControl1.ResumeLayout(false);
            this.sampleTab.ResumeLayout(false);
            this.sampleTab.PerformLayout();
            this.calibrationTab.ResumeLayout(false);
            this.calibrationTab.PerformLayout();
            this.quantityUnitTab.ResumeLayout(false);
            this.quantityUnitTab.PerformLayout();
            this.countTimeTab.ResumeLayout(false);
            this.countTimeTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sampleTab;
        private System.Windows.Forms.TabPage calibrationTab;
        private System.Windows.Forms.TabPage quantityUnitTab;
        private System.Windows.Forms.TabPage countTimeTab;
        private System.Windows.Forms.ComboBox sampleCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calibrationDoneBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button sampleDoneBtn;
        private System.Windows.Forms.Button quantityDoneBtn;
        private System.Windows.Forms.Button countTimeDoneBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button sampleDefinationFileBtn;
        private System.Windows.Forms.Button sampleCalibrationFileBtn;
        private System.Windows.Forms.DateTimePicker sampleCorrectionDate;
        private System.Windows.Forms.TextBox sampleDefinationFile;
        private System.Windows.Forms.TextBox sampleDescription;
        private System.Windows.Forms.TextBox sampleCountTime;
        private System.Windows.Forms.TextBox sampleQty;
        private System.Windows.Forms.ComboBox sampleQtyUnitCB;
        private System.Windows.Forms.TextBox sampleCalibrationFile;
    }
}