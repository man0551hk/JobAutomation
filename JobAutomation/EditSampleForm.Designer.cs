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
    }
}