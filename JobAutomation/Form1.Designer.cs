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
            this.exitSetupBtn = new System.Windows.Forms.Button();
            this.maxSample = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.removeCsBtn = new System.Windows.Forms.Button();
            this.addCsBtn = new System.Windows.Forms.Button();
            this.csListComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.removeAnalysisBtn = new System.Windows.Forms.Button();
            this.addAnalysisBtn = new System.Windows.Forms.Button();
            this.analysisListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupCountingSequenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterSetupPanel = new System.Windows.Forms.GroupBox();
            this.gammaVisionPathBtn = new System.Windows.Forms.Button();
            this.updateSDFFilePathBtn = new System.Windows.Forms.Button();
            this.saveSetupBtn = new System.Windows.Forms.Button();
            this.verifyPassword = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.analysisListPrefix = new System.Windows.Forms.TextBox();
            this.gammaVisionPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.updateSDFFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.analysisSettingsPanel = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.parameterSetupPanel.SuspendLayout();
            this.analysisSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openLoopJobFileDialog
            // 
            this.openLoopJobFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exitSetupBtn);
            this.groupBox1.Controls.Add(this.maxSample);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button6);
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
            // exitSetupBtn
            // 
            this.exitSetupBtn.Location = new System.Drawing.Point(853, 16);
            this.exitSetupBtn.Name = "exitSetupBtn";
            this.exitSetupBtn.Size = new System.Drawing.Size(97, 23);
            this.exitSetupBtn.TabIndex = 8;
            this.exitSetupBtn.Text = "Exit Setup";
            this.exitSetupBtn.UseVisualStyleBackColor = true;
            // 
            // maxSample
            // 
            this.maxSample.Location = new System.Drawing.Point(393, 19);
            this.maxSample.Name = "maxSample";
            this.maxSample.Size = new System.Drawing.Size(91, 20);
            this.maxSample.TabIndex = 7;
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(536, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Start Counting Sequence";
            this.button6.UseVisualStyleBackColor = true;
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
            // addCsBtn
            // 
            this.addCsBtn.Location = new System.Drawing.Point(691, 17);
            this.addCsBtn.Name = "addCsBtn";
            this.addCsBtn.Size = new System.Drawing.Size(75, 23);
            this.addCsBtn.TabIndex = 1;
            this.addCsBtn.Text = "Add";
            this.addCsBtn.UseVisualStyleBackColor = true;
            this.addCsBtn.Visible = false;
            this.addCsBtn.Click += new System.EventHandler(this.addCsBtn_Click);
            // 
            // csListComboBox
            // 
            this.csListComboBox.FormattingEnabled = true;
            this.csListComboBox.Location = new System.Drawing.Point(6, 19);
            this.csListComboBox.Name = "csListComboBox";
            this.csListComboBox.Size = new System.Drawing.Size(302, 21);
            this.csListComboBox.TabIndex = 0;
            this.csListComboBox.SelectedIndexChanged += new System.EventHandler(this.csListComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeAnalysisBtn);
            this.groupBox2.Controls.Add(this.addAnalysisBtn);
            this.groupBox2.Controls.Add(this.analysisListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 545);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequence Analysis List";
            // 
            // removeAnalysisBtn
            // 
            this.removeAnalysisBtn.Enabled = false;
            this.removeAnalysisBtn.Location = new System.Drawing.Point(123, 516);
            this.removeAnalysisBtn.Name = "removeAnalysisBtn";
            this.removeAnalysisBtn.Size = new System.Drawing.Size(113, 23);
            this.removeAnalysisBtn.TabIndex = 2;
            this.removeAnalysisBtn.Text = "Remove";
            this.removeAnalysisBtn.UseVisualStyleBackColor = true;
            // 
            // addAnalysisBtn
            // 
            this.addAnalysisBtn.Enabled = false;
            this.addAnalysisBtn.Location = new System.Drawing.Point(6, 516);
            this.addAnalysisBtn.Name = "addAnalysisBtn";
            this.addAnalysisBtn.Size = new System.Drawing.Size(111, 23);
            this.addAnalysisBtn.TabIndex = 1;
            this.addAnalysisBtn.Text = "Add";
            this.addAnalysisBtn.UseVisualStyleBackColor = true;
            this.addAnalysisBtn.Click += new System.EventHandler(this.addAnalysisBtn_Click);
            // 
            // analysisListBox
            // 
            this.analysisListBox.FormattingEnabled = true;
            this.analysisListBox.Location = new System.Drawing.Point(6, 19);
            this.analysisListBox.Name = "analysisListBox";
            this.analysisListBox.Size = new System.Drawing.Size(231, 485);
            this.analysisListBox.TabIndex = 0;
            this.analysisListBox.SelectedIndexChanged += new System.EventHandler(this.analysisListBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupCountingSequenceToolStripMenuItem,
            this.parameterSetupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupCountingSequenceToolStripMenuItem
            // 
            this.setupCountingSequenceToolStripMenuItem.Name = "setupCountingSequenceToolStripMenuItem";
            this.setupCountingSequenceToolStripMenuItem.Size = new System.Drawing.Size(159, 20);
            this.setupCountingSequenceToolStripMenuItem.Text = "Setup Counting Sequence ";
            this.setupCountingSequenceToolStripMenuItem.Click += new System.EventHandler(this.setupCountingSequenceToolStripMenuItem_Click);
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
            this.parameterSetupPanel.Controls.Add(this.gammaVisionPathBtn);
            this.parameterSetupPanel.Controls.Add(this.updateSDFFilePathBtn);
            this.parameterSetupPanel.Controls.Add(this.saveSetupBtn);
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
            this.parameterSetupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterSetupPanel.Location = new System.Drawing.Point(262, 99);
            this.parameterSetupPanel.Name = "parameterSetupPanel";
            this.parameterSetupPanel.Size = new System.Drawing.Size(731, 209);
            this.parameterSetupPanel.TabIndex = 7;
            this.parameterSetupPanel.TabStop = false;
            this.parameterSetupPanel.Text = "Parameter Setup";
            this.parameterSetupPanel.Visible = false;
            // 
            // gammaVisionPathBtn
            // 
            this.gammaVisionPathBtn.Location = new System.Drawing.Point(623, 48);
            this.gammaVisionPathBtn.Name = "gammaVisionPathBtn";
            this.gammaVisionPathBtn.Size = new System.Drawing.Size(31, 23);
            this.gammaVisionPathBtn.TabIndex = 12;
            this.gammaVisionPathBtn.Text = "...";
            this.gammaVisionPathBtn.UseVisualStyleBackColor = true;
            this.gammaVisionPathBtn.Click += new System.EventHandler(this.gammaVisionPathBtn_Click);
            // 
            // updateSDFFilePathBtn
            // 
            this.updateSDFFilePathBtn.Location = new System.Drawing.Point(623, 22);
            this.updateSDFFilePathBtn.Name = "updateSDFFilePathBtn";
            this.updateSDFFilePathBtn.Size = new System.Drawing.Size(31, 23);
            this.updateSDFFilePathBtn.TabIndex = 11;
            this.updateSDFFilePathBtn.Text = "...";
            this.updateSDFFilePathBtn.UseVisualStyleBackColor = true;
            this.updateSDFFilePathBtn.Click += new System.EventHandler(this.updateSDFFilePathBtn_Click);
            // 
            // saveSetupBtn
            // 
            this.saveSetupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSetupBtn.Location = new System.Drawing.Point(9, 169);
            this.saveSetupBtn.Name = "saveSetupBtn";
            this.saveSetupBtn.Size = new System.Drawing.Size(75, 23);
            this.saveSetupBtn.TabIndex = 10;
            this.saveSetupBtn.Text = "Save";
            this.saveSetupBtn.UseVisualStyleBackColor = true;
            this.saveSetupBtn.Click += new System.EventHandler(this.saveSetupBtn_Click);
            // 
            // verifyPassword
            // 
            this.verifyPassword.Location = new System.Drawing.Point(122, 129);
            this.verifyPassword.Name = "verifyPassword";
            this.verifyPassword.PasswordChar = '*';
            this.verifyPassword.Size = new System.Drawing.Size(145, 22);
            this.verifyPassword.TabIndex = 9;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(122, 103);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(145, 22);
            this.password.TabIndex = 8;
            // 
            // analysisListPrefix
            // 
            this.analysisListPrefix.Location = new System.Drawing.Point(122, 77);
            this.analysisListPrefix.Name = "analysisListPrefix";
            this.analysisListPrefix.Size = new System.Drawing.Size(145, 22);
            this.analysisListPrefix.TabIndex = 7;
            // 
            // gammaVisionPath
            // 
            this.gammaVisionPath.Location = new System.Drawing.Point(122, 51);
            this.gammaVisionPath.Name = "gammaVisionPath";
            this.gammaVisionPath.Size = new System.Drawing.Size(495, 22);
            this.gammaVisionPath.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Verify Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Analysis List Prefix:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "GammaVision Path:";
            // 
            // updateSDFFilePath
            // 
            this.updateSDFFilePath.Location = new System.Drawing.Point(122, 25);
            this.updateSDFFilePath.Name = "updateSDFFilePath";
            this.updateSDFFilePath.Size = new System.Drawing.Size(495, 22);
            this.updateSDFFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UpdateSDF File Path:";
            // 
            // analysisSettingsPanel
            // 
            this.analysisSettingsPanel.Controls.Add(this.label7);
            this.analysisSettingsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisSettingsPanel.Location = new System.Drawing.Point(262, 99);
            this.analysisSettingsPanel.Name = "analysisSettingsPanel";
            this.analysisSettingsPanel.Size = new System.Drawing.Size(778, 544);
            this.analysisSettingsPanel.TabIndex = 13;
            this.analysisSettingsPanel.TabStop = false;
            this.analysisSettingsPanel.Text = "Analysis Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sample Description:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 655);
            this.Controls.Add(this.analysisSettingsPanel);
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
            this.analysisSettingsPanel.ResumeLayout(false);
            this.analysisSettingsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openLoopJobFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox csListComboBox;
        private System.Windows.Forms.Button removeCsBtn;
        private System.Windows.Forms.Button addCsBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button removeAnalysisBtn;
        private System.Windows.Forms.Button addAnalysisBtn;
        private System.Windows.Forms.ListBox analysisListBox;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem parameterSetupToolStripMenuItem;
        private System.Windows.Forms.GroupBox parameterSetupPanel;
        private System.Windows.Forms.Button gammaVisionPathBtn;
        private System.Windows.Forms.Button updateSDFFilePathBtn;
        private System.Windows.Forms.Button saveSetupBtn;
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
        private System.Windows.Forms.GroupBox analysisSettingsPanel;
        private System.Windows.Forms.TextBox maxSample;
        private System.Windows.Forms.Button exitSetupBtn;
        private System.Windows.Forms.Label label7;
    }
}

