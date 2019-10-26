using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBD_2011
{
    public class Login
    {
        public static int loginOther = 0;
        public static int loginAdmin = 0;
        public static string BaNo = "";
        public static string ShooterName = "";
        public static string TraineeId = "";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Now { get; set; }
        public static string fileName = @"D:\Target-01-06\Target\kjhkh\QBD-2011\QBD-2011\";
    }
}
