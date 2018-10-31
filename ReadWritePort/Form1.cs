using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadWritePort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            // GlobalFunc.intIOAddress = Convert.ToInt32(GlobalFunc.basicSetting.IoAddress, 16);
            portAddress.KeyPress += CheckISNumber_KeyPress;
            value.KeyPress += CheckISNumber_KeyPress;
        }

        private void CheckISNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            if (portAddress.Text != "")
            {
                int ioAddress = Convert.ToInt32(portAddress.Text, 16);

            }
        }


    }
}
