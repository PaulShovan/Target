using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mrg;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;


namespace QBD_2011
{

    public class VideoProcess
    {
        bool fileDelete = false;
        public static int count = 1;
        //private const
        //*******************************************************************
        private int camNumber = -1; // 0 - Webcam, 1 - Project cam
        //*****************************************************************
        public static int getPoint = 0;
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        public VideoCaptureDevice videoSource = null;
        public Bitmap img;
       // public Mrg.LaserDetect laser;
        public LaserDetect laser;
        private Mrg.Point point;
        private ArrayList cameraList;
        public Preview p;
        public bool isConnected = false;
        public Color laserColor;
        public static string fileNameEnd = "";
        public bool showPreview = false;

        public VideoProcess()
        {
            //laser = new Mrg.LaserDetect();
            laser = new LaserDetect();
            point = new Mrg.Point();
            //point = new AForge.Point();
            cameraList = new ArrayList();
            p = new Preview(this);
            getCamereaList();
        }


        public void getCamereaList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new ApplicationException();
                }

                DeviceExist = true;
                int indexNumber = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    cameraList.Add(device.Name);
                    
                    //if (cameraList[indexNumber].Equals("Syntek STK1160"))
                    //if (cameraList[indexNumber].Equals("TOSHIBA Web Camera"))
                    if (cameraList[indexNumber].Equals("SMI Grabber Device"))
                    {
                        camNumber = indexNumber;
                        isConnected = true;

                    }

                    indexNumber++;
                    if(camNumber == -1)
                    {
                        isConnected = false;
                    }
                }

            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                //MessageBox.Show("Video device not exists.");
                //combo.Items.Add("No capture device on your system");
            }
        }

        public void connectCamere()
        {
            isConnected = false;
            if (DeviceExist)
            {
                try
                {
                    videoSource = new VideoCaptureDevice(videoDevices[camNumber].MonikerString);//videoSource = new VideoCaptureDevice(videoDevices[f].MonikerString);
                    isConnected = true;
                }
                catch (Exception dnfe)
                {
                    //MessageBox.Show("Target Device not connected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                }
                try
                {
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    videoSource.DesiredFrameSize = new Size(150, 110);
                    videoSource.DesiredFrameRate = 30;
                    videoSource.Start();
                }
                catch (Exception er){}
            }

        }//connetcCamera()
        public void WritePoints(string xy)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Login.fileName + fileNameEnd + ".txt", true))
            {
                file.WriteLine(xy);
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            string y = "";
            string xx = "";
            string yy = "";
            try
            {
                img = (Bitmap)eventArgs.Frame.Clone();
                Graphics dci = Graphics.FromImage(img);
                Pen pe = new Pen(Color.Black, 7);
                dci.DrawLine(pe, 0, 430, img.Width, 430); // Draw yellow horizontal line
                dci.DrawLine(pe, 0, 385, img.Width, 385); // Draw yellow horizontal line
                //dci.DrawLine(pe, 0, 348, img.Width, 348); // Draw yellow horizontal line
                //dci.DrawLine(pe, 0, 318, img.Width, 318); // Draw yellow horizontal line
                //dci.DrawLine(pe, 26, 472, img.Width-50, 64); // Draw yellow horizontal line
                //dci.DrawLine(pe, img.Width-50, 460, img.Width - 500, 42); // Draw yellow horizontal line
                //dci.DrawLine(pe, 0, 260, img.Width, 260); // Draw yellow horizontal line
                //dci.DrawLine(pe, 335, 0, 335, img.Height); // Draw yellow horizontal line
                //dci.DrawLine(pe, xPos, 0, xPos, image.Height); // Draw yellow vertical line

                dci.Dispose();

                point = laser.ProcessFrame(ref img, out laserColor);
                y = point.ToString();
                xx = point.getX().ToString();
                yy = point.getY().ToString();
            }
            catch(Exception e)
            {
            }
            /*if (getPoint == 1)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"G:\Target\kjhkh\QBD-2011\QBD-2011\WriteLines2.txt", true))
                {
                    file.WriteLine(y);
                }
            }*/
            
             
            try
            {
                if (getPoint == 1)
                {
                    if (!fileDelete)
                    {
                        if (File.Exists(Login.fileName + fileNameEnd + ".txt"))
                        {
                            File.Delete(Login.fileName + fileNameEnd + ".txt");
                        }
                        fileDelete = true;
                    }
                    WritePoints(xx + ":" + yy);
                }
                if (showPreview)
                {
                    p.previewPictureBox.Image = img;
                }
            }
            catch (Exception ne) { }
            //MessageBox.Show(string.Format("w: {0} h: {1}", img.Width.ToString(), img.Height.ToString()));
        }

        public void closeVideoSource()
        {
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    //videoSource.SignalToStop();
                    videoSource.Stop();
                    videoSource = null;
                }
            }
        }//closeVideoSource()

        public Bitmap getCurrentImageShotInfo(out Mrg.Point p, out Color c)
        {
            c = this.laserColor;
            p = this.point;
            string tpo = p.ToString();
            string X = p.getX().ToString();
            string Y = p.getY().ToString();
            try
            {
                if (getPoint == 1)
                {
                    WritePoints("shoot" + count.ToString());
                    count++;
                }
                //else
                //{
                //    count = 1;
                //}
            }
            catch (Exception e)
            { 
            }
            return img;
        }

    }//class

}//namespace