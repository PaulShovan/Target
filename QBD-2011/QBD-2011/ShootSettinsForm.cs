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
    public partial class ShootSettinsForm : Form
    {
        public bool isFixed = true;
        public int shootTime;

        public ShootSettinsForm()
        {
            InitializeComponent();
            shootTime = 5;
            shootTextBox.Text = shootTime.ToString();
            this.StartPosition = FormStartPosition.CenterScreen;
            oKbutton.DialogResult = DialogResult.OK;
        }

        private void fixedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fixedRadioButton.Enabled == true)
            {
                shootTextBox.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (unlimitedRadioButton.Enabled == true)
            {
                shootTextBox.Enabled = false;
            }
        }

        private void oKbutton_Click(object sender, EventArgs e)
        {
            bool done = false;

            if (fixedRadioButton.Enabled == true)
            {
                    try
                    {

                         shootTime = Int32.Parse(shootTextBox.Text);
                         done = true;
  
                    }catch
                    {
                        MessageBox.Show("Please enter only numbers.", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        shootTextBox.Text = "";
                    }
              } 
                 if(done == true) this.Hide();
                 //this.Parent.Activate();
           }
           
        
    }
}
