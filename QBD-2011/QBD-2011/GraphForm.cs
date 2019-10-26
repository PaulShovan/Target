using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Collections;
using System.Data.OleDb;
using QBD_2011.Database.ShootingInfoTableAdapters;
using QBD_2011.Database;
using System.IO;

namespace QBD_2011
{

    public partial class GraphForm : Form
    {
        //table adapter of ShootingTable
        ShootingTableTableAdapter taShootingTable = new ShootingTableTableAdapter();
        List<ShootingInfo.ShootingTableRow> lstShootingTable = new List<ShootingInfo.ShootingTableRow>();

        TargetBox tb;
        private int averageDistance = 0;
        private int averageTime = 0;
        private int totalTime = 0;
        private int groupMaxDistance = 0;

        private ShootPointStatus shotInfo = ShootPointController.getController();

        private const float GAYABE_NUMBER = 1.5F;
        ArrayList shotPoint;

        private string bano = "";
        private string name = "";
        private DateTime datetime = DateTime.Now;
        public static short shotsTaken = 0;
        public static short hitsTergeted = 0;
        private short avgAccuracy = 0;
        private short avgGrouping = 0;
        private short reflex = 0;
        private short summury = 0;
        public bool saveData = false;
        public bool doneSave = false;


        public GraphForm(TargetBox t)
        {
            InitializeComponent();
            tb = t;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void SaveData(ShootingData data)
        {
            DatabaseIDU db = new DatabaseIDU();
            doneSave = db.insert(data);
            saveData = false;
        }
        public void showDistanceForm()
        {
            // Lets generate sine and cosine wave
            ArrayList shots = TargetBoxController.getTargetBox().tempPoints;
            shotPoint = new ArrayList();
            for (int i = 0; i < shots.Count; i++)
            {
                Mrg.Point p = (Mrg.Point)shots[i];
                float distance = tb.findDistance(new Mrg.Point(tb.centerX, tb.centerY), new Mrg.Point(p.getX(), p.getY()));
                //distance = (10 - (((float)distance / tb.radius)) * 10);
                
                int distancePoint = (10 - ((int)(distance * (10.0 / tb.radius))));
                shotPoint.Add(distancePoint);
                
            }

            shotsTaken = (short)shotInfo.shots.Count;
            hitsTergeted = (short)ShootPointController.getController().shotAffected;

            double[] x = new double[shotPoint.Count];
            double[] y = new double[shotPoint.Count];

            averageDistance = 0;

            for (int i = 0; i < shotPoint.Count; i++)
            {
                x[i] = i + 1;
                y[i] = (int)shotPoint[i];
                averageDistance += (int)y[i];
            }

            if (shotPoint.Count != 0)
            {
                averageDistance = (int)((float)averageDistance / shotPoint.Count);
            }

            avgAccuracy = (short)averageDistance;

            // This is to remove all plots
            //if (distanceZedGraphControl.GraphPane != null)
            
            distanceZedGraphControl.GraphPane.CurveList.Clear();
            

            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane myPane = distanceZedGraphControl.GraphPane;

            // PointPairList holds the data for plotting, X and Y arrays
            PointPairList spl1 = new PointPairList(x, y);
            //PointPairList spl2 = new PointPairList(x, z);

            // Add cruves to myPane object
            BarItem myCurve1 = myPane.AddBar("Distance", spl1, Color.Blue);
            //LineItem myCurve2 = myPane.AddCurve("Cosine Wave", spl2, Color.Red, SymbolType.None);

            myCurve1.Bar.Border = new Border();
            //myCurve2.Line.Width = 3.0F;
            myPane.Title.Text = "Distance Summary";

            // I add all three functions just to be sure it refeshes the plot.  
            distanceZedGraphControl.AxisChange();
            distanceZedGraphControl.Invalidate();
            distanceZedGraphControl.Refresh();

            MessageBox.Show(averageDistance.ToString());
        }

        public void showCircleForm()
        {
            // Lets generate sine and cosine wave
            ArrayList radiusPoint = tb.shotRadiusPoint;

            double[] x = new double[radiusPoint.Count];
            double[] y = new double[radiusPoint.Count];

            for (int i = 0; i < radiusPoint.Count; i++)
            {
                x[i] = i + 1;
                y[0] = 10;
                y[i] = 10 - (int)radiusPoint[i];
                groupMaxDistance = (int)y[i];
            }

            if (groupMaxDistance < 0)
            {
                groupMaxDistance = 0;
            }

            avgGrouping = (short)groupMaxDistance;
            
            //MessageBox.Show("laod");

            // This is to remove all plots
            circlezedGraphControl.GraphPane.CurveList.Clear();

            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane myPane = circlezedGraphControl.GraphPane;

            // PointPairList holds the data for plotting, X and Y arrays
            PointPairList spl1 = new PointPairList(x, y);
            //PointPairList spl2 = new PointPairList(x, z);

            // Add cruves to myPane object
            BarItem myCurve1 = myPane.AddBar("Radius", spl1, Color.Blue);
            //LineItem myCurve2 = myPane.AddCurve("Cosine Wave", spl2, Color.Red, SymbolType.None);

            myCurve1.Bar.Border = new Border();
            //myCurve2.Line.Width = 3.0F;
            myPane.Title.Text = "Circle Summary";

            // I add all three functions just to be sure it refeshes the plot.  
            circlezedGraphControl.AxisChange();
            circlezedGraphControl.Invalidate();
            circlezedGraphControl.Refresh();
        }


        public void showTimerForm()
        {
            // Lets generate sine and cosine wave
            ArrayList timePoint = ShootPointController.getController().shotTime;

            double[] x = new double[timePoint.Count];
            double[] y = new double[timePoint.Count];

            totalTime = 0;
            for (int i = 0; i < timePoint.Count; i++)
            {
                x[i] = i + 1;
                y[i] = (int)timePoint[i];
                totalTime += (int)timePoint[i];
            }
            
            if (timePoint.Count != 0)
            {
                averageTime = totalTime / timePoint.Count; 
            }

            reflex = (short)averageTime;
            //MessageBox.Show(totalTime.ToString() + " - " + ShootPointController.getController().shotTaken.ToString());
            
            // This is to remove all plots
            timeZedGraphControl.GraphPane.CurveList.Clear();

            // GraphPane object holds one or more Curve objects (or plots)
            GraphPane myPane = timeZedGraphControl.GraphPane;

            // PointPairList holds the data for plotting, X and Y arrays
            PointPairList spl1 = new PointPairList(x, y);
            //PointPairList spl2 = new PointPairList(x, z);

            // Add cruves to myPane object
            BarItem myCurve1 = myPane.AddBar("Time", spl1, Color.Blue);
            //LineItem myCurve2 = myPane.AddCurve("Cosine Wave", spl2, Color.Red, SymbolType.None);

            myCurve1.Bar.Border = new Border();
            //myCurve2.Line.Width = 3.0F;
            myPane.Title.Text = "Time Summary";

            // I add all three functions just to be sure it refeshes the plot.  
            timeZedGraphControl.AxisChange();
            timeZedGraphControl.Invalidate();
            timeZedGraphControl.Refresh();
        }

        public void calculateAverage()
        {
            hitsLabel.Text = ShootPointController.getController().shotAffected.ToString();
            shotsLabel.Text = ShootPointController.getController().shotTaken.ToString();

            int tempPoint = 0;
            for (int i = 0; i < shotPoint.Count; i++)
            {
                tempPoint = tempPoint + (int)shotPoint[i];
            }

            //MessageBox.Show("IN One " + ShootPointController.getController().shotPoint.Count.ToString());
            if (shotPoint.Count != 0)
            {
                tempPoint /= shotPoint.Count;
                distLabel.Text = tempPoint.ToString();
                //MessageBox.Show("IN side");
            }

            //------------------------------------------
            groupLabel.Text = groupMaxDistance.ToString();
            //------------------------------------------

            float maxTime = 0;
            float minTime = 0;

            minTime = GAYABE_NUMBER * ShootPointController.getController().shotTaken;
            maxTime = 24 * ShootPointController.getController().shotTaken;

            float difference = maxTime - minTime;
            float avgTime = 0;
            if (difference != 0)
            {
                float tempGayabe = (((float)totalTime) - (GAYABE_NUMBER * ShootPointController.getController().shotTaken));
                avgTime = tempGayabe * (ShootPointController.getController().shotTaken / difference);
            }
            int result = arannya(avgTime);


            totalTimeLabel.Text = result.ToString();


            //-----------------------
            //  Final Average Value
            //-----------------------

            float finalAverage = ((float)(tempPoint + groupMaxDistance + result)) / 2.50F;

            summury = (short)finalAverage;

            setImageInGraph(tempPoint, false, accImg);
            setImageInGraph(groupMaxDistance, false, grpImg);
            setImageInGraph(result, true, refImg);
            avgLabel.Text = finalAverage.ToString();
            setAverageImage(finalAverage );

            if (saveData)
            {
                if (File.Exists(Login.fileName + VideoProcess.fileNameEnd + "Log.txt"))
                {
                    File.Delete(Login.fileName + VideoProcess.fileNameEnd + "Log.txt");
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Login.fileName + VideoProcess.fileNameEnd + "Log.txt", true))
                {
                    file.WriteLine("Shooter name :" + Login.ShooterName);
                    file.WriteLine("Shots taken :"+ShootPointController.getController().shotTaken.ToString());
                    //file.WriteLine("Shots taken :"+shotsTaken.ToString());
                    file.WriteLine("Hits :" + hitsTergeted.ToString());
                    file.WriteLine("Average accuracy :" + avgAccuracy.ToString());
                    file.WriteLine("Average grouping :" + avgGrouping.ToString());
                    file.WriteLine("Reflex :" + reflex.ToString());
                    file.WriteLine("Summary :" + summury.ToString());
                }
                ShootingData data = new ShootingData();
                data.BaNo = Login.BaNo;
                data.ShooterName = Login.ShooterName;
                data.TraineeId = Login.TraineeId;
                data.Now = DateTime.Now.ToString();
                //data.Shots = shotsTaken.ToString();
                data.Shots = ShootPointController.getController().shotTaken.ToString();
                data.Hits = hitsTergeted.ToString();
                data.AvgAccuracy = avgAccuracy.ToString();
                data.AvgGrouping = avgGrouping.ToString();
                data.Refex = reflex.ToString();
                data.Summary = summury.ToString();
                data.FileName = VideoProcess.fileNameEnd;
                VideoProcess.count = 1;
                
                SaveData(data);
            }
            //DatabaseIDU didu = new DatabaseIDU();
            //int inserted = didu.insert(bano, name, datetime, shotsTaken, hitsTergeted, avgAccuracy, avgGrouping, reflex, summury);

            //if (inserted > 0)
            //{
            //    MessageBox.Show("Data has been saved successfully.");
            //}
            //else 
            //{
            //    MessageBox.Show("Data cannot be saved right now,Please try again later.");
            //}
        }

        private void GraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shotPoint.Clear();
            this.Dispose();
        }

        private void setAverageImage(float finalAvg)
        {
            if (finalAvg <= 3.2)
            {
                avgImage.Image = Properties.Resources.red;
            }
            else if (finalAvg > 3.2 && finalAvg <= 6.67)
            {
                avgImage.Image = Properties.Resources.yellow;
            }
            else
            {
                avgImage.Image = Properties.Resources.green;
            }
            
        }

        private void setImageInGraph(float num, bool isTime, PictureBox p)
        {
            if (isTime == false)
            {
                num = num / 2;
            }

            if (num < 1.6)
            {
                p.Image = Properties.Resources.red_dot;
            }
            else if (num < 3.33)
            {
                p.Image = Properties.Resources.yello_dot;
            }
            else
            {
                p.Image = Properties.Resources.green_dot;
            }
        
        }

        //this function is to convet from gayabe number to real number 
        private int arannya(float number)
        {
            if (number <= 1)
            {
                return 5;
            }
            else if (number > 1 && number <= 2)
            {
                return 4;
            }
            else if (number > 2 && number <= 3)
            {
                return 3;
            }
            else if (number > 3 && number <= 4)
            {
                return 2;
            }
            else if (number > 4 && number <= 5)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
