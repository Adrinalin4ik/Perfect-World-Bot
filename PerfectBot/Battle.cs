using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Threading.Tasks;
using WindowsInput;
namespace PerfectBot 
{
    class Battle
    {
        [DllImport("user32.dll")]
        public static extern int SendMessageA(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }
        /// <summary>
        /// Retrieves the cursor's position, in screen coordinates.
        /// </summary>
        /// <see>See MSDN documentation for further information.</see>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)

            return lpPoint;
        }


        public static int HealHp, HealMp; 
        
        public static bool check = false;
        public static bool Ready = true;

        public static void TestWalk()
        {
            if (Hero.target)
            {
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.D2, (IntPtr)0);
                Thread.Sleep(1000);
                SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.D2, (IntPtr)0);
            }
            else SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYDOWN, (IntPtr)System.Windows.Forms.Keys.Tab, (IntPtr)0);
            Thread.Sleep(1000);
            SendMessageA(Program.PW, (int)Keyboard.WMessages.WM_KEYUP, (IntPtr)System.Windows.Forms.Keys.Tab, (IntPtr)0);
        }
        public static void battle()
        {
            Restoration();
            
            if (Ready)
            {
                if (Hero.target)
                {
                    MeditationOff();
                    var task = Task.Factory.StartNew(() =>
                    {
                        Hero.Status = "in battle";
                        Keyboard.BattleKey();
                    });
                }
                else
                {
                    //isLooting = false;
                    if (!isLooting)
                    {
                        Hero.ExpCounter();
                        MeditationOff();
                        mCheck = false;
                        Hero.Status = "finding target";
                        Keyboard.TabKey();
                    }

                }
            }

        }
        public static bool CheckHp = false, CheckMp=false;

        public static void Restoration()
        {
            int Hp, Mp,FullHp = 99,FullMp = 99;
            
            Hp = Hero.CurrentHp; 
            Mp = Hero.CurrentMp;

            if (Hero.target) Ready = true;
            
            if (Hero.CurrentHp > 80 && Hero.CurrentMp>80 && !Hero.target)
            {
                loot();
            }

            if (Hp < HealHp && !Hero.target)
            {
                Ready = false;
                Hero.Status = "HP restoration";
                Keyboard.pressKey("F5");  //HealHpFlask
                meditation();
                CheckHp = true;
            }
            else
            {
                //MeditationOff();
               // Ready = true;
            }


            if (Mp < HealMp && !Hero.target)
            {
                Ready = false;
                Hero.Status = "MP restoration";
                Keyboard.pressKey("F6");  //HealMpFlask
                meditation(); 
                CheckMp = true;
            }
            else
            {
                //MeditationOff();
               // Ready = true;
            }

            if (Hp >= FullHp && Mp >= FullMp)
            {
                Ready = true;
                CheckHp = false;
                CheckMp = false;
            }
            else
            {
                if (CheckHp) Keyboard.pressKey("F5");
                if (CheckMp) Keyboard.pressKey("F6");
            }
            
        }
        public static bool isLooting = false;
        public static bool loot()
        {
            if (Hero.CurrentHp > 50 && Hero.CurrentMp>30 && !Hero.target && Hero.lutCounter>0 && !MainWindow.isActive && !isLooting)
            {
                var task = Task.Factory.StartNew(() =>
                    {
                        isLooting = true;
                        do
                        {
                            Hero.Status = "looting";
                            Keyboard.pressKey("F8");
                            mCheck = false;
                            Thread.Sleep(1000);
                        } while (Hero.lutCounter > 0 || !MainWindow.isActive);

                        isLooting = false;
                    }); 
                return true;
            }
            return false;
            
        }
        public static bool mCheck=false;
        public static bool meditation()
        {

                if (Hero.CurrentHp <= 95 && !mCheck)
                {
                    mCheck = true;
                    Keyboard.pressKey("F7");
                    return true;
                }
                else
                {
                    if (healthFull() && Hero.Meditation)
                    {
                        Keyboard.pressKey("F7");
                        mCheck = false;
                    }
                }

                if (Hero.CurrentMp <= 95 && !mCheck)
                {
                    mCheck = true;
                    if (!Hero.Meditation)
                    {
                        Keyboard.pressKey("F7");
                    }
                    return true;
                }
                else
                {
                    if (healthFull() && Hero.Meditation)
                    {
                        Keyboard.pressKey("F7");
                        mCheck = false;
                    }
                
            }
            return false;
        } 
        public static bool meditationOn() 
        {
            if (!Hero.Meditation)
            {
                Keyboard.pressKey("F7");
            }
            return true;
        }

        public static bool healthFull()
        {
            if (Hero.CurrentHp >= 95 && Hero.CurrentMp >= 95)
            {
                return true;
            }
            return false;
        }
        public static void MeditationOff()
        {
            if (Hero.Meditation)
            {
                Keyboard.pressKey("F7");
            }
        }

        
    }
}
