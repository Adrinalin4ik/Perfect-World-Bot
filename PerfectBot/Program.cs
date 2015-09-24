using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PerfectBot
{

    class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        public static IntPtr PW;
        public static IntPtr PWWindowHandle;
        public static string PWWindowTitle; 



        public static void GetWindow()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (process.ProcessName == "elementclient")
                {
                   PWWindowTitle = process.MainWindowTitle;
                    PWWindowHandle = process.MainWindowHandle;

                }
            }
            Program.PW = FindWindow(null, Program.PWWindowTitle);
        }
    }
}
