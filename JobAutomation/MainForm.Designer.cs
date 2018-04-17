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
            this.psBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scsBtn
            // 
            this.scsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scsBtn.Location = new System.Drawing.Point(12, 12);
            this.scsBtn.Name = "scsBtn";
            this.scsBtn.Size = new System.Drawing.Size(208, 86);
            this.scsBtn.TabIndex = 0;
            this.scsBtn.Text = "Start Counting Sequence";
            this.scsBtn.UseVisualStyleBackColor = true;
            this.scsBtn.Click += new System.EventHandler(this.scsBtn_Click);
            // 
            // cssBtn
            // 
            this.cssBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cssBtn.Location = new System.Drawing.Point(12, 104);
            this.cssBtn.Name = "cssBtn";
            this.cssBtn.Size = new System.Drawing.Size(208, 86);
            this.cssBtn.TabIndex = 1;
            this.cssBtn.Text = " Setup Counting Sequence";
            this.cssBtn.UseVisualStyleBackColor = true;
            this.cssBtn.Click += new System.EventHandler(this.cssBtn_Click);
            // 
            // psBtn
            // 
            this.psBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.psBtn.Location = new System.Drawing.Point(12, 196);
            this.psBtn.Name = "psBtn";
            this.psBtn.Size = new System.Drawing.Size(208, 86);
            this.psBtn.TabIndex = 2;
            this.psBtn.Text = "Parameter Setup";
            this.psBtn.UseVisualStyleBackColor = true;
            this.psBtn.Click += new System.EventHandler(this.psBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 292);
            this.Controls.Add(this.psBtn);
            this.Controls.Add(this.cssBtn);
            this.Controls.Add(this.scsBtn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Job Automation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scsBtn;
        private System.Windows.Forms.Button cssBtn;
        private System.Windows.Forms.Button psBtn;
    }
}