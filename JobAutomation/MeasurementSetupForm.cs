using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace JobAutomation
{
    public partial class MeasurementSetupForm : Form
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        public MeasurementSetupForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(150 + 524, GlobalFunc.mainFormHeight);
            SetProfile();
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        #region profile
        private void SetProfile()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "profile.json"))
            {
                GlobalFunc.profile = (Profile)js.Deserialize<Profile>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json"));
                profileCB.Items.Clear();
                for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
                {
                    profileCB.Items.Add(GlobalFunc.profile.operationName[i]);
                }
            }
            else
            {
                GlobalFunc.profile = new Profile();
                GlobalFunc.profile.operationName = new List<string>();
            }
        }

        private void SaveProfile()
        {
            bool existed = false;
            for (int i = 0; i < GlobalFunc.profile.operationName.Count; i++)
            {
                if (profileCB.Text == GlobalFunc.profile.operationName[i])
                {
                    existed = true;
                    break;
                }
            }

            if (!existed)
            {
                GlobalFunc.profile.operationName.Add(profileCB.Text);
                string json = js.Serialize(GlobalFunc.profile);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "profile.json", json);
                SetProfile();
                ShowMessage("Add operation successful");
                GlobalFunc.mainForm.SetProfile();
                GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
            }
            else
            {
                ShowMessage("The opertaion name existed");
            }
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalFunc.mainForm.SelectionProfile(profileCB.Text);
        }

        public void SelectionProfile(string profileName)
        {
            int selectIndex = 0;
            for (int i = 0; i < profileCB.Items.Count; i++)
            {
                if (profileCB.Items[i].ToString() == profileName)
                {
                    selectIndex = i;
                    break;
                }
            }
            profileCB.SelectedIndex = selectIndex;
        }
        #endregion

        private void doneBtn_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }





    }
}
