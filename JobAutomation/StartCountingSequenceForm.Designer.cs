namespace JobAutomation
{
    partial class StartCountingSequenceForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.csListComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maxNumberTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.analysisListBox = new System.Windows.Forms.ListBox();
            this.analysisSettingsPanel = new System.Windows.Forms.GroupBox();
            this.sampleDefaultFilePathTxt = new System.Windows.Forms.TextBox();
            this.jobTemplatePathTxt = new System.Windows.Forms.TextBox();
            this.spectrumFilePathTxt = new System.Windows.Forms.TextBox();
            this.sampleDescriptionTxt = new System.Windows.Forms.TextBox();
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
            this.decayCorrectionStopDateTimeCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.sampleDefaultFilePathBtn = new System.Windows.Forms.Button();
            this.jobTemplatePathBtn = new System.Windows.Forms.Button();
            this.spectrumFilePathBtn = new System.Windows.Forms.Button();
            this.libraryFilePathBtn = new System.Windows.Forms.Button();
            this.calibrationFilePathBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.analysisSettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxNumberTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.csListComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Counting Sequence";
            // 
            // csListComboBox
            // 
            this.csListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.csListComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csListComboBox.FormattingEnabled = true;
            this.csListComboBox.Location = new System.Drawing.Point(6, 21);
            this.csListComboBox.Name = "csListComboBox";
            this.csListComboBox.Size = new System.Drawing.Size(237, 21);
            this.csListComboBox.TabIndex = 0;
            this.csListComboBox.SelectedIndexChanged += new System.EventHandler(this.csListComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(355, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max.";
            // 
            // maxNumberTxt
            // 
            this.maxNumberTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxNumberTxt.Location = new System.Drawing.Point(295, 19);
            this.maxNumberTxt.Name = "maxNumberTxt";
            this.maxNumberTxt.Size = new System.Drawing.Size(54, 20);
            this.maxNumberTxt.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.analysisListBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 464);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sequence Analysis List";
            // 
            // analysisListBox
            // 
            this.analysisListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisListBox.FormattingEnabled = true;
            this.analysisListBox.Location = new System.Drawing.Point(6, 19);
            this.analysisListBox.Name = "analysisListBox";
            this.analysisListBox.Size = new System.Drawing.Size(231, 433);
            this.analysisListBox.TabIndex = 0;
            this.analysisListBox.SelectedIndexChanged += new System.EventHandler(this.analysisListBox_SelectedIndexChanged);
            // 
            // analysisSettingsPanel
            // 
            this.analysisSettingsPanel.Controls.Add(this.sampleDefaultFilePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.jobTemplatePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.spectrumFilePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.libraryFilePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.calibrationFilePathBtn);
            this.analysisSettingsPanel.Controls.Add(this.label21);
            this.analysisSettingsPanel.Controls.Add(this.label20);
            this.analysisSettingsPanel.Controls.Add(this.label19);
            this.analysisSettingsPanel.Controls.Add(this.attenuationSizeTxt);
            this.analysisSettingsPanel.Controls.Add(this.label18);
            this.analysisSettingsPanel.Controls.Add(this.systematicErrorTxt);
            this.analysisSettingsPanel.Controls.Add(this.label17);
            this.analysisSettingsPanel.Controls.Add(this.randomErrorTxt);
            this.analysisSettingsPanel.Controls.Add(this.label16);
            this.analysisSettingsPanel.Controls.Add(this.label15);
            this.analysisSettingsPanel.Controls.Add(this.label14);
            this.analysisSettingsPanel.Controls.Add(this.label13);
            this.analysisSettingsPanel.Controls.Add(this.label12);
            this.analysisSettingsPanel.Controls.Add(this.label11);
            this.analysisSettingsPanel.Controls.Add(this.randomSummingFactorTxt);
            this.analysisSettingsPanel.Controls.Add(this.label10);
            this.analysisSettingsPanel.Controls.Add(this.activityDivisorTxt);
            this.analysisSettingsPanel.Controls.Add(this.unitsTxt);
            this.analysisSettingsPanel.Controls.Add(this.activityMultiperTxt);
            this.analysisSettingsPanel.Controls.Add(this.label9);
            this.analysisSettingsPanel.Controls.Add(this.realTimePresetTxt);
            this.analysisSettingsPanel.Controls.Add(this.label8);
            this.analysisSettingsPanel.Controls.Add(this.liveTimePresetTxt);
            this.analysisSettingsPanel.Controls.Add(this.label7);
            this.analysisSettingsPanel.Controls.Add(this.activityUnitsTxt);
            this.analysisSettingsPanel.Controls.Add(this.label6);
            this.analysisSettingsPanel.Controls.Add(this.label5);
            this.analysisSettingsPanel.Controls.Add(this.label4);
            this.analysisSettingsPanel.Controls.Add(this.label3);
            this.analysisSettingsPanel.Controls.Add(this.label2);
            this.analysisSettingsPanel.Controls.Add(this.sampleDefaultFilePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.sampleQuantityTxt);
            this.analysisSettingsPanel.Controls.Add(this.jobTemplatePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.decayCorrectionDatePicker);
            this.analysisSettingsPanel.Controls.Add(this.spectrumFilePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.sampleDescriptionTxt);
            this.analysisSettingsPanel.Controls.Add(this.collectionStopDatePicker);
            this.analysisSettingsPanel.Controls.Add(this.calibrationFilePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.collectionStartDatePicker);
            this.analysisSettingsPanel.Controls.Add(this.libraryFilePathTxt);
            this.analysisSettingsPanel.Controls.Add(this.decayCorrectionStopDateTimeCB);
            this.analysisSettingsPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analysisSettingsPanel.Location = new System.Drawing.Point(264, 76);
            this.analysisSettingsPanel.Name = "analysisSettingsPanel";
            this.analysisSettingsPanel.Size = new System.Drawing.Size(635, 464);
            this.analysisSettingsPanel.TabIndex = 14;
            this.analysisSettingsPanel.TabStop = false;
            this.analysisSettingsPanel.Text = "Analysis Settings";
            // 
            // sampleDefaultFilePathTxt
            // 
            this.sampleDefaultFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefaultFilePathTxt.Location = new System.Drawing.Point(138, 102);
            this.sampleDefaultFilePathTxt.Name = "sampleDefaultFilePathTxt";
            this.sampleDefaultFilePathTxt.Size = new System.Drawing.Size(441, 20);
            this.sampleDefaultFilePathTxt.TabIndex = 12;
            // 
            // jobTemplatePathTxt
            // 
            this.jobTemplatePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTemplatePathTxt.Location = new System.Drawing.Point(138, 74);
            this.jobTemplatePathTxt.Name = "jobTemplatePathTxt";
            this.jobTemplatePathTxt.Size = new System.Drawing.Size(441, 20);
            this.jobTemplatePathTxt.TabIndex = 11;
            // 
            // spectrumFilePathTxt
            // 
            this.spectrumFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spectrumFilePathTxt.Location = new System.Drawing.Point(138, 46);
            this.spectrumFilePathTxt.Name = "spectrumFilePathTxt";
            this.spectrumFilePathTxt.Size = new System.Drawing.Size(441, 20);
            this.spectrumFilePathTxt.TabIndex = 10;
            // 
            // sampleDescriptionTxt
            // 
            this.sampleDescriptionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDescriptionTxt.Location = new System.Drawing.Point(138, 18);
            this.sampleDescriptionTxt.Name = "sampleDescriptionTxt";
            this.sampleDescriptionTxt.Size = new System.Drawing.Size(441, 20);
            this.sampleDescriptionTxt.TabIndex = 9;
            // 
            // attenuationSizeTxt
            // 
            this.attenuationSizeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attenuationSizeTxt.Location = new System.Drawing.Point(372, 359);
            this.attenuationSizeTxt.Name = "attenuationSizeTxt";
            this.attenuationSizeTxt.Size = new System.Drawing.Size(86, 20);
            this.attenuationSizeTxt.TabIndex = 54;
            // 
            // systematicErrorTxt
            // 
            this.systematicErrorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systematicErrorTxt.Location = new System.Drawing.Point(372, 333);
            this.systematicErrorTxt.Name = "systematicErrorTxt";
            this.systematicErrorTxt.Size = new System.Drawing.Size(86, 20);
            this.systematicErrorTxt.TabIndex = 53;
            // 
            // randomErrorTxt
            // 
            this.randomErrorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomErrorTxt.Location = new System.Drawing.Point(372, 307);
            this.randomErrorTxt.Name = "randomErrorTxt";
            this.randomErrorTxt.Size = new System.Drawing.Size(86, 20);
            this.randomErrorTxt.TabIndex = 52;
            // 
            // unitsTxt
            // 
            this.unitsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsTxt.Location = new System.Drawing.Point(372, 281);
            this.unitsTxt.Name = "unitsTxt";
            this.unitsTxt.Size = new System.Drawing.Size(86, 20);
            this.unitsTxt.TabIndex = 51;
            // 
            // randomSummingFactorTxt
            // 
            this.randomSummingFactorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomSummingFactorTxt.Location = new System.Drawing.Point(138, 437);
            this.randomSummingFactorTxt.Name = "randomSummingFactorTxt";
            this.randomSummingFactorTxt.Size = new System.Drawing.Size(86, 20);
            this.randomSummingFactorTxt.TabIndex = 50;
            // 
            // activityDivisorTxt
            // 
            this.activityDivisorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityDivisorTxt.Location = new System.Drawing.Point(138, 411);
            this.activityDivisorTxt.Name = "activityDivisorTxt";
            this.activityDivisorTxt.Size = new System.Drawing.Size(86, 20);
            this.activityDivisorTxt.TabIndex = 49;
            // 
            // activityMultiperTxt
            // 
            this.activityMultiperTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityMultiperTxt.Location = new System.Drawing.Point(138, 385);
            this.activityMultiperTxt.Name = "activityMultiperTxt";
            this.activityMultiperTxt.Size = new System.Drawing.Size(86, 20);
            this.activityMultiperTxt.TabIndex = 48;
            // 
            // realTimePresetTxt
            // 
            this.realTimePresetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimePresetTxt.Location = new System.Drawing.Point(138, 359);
            this.realTimePresetTxt.Name = "realTimePresetTxt";
            this.realTimePresetTxt.Size = new System.Drawing.Size(86, 20);
            this.realTimePresetTxt.TabIndex = 47;
            // 
            // liveTimePresetTxt
            // 
            this.liveTimePresetTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveTimePresetTxt.Location = new System.Drawing.Point(138, 333);
            this.liveTimePresetTxt.Name = "liveTimePresetTxt";
            this.liveTimePresetTxt.Size = new System.Drawing.Size(86, 20);
            this.liveTimePresetTxt.TabIndex = 46;
            // 
            // activityUnitsTxt
            // 
            this.activityUnitsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityUnitsTxt.Location = new System.Drawing.Point(138, 307);
            this.activityUnitsTxt.Name = "activityUnitsTxt";
            this.activityUnitsTxt.Size = new System.Drawing.Size(86, 20);
            this.activityUnitsTxt.TabIndex = 45;
            // 
            // sampleQuantityTxt
            // 
            this.sampleQuantityTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleQuantityTxt.Location = new System.Drawing.Point(138, 281);
            this.sampleQuantityTxt.Name = "sampleQuantityTxt";
            this.sampleQuantityTxt.Size = new System.Drawing.Size(86, 20);
            this.sampleQuantityTxt.TabIndex = 44;
            // 
            // decayCorrectionDatePicker
            // 
            this.decayCorrectionDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decayCorrectionDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.decayCorrectionDatePicker.Location = new System.Drawing.Point(138, 255);
            this.decayCorrectionDatePicker.Name = "decayCorrectionDatePicker";
            this.decayCorrectionDatePicker.Size = new System.Drawing.Size(200, 20);
            this.decayCorrectionDatePicker.TabIndex = 43;
            // 
            // collectionStopDatePicker
            // 
            this.collectionStopDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionStopDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.collectionStopDatePicker.Location = new System.Drawing.Point(138, 206);
            this.collectionStopDatePicker.Name = "collectionStopDatePicker";
            this.collectionStopDatePicker.Size = new System.Drawing.Size(200, 20);
            this.collectionStopDatePicker.TabIndex = 42;
            // 
            // collectionStartDatePicker
            // 
            this.collectionStartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.collectionStartDatePicker.Location = new System.Drawing.Point(138, 180);
            this.collectionStartDatePicker.Name = "collectionStartDatePicker";
            this.collectionStartDatePicker.Size = new System.Drawing.Size(200, 20);
            this.collectionStartDatePicker.TabIndex = 41;
            // 
            // libraryFilePathTxt
            // 
            this.libraryFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryFilePathTxt.Location = new System.Drawing.Point(138, 154);
            this.libraryFilePathTxt.Name = "libraryFilePathTxt";
            this.libraryFilePathTxt.Size = new System.Drawing.Size(441, 20);
            this.libraryFilePathTxt.TabIndex = 40;
            // 
            // calibrationFilePathTxt
            // 
            this.calibrationFilePathTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationFilePathTxt.Location = new System.Drawing.Point(138, 128);
            this.calibrationFilePathTxt.Name = "calibrationFilePathTxt";
            this.calibrationFilePathTxt.Size = new System.Drawing.Size(441, 20);
            this.calibrationFilePathTxt.TabIndex = 39;
            // 
            // decayCorrectionStopDateTimeCB
            // 
            this.decayCorrectionStopDateTimeCB.AutoSize = true;
            this.decayCorrectionStopDateTimeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decayCorrectionStopDateTimeCB.Location = new System.Drawing.Point(138, 232);
            this.decayCorrectionStopDateTimeCB.Name = "decayCorrectionStopDateTimeCB";
            this.decayCorrectionStopDateTimeCB.Size = new System.Drawing.Size(234, 17);
            this.decayCorrectionStopDateTimeCB.TabIndex = 25;
            this.decayCorrectionStopDateTimeCB.Text = "Decay Correct to Collection Stop Date/Time";
            this.decayCorrectionStopDateTimeCB.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sample Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Spectrum File Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Job Template Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Sample Default File Path:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Calibration File Path:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Library File Path:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Collection Start Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Collection Stop Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 258);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Decay Correction Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Sample Quantity:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(244, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Units:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 310);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "Activity Units:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Live Time Preset:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 362);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "Real Time Preset:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 388);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 55;
            this.label16.Text = "Activity Multiper:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 414);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 56;
            this.label17.Text = "Activity Divisor:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 440);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "Random Summing Factor:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(244, 310);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 58;
            this.label19.Text = "Random Error:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(244, 336);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 13);
            this.label20.TabIndex = 59;
            this.label20.Text = "Systematic Error:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(244, 362);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(122, 13);
            this.label21.TabIndex = 60;
            this.label21.Text = "Attenuation Size/Length";
            // 
            // sampleDefaultFilePathBtn
            // 
            this.sampleDefaultFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sampleDefaultFilePathBtn.Location = new System.Drawing.Point(585, 100);
            this.sampleDefaultFilePathBtn.Name = "sampleDefaultFilePathBtn";
            this.sampleDefaultFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.sampleDefaultFilePathBtn.TabIndex = 63;
            this.sampleDefaultFilePathBtn.Text = "...";
            this.sampleDefaultFilePathBtn.UseVisualStyleBackColor = true;
            // 
            // jobTemplatePathBtn
            // 
            this.jobTemplatePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobTemplatePathBtn.Location = new System.Drawing.Point(585, 72);
            this.jobTemplatePathBtn.Name = "jobTemplatePathBtn";
            this.jobTemplatePathBtn.Size = new System.Drawing.Size(40, 22);
            this.jobTemplatePathBtn.TabIndex = 62;
            this.jobTemplatePathBtn.Text = "...";
            this.jobTemplatePathBtn.UseVisualStyleBackColor = true;
            // 
            // spectrumFilePathBtn
            // 
            this.spectrumFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spectrumFilePathBtn.Location = new System.Drawing.Point(585, 46);
            this.spectrumFilePathBtn.Name = "spectrumFilePathBtn";
            this.spectrumFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.spectrumFilePathBtn.TabIndex = 61;
            this.spectrumFilePathBtn.Text = "...";
            this.spectrumFilePathBtn.UseVisualStyleBackColor = true;
            // 
            // libraryFilePathBtn
            // 
            this.libraryFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryFilePathBtn.Location = new System.Drawing.Point(585, 152);
            this.libraryFilePathBtn.Name = "libraryFilePathBtn";
            this.libraryFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.libraryFilePathBtn.TabIndex = 65;
            this.libraryFilePathBtn.Text = "...";
            this.libraryFilePathBtn.UseVisualStyleBackColor = true;
            // 
            // calibrationFilePathBtn
            // 
            this.calibrationFilePathBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrationFilePathBtn.Location = new System.Drawing.Point(585, 126);
            this.calibrationFilePathBtn.Name = "calibrationFilePathBtn";
            this.calibrationFilePathBtn.Size = new System.Drawing.Size(40, 22);
            this.calibrationFilePathBtn.TabIndex = 64;
            this.calibrationFilePathBtn.Text = "...";
            this.calibrationFilePathBtn.UseVisualStyleBackColor = true;
            // 
            // StartCountingSequenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 545);
            this.Controls.Add(this.analysisSettingsPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StartCountingSequenceForm";
            this.Text = "StartCountingSequenceForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.analysisSettingsPanel.ResumeLayout(false);
            this.analysisSettingsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox maxNumberTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox csListComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox analysisListBox;
        private System.Windows.Forms.GroupBox analysisSettingsPanel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox randomSummingFactorTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox activityDivisorTxt;
        private System.Windows.Forms.TextBox unitsTxt;
        private System.Windows.Forms.TextBox activityMultiperTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox realTimePresetTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox liveTimePresetTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox activityUnitsTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sampleDefaultFilePathTxt;
        private System.Windows.Forms.TextBox sampleQuantityTxt;
        private System.Windows.Forms.TextBox jobTemplatePathTxt;
        private System.Windows.Forms.DateTimePicker decayCorrectionDatePicker;
        private System.Windows.Forms.TextBox spectrumFilePathTxt;
        private System.Windows.Forms.TextBox sampleDescriptionTxt;
        private System.Windows.Forms.TextBox attenuationSizeTxt;
        private System.Windows.Forms.TextBox systematicErrorTxt;
        private System.Windows.Forms.TextBox randomErrorTxt;
        private System.Windows.Forms.DateTimePicker collectionStopDatePicker;
        private System.Windows.Forms.TextBox calibrationFilePathTxt;
        private System.Windows.Forms.DateTimePicker collectionStartDatePicker;
        private System.Windows.Forms.TextBox libraryFilePathTxt;
        private System.Windows.Forms.CheckBox decayCorrectionStopDateTimeCB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button sampleDefaultFilePathBtn;
        private System.Windows.Forms.Button jobTemplatePathBtn;
        private System.Windows.Forms.Button spectrumFilePathBtn;
        private System.Windows.Forms.Button libraryFilePathBtn;
        private System.Windows.Forms.Button calibrationFilePathBtn;

    }
}