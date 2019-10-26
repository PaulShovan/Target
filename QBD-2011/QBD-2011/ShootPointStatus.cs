using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QBD_2011
{
    public class ShootPointStatus
    {
        public ArrayList shots = null;
        public bool isDistanceDraw = false;
        public bool isCircleDraw = false;
        public int shotTaken;
        public int shotAffected;
        public bool isProjectLaser = true;
        public ArrayList shotPoint = null;
        public ArrayList shotRadius = null;
        public ArrayList shotTime = null;

        public ShootPointStatus()
        {
            shots = new ArrayList();
            shotPoint = new ArrayList();
            shotRadius = new ArrayList();
            shotTime = new ArrayList();
            shotTaken = 0;
            shotAffected = 0;
        }

        public void resetPoint()
        {
            shots.Clear();
            shotTaken = 0;
            shotAffected = 0;
            shotPoint.Clear();
            shotRadius.Clear();
            shotTime.Clear();
            TargetBoxController.getTargetBox().Invalidate();
        }

        public void incrementShotTaken()
        {
            shotTaken++;
        }

        public void incrementShotAffected()
        {
            shotAffected++;
        }

        public void outOfRadius()
        {
            shotAffected--;
        }
        public void incrementShot(bool sa, bool st)
        {
            if (sa) incrementShotAffected();
            if (st) incrementShotTaken();
        }

    }
}
