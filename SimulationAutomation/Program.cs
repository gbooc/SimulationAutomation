﻿using SimulationAutomation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static string userLog = string.Empty;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Views.MDIMain());
            //Application.Run(new FrmCalendarSetup());

            Application.Run(new Views.frmLogin());
            //Application.Run(new Views.FrmCustomerOrder());

        }
    }
}