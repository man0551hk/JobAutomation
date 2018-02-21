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
            this.createJobBtn = new System.Windows.Forms.Button();
            this.editJobBtn = new System.Windows.Forms.Button();
            this.createMasterPanel = new System.Windows.Forms.Panel();
            this.openLoopFileBtn = new System.Windows.Forms.Button();
            this.loopJobFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sampleNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newJobFileName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editTemplateBtn = new System.Windows.Forms.Button();
            this.createTemplateBtn = new System.Windows.Forms.Button();
            this.openLoopJobFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.editMasterFilePanel = new System.Windows.Forms.Panel();
            this.createTemplatePanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.createMasterPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.editMasterFilePanel.SuspendLayout();
            this.createTemplatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // createJobBtn
            // 
            this.createJobBtn.Location = new System.Drawing.Point(3, 7);
            this.createJobBtn.Name = "createJobBtn";
            this.createJobBtn.Size = new System.Drawing.Size(95, 23);
            this.createJobBtn.TabIndex = 0;
            this.createJobBtn.Text = "Create Master File";
            this.createJobBtn.UseVisualStyleBackColor = true;
            // 
            // editJobBtn
            // 
            this.editJobBtn.Location = new System.Drawing.Point(3, 35);
            this.editJobBtn.Name = "editJobBtn";
            this.editJobBtn.Size = new System.Drawing.Size(95, 23);
            this.editJobBtn.TabIndex = 1;
            this.editJobBtn.Text = "Edit Master File";
            this.editJobBtn.UseVisualStyleBackColor = true;
            // 
            // createMasterPanel
            // 
            this.createMasterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.createMasterPanel.Controls.Add(this.editMasterFilePanel);
            this.createMasterPanel.Controls.Add(this.openLoopFileBtn);
            this.createMasterPanel.Controls.Add(this.loopJobFilePath);
            this.createMasterPanel.Controls.Add(this.label3);
            this.createMasterPanel.Controls.Add(this.sampleNo);
            this.createMasterPanel.Controls.Add(this.label2);
            this.createMasterPanel.Controls.Add(this.label1);
            this.createMasterPanel.Controls.Add(this.newJobFileName);
            this.createMasterPanel.Location = new System.Drawing.Point(128, 12);
            this.createMasterPanel.Name = "createMasterPanel";
            this.createMasterPanel.Size = new System.Drawing.Size(561, 426);
            this.createMasterPanel.TabIndex = 2;
            this.createMasterPanel.Visible = false;
            // 
            // openLoopFileBtn
            // 
            this.openLoopFileBtn.Location = new System.Drawing.Point(516, 63);
            this.openLoopFileBtn.Name = "openLoopFileBtn";
            this.openLoopFileBtn.Size = new System.Drawing.Size(33, 23);
            this.openLoopFileBtn.TabIndex = 6;
            this.openLoopFileBtn.Text = "...";
            this.openLoopFileBtn.UseVisualStyleBackColor = true;
            this.openLoopFileBtn.Click += new System.EventHandler(this.openLoopFileBtn_Click);
            // 
            // loopJobFilePath
            // 
            this.loopJobFilePath.Location = new System.Drawing.Point(123, 65);
            this.loopJobFilePath.Name = "loopJobFilePath";
            this.loopJobFilePath.Size = new System.Drawing.Size(387, 20);
            this.loopJobFilePath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loop Job Files";
            // 
            // sampleNo
            // 
            this.sampleNo.FormattingEnabled = true;
            this.sampleNo.Items.AddRange(new object[] {
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
            this.sampleNo.Location = new System.Drawing.Point(123, 37);
            this.sampleNo.Name = "sampleNo";
            this.sampleNo.Size = new System.Drawing.Size(102, 21);
            this.sampleNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max. no. of sample";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Job File Name";
            // 
            // newJobFileName
            // 
            this.newJobFileName.Location = new System.Drawing.Point(123, 10);
            this.newJobFileName.Name = "newJobFileName";
            this.newJobFileName.Size = new System.Drawing.Size(426, 20);
            this.newJobFileName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editTemplateBtn);
            this.panel1.Controls.Add(this.createTemplateBtn);
            this.panel1.Controls.Add(this.createJobBtn);
            this.panel1.Controls.Add(this.editJobBtn);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 426);
            this.panel1.TabIndex = 3;
            // 
            // editTemplateBtn
            // 
            this.editTemplateBtn.Location = new System.Drawing.Point(4, 95);
            this.editTemplateBtn.Name = "editTemplateBtn";
            this.editTemplateBtn.Size = new System.Drawing.Size(94, 23);
            this.editTemplateBtn.TabIndex = 3;
            this.editTemplateBtn.Text = "Edit Template";
            this.editTemplateBtn.UseVisualStyleBackColor = true;
            // 
            // createTemplateBtn
            // 
            this.createTemplateBtn.Location = new System.Drawing.Point(4, 65);
            this.createTemplateBtn.Name = "createTemplateBtn";
            this.createTemplateBtn.Size = new System.Drawing.Size(94, 23);
            this.createTemplateBtn.TabIndex = 2;
            this.createTemplateBtn.Text = "Create Template";
            this.createTemplateBtn.UseVisualStyleBackColor = true;
            // 
            // openLoopJobFileDialog
            // 
            this.openLoopJobFileDialog.FileName = "openFileDialog1";
            // 
            // editMasterFilePanel
            // 
            this.editMasterFilePanel.Controls.Add(this.createTemplatePanel);
            this.editMasterFilePanel.Location = new System.Drawing.Point(-1, -1);
            this.editMasterFilePanel.Name = "editMasterFilePanel";
            this.editMasterFilePanel.Size = new System.Drawing.Size(561, 426);
            this.editMasterFilePanel.TabIndex = 7;
            this.editMasterFilePanel.Visible = false;
            // 
            // createTemplatePanel
            // 
            this.createTemplatePanel.Controls.Add(this.textBox1);
            this.createTemplatePanel.Location = new System.Drawing.Point(0, 0);
            this.createTemplatePanel.Name = "createTemplatePanel";
            this.createTemplatePanel.Size = new System.Drawing.Size(561, 426);
            this.createTemplatePanel.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(545, 376);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.createMasterPanel);
            this.Name = "Form1";
            this.Text = "Job Automation";
            this.createMasterPanel.ResumeLayout(false);
            this.createMasterPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.editMasterFilePanel.ResumeLayout(false);
            this.createTemplatePanel.ResumeLayout(false);
            this.createTemplatePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createJobBtn;
        private System.Windows.Forms.Button editJobBtn;
        private System.Windows.Forms.Panel createMasterPanel;
        private System.Windows.Forms.ComboBox sampleNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newJobFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openLoopFileBtn;
        private System.Windows.Forms.TextBox loopJobFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openLoopJobFileDialog;
        private System.Windows.Forms.Button createTemplateBtn;
        private System.Windows.Forms.Button editTemplateBtn;
        private System.Windows.Forms.Panel editMasterFilePanel;
        private System.Windows.Forms.Panel createTemplatePanel;
        private System.Windows.Forms.TextBox textBox1;
    }
}

