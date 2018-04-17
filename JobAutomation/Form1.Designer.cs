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
            this.sampleDefaultFilePathBtn = new System.Windows.Forms.Button();
            this.jobTemplatePathBtn = new System.Windows.Forms.Button();
            this.spectrumFilePathBtn = new System.Windows.Forms.Button();
            this.saveAnalysisSettingTemplateBtn = new System.Windows.Forms.Button();
            this.loadAnalysisSettingTemplateBtn = new System.Windows.Forms.Button();
            this.sampleDefaultFilePathTxt = new System.Windows.Forms.TextBox();
            this.jobTemplatePathTxt = new System.Windows.Forms.TextBox();
            this.spectrumFilePathTxt = new System.Windows.Forms.TextBox();
            this.sampleDescriptionTxt = new System.Windows.Forms.TextBox();
            this.sampleDefaultFilePathCB = new System.Windows.Forms.CheckBox();
            this.jobTemplatePathCB = new System.Windows.Forms.CheckBox();
            this.spectrumFilePatbCB = new System.Windows.Forms.CheckBox();
            this.sampleDescriptionCB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveSettingBtn = new System.Windows.Forms.Button();
            this.libraryFilePathBtn = new System.Windows.Forms.Button();
            this.calibrationFilePathBtn = new System.Windows.Forms.Button();
            this.attenuationSizeTxt = new System.Windows.Forms.TextBox();
            this.systematicErrorTxt = new System.Windows.Forms.TextBox();
            this.randomErrorTxt = new System.Windows.Forms.TextBox();
            this.unitsTxt = new System.Windows.Forms.TextBox();
            this.randomSummingFactorTxt = new System.Windows.Forms.TextBox();
            this.activityDivisorTxt = new System.Windows.Forms.TextBox();
            this.activityMultiperTxt = new System.Windows.Forms.TextBox();
            this.realTimePresetTxt = new System.Windows.Forms.TextBox();
            this.liveTimePresetTxt = new System.Windows.Forms.TextBox();
            this.activityUnitsTxt = new System.Windows.Forms.TextBox();
            this.sampleQuantityTxt = new System.Windows.Forms.TextBox();
            this.decayCorrectionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.collectionStopDatePicker = new System.Windows.Forms.DateTimePicker();
            this.collectionStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.libraryFilePathTxt = new System.Windows.Forms.TextBox();
            this.calibrationFilePathTxt = new System.Windows.Forms.TextBox();
            this.attenuationSizeCB = new System.Windows.Forms.CheckBox();
            this.systematicErrorCB = new System.Windows.Forms.CheckBox();
            this.randomErrorCB = new System.Windows.Forms.CheckBox();
            this.unitsCB = new System.Windows.Forms.CheckBox();
            this.randomSummingFactorCB = new System.Windows.Forms.CheckBox();
            this.activityDivisorCB = new System.Windows.Forms.CheckBox();
            this.activityMultiperCB = new System.Windows.Forms.CheckBox();
            this.realTimePresetCB = new System.Windows.Forms.CheckBox();
            this.liveTimePresetCB = new System.Windows.Forms.CheckBox();
            this.activityUnitsCB = new System.Windows.Forms.CheckBox();
            this.sampleQuantityCB = new System.Windows.Forms.CheckBox();
            this.decayCorrectionDateCB = new System.Windows.Forms.CheckBox();
            this.decayCorrectionStopDateTimeCB = new System.Windows.Forms.CheckBox();
            this.collectionStopDateCB = new System.Windows.Forms.CheckBox();
            this.collectionStartDateCB = new System.Windows.Forms.CheckBox();
            this.libraryFilePathCB = new System.Windows.Forms.CheckBox();
            this.calibrationFilePathCB = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.parameterSetupPanel.SuspendLayout();
            this.analysisSettingsPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.exitSetupBtn.Location = new System.Drawing.Point(807, 16);
            this.exitSetupBtn.Name = "exitSetupBtn";
            this.exitSetupBtn.Size = new System.Drawing.Size(97, 23);
            this.exitSetupBtn.TabIndex = 8;
            this.exitSetupBtn.Text = "Exit Setup";
            this.exitSetupBtn.UseVisualStyleBackColor = true;
            this.exitSetupBtn.Click += new System.EventHandler(this.exitSetupBtn_Click);
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
            this.button6.Location = new System.Drawing.Point(490, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Start Counting Sequence";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // removeCsBtn
            // 
            this.removeCsBtn.Location = new System.Drawing.Point(726, 16);
            this.removeCsBtn.Name = "removeCsBtn";
            this.removeCsBtn.Size = new System.Drawing.Size(75, 23);
            this.removeCsBtn.TabIndex = 2;
            this.removeCsBtn.Text = "Remove";
            this.removeCsBtn.UseVisualStyleBackColor = true;
            this.removeCsBtn.Visible = false;
            // 
            // addCsBtn
            // 
            this.addCsBtn.Location = new System.Drawing.Point(645, 17);
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
            this.verifyPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyPassword.Location = new System.Drawing.Point(122, 129);
            this.verifyPassword.Name = "verifyPassword";
            this.verifyPassword.PasswordChar = '*';
            this.verifyPassword.Size = new System.Drawing.Size(145, 20);
            this.verifyPassword.TabIndex = 9;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(122, 103);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(145, 20);
            this.password.TabIndex = 8;
            // 
            // analysisListPrefix
            // 
            this.analysisListPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisListPrefix.Location = new System.Drawing.Point(122, 77);
            this.analysisListPrefix.Name = "analysisListPrefix";
            this.analysisListPrefix.Size = new System.Drawing.Size(145, 20);
            this.analysisListPrefix.TabIndex = 7;
            // 
            // gammaVisionPath
            // 
            this.gammaVisionPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gammaVisionPath.Location = new System.Drawing.Point(122, 51);
            this.gammaVisionPath.Name = "gammaVisionPath";
            this.gammaVisionPath.Size = new System.Drawing.Size(495, 20);
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
            this.updateSDFFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateSDFFilePath.Location = new System.Drawing.Point(122, 25);
            this.updateSDFFilePath.Name = "updateSDFFilePath";
            this.updateSDFFilePath.Size = new System.Drawing.Size(495, 20);
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
            this.analysisSettingsPanel.Controls.Add(this.sampleDefaultFilePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.jobTemplatePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.spectrumFilePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.saveAnalysisSettingTemplateBtn);
            this.analysisSettingsPanel.Controls.Add(this.loadAnalysisSettingTemplateBtn);
            this.analysisSettingsPanel.Controls.Add(this.sampleDefaultFilePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.jobTemplatePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.spectrumFilePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.sampleDescriptionTxt);
            this.analysisSettingsPanel.Controls.Add(this.sampleDefaultFilePathCB);
            this.analysisSettingsPanel.Controls.Add(this.jobTemplatePathCB);
            this.analysisSettingsPanel.Controls.Add(this.spectrumFilePatbCB);
            this.analysisSettingsPanel.Controls.Add(this.sampleDescriptionCB);
            this.analysisSettingsPanel.Controls.Add(this.groupBox3);
            this.analysisSettingsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisSettingsPanel.Location = new System.Drawing.Point(262, 99);
            this.analysisSettingsPanel.Name = "analysisSettingsPanel";
            this.analysisSettingsPanel.Size = new System.Drawing.Size(778, 544);
            this.analysisSettingsPanel.TabIndex = 13;
            this.analysisSettingsPanel.TabStop = false;
            this.analysisSettingsPanel.Text = "Analysis Settings";
            // 
            // sampleDefaultFilePathBtn
            // 
            this.sampleDefaultFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefaultFilePathBtn.Location = new System.Drawing.Point(706, 101);
            this.sampleDefaultFilePathBtn.Name = "sampleDefaultFilePathBtn";
            this.sampleDefaultFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.sampleDefaultFilePathBtn.TabIndex = 17;
            this.sampleDefaultFilePathBtn.Text = "...";
            this.sampleDefaultFilePathBtn.UseVisualStyleBackColor = true;
            this.sampleDefaultFilePathBtn.Click += new System.EventHandler(this.sampleDefaultFilePathBtn_Click);
            // 
            // jobTemplatePathBtn
            // 
            this.jobTemplatePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTemplatePathBtn.Location = new System.Drawing.Point(706, 73);
            this.jobTemplatePathBtn.Name = "jobTemplatePathBtn";
            this.jobTemplatePathBtn.Size = new System.Drawing.Size(40, 22);
            this.jobTemplatePathBtn.TabIndex = 16;
            this.jobTemplatePathBtn.Text = "...";
            this.jobTemplatePathBtn.UseVisualStyleBackColor = true;
            this.jobTemplatePathBtn.Click += new System.EventHandler(this.jobTemplatePathBtn_Click);
            // 
            // spectrumFilePathBtn
            // 
            this.spectrumFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spectrumFilePathBtn.Location = new System.Drawing.Point(706, 46);
            this.spectrumFilePathBtn.Name = "spectrumFilePathBtn";
            this.spectrumFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.spectrumFilePathBtn.TabIndex = 15;
            this.spectrumFilePathBtn.Text = "...";
            this.spectrumFilePathBtn.UseVisualStyleBackColor = true;
            this.spectrumFilePathBtn.Click += new System.EventHandler(this.spectrumFilePathBtn_Click);
            // 
            // saveAnalysisSettingTemplateBtn
            // 
            this.saveAnalysisSettingTemplateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAnalysisSettingTemplateBtn.Location = new System.Drawing.Point(237, 502);
            this.saveAnalysisSettingTemplateBtn.Name = "saveAnalysisSettingTemplateBtn";
            this.saveAnalysisSettingTemplateBtn.Size = new System.Drawing.Size(225, 23);
            this.saveAnalysisSettingTemplateBtn.TabIndex = 14;
            this.saveAnalysisSettingTemplateBtn.Text = "Save Analysis Setting Template";
            this.saveAnalysisSettingTemplateBtn.UseVisualStyleBackColor = true;
            this.saveAnalysisSettingTemplateBtn.Click += new System.EventHandler(this.saveAnalysisSettingTemplateBtn_Click);
            // 
            // loadAnalysisSettingTemplateBtn
            // 
            this.loadAnalysisSettingTemplateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadAnalysisSettingTemplateBtn.Location = new System.Drawing.Point(6, 502);
            this.loadAnalysisSettingTemplateBtn.Name = "loadAnalysisSettingTemplateBtn";
            this.loadAnalysisSettingTemplateBtn.Size = new System.Drawing.Size(225, 23);
            this.loadAnalysisSettingTemplateBtn.TabIndex = 13;
            this.loadAnalysisSettingTemplateBtn.Text = "Load Analysis Setting Template";
            this.loadAnalysisSettingTemplateBtn.UseVisualStyleBackColor = true;
            this.loadAnalysisSettingTemplateBtn.Click += new System.EventHandler(this.loadAnalysisSettingTemplateBtn_Click);
            // 
            // sampleDefaultFilePathTxt
            // 
            this.sampleDefaultFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefaultFilePathTxt.Location = new System.Drawing.Point(160, 102);
            this.sampleDefaultFilePathTxt.Name = "sampleDefaultFilePathTxt";
            this.sampleDefaultFilePathTxt.Size = new System.Drawing.Size(540, 20);
            this.sampleDefaultFilePathTxt.TabIndex = 12;
            // 
            // jobTemplatePathTxt
            // 
            this.jobTemplatePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTemplatePathTxt.Location = new System.Drawing.Point(160, 74);
            this.jobTemplatePathTxt.Name = "jobTemplatePathTxt";
            this.jobTemplatePathTxt.Size = new System.Drawing.Size(540, 20);
            this.jobTemplatePathTxt.TabIndex = 11;
            // 
            // spectrumFilePathTxt
            // 
            this.spectrumFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spectrumFilePathTxt.Location = new System.Drawing.Point(160, 46);
            this.spectrumFilePathTxt.Name = "spectrumFilePathTxt";
            this.spectrumFilePathTxt.Size = new System.Drawing.Size(540, 20);
            this.spectrumFilePathTxt.TabIndex = 10;
            // 
            // sampleDescriptionTxt
            // 
            this.sampleDescriptionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDescriptionTxt.Location = new System.Drawing.Point(160, 18);
            this.sampleDescriptionTxt.Name = "sampleDescriptionTxt";
            this.sampleDescriptionTxt.Size = new System.Drawing.Size(540, 20);
            this.sampleDescriptionTxt.TabIndex = 9;
            // 
            // sampleDefaultFilePathCB
            // 
            this.sampleDefaultFilePathCB.AutoSize = true;
            this.sampleDefaultFilePathCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefaultFilePathCB.Location = new System.Drawing.Point(9, 105);
            this.sampleDefaultFilePathCB.Name = "sampleDefaultFilePathCB";
            this.sampleDefaultFilePathCB.Size = new System.Drawing.Size(145, 17);
            this.sampleDefaultFilePathCB.TabIndex = 8;
            this.sampleDefaultFilePathCB.Text = "Sample Default File Path:";
            this.sampleDefaultFilePathCB.UseVisualStyleBackColor = true;
            // 
            // jobTemplatePathCB
            // 
            this.jobTemplatePathCB.AutoSize = true;
            this.jobTemplatePathCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTemplatePathCB.Location = new System.Drawing.Point(9, 78);
            this.jobTemplatePathCB.Name = "jobTemplatePathCB";
            this.jobTemplatePathCB.Size = new System.Drawing.Size(118, 17);
            this.jobTemplatePathCB.TabIndex = 7;
            this.jobTemplatePathCB.Text = "Job Template Path:";
            this.jobTemplatePathCB.UseVisualStyleBackColor = true;
            // 
            // spectrumFilePatbCB
            // 
            this.spectrumFilePatbCB.AutoSize = true;
            this.spectrumFilePatbCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spectrumFilePatbCB.Location = new System.Drawing.Point(9, 50);
            this.spectrumFilePatbCB.Name = "spectrumFilePatbCB";
            this.spectrumFilePatbCB.Size = new System.Drawing.Size(118, 17);
            this.spectrumFilePatbCB.TabIndex = 6;
            this.spectrumFilePatbCB.Text = "Spectrum File Path:";
            this.spectrumFilePatbCB.UseVisualStyleBackColor = true;
            // 
            // sampleDescriptionCB
            // 
            this.sampleDescriptionCB.AutoSize = true;
            this.sampleDescriptionCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDescriptionCB.Location = new System.Drawing.Point(9, 22);
            this.sampleDescriptionCB.Name = "sampleDescriptionCB";
            this.sampleDescriptionCB.Size = new System.Drawing.Size(120, 17);
            this.sampleDescriptionCB.TabIndex = 5;
            this.sampleDescriptionCB.Text = "Sample Description:";
            this.sampleDescriptionCB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.saveSettingBtn);
            this.groupBox3.Controls.Add(this.libraryFilePathBtn);
            this.groupBox3.Controls.Add(this.calibrationFilePathBtn);
            this.groupBox3.Controls.Add(this.attenuationSizeTxt);
            this.groupBox3.Controls.Add(this.systematicErrorTxt);
            this.groupBox3.Controls.Add(this.randomErrorTxt);
            this.groupBox3.Controls.Add(this.unitsTxt);
            this.groupBox3.Controls.Add(this.randomSummingFactorTxt);
            this.groupBox3.Controls.Add(this.activityDivisorTxt);
            this.groupBox3.Controls.Add(this.activityMultiperTxt);
            this.groupBox3.Controls.Add(this.realTimePresetTxt);
            this.groupBox3.Controls.Add(this.liveTimePresetTxt);
            this.groupBox3.Controls.Add(this.activityUnitsTxt);
            this.groupBox3.Controls.Add(this.sampleQuantityTxt);
            this.groupBox3.Controls.Add(this.decayCorrectionDatePicker);
            this.groupBox3.Controls.Add(this.collectionStopDatePicker);
            this.groupBox3.Controls.Add(this.collectionStartDatePicker);
            this.groupBox3.Controls.Add(this.libraryFilePathTxt);
            this.groupBox3.Controls.Add(this.calibrationFilePathTxt);
            this.groupBox3.Controls.Add(this.attenuationSizeCB);
            this.groupBox3.Controls.Add(this.systematicErrorCB);
            this.groupBox3.Controls.Add(this.randomErrorCB);
            this.groupBox3.Controls.Add(this.unitsCB);
            this.groupBox3.Controls.Add(this.randomSummingFactorCB);
            this.groupBox3.Controls.Add(this.activityDivisorCB);
            this.groupBox3.Controls.Add(this.activityMultiperCB);
            this.groupBox3.Controls.Add(this.realTimePresetCB);
            this.groupBox3.Controls.Add(this.liveTimePresetCB);
            this.groupBox3.Controls.Add(this.activityUnitsCB);
            this.groupBox3.Controls.Add(this.sampleQuantityCB);
            this.groupBox3.Controls.Add(this.decayCorrectionDateCB);
            this.groupBox3.Controls.Add(this.decayCorrectionStopDateTimeCB);
            this.groupBox3.Controls.Add(this.collectionStopDateCB);
            this.groupBox3.Controls.Add(this.collectionStartDateCB);
            this.groupBox3.Controls.Add(this.libraryFilePathCB);
            this.groupBox3.Controls.Add(this.calibrationFilePathCB);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(763, 352);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sample Default File Modifications";
            // 
            // saveSettingBtn
            // 
            this.saveSettingBtn.Location = new System.Drawing.Point(617, 311);
            this.saveSettingBtn.Name = "saveSettingBtn";
            this.saveSettingBtn.Size = new System.Drawing.Size(140, 35);
            this.saveSettingBtn.TabIndex = 57;
            this.saveSettingBtn.Text = "Save Settings";
            this.saveSettingBtn.UseVisualStyleBackColor = true;
            this.saveSettingBtn.Click += new System.EventHandler(this.saveSettingBtn_Click);
            // 
            // libraryFilePathBtn
            // 
            this.libraryFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryFilePathBtn.Location = new System.Drawing.Point(681, 45);
            this.libraryFilePathBtn.Name = "libraryFilePathBtn";
            this.libraryFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.libraryFilePathBtn.TabIndex = 56;
            this.libraryFilePathBtn.Text = "...";
            this.libraryFilePathBtn.UseVisualStyleBackColor = true;
            this.libraryFilePathBtn.Click += new System.EventHandler(this.libraryFilePathBtn_Click);
            // 
            // calibrationFilePathBtn
            // 
            this.calibrationFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationFilePathBtn.Location = new System.Drawing.Point(681, 21);
            this.calibrationFilePathBtn.Name = "calibrationFilePathBtn";
            this.calibrationFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.calibrationFilePathBtn.TabIndex = 55;
            this.calibrationFilePathBtn.Text = "...";
            this.calibrationFilePathBtn.UseVisualStyleBackColor = true;
            this.calibrationFilePathBtn.Click += new System.EventHandler(this.calibrationFilePathBtn_Click);
            // 
            // attenuationSizeTxt
            // 
            this.attenuationSizeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attenuationSizeTxt.Location = new System.Drawing.Point(453, 246);
            this.attenuationSizeTxt.Name = "attenuationSizeTxt";
            this.attenuationSizeTxt.Size = new System.Drawing.Size(86, 20);
            this.attenuationSizeTxt.TabIndex = 54;
            // 
            // systematicErrorTxt
            // 
            this.systematicErrorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systematicErrorTxt.Location = new System.Drawing.Point(453, 220);
            this.systematicErrorTxt.Name = "systematicErrorTxt";
            this.systematicErrorTxt.Size = new System.Drawing.Size(86, 20);
            this.systematicErrorTxt.TabIndex = 53;
            // 
            // randomErrorTxt
            // 
            this.randomErrorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomErrorTxt.Location = new System.Drawing.Point(453, 194);
            this.randomErrorTxt.Name = "randomErrorTxt";
            this.randomErrorTxt.Size = new System.Drawing.Size(86, 20);
            this.randomErrorTxt.TabIndex = 52;
            // 
            // unitsTxt
            // 
            this.unitsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsTxt.Location = new System.Drawing.Point(453, 168);
            this.unitsTxt.Name = "unitsTxt";
            this.unitsTxt.Size = new System.Drawing.Size(86, 20);
            this.unitsTxt.TabIndex = 51;
            // 
            // randomSummingFactorTxt
            // 
            this.randomSummingFactorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomSummingFactorTxt.Location = new System.Drawing.Point(160, 327);
            this.randomSummingFactorTxt.Name = "randomSummingFactorTxt";
            this.randomSummingFactorTxt.Size = new System.Drawing.Size(86, 20);
            this.randomSummingFactorTxt.TabIndex = 50;
            // 
            // activityDivisorTxt
            // 
            this.activityDivisorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityDivisorTxt.Location = new System.Drawing.Point(160, 301);
            this.activityDivisorTxt.Name = "activityDivisorTxt";
            this.activityDivisorTxt.Size = new System.Drawing.Size(86, 20);
            this.activityDivisorTxt.TabIndex = 49;
            // 
            // activityMultiperTxt
            // 
            this.activityMultiperTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityMultiperTxt.Location = new System.Drawing.Point(160, 275);
            this.activityMultiperTxt.Name = "activityMultiperTxt";
            this.activityMultiperTxt.Size = new System.Drawing.Size(86, 20);
            this.activityMultiperTxt.TabIndex = 48;
            // 
            // realTimePresetTxt
            // 
            this.realTimePresetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimePresetTxt.Location = new System.Drawing.Point(160, 249);
            this.realTimePresetTxt.Name = "realTimePresetTxt";
            this.realTimePresetTxt.Size = new System.Drawing.Size(86, 20);
            this.realTimePresetTxt.TabIndex = 47;
            // 
            // liveTimePresetTxt
            // 
            this.liveTimePresetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveTimePresetTxt.Location = new System.Drawing.Point(160, 223);
            this.liveTimePresetTxt.Name = "liveTimePresetTxt";
            this.liveTimePresetTxt.Size = new System.Drawing.Size(86, 20);
            this.liveTimePresetTxt.TabIndex = 46;
            // 
            // activityUnitsTxt
            // 
            this.activityUnitsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityUnitsTxt.Location = new System.Drawing.Point(160, 197);
            this.activityUnitsTxt.Name = "activityUnitsTxt";
            this.activityUnitsTxt.Size = new System.Drawing.Size(86, 20);
            this.activityUnitsTxt.TabIndex = 45;
            // 
            // sampleQuantityTxt
            // 
            this.sampleQuantityTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleQuantityTxt.Location = new System.Drawing.Point(160, 171);
            this.sampleQuantityTxt.Name = "sampleQuantityTxt";
            this.sampleQuantityTxt.Size = new System.Drawing.Size(86, 20);
            this.sampleQuantityTxt.TabIndex = 44;
            // 
            // decayCorrectionDatePicker
            // 
            this.decayCorrectionDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decayCorrectionDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.decayCorrectionDatePicker.Location = new System.Drawing.Point(148, 145);
            this.decayCorrectionDatePicker.Name = "decayCorrectionDatePicker";
            this.decayCorrectionDatePicker.Size = new System.Drawing.Size(200, 20);
            this.decayCorrectionDatePicker.TabIndex = 43;
            // 
            // collectionStopDatePicker
            // 
            this.collectionStopDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionStopDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.collectionStopDatePicker.Location = new System.Drawing.Point(135, 99);
            this.collectionStopDatePicker.Name = "collectionStopDatePicker";
            this.collectionStopDatePicker.Size = new System.Drawing.Size(200, 20);
            this.collectionStopDatePicker.TabIndex = 42;
            // 
            // collectionStartDatePicker
            // 
            this.collectionStartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.collectionStartDatePicker.Location = new System.Drawing.Point(135, 73);
            this.collectionStartDatePicker.Name = "collectionStartDatePicker";
            this.collectionStartDatePicker.Size = new System.Drawing.Size(200, 20);
            this.collectionStartDatePicker.TabIndex = 41;
            // 
            // libraryFilePathTxt
            // 
            this.libraryFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryFilePathTxt.Location = new System.Drawing.Point(135, 47);
            this.libraryFilePathTxt.Name = "libraryFilePathTxt";
            this.libraryFilePathTxt.Size = new System.Drawing.Size(540, 20);
            this.libraryFilePathTxt.TabIndex = 40;
            // 
            // calibrationFilePathTxt
            // 
            this.calibrationFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationFilePathTxt.Location = new System.Drawing.Point(135, 21);
            this.calibrationFilePathTxt.Name = "calibrationFilePathTxt";
            this.calibrationFilePathTxt.Size = new System.Drawing.Size(540, 20);
            this.calibrationFilePathTxt.TabIndex = 39;
            // 
            // attenuationSizeCB
            // 
            this.attenuationSizeCB.AutoSize = true;
            this.attenuationSizeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attenuationSizeCB.Location = new System.Drawing.Point(305, 248);
            this.attenuationSizeCB.Name = "attenuationSizeCB";
            this.attenuationSizeCB.Size = new System.Drawing.Size(141, 17);
            this.attenuationSizeCB.TabIndex = 38;
            this.attenuationSizeCB.Text = "Attenuation Size/Length";
            this.attenuationSizeCB.UseVisualStyleBackColor = true;
            // 
            // systematicErrorCB
            // 
            this.systematicErrorCB.AutoSize = true;
            this.systematicErrorCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systematicErrorCB.Location = new System.Drawing.Point(305, 222);
            this.systematicErrorCB.Name = "systematicErrorCB";
            this.systematicErrorCB.Size = new System.Drawing.Size(105, 17);
            this.systematicErrorCB.TabIndex = 37;
            this.systematicErrorCB.Text = "Systematic Error:";
            this.systematicErrorCB.UseVisualStyleBackColor = true;
            // 
            // randomErrorCB
            // 
            this.randomErrorCB.AutoSize = true;
            this.randomErrorCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomErrorCB.Location = new System.Drawing.Point(305, 196);
            this.randomErrorCB.Name = "randomErrorCB";
            this.randomErrorCB.Size = new System.Drawing.Size(94, 17);
            this.randomErrorCB.TabIndex = 36;
            this.randomErrorCB.Text = "Random Error:";
            this.randomErrorCB.UseVisualStyleBackColor = true;
            // 
            // unitsCB
            // 
            this.unitsCB.AutoSize = true;
            this.unitsCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsCB.Location = new System.Drawing.Point(305, 170);
            this.unitsCB.Name = "unitsCB";
            this.unitsCB.Size = new System.Drawing.Size(53, 17);
            this.unitsCB.TabIndex = 35;
            this.unitsCB.Text = "Units:";
            this.unitsCB.UseVisualStyleBackColor = true;
            // 
            // randomSummingFactorCB
            // 
            this.randomSummingFactorCB.AutoSize = true;
            this.randomSummingFactorCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomSummingFactorCB.Location = new System.Drawing.Point(3, 329);
            this.randomSummingFactorCB.Name = "randomSummingFactorCB";
            this.randomSummingFactorCB.Size = new System.Drawing.Size(148, 17);
            this.randomSummingFactorCB.TabIndex = 33;
            this.randomSummingFactorCB.Text = "Random Summing Factor:";
            this.randomSummingFactorCB.UseVisualStyleBackColor = true;
            // 
            // activityDivisorCB
            // 
            this.activityDivisorCB.AutoSize = true;
            this.activityDivisorCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityDivisorCB.Location = new System.Drawing.Point(3, 303);
            this.activityDivisorCB.Name = "activityDivisorCB";
            this.activityDivisorCB.Size = new System.Drawing.Size(98, 17);
            this.activityDivisorCB.TabIndex = 32;
            this.activityDivisorCB.Text = "Activity Divisor:";
            this.activityDivisorCB.UseVisualStyleBackColor = true;
            // 
            // activityMultiperCB
            // 
            this.activityMultiperCB.AutoSize = true;
            this.activityMultiperCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityMultiperCB.Location = new System.Drawing.Point(5, 277);
            this.activityMultiperCB.Name = "activityMultiperCB";
            this.activityMultiperCB.Size = new System.Drawing.Size(103, 17);
            this.activityMultiperCB.TabIndex = 31;
            this.activityMultiperCB.Text = "Activity Multiper:";
            this.activityMultiperCB.UseVisualStyleBackColor = true;
            // 
            // realTimePresetCB
            // 
            this.realTimePresetCB.AutoSize = true;
            this.realTimePresetCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimePresetCB.Location = new System.Drawing.Point(5, 251);
            this.realTimePresetCB.Name = "realTimePresetCB";
            this.realTimePresetCB.Size = new System.Drawing.Size(110, 17);
            this.realTimePresetCB.TabIndex = 30;
            this.realTimePresetCB.Text = "Real Time Preset:";
            this.realTimePresetCB.UseVisualStyleBackColor = true;
            // 
            // liveTimePresetCB
            // 
            this.liveTimePresetCB.AutoSize = true;
            this.liveTimePresetCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveTimePresetCB.Location = new System.Drawing.Point(5, 225);
            this.liveTimePresetCB.Name = "liveTimePresetCB";
            this.liveTimePresetCB.Size = new System.Drawing.Size(108, 17);
            this.liveTimePresetCB.TabIndex = 29;
            this.liveTimePresetCB.Text = "Live Time Preset:";
            this.liveTimePresetCB.UseVisualStyleBackColor = true;
            // 
            // activityUnitsCB
            // 
            this.activityUnitsCB.AutoSize = true;
            this.activityUnitsCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityUnitsCB.Location = new System.Drawing.Point(5, 199);
            this.activityUnitsCB.Name = "activityUnitsCB";
            this.activityUnitsCB.Size = new System.Drawing.Size(90, 17);
            this.activityUnitsCB.TabIndex = 28;
            this.activityUnitsCB.Text = "Activity Units:";
            this.activityUnitsCB.UseVisualStyleBackColor = true;
            // 
            // sampleQuantityCB
            // 
            this.sampleQuantityCB.AutoSize = true;
            this.sampleQuantityCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleQuantityCB.Location = new System.Drawing.Point(5, 173);
            this.sampleQuantityCB.Name = "sampleQuantityCB";
            this.sampleQuantityCB.Size = new System.Drawing.Size(106, 17);
            this.sampleQuantityCB.TabIndex = 27;
            this.sampleQuantityCB.Text = "Sample Quantity:";
            this.sampleQuantityCB.UseVisualStyleBackColor = true;
            // 
            // decayCorrectionDateCB
            // 
            this.decayCorrectionDateCB.AutoSize = true;
            this.decayCorrectionDateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decayCorrectionDateCB.Location = new System.Drawing.Point(5, 148);
            this.decayCorrectionDateCB.Name = "decayCorrectionDateCB";
            this.decayCorrectionDateCB.Size = new System.Drawing.Size(137, 17);
            this.decayCorrectionDateCB.TabIndex = 26;
            this.decayCorrectionDateCB.Text = "Decay Correction Date:";
            this.decayCorrectionDateCB.UseVisualStyleBackColor = true;
            // 
            // decayCorrectionStopDateTimeCB
            // 
            this.decayCorrectionStopDateTimeCB.AutoSize = true;
            this.decayCorrectionStopDateTimeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decayCorrectionStopDateTimeCB.Location = new System.Drawing.Point(82, 125);
            this.decayCorrectionStopDateTimeCB.Name = "decayCorrectionStopDateTimeCB";
            this.decayCorrectionStopDateTimeCB.Size = new System.Drawing.Size(234, 17);
            this.decayCorrectionStopDateTimeCB.TabIndex = 25;
            this.decayCorrectionStopDateTimeCB.Text = "Decay Correct to Collection Stop Date/Time";
            this.decayCorrectionStopDateTimeCB.UseVisualStyleBackColor = true;
            // 
            // collectionStopDateCB
            // 
            this.collectionStopDateCB.AutoSize = true;
            this.collectionStopDateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionStopDateCB.Location = new System.Drawing.Point(6, 102);
            this.collectionStopDateCB.Name = "collectionStopDateCB";
            this.collectionStopDateCB.Size = new System.Drawing.Size(126, 17);
            this.collectionStopDateCB.TabIndex = 24;
            this.collectionStopDateCB.Text = "Collection Stop Date:";
            this.collectionStopDateCB.UseVisualStyleBackColor = true;
            // 
            // collectionStartDateCB
            // 
            this.collectionStartDateCB.AutoSize = true;
            this.collectionStartDateCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionStartDateCB.Location = new System.Drawing.Point(7, 76);
            this.collectionStartDateCB.Name = "collectionStartDateCB";
            this.collectionStartDateCB.Size = new System.Drawing.Size(126, 17);
            this.collectionStartDateCB.TabIndex = 23;
            this.collectionStartDateCB.Text = "Collection Start Date:";
            this.collectionStartDateCB.UseVisualStyleBackColor = true;
            // 
            // libraryFilePathCB
            // 
            this.libraryFilePathCB.AutoSize = true;
            this.libraryFilePathCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryFilePathCB.Location = new System.Drawing.Point(7, 49);
            this.libraryFilePathCB.Name = "libraryFilePathCB";
            this.libraryFilePathCB.Size = new System.Drawing.Size(104, 17);
            this.libraryFilePathCB.TabIndex = 22;
            this.libraryFilePathCB.Text = "Library File Path:";
            this.libraryFilePathCB.UseVisualStyleBackColor = true;
            // 
            // calibrationFilePathCB
            // 
            this.calibrationFilePathCB.AutoSize = true;
            this.calibrationFilePathCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationFilePathCB.Location = new System.Drawing.Point(7, 23);
            this.calibrationFilePathCB.Name = "calibrationFilePathCB";
            this.calibrationFilePathCB.Size = new System.Drawing.Size(122, 17);
            this.calibrationFilePathCB.TabIndex = 21;
            this.calibrationFilePathCB.Text = "Calibration File Path:";
            this.calibrationFilePathCB.UseVisualStyleBackColor = true;
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox sampleDescriptionCB;
        private System.Windows.Forms.TextBox sampleDefaultFilePathTxt;
        private System.Windows.Forms.TextBox jobTemplatePathTxt;
        private System.Windows.Forms.TextBox spectrumFilePathTxt;
        private System.Windows.Forms.TextBox sampleDescriptionTxt;
        private System.Windows.Forms.CheckBox sampleDefaultFilePathCB;
        private System.Windows.Forms.CheckBox jobTemplatePathCB;
        private System.Windows.Forms.CheckBox spectrumFilePatbCB;
        private System.Windows.Forms.CheckBox attenuationSizeCB;
        private System.Windows.Forms.CheckBox systematicErrorCB;
        private System.Windows.Forms.CheckBox randomErrorCB;
        private System.Windows.Forms.CheckBox unitsCB;
        private System.Windows.Forms.CheckBox randomSummingFactorCB;
        private System.Windows.Forms.CheckBox activityDivisorCB;
        private System.Windows.Forms.CheckBox activityMultiperCB;
        private System.Windows.Forms.CheckBox realTimePresetCB;
        private System.Windows.Forms.CheckBox liveTimePresetCB;
        private System.Windows.Forms.CheckBox activityUnitsCB;
        private System.Windows.Forms.CheckBox sampleQuantityCB;
        private System.Windows.Forms.CheckBox decayCorrectionDateCB;
        private System.Windows.Forms.CheckBox decayCorrectionStopDateTimeCB;
        private System.Windows.Forms.CheckBox collectionStopDateCB;
        private System.Windows.Forms.CheckBox collectionStartDateCB;
        private System.Windows.Forms.CheckBox libraryFilePathCB;
        private System.Windows.Forms.CheckBox calibrationFilePathCB;
        private System.Windows.Forms.Button saveAnalysisSettingTemplateBtn;
        private System.Windows.Forms.Button loadAnalysisSettingTemplateBtn;
        private System.Windows.Forms.TextBox attenuationSizeTxt;
        private System.Windows.Forms.TextBox systematicErrorTxt;
        private System.Windows.Forms.TextBox randomErrorTxt;
        private System.Windows.Forms.TextBox unitsTxt;
        private System.Windows.Forms.TextBox randomSummingFactorTxt;
        private System.Windows.Forms.TextBox activityDivisorTxt;
        private System.Windows.Forms.TextBox activityMultiperTxt;
        private System.Windows.Forms.TextBox realTimePresetTxt;
        private System.Windows.Forms.TextBox liveTimePresetTxt;
        private System.Windows.Forms.TextBox activityUnitsTxt;
        private System.Windows.Forms.TextBox sampleQuantityTxt;
        private System.Windows.Forms.DateTimePicker decayCorrectionDatePicker;
        private System.Windows.Forms.DateTimePicker collectionStopDatePicker;
        private System.Windows.Forms.DateTimePicker collectionStartDatePicker;
        private System.Windows.Forms.TextBox libraryFilePathTxt;
        private System.Windows.Forms.TextBox calibrationFilePathTxt;
        private System.Windows.Forms.Button sampleDefaultFilePathBtn;
        private System.Windows.Forms.Button jobTemplatePathBtn;
        private System.Windows.Forms.Button spectrumFilePathBtn;
        private System.Windows.Forms.Button libraryFilePathBtn;
        private System.Windows.Forms.Button calibrationFilePathBtn;
        private System.Windows.Forms.Button saveSettingBtn;
    }
}

