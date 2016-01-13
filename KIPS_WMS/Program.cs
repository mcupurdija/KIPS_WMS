using System;
using System.Windows.Forms;
using KIPS_WMS.UI;

namespace KIPS_WMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new Meni());
        }
    }
}