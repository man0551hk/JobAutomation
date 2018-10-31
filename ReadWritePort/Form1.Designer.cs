namespace ReadWritePort
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
            this.portAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.value = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.TextBox();
            this.readBtn = new System.Windows.Forms.Button();
            this.Write = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // portAddress
            // 
            this.portAddress.Location = new System.Drawing.Point(12, 25);
            this.portAddress.Name = "portAddress";
            this.portAddress.Size = new System.Drawing.Size(100, 20);
            this.portAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // value
            // 
            this.value.Location = new System.Drawing.Point(12, 64);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(100, 20);
            this.value.TabIndex = 3;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(174, 6);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(329, 108);
            this.result.TabIndex = 4;
            // 
            // readBtn
            // 
            this.readBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readBtn.ForeColor = System.Drawing.Color.Blue;
            this.readBtn.Location = new System.Drawing.Point(12, 90);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(75, 23);
            this.readBtn.TabIndex = 5;
            this.readBtn.Text = "Read";
            this.readBtn.UseVisualStyleBackColor = true;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // Write
            // 
            this.Write.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Write.ForeColor = System.Drawing.Color.Blue;
            this.Write.Location = new System.Drawing.Point(93, 90);
            this.Write.Name = "Write";
            this.Write.Size = new System.Drawing.Size(75, 23);
            this.Write.TabIndex = 6;
            this.Write.Text = "Write";
            this.Write.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 123);
            this.Controls.Add(this.Write);
            this.Controls.Add(this.readBtn);
            this.Controls.Add(this.result);
            this.Controls.Add(this.value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portAddress);
            this.Name = "Form1";
            this.Text = "Read Write Port";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox portAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button readBtn;
        private System.Windows.Forms.Button Write;
    }
}

