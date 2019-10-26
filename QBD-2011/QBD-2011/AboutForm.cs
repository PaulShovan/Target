using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace QBD_2011
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //oKbutton.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            libLink.Links.Remove(libLink.Links[0]);
            libLink.Links.Add(0, libLink.Text.Length, "http://www.ipackbd.com");
        }

        private void libLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
