using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace QBD_2011
{
    public partial class TargetBox : UserControl
    {
        private const int DEFAULT_NUMBER = 7;
        private const int SHOT_RADIUS = 6;

        private const int IMAGE_WIDTH = 640;
        private const int IMAGE_HEIGHT = 480;

        //now this values are given relatively but it have to accurate 
        private const int IMAGE_CENTER_X = 345;
        private const int IMAGE_CENTER_Y = 230;
        public float maxRadiusDistace = 0;

        private int width;
        private int height;
        public int centerX;
        public int centerY;
        public int radius;
        private int startX;
        private int startY;
        private int targetBoxWidth;
        private int targetBoxHeight;
        public bool isFullScreen = false;
        public int pr;
        public float distance;


        private int groupRadius = 0;
        private Mrg.Point groupMid;

        private Mrg.Point groupMidPoint1;
        private Mrg.Point groupMidPoint2;

        private int numberOfCircle;
        private ShootPointStatus shotInfo;
        public ArrayList tempPoints;


        public bool isDistanceDrawn = false;
        public bool isCircleDrawn = false;
        //public int[] shotRad;
        public int r;
        public ArrayList shotRadiusPoint;
        private TargetInfo ti;
        public static int divide = 0;
        public int startPointX = 0;
        public int endPointX = 0;
        public int startPointY = 0;
        public int endPointY = 0;
        public int regionDone = 0;
        public static int totalHits = 0;
        Point start;
        Point end;

        public TargetBox()
        {
            InitializeComponent();
            shotInfo = ShootPointController.getController();

            //Initializeing the contorl
            width = this.Width;
            height = this.Height;
            numberOfCircle = DEFAULT_NUMBER;
            shotRadiusPoint = new ArrayList();
            tempPoints = new ArrayList();
            groupMid = new Mrg.Point(0, 0);
            //shotRad = new int[50];
            calculateInfo();
        }
        public void setTargetInfo(TargetInfo t)
        {
            this.ti = t;
        }
        public void setNumberOfCircle(int i)
        {
            //checking that the number is beetween 3 to 11
            if (i >= 3 && i <= 11)
            {
                if (i % 2 == 0)
                {
                    i = i + 1;
                    numberOfCircle = i;
                }
                else
                {
                    numberOfCircle = i;
                }
                calculateInfo();
            }

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            
            //validation of the point accourding to the screen 
            validatePoints();
           
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

            //if (divide == 1)
            //{
            //    DivideCircle();
            //    divide = 0;
            //}
            //functions for various effects
            drawShootPoint(g);

            //Disposing brushes for freeing memory 
            
            g.Dispose();
            whiteBrush.Dispose();
            blackBrush.Dispose();
        }

        private void TargetBox_Resize(object sender, EventArgs e)
        {
            width = this.Width;
            height = this.Height;
            calculateInfo();
            //MessageBox.Show(radius.ToString());
            //MessageBox.Show(centerX.ToString() + " " + centerY.ToString());
        }
        //public void SetDivide()
        //{
        //    divide = 1;

        //}
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
        public void DivideCircle()
        {
            divide = 1;
            start.X = 375;
            start.Y = 0;
            end.X = width-375;
            end.Y = 0;
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            for (int i = 0; i < 10; i++)
            {
                using (var p = new Pen(Color.Red, 5))
                {
                    formGraphics.DrawLine(p, start, end);
                }
                if (i < 4)
                {
                    start.Y = start.Y + 206;
                    end.Y = end.Y + 206;
                }
                else if (i == 5)
                {
                    start.Y = 0;
                    start.X = 375;
                    end.X = 375;
                }
                else
                {
                    start.X = start.X + 206;
                    end.X = end.X + 206;
                }
            }
        }
        public void DrawRegion(int a, int b, int c, int d)
        {
            startPointX = a;
            endPointX = a + c;
            startPointY = b;
            endPointY = b + d;
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            using (var p = new Pen(Color.Blue, 5))
            {
                formGraphics.DrawRectangle(p, a, b,c,d);
            }
          
        }
        private void drawShootPoint(Graphics g)
        {
            Mrg.Point p;
            float x = 0;
            float y = 0;
            int gcx, gcy;
            Color darkRed = Color.FromArgb(139, 0, 0);
            Color red = Color.FromArgb(255, 0, 0);
            Color yellow = Color.Yellow;

            Brush redBrush = new SolidBrush(red);
            Pen redPen = new Pen(darkRed, 3);
            Pen yellowPen = new Pen(yellow, 2);
            Pen bluePen = new Pen(Color.Blue, 2);

            if (tempPoints != null)
            {
                for (int i = 0; i < tempPoints.Count; i++)
                {
                    p = (Mrg.Point)tempPoints[i];
                    string shootPoint = p.ToString();
                    //p = (Point)shotInfo.shots[i];
                    x = (float)p.getX();
                    y = (float)p.getY();
                    //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"G:\Target\kjhkh\QBD-2011\QBD-2011\ShootPoint.txt", true))
                    //{
                    //    file.WriteLine(x + ":" + y);
                    //}
                    distance = findDistance(new Mrg.Point(centerX, centerY), new Mrg.Point(x, y));

                    //MessageBox.Show(tempPoints[i].ToString());
                    //r = getCircleInfo(out gcx, out gcy);
                    if (x != -1 && y != -1)
                    {
                        //distance line
                        if (isDistanceDrawn)
                        {
                            g.DrawLine(yellowPen, centerX, centerY, x, y);
                        }
                        

                            g.FillEllipse(redBrush, x - SHOT_RADIUS, y - SHOT_RADIUS, 2 * SHOT_RADIUS, 2 * SHOT_RADIUS);
                            g.DrawEllipse(redPen, x - SHOT_RADIUS - 1, y - SHOT_RADIUS - 1, 2 * SHOT_RADIUS + 2, 2 * SHOT_RADIUS + 2);

                        if (divide == 1)
                        {
                            DivideCircle();
                            DrawRegion(startPointX, startPointY, endPointX - startPointX, endPointY - startPointY);
                            //int screenX = Convert.ToInt32((2.45*centerX - x - 485.75)/1.45);
                            //int screenY = Convert.ToInt32((y - 137.74 + 0.45 * centerY) / 1.42);
                            if ((x >= startPointX) && (x <= endPointX) && (y >= startPointY) && (y <= endPointY))
                            {
                                regionDone = 1;
                            }
                        }
                    }
                    else
                    {
                        //ShootPointController.getController().shotPoint.Add(0.0);
                    }
                }



                r = getCircleInfo(out gcx, out gcy);
                ///-----------------------
                //pr = (int)(10 - ((((float)r) / radius) * 10));
                //MessageBox.Show("Debug:: R" + r.ToString() + "Po: " + pr.ToString());


                if (isCircleDrawn)
                {

                    //the GROUP_RADIUS is trun-off


                    //g.DrawEllipse(bluePen, gcx - r, gcy - r, 2 * r, 2 * r);
                    
                    
                    
                    //MessageBox.Show(gcx.ToString() + " x<>y " + gcy.ToString() + "r " + r.ToString());
                    //float ptttt = findDistance(new Point(-2,-3), new Point(-4,4));
                    //MessageBox.Show("dist"+ r.ToString());

                    if (tempPoints.Count > 2 &&  isInsideCircle((Mrg.Point)tempPoints[tempPoints.Count - 1], new Mrg.Point(gcx, gcy), r))
                    {
                        //MessageBox.Show("In");
                    }
                    else
                    {
                        //MessageBox.Show("Out");
                    }
                }//isCircelDrawn
            }

            redBrush.Dispose();
            redPen.Dispose();
            yellowPen.Dispose();
            bluePen.Dispose();
        }

        public void validatePoints()
        {
            tempPoints.Clear();

            int imageX = 0;
            int imageY = 0;
            float relativeX = 0;
            float relativeY = 0;
            float filterX = 0;
            float filterY = 0;
            Mrg.Point p = new Mrg.Point(-1, -1);
            int mirroredX = 0;
            int sPointX = 0;
            int sPointY = 0;

            for (int i = 0; i < shotInfo.shots.Count; i++)
            {
                //calculation for validated point

                //getting original image x, y
                p = (Mrg.Point)shotInfo.shots[i];
                string po = p.ToString();
                imageX = (int)p.getX() + 360;//335
                imageY = (int)p.getY() + 60;//+97



                relativeX = imageX - centerX;
                relativeX = relativeX * 1.40f;//1.45

                //------------
                relativeY = imageY - centerY;
                relativeY = relativeY * 1.60f;//1.42
                imageY = (int)relativeY + centerY;
                //------

                imageX = (int)(centerX + relativeX);
                if (imageX > centerX)
                {
                }
                else
                {
                    imageX = imageX - 15;
                }
                if (isFullScreen == true)
                {

                    imageX = (int)p.getX() + 360;//335
                    imageY = (int)p.getY() + 60 + 43;//+97

                    relativeX = imageX - centerX;
                    relativeX = relativeX * 1.636f;//1.636
                    imageX = (int)(centerX + relativeX);
                    //------------
                    relativeY = imageY - centerY;
                    relativeY = relativeY * 1.604f;//1.604
                    imageY = (int)relativeY + centerY;
                    //------
                    
                    
                    /*
                    Point centerPoint = new Point(0, 0);
                    Point result = new Point(imageX - centerX, imageY - centerY);
                    double distance = Math.Sqrt(Math.Pow((centerPoint.getX() + result.getX()), 2) + Math.Pow((centerPoint.getY() + result.getY()), 2));
                    double angle = Angle(centerPoint.getX(), centerPoint.getY(), result.getX(), result.getY());
                    distance = distance * 1.13f;

                    imageX = (int)centerPoint.getX() + (int)Math.Round(distance * Math.Cos(angle));
                    imageY = (int)centerPoint.getY() + (int)Math.Round(distance * Math.Sin(angle));
                    //imageY += 40;

                    imageX += centerX;
                    imageY += centerY;

                    */

                }
                float distance = findDistance(new Mrg.Point(imageX, imageY), new Mrg.Point(centerX, centerY));
                //MessageBox.Show(distance.ToString() + ">" + radius.ToString());
                if(distance <= radius)
                {
                    tempPoints.Add(new Mrg.Point(imageX, imageY));
                    ShootPointController.getController().shotAffected = tempPoints.Count;
                    ti.setShotLabelInfo(ShootPointController.getController().shotAffected, ShootPointController.getController().shotTaken);
                    
                }
                /*
                mirroredX = getMirrorX(p);

                relativeX = ((float)targetBoxWidth / IMAGE_WIDTH) * mirroredX;
                relativeY = ((float)targetBoxHeight / IMAGE_HEIGHT) * imageY;

                //filter x is the final x,y with paddiing added

                filterX = startX + relativeX;
                filterY = startY + relativeY;
                
                tempPoints.Add(new Point(filterX, filterY));
                */


                //Debbug Messages
                string str = string.Format("x {0} y {1}\nrx {2} ry {3}\nfx {4} fy {5}\n", imageX.ToString(), imageY.ToString(), relativeX.ToString(), relativeY.ToString(), filterX.ToString(), filterY.ToString());
                str += string.Format("tbw {0} tbh {1} \nih {2} iw {3}\n", targetBoxWidth.ToString(), targetBoxHeight.ToString(), IMAGE_WIDTH.ToString(), IMAGE_HEIGHT.ToString());
                str += string.Format("sx {0} sy{1}\nmx{2}\n", startX.ToString(), startY.ToString(), mirroredX.ToString());
                str += string.Format("cx {0}, cy{1}", centerX.ToString(), centerY.ToString());
                //MessageBox.Show(str);
            }

        }//validate point

        private int getMirrorX(Mrg.Point retPoint)
        {
            double mirrorPointX = 0;
            double pointX = 0;

            mirrorPointX = retPoint.getX();
            pointX = mirrorPointX;
            //double difference = mirrorPointX - IMAGE_CENTER_X;
            //if (difference > 0)
            //{
            //    pointX = IMAGE_CENTER_X - (mirrorPointX - IMAGE_CENTER_X);
            //    //MessageBox.Show("SHOW");
            //}
            //else
            //{
            //    pointX = IMAGE_CENTER_X + (IMAGE_CENTER_X - mirrorPointX);
            //}

            return (int)pointX;
        }

//----------------------------------------------------------------------------------------------------------------------------------
        public int getCircleInfo(out int x, out int y)
        {

            Mrg.Point newRadiusPoint;
            float newRadiusDistance = 0;
            maxRadiusDistace = 0;
            int pr = 0;
            
            
            if (tempPoints.Count == 0)
            {
                x = 0;
                y = 0;
                groupRadius = 0;
                return groupRadius;
            }

            if (tempPoints.Count == 1)
            {
                Mrg.Point p = (Mrg.Point)tempPoints[0];
                x = (int)p.getX();
                y = (int)p.getY();
                groupRadius = 10;
                shotRadiusPoint.Add(10);
                //ShootPointController.getController().shotRadius.Add(groupRadius);
                
                return groupRadius;

            }


           
            if (tempPoints.Count == 2)
            {
                Mrg.Point p1 = (Mrg.Point)tempPoints[0];
                Mrg.Point p2 = (Mrg.Point)tempPoints[1];
                groupMidPoint1 = p1;
                groupMidPoint2 = p2;

                groupMid = findCenterPoint(p1, p2);
                x = (int)groupMid.getX();
                y = (int)groupMid.getY();
                float d = findDistance(p1, p2);
                groupRadius = (int)(d / 2.0);
                //pr = (int)(10 - ((float)(groupRadius / radius) * 10));
                
                //ShootPointController.getController().shotRadius.Add(pr);
                int point =(int) (groupRadius * (10.0 / 81.75)); // 272.5
                shotRadiusPoint.Add(point);
                return groupRadius;
            }


            Mrg.Point tempPoint = new Mrg.Point();
            groupRadius = calculateRectangle(out tempPoint);
            x = (int)tempPoint.getX();
            y = (int)tempPoint.getY();

            #region blokced codes
            /*
            for(int i=0; i<tempPoints.Count; i++)
            {
                for(int j=0; j < tempPoints.Count; j++)
                {
                    newRadiusDistance = findDistance((Point)tempPoints[i], (Point)tempPoints[j]);

                    if (newRadiusDistance > maxRadiusDistace)
                    {
                        maxRadiusDistace = newRadiusDistance;
                        groupMidPoint1 = (Point)tempPoints[i];
                        groupMidPoint2 = (Point)tempPoints[j];

                    }
                }
                
            }//end of for
            groupMid = findCenterPoint(groupMidPoint1, groupMidPoint2);
            */

            /*
            Point latestPoint = (Point)tempPoints[tempPoints.Count - 1];

            float maxRadius = 0;
            float newMaxRadius = 0;
            int maxRadiusIndex = 0;
             * 
            if (isInsideCircle(latestPoint, this.groupMid, groupRadius))
            {
                //MessageBox.Show("Inside");
                x = (int)groupMid.getX();
                y = (int)groupMid.getY();

                return groupRadius;

            }
            else
            {
                
                for (int i = 0; i < tempPoints.Count - 1; i++)
                {
                    newMaxRadius = findDistance(latestPoint, (Point)tempPoints[i]);

                    if (newMaxRadius > maxRadius)
                    {
                        maxRadius = newMaxRadius;
                        maxRadiusIndex = i;
                    }

                }

                groupMidPoint2 = latestPoint;
                groupMidPoint1 = (Point)tempPoints[maxRadiusIndex];
                newRadiusPoint = findCenterPoint(groupMidPoint2, groupMidPoint1);
                newRadiusDistance = findDistance(groupMidPoint2, groupMidPoint1) / 2;
            */

                /* 
               
                //MessageBox.Show("Outside");
                
                float distance1, distance2;

                distance1 = findDistance(latestPoint, groupMidPoint1);
                distance2 = findDistance(latestPoint, groupMidPoint2);
                


                if (distance1 > distance2)
                {
                    newRadiusPoint = findCenterPoint(groupMidPoint1, latestPoint);
                    newRadiusDistance = findDistance(groupMidPoint1, latestPoint) / 2;
                    
                }
                else
                {
                    newRadiusPoint = findCenterPoint(groupMidPoint2, latestPoint);
                    newRadiusDistance = findDistance(groupMidPoint2, latestPoint) / 2;
                    groupMidPoint1 = groupMidPoint2;
                }
            }
            */

            //x = (int)groupMid.getX();
            //y = (int)groupMid.getY();
            //groupRadius = (int)maxRadiusDistace/2;
            //groupMidPoint2 = latestPoint;
            #endregion

            int radiusPoint = (int)(groupRadius * (10.0 / 272.5));
            shotRadiusPoint.Add(radiusPoint);
            return groupRadius;

            
        }
//------------------------------------------------------------------------------------------------------------------
        private bool isInsideCircle(Mrg.Point testPoint, Mrg.Point midPoint, float radius)
        {
            float dist = findDistance(testPoint, midPoint);

            if (dist < radius) return true;

            return false;
        
        }       
        
        public float findDistance(Mrg.Point p1, Mrg.Point p2)
        {
            double x = p1.getX() - p2.getX();
            double y = p1.getY() - p2.getY();

            x = Math.Pow(x, 2);
            y = Math.Pow(y, 2);

            float distance = (float)Math.Sqrt(x + y);

            return distance;
        }

        private Mrg.Point findCenterPoint(Mrg.Point p1, Mrg.Point p2)
        {
            double midX = (p1.getX() + p2.getX()) / 2.0;
            double midY = (p1.getY() + p2.getY()) / 2.0;

            return new Mrg.Point(midX, midY);
        }

        public double Angle(double px1, double py1, double px2, double py2)
        {

            // Negate X and Y values
            double pxRes = px2 - px1;

            double pyRes = py2 - py1;
            double angle = 0.0;

            // Calculate the angle
            if (pxRes == 0.0)
            {
                if (pxRes == 0.0)

                    angle = 0.0;
                else if (pyRes > 0.0) angle = System.Math.PI / 2.0;

                else
                    angle = System.Math.PI * 3.0 / 2.0;

            }
            else if (pyRes == 0.0)
            {
                if (pxRes > 0.0)

                    angle = 0.0;

                else
                    angle = System.Math.PI;

            }

            else
            {
                if (pxRes < 0.0)

                    angle = System.Math.Atan(pyRes / pxRes) + System.Math.PI;
                else if (pyRes < 0.0) angle = System.Math.Atan(pyRes / pxRes) + (2 * System.Math.PI);

                else
                    angle = System.Math.Atan(pyRes / pxRes);

            }

            //convert to dergee
            angle = angle * 180 / System.Math.PI; return angle;
        }//function



        private int calculateRectangle(out Mrg.Point gcMidPoint)
        {
            int minX = 10000, maxX = 0;
            int minY = 10000, maxY = 0;

            Mrg.Point minXPoint = new Mrg.Point();
            Mrg.Point minYPoint = new Mrg.Point();
            Mrg.Point maxXPoint = new Mrg.Point();
            Mrg.Point maxYPoint = new Mrg.Point();

            //tempPoints
            //shotInfo.shots.Count
            for (int i = 0; i < tempPoints.Count; i++)
            {
                for (int j = 0; j < tempPoints.Count; j++) 
                {
                    Mrg.Point p = (Mrg.Point)tempPoints[i];

                    if (p.getX() > maxX)
                    {
                        maxX = (int)p.getX();
                        maxXPoint = p;
                    }
                    if (p.getX() < minX)
                    {
                        minX = (int)p.getX();
                        minXPoint = p;
                    }

                    if (p.getY() > maxY)
                    {
                        maxY = (int)p.getY();
                        maxYPoint = p;
                    }
                    if (p.getY() < minY)
                    {
                        minY = (int)p.getY();
                        minYPoint = p;
                    }
                                      
                }//nesed for
              
            }//outee for


            int diffX = 0;
            int diffY = 0;
            int gcradius = 0;
            Mrg.Point gcmidPoint;
            diffX = maxX - minX;
            diffY = maxY - minY;

            if (diffX > diffY)
            {
                gcradius = (int)(findDistance(maxXPoint, minXPoint) / 2.0);
                gcmidPoint = findCenterPoint(maxXPoint, minXPoint);
            }
            else
            {
                gcradius = (int)(findDistance(maxYPoint, minYPoint)/ 2.0);
                gcmidPoint = findCenterPoint(maxYPoint, minYPoint);
            }
            //for cheking
            for (int i = 0; i < tempPoints.Count; i++)
            {
                if (!isInsideCircle((Mrg.Point)tempPoints[i], gcmidPoint, gcradius))
                {
                    gcradius = (int)(findDistance((Mrg.Point)tempPoints[i], gcmidPoint));
                }
            }
            gcMidPoint = gcmidPoint;
            string str = string.Format("mx {0}, my {1}\nminx {2} miny {3}", maxX.ToString(), maxY.ToString(), minX.ToString(), minY.ToString());
            str += string.Format("\nradius: {0} midPoint {1}", gcradius.ToString(), gcmidPoint.ToString());
            //MessageBox.Show(str);
            return gcradius;
        
        }

        private void TargetBox_Load(object sender, EventArgs e)
        {

        }//funciton calculateRect
    }//calss
}//namespace
