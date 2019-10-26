using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QBD_2011
{
    public partial class TimeSettingsForm : Form
    {
        public bool isCounter = true;
        public int minutes = 5;
        public int seconds = 0;


        public TimeSettingsForm()
        {
            InitializeComponent();
            minNumericUpDown.Value = 5;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public int getTimeInSeconds()
        {
            return minutes * 60 + seconds;
        }

        private void counterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (counterRadioButton.Checked == true)
            {
                timeGroupBox.Enabled = true;
            }
        }

        private void unlimitedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (unlimitedRadioButton.Enabled == true)
            {
                timeGroupBox.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (counterRadioButton.Checked == true)
            {
                isCounter = true;

                if (minNumericUpDown.Value == 0 && secondNumericUpDown.Value == 0)
                {
                    MessageBox.Show("Please Enter a valid time.", "Input Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    minutes = Decimal.ToInt32(minNumericUpDown.Value);
                    seconds = Decimal.ToInt32(secondNumericUpDown.Value);
                    //MessageBox.Show(getTimeInSeconds().ToString());
                }
            }
            else {

                isCounter = false;
            }

            this.Hide();
        }

 
    }
}
