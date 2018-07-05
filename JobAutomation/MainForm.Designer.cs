namespace JobAutomation
{
    partial class MainForm
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
            this.scsBtn = new System.Windows.Forms.Button();
            this.cssBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.profileCB = new System.Windows.Forms.ComboBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.currentSampleNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scsBtn
            // 
            this.scsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scsBtn.Location = new System.Drawing.Point(176, 159);
            this.scsBtn.Name = "scsBtn";
            this.scsBtn.Size = new System.Drawing.Size(138, 57);
            this.scsBtn.TabIndex = 0;
            this.scsBtn.Text = "Run";
            this.scsBtn.UseVisualStyleBackColor = true;
            this.scsBtn.Click += new System.EventHandler(this.scsBtn_Click);
            // 
            // cssBtn
            // 
            this.cssBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cssBtn.Location = new System.Drawing.Point(12, 159);
            this.cssBtn.Name = "cssBtn";
            this.cssBtn.Size = new System.Drawing.Size(138, 57);
            this.cssBtn.TabIndex = 1;
            this.cssBtn.Text = "Setup";
            this.cssBtn.UseVisualStyleBackColor = true;
            this.cssBtn.Click += new System.EventHandler(this.cssBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Automatic Sample Charger Control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sample";
            // 
            // quitBtn
            // 
            this.quitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.Location = new System.Drawing.Point(343, 159);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(138, 57);
            this.quitBtn.TabIndex = 12;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sequence";
            // 
            // profileCB
            // 
            this.profileCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileCB.FormattingEnabled = true;
            this.profileCB.Location = new System.Drawing.Point(108, 61);
            this.profileCB.Name = "profileCB";
            this.profileCB.Size = new System.Drawing.Size(373, 21);
            this.profileCB.TabIndex = 14;
            this.profileCB.SelectedIndexChanged += new System.EventHandler(this.profileCB_SelectedIndexChanged);
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(451, 18);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(0, 13);
            this.versionLabel.TabIndex = 19;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(105, 121);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(49, 16);
            this.statusLabel.TabIndex = 20;
            this.statusLabel.Text = "Ready";
            // 
            // currentSampleNo
            // 
            this.currentSampleNo.AutoSize = true;
            this.currentSampleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSampleNo.Location = new System.Drawing.Point(105, 94);
            this.currentSampleNo.Name = "currentSampleNo";
            this.currentSampleNo.Size = new System.Drawing.Size(15, 16);
            this.currentSampleNo.TabIndex = 21;
            this.currentSampleNo.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 224);
            this.Controls.Add(this.currentSampleNo);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.profileCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cssBtn);
            this.Controls.Add(this.scsBtn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Automatic Sample Charger Control";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button scsBtn;
        private System.Windows.Forms.Button cssBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox profileCB;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label currentSampleNo;
    }
}