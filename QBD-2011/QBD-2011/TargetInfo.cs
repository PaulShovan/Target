using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace QBD_2011
{
    public partial class TargetInfo : UserControl
    {
        delegate void StringParameterDelegate(string Text);
        delegate void IntIntParameterDelegate(int shotAffected, int shotTaken);


        private IntIntParameterDelegate setShotdelegate;
        private string labelInfo;

        public TargetInfo()
        {
            InitializeComponent();
            setShotdelegate = new IntIntParameterDelegate(calculateShotLabel);

        }

        public void setShotLabelInfo(int shotAffected, int shotTaken)
        {
            setShotdelegate(shotAffected, shotTaken);
        }

        public void calculateShotLabel(int shotAffected, int shotTaken)
        {
            labelInfo = "";
            if (shotAffected < 10)
            {
                labelInfo = "0" + shotAffected.ToString();
            }
            else
            {
                labelInfo = shotAffected.ToString();
            }

            labelInfo += ":";

            if (shotTaken < 10)
            {
                labelInfo += "0" + shotTaken.ToString();
            }
            else
            {
                labelInfo += shotTaken.ToString();
            }

            UdpateStatusText(labelInfo);
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
            string[] info = Text.Split(':');
            if (info.Length == 2)
            {
                this.shootCount.Text = info[0];
                this.totalShoot.Text = "/" + info[1];
            }
        }

    }
}
