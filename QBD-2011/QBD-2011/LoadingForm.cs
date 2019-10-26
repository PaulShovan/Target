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
    public partial class LoadingForm : Form
    {
        delegate void StringParameterDelegate(string Text);
        delegate void SplashShowCloseDelegate();

        bool CloseSplashScreenFlag = false;
        
        public LoadingForm()
        {
            InitializeComponent();
            this.loadingStatusLabel.Parent = this.LoagingImagePictureBox;
            this.loadingStatusLabel.BackColor = Color.Transparent;
            this.loadingStatusLabel.ForeColor = Color.White;
        }

        public void ShowLoadingScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowLoadingScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        public void CloseLoadingScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseLoadingScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }

        public void UdpateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { Text });
                return;
            }
            // Must be on the UI thread if we've got this far
            this.loadingStatusLabel.ForeColor = Color.White;
            this.loadingStatusLabel.Text = Text;
        }
    }
}
