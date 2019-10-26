using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QBD_2011
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm main = new MainForm();
            //if (main.vp.isConnected && main.serialPort.isPortConnected)
            //{
                Application.Run(main);
            //}
            //else
            //{
            //    main.Dispose();
            //    Application.Exit();
                
            //}
            //Application.Run(new ShootSettinsForm());
        }
    }
}
