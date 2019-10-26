using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Reflection;


using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

namespace QBD_2011
{
    public class LaserDetect
    {
        private Mrg.Point point;
        //private AForge.Point point;
        private int xPos, yPos;
        public ColorFiltering colorFilter;
        Color c;


        public LaserDetect()
        {
            point = new Mrg.Point(-1, -1);
            //point = new AForge.Point(-1, -1);
            xPos = yPos = 0;
            colorFilter = new ColorFiltering();

            colorFilter.Red = new IntRange(150, 255);//150, 180
            colorFilter.Green = new IntRange(50, 120);//0,90
            colorFilter.Blue = new IntRange(80, 220);//0,100
        }

        public Mrg.Point ProcessFrame(ref Bitmap image, out Color returnColor)
        {

            Bitmap bitmap = new Bitmap(image);
            //Bitmap bitmap = image;
            point = new Mrg.Point(-1, -1);
            //point = new AForge.Point(-1, -1);

            //currently not needed
            BitmapData bitmapData = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite, bitmap.PixelFormat);


            //ColorFiltering colorFilter = new ColorFiltering();


            colorFilter.FillOutsideRange = true;

            colorFilter.ApplyInPlace(bitmapData);

            bitmap.UnlockBits(bitmapData);

            //previous function findPoint()
            bool found = false;
            //bool found = true;

            Graphics g = Graphics.FromImage(image);
            Pen bluePen = new Pen(Color.Blue, 2);


            Color black = Color.FromArgb(0, 0, 0);


            for (int i = 120; i < 560; i += 4)// 0-120 >(tatgetbox)< 550 - inf
            {
                for (int j = 0; j < bitmap.Height; j += 5)
                {
                    c = bitmap.GetPixel(i, j);
                    //MessageBox.Show("i:" + i.ToString() + "j:" + j.ToString() + "> " + c.R.ToString() + "-" + c.G.ToString() + "-" +c.B.ToString());
                    //if ((c.R >= 150 && c.R <= 255) && (c.G >= 0 && c.G <= 255) && (c.B >= 0 && c.B <= 255))
                    if ((c.R >= colorFilter.Red.Min && c.R <= colorFilter.Red.Max) && (c.G >= colorFilter.Green.Min && c.G <= colorFilter.Green.Max) && (c.B >= colorFilter.Blue.Min && c.B <= colorFilter.Blue.Max))
                    {
                        found = true;
                        xPos = i;
                        yPos = j;
                        point.setXY(i, j);
                    }
                    returnColor = Color.FromArgb(255, 0, 0, 0);
                    if (found == true)
                    {
                        //g.DrawEllipse(bluePen, i - 5, j - 5, 10, 10);
                        Pen p = new Pen(Color.Yellow, 1);
                        g.DrawLine(p, 0, yPos, image.Width, yPos); // Draw yellow horizontal line
                        g.DrawLine(p, xPos, 0, xPos, image.Height); // Draw yellow vertical line

                        Font drawFont = new Font("Arial", 12);
                        SolidBrush drawBrush = new SolidBrush(Color.White);
                        string str = "X: " + xPos.ToString() + ",   Y: " + yPos.ToString();
                        g.DrawString(str, drawFont, drawBrush, new PointF(5, 5));
                        g.Dispose();
                        break;
                    }
                }//for
                if (found == true) break;
            }//for-main
            returnColor = c;
            return point;
        }//func

        
    }
}
