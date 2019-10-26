using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QBD_2011
{
    public partial class TargetTimer : UserControl
    {
        delegate void StringParameterDelegate(string time);
        delegate void DoubleIntParameterDelegate(int min, int second);
        public delegate void eventDelegate();
        
        
        private int timeCounter;
        private DoubleIntParameterDelegate delegatetimeCalculator;
        private bool isStopWatch = false;
        public event eventDelegate countingComplete;

        public bool isRunning = false;
        private MainForm mainForm;
        public int singleShotTime = 0;
        public TargetTimer()
        {
            InitializeComponent();
            delegatetimeCalculator = new DoubleIntParameterDelegate(calculateTimeString);
            this.Visible = false;
            isRunning = false;
            //mainForm = m;
        }
        public void setMainForm(MainForm m)
        {
            mainForm = m;
        }
        public void setTimer(int i)
        {
            timeCounter = i;
            isStopWatch = false;
            clockUpdaterTimer.Start();
            isRunning = true;

        }

        public void startStopWatch()
        {
            timeCounter = 0;
            isStopWatch = true;
            isRunning = true;
            clockUpdaterTimer.Start();
            
        }

        public void stopTimer()
        {
            clockUpdaterTimer.Stop();
            isRunning = false;
            UdpateTimer("00 : 00");
        }

        public void hangTimer()
        {
            clockUpdaterTimer.Stop();
            isRunning = false;
        }

        private void clockUpdaterTimer_Tick(object sender, EventArgs e)
        {
            int min = 0 ;
            int second = 0;
            min = timeCounter / 60;
            second = timeCounter % 60;
            delegatetimeCalculator(min, second);
            singleShotTime++;

            if (isStopWatch == false && isRunning)
            {
                timeCounter--;

                if (timeCounter == -1)
                {
                    //Generate a event
                    //isRunning = false;
                    //countingComplete();
                    taskComplete();
                    
                }
            }
            else
            {
                if (isRunning == true)
                { 
                    timeCounter++;
                }
                
            }
        }

        private void calculateTimeString(int minutes, int seceonds)
        {
            string time = "";
            if (minutes < 10)
            {
                time = "0" + minutes.ToString();
            }
            else
            {
                time = minutes.ToString();
            }

            if (seceonds < 10)
            {
                time += " : 0" + seceonds.ToString();
            }
            else {
               time += " : " + seceonds.ToString();
            }
            if (isRunning == true)
            {
                UdpateTimer(time);
            }
        }


        public void UdpateTimer(string time)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateTimer), new object[] { time });
                return;
            }
            // Must be on the UI thread if we've got this far
            this.timeLabel.Text = time;
        }

        public void taskComplete()
        {
            if (isRunning == true)
            {
                this.Visible = false;
                isRunning = false;
                mainForm.setControlToolButton(true, true, true);
                //
                //MessageBox.Show("Hi");
                
                
            }
        }

    }
}
