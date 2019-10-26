using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;

namespace QBD_2011
{
    public partial class ReplayForm : Form
    {
        int numberOfCircle = 7;
        int height = 0;
        int width = 0;
        public int centerX;
        public int centerY;
        public int radius;
        private int startX;
        private int startY;
        private int targetBoxWidth;
        private int targetBoxHeight;
        private Point P;
        List<Point> p1List = new List<Point>();
        int x = 0;
        int y = 0;
        public string[] inputLine = new string[10];
        public string textFile = "";
        public int drawBullet = 0;
        public ReplayForm(string fileName)
        {
            
            InitializeComponent();
            textFile = fileName;
            //XYGraphButton.Visible = false;
            if (File.Exists(Login.fileName + textFile + "Log" + ".txt"))
            {

                string line;
                int i = 0;
                using (StreamReader sr = File.OpenText(Login.fileName + textFile + "Log" + ".txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        inputLine[i] = line;
                        i++;
                    }
                }
                label1.Text = inputLine[0];
                label2.Text = inputLine[1];
                label3.Text = inputLine[2];
                label4.Text = inputLine[3];
                label5.Text = inputLine[4];
                label6.Text = inputLine[5];
                label7.Text = inputLine[6];
            }
            else 
            {
                MessageBox.Show("Sorry,no data was found.");
                button1.Visible = false;
                shootPointButton.Visible = false;
                XYGraphButton.Visible = false;
            }
            TargetBox targetBox = new TargetBox();
            height = this.Height;
            width = this.Width;
            this.WindowState = FormWindowState.Maximized;
            calculateInfo();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;

            //validation of the point accourding to the screen 

            // Create two colors
            Color white = Color.FromArgb(255, 255, 255);
            Color black = Color.FromArgb(0, 0, 0);

            Brush whiteBrush = new SolidBrush(white);
            Brush blackBrush = new SolidBrush(black);
            int radiusNow = radius;
            int radiusLess = radius / numberOfCircle;
            for (int i = 0; i < numberOfCircle; i++)
            {
                if (i % 2 == 0)
                {
                    g.FillEllipse(blackBrush, centerX - radiusNow, centerY - radiusNow, 2 * radiusNow, 2 * radiusNow);
                    radiusNow = radiusNow - radiusLess;

                }
                else
                {
                    g.FillEllipse(whiteBrush, centerX - radiusNow, centerY - radiusNow, 2 * radiusNow, 2 * radiusNow);
                    radiusNow = radiusNow - radiusLess;
                }
            }
            whiteBrush.Dispose();
            blackBrush.Dispose();
            //CreateLine();
        }
        private void calculateInfo()
        {
            centerX = width / 2;
            centerY = height / 2;
            radius = height / 2;
            startX = centerX - radius;
            startY = centerY - radius;

            targetBoxWidth = 2 * radius;
            targetBoxHeight = 2 * radius;

            //MessageBox.Show(string.Format("w: {0} h: {1}", startX.ToString(), startY.ToString()));

            //call onPaint() to redraw the change
            Invalidate();
        }
        public void GetXY()
        {
            
            string[] shotsTaken = inputLine[1].Split(':');
            using (StreamReader sr = File.OpenText(Login.fileName + textFile + ".txt"))
            {
                
                double relativeX = 0;
                double relativeY = 0;
                String input;
                int start = 1;
                int shots = Convert.ToInt32(shotsTaken[1]);
                while ((input = sr.ReadLine()) != "shoot" + shots.ToString())
                {

                //    //while ((input = sr.ReadLine()) != "shoot"+shots.ToString())
                //    //{
                   // if (start == 1)
                   //{
                        while ((input = sr.ReadLine()) != "shoot" + start.ToString())
                        {
                            if (input != null)
                            {
                                string[] xy = input.Split(':');
                                if (input != ":")
                                {
                                    if (Convert.ToInt32(xy[0]) != -1 && Convert.ToInt32(xy[1]) != -1)
                                    {
                                        P.X = Convert.ToInt32(xy[0]);
                                        P.Y = Convert.ToInt32(xy[1]);

                                        //P.X = P.X + 378;//335
                                        
                                        P.Y = P.Y + 75;//+97



                                        relativeX = P.X - centerX;
                                        relativeX = relativeX * 1.60f;

                                        //------------
                                        //P.Y = P.Y + 30;
                                        relativeY = P.Y - centerY;
                                        relativeY = relativeY * 1.65f;
                                        P.Y = (int)relativeY + centerY;
                                        
                                        //------

                                        P.X = (int)(centerX + relativeX);
                                        P.X = P.X + 30;
                                        if (P.X > centerX)
                                        {
                                            P.X = P.X + 190;
                                            //P.X = P.X + 345;
                                            //P.Y = P.Y + 59;
                                        }
                                        else
                                        {
                                            P.X = P.X + 185;
                                            //P.X = P.X + 150;
                                            //P.X = P.X + 300;
                                            //P.Y = P.Y + 59;
                                        }

                                        //double difference = P.X - 345;
                                        //if (difference > 0)
                                        //{
                                        //    P.X = 345 - (P.X - 345);
                                        //    //MessageBox.Show("SHOW");
                                        //}
                                        //else
                                        //{
                                        //    P.X = 345 + (345 - P.X);
                                        //}
                                        p1List.Add(P);
                                    }
                                }
                            }
                        }
                        if (drawBullet == 0)
                        {
                            CreateLine(p1List);
                        }
                        else if (drawBullet == 1)
                        {
                            CreateBullet(p1List);
                        }
                        p1List.Clear();
                        if (start < shots)
                            start++;
                        else
                        {
                            //start = 1;
                            break;
                        }
                            
                    }
                    /*else
                    {
                        if ((input = sr.ReadLine()) == "shoot" + start.ToString())
                        {
                            while ((input = sr.ReadLine()) != "shoot" + start + 1.ToString())
                            {
                                if ((input = sr.ReadLine()) != "shoot" + start.ToString())
                                {
                                    if (input != null)
                                    {
                                        string[] xy = input.Split(':');
                                        if (Convert.ToInt32(xy[0]) != -1 && Convert.ToInt32(xy[1]) != -1)
                                        {
                                            P.X = Convert.ToInt32(xy[0]);
                                            P.Y = Convert.ToInt32(xy[1]);

                                            P.X = P.X + 335;
                                            P.Y = P.Y + 97;//+97



                                            relativeX = P.X - centerX;
                                            relativeX = relativeX * 1.45f;

                                            //------------
                                            relativeY = P.Y - centerY;
                                            relativeY = relativeY * 1.42f;
                                            P.Y = (int)relativeY + centerY;
                                            //------

                                            P.X = (int)(centerX - relativeX);
                                            double difference = P.X - 345;
                                            if (difference > 0)
                                            {
                                                P.X = 345 - (P.X - 345);
                                                //MessageBox.Show("SHOW");
                                            }
                                            else
                                            {
                                                P.X = 345 + (345 - P.X);
                                            }
                                            p1List.Add(P);
                                        }
                                    }
                                }

                            }
                            CreateLine(p1List);
                            p1List.Clear();
                            if (start < shots)
                                start++;
                        }
                    }*/
                    //        while ((input = sr.ReadLine()) != "shoot" + start.ToString())
                    //        {
                    //            if (input != null)
                    //            {
                    //                string[] xy = input.Split(':');
                    //                if (Convert.ToInt32(xy[0]) != -1 && Convert.ToInt32(xy[1]) != -1)
                    //                {
                    //                    P.X = Convert.ToInt32(xy[0]);
                    //                    P.Y = Convert.ToInt32(xy[1]);

                    //                    P.X = P.X + 335;
                    //                    P.Y = P.Y + 97;//+97



                    //                    relativeX = P.X - centerX;
                    //                    relativeX = relativeX * 1.45f;

                    //                    //------------
                    //                    relativeY = P.Y - centerY;
                    //                    relativeY = relativeY * 1.42f;
                    //                    P.Y = (int)relativeY + centerY;
                    //                    //------

                    //                    P.X = (int)(centerX - relativeX);
                    //                    double difference = P.X - 345;
                    //                    if (difference > 0)
                    //                    {
                    //                        P.X = 345 - (P.X - 345);
                    //                        //MessageBox.Show("SHOW");
                    //                    }
                    //                    else
                    //                    {
                    //                        P.X = 345 + (345 - P.X);
                    //                    }
                    //                    p1List.Add(P);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }
                    //        CreateLine(p1List);
                    //        p1List.Clear();
                    //        if(start < shots)
                    //            start++;
                    //    }
                    //    CreateLine(p1List);
                    //    p1List.Clear();
                    //    start++;
                    //}
                //}
            }
        }
        public void CreateLine(List<Point> p1List)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            try
            {
                for (x = 0; x < p1List.Count/2; x++)
                {
                    using (var p = new Pen(Color.Blue, 5))
                    {
                        formGraphics.DrawLine(p, p1List[x], p1List[x + 1]);
                        Thread.Sleep(20);
                    }
                }
                for (; x < p1List.Count - 1; x++)
                {
                    using (var p = new Pen(Color.Yellow, 2))
                    {
                        formGraphics.DrawLine(p, p1List[x], p1List[x + 1]);
                        Thread.Sleep(20);
                    }
                }
                using (var p = new Pen(Color.Red, 5))
                {
                    Brush whiteBrush = new SolidBrush(Color.Red);
                    //Brush blackBrush = new SolidBrush(black);
                    Point shootPoint = p1List[p1List.Count-1];
                    Rectangle rect = new Rectangle(shootPoint.X, shootPoint.Y, 10, 10);

                    formGraphics.DrawEllipse(p, rect);

                    //formGraphics.DrawLine(p, p1List[p1List.Count - 1], p1List[p1List.Count]);
                    //Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void CreateBullet(List<Point> p1List)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            try
            {
                using (var p = new Pen(Color.Red, 5))
                {
                    Brush whiteBrush = new SolidBrush(Color.Red);
                    //Brush blackBrush = new SolidBrush(black);
                    Point shootPoint = p1List[p1List.Count - 1];
                    Rectangle rect = new Rectangle(shootPoint.X, shootPoint.Y, 10, 10);

                    formGraphics.DrawEllipse(p, rect);

                    //formGraphics.DrawLine(p, p1List[p1List.Count - 1], p1List[p1List.Count]);
                    //Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {

            }
        }


        private void ReplayForm_Load(object sender, EventArgs e)
        {
        }
        public void Clear()
        {
            this.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Clear();
            button1.Enabled = false;
            XYGraphButton.Enabled = false;
            shootPointButton.Enabled = false;
            clearButton.Enabled = false;
            GetXY();
            button1.Enabled = true;
            XYGraphButton.Enabled = true;
            shootPointButton.Enabled = true;
            clearButton.Enabled = true;

        }

        private void shootPointButton_Click(object sender, EventArgs e)
        {
            drawBullet = 1;
            GetXY();
            drawBullet = 0;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            
        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void XYGraphButton_Click(object sender, EventArgs e)
        {
            XYGraph xyGraph = new XYGraph(textFile,inputLine[1]);
            xyGraph.Visible = true;
        }
    }
}
