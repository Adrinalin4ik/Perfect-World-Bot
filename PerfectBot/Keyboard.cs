using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput;
using System.Windows.Threading;
 
namespace PerfectBot
{
    class Keyboard
    {
        [DllImport("user32.dll")]
        public static extern int SendMessageA(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_WHEEL = 0x0800;
        private const int MOUSEEVENTF_XDOWN = 0x0080;
        private const int MOUSEEVENTF_XUP = 0x0100;
        ///summary>
        /// Virtual Messages
        /// </summary>
        public static bool d1;
        public static bool d2;
        public static bool d3;
        public static bool d4;
        public static bool d5;
        public static bool d6;
        public static bool d7;
        public static bool d8;
        public static bool d9;
        public static bool d0;
        public static bool f1;
        public static bool f2;
        public static bool f3;
        public static bool f4; 
        public static bool f5;
        public static bool f6;
        public static bool f7;
        public static bool f8;
        public static bool f9;
        public static bool f10; 

        public static int Sleepd1;
        public static int Sleepd2;
        public static int Sleepd3;
        public static int Sleepd4;
        public static int Sleepd5;
        public static int Sleepd6;
        public static int Sleepd7;
        public static int Sleepd8;
        public static int Sleepd9;
        public static int Sleepd0;
        public static int Sleepf1;
        public static int Sleepf2;
        public static int Sleepf3;
        public static int Sleepf4;
        public static int Sleepf5;
        public static int Sleepf6;
        public static int Sleepf7;
        public static int Sleepf8;
        public static int Sleepf9;
        public static int Sleepf10;

        public static int PauseBetweenSkills = 100;
        public static bool KeyPress = false;

        public static void MouseMove(uint x, uint y)
        {
            mouse_event(0x0001, x, y, 0, 0);
        }

        public enum WMessages : int
        {
            WM_LBUTTONDOWN = 0x201, //Left mousebutton down
            WM_LBUTTONUP = 0x202,  //Left mousebutton up
            WM_LBUTTONDBLCLK = 0x203, //Left mousebutton doubleclick
            WM_RBUTTONDOWN = 0x204, //Right mousebutton down
            WM_RBUTTONUP = 0x205,   //Right mousebutton up
            WM_RBUTTONDBLCLK = 0x206, //Right mousebutton doubleclick
            WM_KEYDOWN = 0x100,  //Key down
            WM_KEYUP = 0x101,   //Key up
            WM_CHAR = 0x0102,
            VK_RETURN = 0x0D,
        }
        public static Random r;
        public static void BattleKey()
        {
            if (d1 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D1, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D1, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd1);
            }
            if (d2 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D2, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D2, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd2);
            }
            if (d3 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D3, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D3, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd3);
            }
            if (d4 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D4, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D4, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd4);
            }
            if (d5 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D5, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D5, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd5);
            }
            if (d6 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D6, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D6, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd6);
            }
            if (d7 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D7, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D7, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd7);
            }
            if (d8 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D8, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D8, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd8);
            }
            if (d9 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D9, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D9, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd9);
            }
            if (d0 && Hero.target && !KeyPress)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D0, (IntPtr)0);
                Thread.Sleep(25);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D0, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
                Thread.Sleep(Sleepd0);
            }
            /*
            if (f1 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F1, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F1, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f2 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F2, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F2, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f3 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F3, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F3, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f4 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F4, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F4, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f5 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F5, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F5, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f6 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F6, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F6, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f7 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F7, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F7, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f8 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F8, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F8, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f9 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F9, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F9, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
            if (f10 && Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F10, (IntPtr)0);
                Thread.Sleep(Sleepd1);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F10, (IntPtr)0);
                Thread.Sleep(PauseBetweenSkills);
            }
             */
        }

        public static void TabKey()
        {
            if (!KeyPress && !MainWindow.isActive)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.Tab, (IntPtr)0);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.Tab, (IntPtr)0);
                Thread.Sleep(10);
            }
        }
        public static void pressKey(string key)
        {
            var task = Task.Factory.StartNew(() =>
                    {
                        if (!MainWindow.isActive)
                        {
                            KeyPress = true;

                            if (f1 && key == "F1")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F1, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F1, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf1);
                                KeyPress = false;
                            }
                            if (f2 && key == "F2")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F2, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F2, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf2);
                                KeyPress = false;
                            }
                            if (f3 && key == "F3")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F3, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F3, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf3);
                                KeyPress = false;
                            }
                            if (f4 && key == "F4")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F4, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F4, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf4);
                                KeyPress = false;
                            }
                            if (f5 && key == "F5")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F5, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F5, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf5);
                                KeyPress = false;
                            }
                            if (f6 && key == "F6")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F6, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F6, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf6);
                                KeyPress = false;
                            }
                            if (f7 && key == "F7")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F7, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F7, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf7);
                                KeyPress = false;
                            }
                            if (f8 && key == "F8")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F8, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F8, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf8);
                                KeyPress = false;
                            }
                            if (f9 && key == "F9")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F9, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F9, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf9);
                                KeyPress = false;
                            }
                            if (f10 && key == "F10")
                            {
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.F10, (IntPtr)0);
                                Thread.Sleep(25);
                                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.F10, (IntPtr)0);
                                Thread.Sleep(PauseBetweenSkills);
                                Thread.Sleep(Sleepf10);
                                KeyPress = false;
                            }
                        }
                    });
        }

    }
}
