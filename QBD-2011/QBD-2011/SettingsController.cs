using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBD_2011
{
    public static class SettingsController
    {
        public static TimeSettingsForm tsf = null;
        public static ShootSettinsForm ssf = null;

        public static TimeSettingsForm getTimeSettingForm()
        {
            if (tsf == null)
            {
                tsf = new TimeSettingsForm();
            }

            return tsf;
        }

        public static ShootSettinsForm getShootSettingForm()
        {
            if (ssf == null)
            {
                ssf = new ShootSettinsForm();
            }

            return ssf;
        }
    }
}
