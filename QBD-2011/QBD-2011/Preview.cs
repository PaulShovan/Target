using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QBD_2011
{
    public partial class Preview : Form
    {
        const int MF_BYPOSITION = 0x400;

        [DllImport("User32")]

        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]

        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]

        private static extern int GetMenuItemCount(IntPtr hWnd);
        private VideoProcess videoProcess = null;
        public Preview(VideoProcess vp)
        {
            InitializeComponent();
            videoProcess = vp;
            
            //this.Visible = false;
        }

        private void Preview_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoProcess.showPreview = false;
            this.Hide();
        }

        private void Preview_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Preview_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);

            int menuItemCount = GetMenuItemCount(hMenu);

            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoProcess.showPreview = false;
            this.Hide();
        }
    }
}
