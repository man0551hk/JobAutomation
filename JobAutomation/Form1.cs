using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JobAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sampleNo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void openLoopFileBtn_Click(object sender, EventArgs e)
        {
            openLoopJobFileDialog.InitialDirectory = "c:\\";
            openLoopJobFileDialog.Filter = "job files (*.job)|*.job";
            openLoopJobFileDialog.FilterIndex = 2;
            openLoopJobFileDialog.Title = "Select Job File";

            openLoopJobFileDialog.RestoreDirectory = true;

            if (openLoopJobFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    loopJobFilePath.Text = openLoopJobFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
