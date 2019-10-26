using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace QBD_2011
{
    public partial class XYGraph : Form
    {
        Point p1;
        Point p2;
        Point P;
        Point prevPoint;
        Point nextPoint;
        int time = 0;
        List<Point> p1List = new List<Point>();
        public string textFile = "";
        public string shotsTake = "";
        int perPoint = 0;
        public XYGraph(string fileName, string ShotsTaken)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            textFile = fileName;
            shotsTake = ShotsTaken;
            perPoint = 100;
            //DrawXY();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics formGraphics = pe.Graphics;
            //System.Drawing.Graphics formGraphics = this.CreateGraphics();
            try
            {
                p1.X = 100;
                p1.Y = 100;
                p2.X = 1200;
                p2.Y = 100;
                for (int i = 1; i <= 15; i++)
                {
                    using (var p = new Pen(Color.Black, 3))
                    {
                        formGraphics.DrawLine(p, p1, p2);
                        if (i == 8)
                        {
                            using (var pen = new Pen(Color.Red, 3))
                            {
                                formGraphics.DrawLine(pen, p1, p2);
                            }
                        }
                        //Thread.Sleep(50);
                    }
                    p1.Y += 30;
                    p2.Y += 30;
                }
                using (var p = new Pen(Color.Red, 3))
                {
                    p1.X = 100;
                    p1.Y = 50;

                    p2.X = 100;
                    p2.Y = 550;
                    formGraphics.DrawLine(p, p1, p2);
                    //Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //this.Invalidate();
            showButton.Enabled = false;
            clearButton.Enabled = false;
            GetXY();
        }
        public void GetXY()
        {
            string[] shotsTaken = shotsTake.Split(':');
            using (StreamReader sr = File.OpenText(Login.fileName + textFile + ".txt"))
            {
                double relativeX = 0;
                double relativeY = 0;
                String input;
                int start = 1;
                int shots = Convert.ToInt32(shotsTaken[1]);
                int width = (int)1000 / shots + 100;
                while ((input = sr.ReadLine()) != "shoot" + shots.ToString())
                {
                    while ((input = sr.ReadLine()) != "shoot" + start.ToString())
                    {
                        if (input != null)
                        {
                            string[] xy = input.Split(':');
                            if (input != ":")
                            {
                                if (Convert.ToInt32(xy[0]) != -1 && Convert.ToInt32(xy[1]) != -1)
                                {
                                    P.Y = Convert.ToInt32(xy[0]) + 60;
                                    p1List.Add(P);
                                }
                            }
                        }
                    }
                    CreateLine(p1List, width);
                    p1List.Clear();
                    //time++;
                    if (start < shots)
                        start++;
                    else
                    {
                        //start = 1;
                        break;
                    }

                }
                perPoint = 100;
                GetY();
                showButton.Enabled = true;
                clearButton.Enabled = true;
            }
        }
        //public void GetXY()
        //{
        //    p1List.Clear();
        //    string[] p_shot_count = shotsTake.Split(':');
        //    int shots_count_int = Convert.ToInt32(p_shot_count[1]);
           
        //    using (StreamReader sr = File.OpenText(Login.fileName + textFile + ".txt"))
        //    {
        //        double relativeX = 0;
        //        double relativeY = 0;
        //        String input;
        //       // int start = 1;
        //        int shots = Convert.ToInt32(p_shot_count[1]);
        //        int width = (int)1000 / shots + 100;
        //        while (!((input = sr.ReadLine()) == ("shoot" + p_shot_count[1].ToString())))
        //        {
        //            if (input.StartsWith("shoot"))
        //            {
        //               // int temp = 1;
        //                //draw point
        //            }
        //            if (input != null)
        //            {
        //                string[] xy = input.Split(':');
        //                if (xy[0] != "-1")
        //                {
        //                   // int count_int = Convert.ToInt32(xy[0].ToString());
        //                     P.Y = Convert.ToInt32(xy[0]);
        //                   // P.Y = count_int;
        //                    p1List.Add(P);

        //                }

        //            }
               
        //            CreateLine(p1List, width);
        //            p1List.Clear();
              

        //        }
        //    }
        //}
        public void GetY()
        {
            string[] shotsTaken = shotsTake.Split(':');
            using (StreamReader sr = File.OpenText(Login.fileName + textFile + ".txt"))
            {
                double relativeX = 0;
                double relativeY = 0;
                String input;
                int start = 1;
                int shots = Convert.ToInt32(shotsTaken[1]);
                int width = (int)1000 / shots + 100;
                while ((input = sr.ReadLine()) != "shoot" + shots.ToString())
                {
                    while ((input = sr.ReadLine()) != "shoot" + start.ToString())
                    {
                        if (input != null)
                        {
                            string[] xy = input.Split(':');
                            if (input != ":")
                            {
                                if (Convert.ToInt32(xy[0]) != -1 && Convert.ToInt32(xy[1]) != -1)
                                {
                                    P.Y = Convert.ToInt32(xy[1]) + 100;
                                    p1List.Add(P);
                                }
                            }
                        }
                    }
                    CreateLineY(p1List, width);
                    p1List.Clear();
                    //time++;
                    if (start < shots)
                        start++;
                    else
                    {
                        //start = 1;
                        break;
                    }

                }
            }
        }
        public void CreateLine(List<Point> p1List,int wide)
        { 
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            try
            {
                
             //   perPoint = wide / p1List.Count;
                for (int xp = 0; xp < p1List.Count; xp++)
                {
                    prevPoint = p1List[xp];
                    prevPoint.X = perPoint;
                    if (perPoint <= 1200)
                        perPoint++;
                    else
                        break;
                    nextPoint = p1List[xp + 1];
                    nextPoint.X = perPoint;
                    //p1List[xp] = xp;
                    //p1List[xp + 1] = xp + 1;
                    using (var p = new Pen(Color.Red, 2))
                    {
                        formGraphics.DrawLine(p,prevPoint,nextPoint);
                        Thread.Sleep(50);
                    }
                }
                perPoint = 100;
            }
            catch (Exception ex)
            {

            }
        }
        public void CreateLineY(List<Point> p1List, int wide)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            try
            {

                //   perPoint = wide / p1List.Count;
                for (int xp = 0; xp < p1List.Count; xp++)
                {
                    prevPoint = p1List[xp];
                    prevPoint.X = perPoint;
                    if (perPoint <= 1200)
                        perPoint++;
                    else
                        break;
                    nextPoint = p1List[xp + 1];
                    nextPoint.X = perPoint;
                    //p1List[xp] = xp;
                    //p1List[xp + 1] = xp + 1;
                    using (var p = new Pen(Color.Blue, 2))
                    {
                        formGraphics.DrawLine(p, prevPoint, nextPoint);
                        Thread.Sleep(50);
                    }
                }
                //perPoint = 100;
            }
            catch (Exception ex)
            {

            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            perPoint = 100;
            this.Invalidate();
        }
    }
}
