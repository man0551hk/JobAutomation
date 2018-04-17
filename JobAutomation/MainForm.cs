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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150, GlobalFunc.h / 2 - 330);
            this.FormClosing += Form1_Closing;
            GlobalFunc.mainFormHeight = GlobalFunc.h / 2 - 330;

            GlobalFunc.startCountingSequenceForm = new StartCountingSequenceForm();
            GlobalFunc.startCountingSequenceForm.Show();
        }

        private void psBtn_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "ParameterSetup";
            if (CheckLoginStatus())
            {
                if (GlobalFunc.parameterSetupForm == null || GlobalFunc.parameterSetupForm.IsDisposed)
                {
                    GlobalFunc.parameterSetupForm = new ParameterSetupForm();
                }
                GlobalFunc.parameterSetupForm.Show();

                if (GlobalFunc.setupCountingSequenceForm != null)
                {
                    GlobalFunc.setupCountingSequenceForm.Hide();
                    GlobalFunc.setupCountingSequenceForm.Dispose();
                }
            }
        }

        private void cssBtn_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "SetupCountingSequence";
            if (CheckLoginStatus())
            {
                if (GlobalFunc.setupCountingSequenceForm == null || GlobalFunc.setupCountingSequenceForm.IsDisposed)
                {
                    GlobalFunc.setupCountingSequenceForm = new SetupCountingSequenceForm();
                }
                GlobalFunc.setupCountingSequenceForm.Show();

                if (GlobalFunc.parameterSetupForm != null)
                {
                    GlobalFunc.parameterSetupForm.Hide();
                    GlobalFunc.parameterSetupForm.Dispose();
                }
            }
        }

        private void scsBtn_Click(object sender, EventArgs e)
        {
            GlobalFunc.passwordFormToggle = "StartCountingSequence";

            if (GlobalFunc.startCountingSequenceForm == null || GlobalFunc.startCountingSequenceForm.IsDisposed)
            {
                GlobalFunc.startCountingSequenceForm = new StartCountingSequenceForm();
            }
            GlobalFunc.startCountingSequenceForm.Show();


            if (GlobalFunc.parameterSetupForm != null)
            {
                GlobalFunc.parameterSetupForm.Hide();
                GlobalFunc.parameterSetupForm.Dispose();
            }

        }

        private bool CheckLoginStatus()
        {
            if (GlobalFunc.loginStatus == 1)
            {
                return true;
            }
            else
            {
                GlobalFunc.passwordForm.Dispose();
                GlobalFunc.passwordForm = new PasswordForm();
                GlobalFunc.passwordForm.Show();
                return false;
            }
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }
    }
}
