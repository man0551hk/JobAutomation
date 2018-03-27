namespace JobAutomation
{
    partial class Form1
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
            this.openLoopJobFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.csListComboBox = new System.Windows.Forms.ComboBox();
            this.addCsBtn = new System.Windows.Forms.Button();
            this.removeCsBtn = new System.Windows.Forms.Button();
            this.sfpBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.maxSampleComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.parameterSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterSetupPanel = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateSDFFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gammaVisionPath = new System.Windows.Forms.TextBox();
            this.analysisListPrefix = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.verifyPassword = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.setupCountingSequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.parameterSetupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openLoopJobFileDialog
            // 
            this.openLoopJobFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.maxSampleComboBox);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.sfpBtn);
            this.groupBox1.Controls.Add(this.removeCsBtn);
            this.groupBox1.Controls.Add(this.addCsBtn);
            this.groupBox1.Controls.Add(this.csListComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Counting Sequence";
            // 
            // csListComboBox
            // 
            this.csListComboBox.FormattingEnabled = true;
            this.csListComboBox.Location = new System.Drawing.Point(6, 19);
            this.csListComboBox.Name = "csListComboBox";
            this.csListComboBox.Size = new System.Drawing.Size(302, 21);
            this.csListComboBox.TabIndex = 0;
            // 
            // addCsBtn
            // 
            this.addCsBtn.Location = new System.Drawing.Point(691, 17);
            this.addCsBtn.Name = "addCsBtn";
            this.addCsBtn.Size = new System.Drawing.Size(75, 23);
            this.addCsBtn.TabIndex = 1;
            this.addCsBtn.Text = "Add";
            this.addCsBtn.UseVisualStyleBackColor = true;
            this.addCsBtn.Visible = false;
            // 
            // removeCsBtn
            // 
            this.removeCsBtn.Location = new System.Drawing.Point(772, 17);
            this.removeCsBtn.Name = "removeCsBtn";
            this.removeCsBtn.Size = new System.Drawing.Size(75, 23);
            this.removeCsBtn.TabIndex = 2;
            this.removeCsBtn.Text = "Remove";
            this.removeCsBtn.UseVisualStyleBackColor = true;
            this.removeCsBtn.Visible = false;
            // 
            // sfpBtn
            // 
            this.sfpBtn.Location = new System.Drawing.Point(853, 17);
            this.sfpBtn.Name = "sfpBtn";
            this.sfpBtn.Size = new System.Drawing.Size(167, 23);
            this.sfpBtn.TabIndex = 3;
            this.sfpBtn.Text = "Sequence Field Properties";
            this.sfpBtn.UseVisualStyleBackColor = true;
            this.sfpBtn.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 398);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequence Analysis List";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(231, 329);
            this.listBox1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 356);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(124, 356);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(536, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Start Counting Sequence";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // maxSampleComboBox
            // 
            this.maxSampleComboBox.FormattingEnabled = true;
            this.maxSampleComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.maxSampleComboBox.Location = new System.Drawing.Point(393, 19);
            this.maxSampleComboBox.Name = "maxSampleComboBox";
            this.maxSampleComboBox.Size = new System.Drawing.Size(137, 21);
            this.maxSampleComboBox.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parameterSetupToolStripMenuItem,
            this.setupCountingSequenceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // parameterSetupToolStripMenuItem
            // 
            this.parameterSetupToolStripMenuItem.Name = "parameterSetupToolStripMenuItem";
            this.parameterSetupToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.parameterSetupToolStripMenuItem.Text = "Parameter Setup";
            this.parameterSetupToolStripMenuItem.Click += new System.EventHandler(this.parameterSetupToolStripMenuItem_Click);
            // 
            // parameterSetupPanel
            // 
            this.parameterSetupPanel.Controls.Add(this.button9);
            this.parameterSetupPanel.Controls.Add(this.button8);
            this.parameterSetupPanel.Controls.Add(this.button7);
            this.parameterSetupPanel.Controls.Add(this.verifyPassword);
            this.parameterSetupPanel.Controls.Add(this.password);
            this.parameterSetupPanel.Controls.Add(this.analysisListPrefix);
            this.parameterSetupPanel.Controls.Add(this.gammaVisionPath);
            this.parameterSetupPanel.Controls.Add(this.label5);
            this.parameterSetupPanel.Controls.Add(this.label4);
            this.parameterSetupPanel.Controls.Add(this.label3);
            this.parameterSetupPanel.Controls.Add(this.label2);
            this.parameterSetupPanel.Controls.Add(this.updateSDFFilePath);
            this.parameterSetupPanel.Controls.Add(this.label1);
            this.parameterSetupPanel.Location = new System.Drawing.Point(262, 99);
            this.parameterSetupPanel.Name = "parameterSetupPanel";
            this.parameterSetupPanel.Size = new System.Drawing.Size(731, 397);
            this.parameterSetupPanel.TabIndex = 7;
            this.parameterSetupPanel.TabStop = false;
            this.parameterSetupPanel.Text = "Parameter Setup";
            this.parameterSetupPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UpdateSDF File Path:";
            // 
            // updateSDFFilePath
            // 
            this.updateSDFFilePath.Location = new System.Drawing.Point(122, 25);
            this.updateSDFFilePath.Name = "updateSDFFilePath";
            this.updateSDFFilePath.Size = new System.Drawing.Size(495, 20);
            this.updateSDFFilePath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "GammaVision Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Analysis List Prefix:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Verify Password:";
            // 
            // gammaVisionPath
            // 
            this.gammaVisionPath.Location = new System.Drawing.Point(122, 51);
            this.gammaVisionPath.Name = "gammaVisionPath";
            this.gammaVisionPath.Size = new System.Drawing.Size(495, 20);
            this.gammaVisionPath.TabIndex = 6;
            // 
            // analysisListPrefix
            // 
            this.analysisListPrefix.Location = new System.Drawing.Point(122, 77);
            this.analysisListPrefix.Name = "analysisListPrefix";
            this.analysisListPrefix.Size = new System.Drawing.Size(145, 20);
            this.analysisListPrefix.TabIndex = 7;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(122, 103);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(145, 20);
            this.password.TabIndex = 8;
            // 
            // verifyPassword
            // 
            this.verifyPassword.Location = new System.Drawing.Point(122, 129);
            this.verifyPassword.Name = "verifyPassword";
            this.verifyPassword.Size = new System.Drawing.Size(145, 20);
            this.verifyPassword.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(9, 169);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "Save";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(623, 22);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(31, 23);
            this.button8.TabIndex = 11;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(623, 48);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(31, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "...";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Max Samples:";
            // 
            // setupCountingSequenceToolStripMenuItem
            // 
            this.setupCountingSequenceToolStripMenuItem.Name = "setupCountingSequenceToolStripMenuItem";
            this.setupCountingSequenceToolStripMenuItem.Size = new System.Drawing.Size(159, 20);
            this.setupCountingSequenceToolStripMenuItem.Text = "Setup Counting Sequence ";
            this.setupCountingSequenceToolStripMenuItem.Click += new System.EventHandler(this.setupCountingSequenceToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 508);
            this.Controls.Add(this.parameterSetupPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Automation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.parameterSetupPanel.ResumeLayout(false);
            this.parameterSetupPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openLoopJobFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox csListComboBox;
        private System.Windows.Forms.Button sfpBtn;
        private System.Windows.Forms.Button removeCsBtn;
        private System.Windows.Forms.Button addCsBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox maxSampleComboBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parameterSetupToolStripMenuItem;
        private System.Windows.Forms.GroupBox parameterSetupPanel;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox verifyPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox analysisListPrefix;
        private System.Windows.Forms.TextBox gammaVisionPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox updateSDFFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem setupCountingSequenceToolStripMenuItem;
    }
}

