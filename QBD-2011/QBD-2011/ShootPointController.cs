using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QBD_2011
{
    public static class ShootPointController
    {
        public static ShootPointStatus controller = null;

        public static ShootPointStatus getController()
        {
            if (controller == null)
            {
                controller = new ShootPointStatus();
            }

            return controller;
        }

        public static void addPoint(Mrg.Point p)
        {
            if (controller != null)
            {
                controller.shots.Add(p);
            }
        }

        public static void resetPoint()
        {
            if (controller != null)
            {
                controller.resetPoint();
            }
        }

        public static void saveStatus(bool shotAffected)
        {
            if (controller != null)
            {
                controller.incrementShot(shotAffected, true);
            }
        }
    }
}
