using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SupportAlerter
{
    static class Program
    {
        public static SupportAlerter supportAlerter;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegistrySettings.getInstance(); //prepare registry
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            supportAlerter = new SupportAlerter();
            Application.Run(supportAlerter);
        }

    }
}
