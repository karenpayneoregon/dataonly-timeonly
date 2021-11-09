using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
             * This is default, will not compile in VS2019 but will with dotnet build or in VS Code
             */
            //ApplicationConfiguration.Initialize();

            /*
             * Add by Karen as per the above.
             */
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
