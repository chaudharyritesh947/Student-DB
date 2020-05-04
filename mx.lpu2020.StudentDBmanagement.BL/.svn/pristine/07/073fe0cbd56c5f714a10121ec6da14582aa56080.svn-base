using mx.lpu2020.StudentDB.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mx.lpu2020.StudentDBmanagment.UI
{
    static class Program
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // log.Info("ENTERED INTO MAIN FUNCTION. THE PROGRAM STARTS THE EXCECUTION");
            try
            {
                log.Info("IN THE MAIN FUNCTION");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new WelcomeForm());
                log.Info("EXITED THE MAIN FUNCTION");
            }
            catch (Exception exception)
            {
                log.Debug(exception.Message);
            }
        }
    }
}
