using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QBD_2011
{
    public static class Loading
    {
        static LoadingForm loadingFrom = null;

        public static void ShowLoadingScreen()
        {
            if (loadingFrom == null)
            {
                loadingFrom = new LoadingForm();
                loadingFrom.ShowLoadingScreen();
            }
        }

        public static void CloseLoadingScreen()
        {
            if (loadingFrom != null)
            {
                loadingFrom.CloseLoadingScreen();
                loadingFrom = null;
            }
        }

        public static void UdpateStatusText(string Text)
        {
            if (loadingFrom != null)
                loadingFrom.UdpateStatusText(Text);

        }
    }
}
