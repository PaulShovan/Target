using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBD_2011
{
    public static class TargetBoxController
    {
        public static TargetBox tb = null;
        private static int currentSize = 7;

        //Preventing for calling constructor

        public static void setTargetBox(TargetBox targetBox)
        {
            if (tb == null) { tb = targetBox; }
        }
        public static TargetBox getTargetBox()
        {
            if (tb == null)
            {
                tb = new TargetBox();
                return tb;
            }
            return tb;
        }

        public static void closeTargerBox()
        {
            if (tb != null)
            {
                tb = null;
            }
        }

        public static void incrementCircle()
        {
            if (currentSize <= 9)
            {
                currentSize += 2;
                tb.setNumberOfCircle(currentSize);
            }
        }

        public static void decrementCircle()
        {
            if (currentSize >= 5)
            {
                currentSize -= 2;
                tb.setNumberOfCircle(currentSize);
            }
        }

        public static void livaView()
        {
            currentSize = 7;
            tb.setNumberOfCircle(currentSize);
        }


        public static void zeroing()
        {
            if (currentSize != 11)
            {
                currentSize = 11;
                tb.setNumberOfCircle(currentSize);
            }
        }
        public static void SnapShooting()
        {
            tb.DivideCircle();
        }
        public static void SelectRegion(int a, int b, int c, int d)
        {
            tb.DrawRegion(a,b,c,d);
        }
    }
}
