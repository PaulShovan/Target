using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using QBD_2011.Properties;

namespace QBD_2011
{
    public class SerialPortComm
    {
        private SerialPort port;
        private Bitmap i;
        private VideoProcess vp = null;
        private TargetBox tb = null;
        private ShootPointStatus pointController = null;
        private TargetBox targetBox = null;
        private TargetInfo mainTargetInfo = null;
        private ShootPointStatus allShots = null;
        public bool isPortConnected = false;
        public MainForm mainFrom;
        private TargetTimer targetTimer;
        private int counter = 0;
        private Color c;
        private Settings settings;

        public SerialPortComm(VideoProcess v, TargetBox t, TargetInfo ti, MainForm m, TargetTimer tt)
        {
            port = new SerialPort();
            vp = v;
            tb = t;
            mainTargetInfo = ti;
            targetBox = TargetBoxController.getTargetBox();
            allShots = ShootPointController.getController();
            mainFrom = m;
            targetTimer = tt;
            this.openPort();   
        }

        public void openPort()
        {
            //port = new SerialPort();
            if (port.IsOpen == true)
            {
                port.Close();
            }
            isPortConnected = false;
            string str = "";
            for (int i = 1; i <= 15; i++)
            {
                try
                {
                    str = "COM" + i.ToString();
                    port.BaudRate = 9600;
                    port.PortName = str;
                    port.DataBits = 8;
                    port.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                    port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    port.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
                    port.Open();
                    isPortConnected = true; 
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Shooting Device not connected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(isPortConnected == true) break;
            }
                if (str.Equals("COM15"))
                {
                    MessageBox.Show("Shooting Device not connected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string msg = port.ReadExisting();
            Mrg.Point p = new Mrg.Point();
            if (msg == "H" && ShootPointController.getController().isProjectLaser == true)
            {
                mainFrom.player.Play();
                msg = "";
                //MessageBox.Show("Data received");


                pointController = ShootPointController.getController();
                Bitmap img = vp.getCurrentImageShotInfo(out p, out c);
                //img.Save(@"C:\" + counter.ToString() + ".jpg");
                
                counter++;
                //mainFrom.player.Stop();
                //MessageBox.Show(string.Format("x ={0}, y ={1} ", p.getX().ToString(), p.getY().ToString()));
                
                if (p.getX() != -1 && p.getY() != -1)
                {
                    pointController.shots.Add(new Mrg.Point(p.getX(), p.getY()));
                    //;
                    
                    pointController.incrementShot(true, true);
                }
                else {
                    pointController.incrementShot(false, true);
                    //this is the missing bullet info
                    //MessageBox.Show(c.ToString());
                }

                targetBox.Invalidate();
                //mainTargetInfo.setShotLabelInfo(allShots.shotAffected, allShots.shotTaken);

                //i = new Bitmap(vp.img);
                //i.Save("1.jpg");

                if (ShootPointController.getController().shotTaken == mainFrom.shootTime)
                {
                    if (MessageBox.Show("Do you want to save current shooting records?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        GraphForm graphForm = new GraphForm(tb);
                        graphForm.saveData = true;
                        graphForm.showTimerForm();
                        graphForm.showDistanceForm();
                        graphForm.showCircleForm();
                        graphForm.calculateAverage();
                        if (graphForm.doneSave)
                        {
                            MessageBox.Show("Data has been saved successfully.");
                        }
                    }
                    else
                    {
                        if (File.Exists(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName + "Log" + ".txt"))
                        {
                            File.Delete(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName + "Log" + ".txt");
                        }
                        if (File.Exists(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName + ".txt"))
                        {
                            File.Delete(@"G:\Target\kjhkh\QBD-2011\QBD-2011\" + Login.ShooterName + ".txt");
                        }
                    }
                    //MessageBox.Show("Complete");
                    mainFrom.setControlToolButton(true, true, true);

                    targetBox.isCircleDrawn = true;
                    targetBox.isDistanceDrawn = true;
                    targetTimer.hangTimer();
                }

                ShootPointController.getController().shotTime.Add(targetTimer.singleShotTime);
                targetTimer.singleShotTime = 0;

            }

        }

    }
}
