using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Security.Principal;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PerfectBot
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
    /// 
	public partial class MainWindow : Window
	{
        double version = 1.1;
        
        static Memory m = new Memory();
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        DateTime time = new DateTime();
        public static bool isActive;
        public static bool Pause = false;

		public MainWindow()
		{
			this.InitializeComponent();
            // Insert code required on object creation below this point.
            #region AdministrationRights
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
            if (hasAdministrativeRight == false)
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(); //создаем новый процесс
                processInfo.Verb = "runas"; //в данном случае указываем, что процесс должен быть запущен с правами администратора
                processInfo.FileName = "PerfectBot.exe"; //указываем исполняемый файл (программу) для запуска
                try
                {
                    Process.Start(processInfo); //пытаемся запустить процесс
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    //Ничего не делаем, потому что пользователь, возможно, нажал кнопку "Нет" в ответ на вопрос о запуске программы в окне предупреждения UAC (для Windows 7)
                }
                Process.GetCurrentProcess().Kill(); //закрываем текущую копию программы (в любом случае, даже если пользователь отменил запуск с правами администратора в окне UAC)
            }
            else //имеем права администратора, значит, стартуем
            {
            }
            #endregion AdministrationRights
            readSettings();
            Greeting();
        }

        public void StartTimers()
        {
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (!Pause)
            {
                refreshControls();
                Battle.battle();
            }

            
        }
        #region FormActive
        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            saveLog();
            saveSettings();
            Process.GetCurrentProcess().Kill();
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion FormActive
        private void Button_Click_1(object sender, RoutedEventArgs e)//StartButton
        {
            KeyCheck();
            m.GetProcess("elementclient");
            StartTimers();
            Program.GetWindow();
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e) //StopButton
        {
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            timer.IsEnabled = false;
        }

        public void RefreshValue()
        {
            Hero.CurrentHp = m.ReadMemory(offsets.baseAddress, offsets.CurrentHP);
            Hero.CurrentMp = m.ReadMemory(offsets.baseAddress, offsets.CurrentMP);
            Hero.FullHp = m.ReadMemory(offsets.baseAddress, offsets.FullHP);
            Hero.FullMp = m.ReadMemory(offsets.baseAddress, offsets.FullMP);
            Hero.lvl = m.ReadMemory(offsets.TargetBaseAddress, offsets.lvl); 
            Hero.CurrentExp = m.ReadMemory(offsets.TargetBaseAddress, offsets.CurrentExp);
            #region Meditation
            if (m.ReadMemory(offsets.TargetBaseAddress, offsets.Meditation) == 32768)
            {
                Hero.Meditation = false;
            }
            else Hero.Meditation = true;
            
            #endregion Meditation
            #region Position
            Hero.PosX = m.ReadMemory(offsets.baseAddress, offsets.PosX);
            Hero.PosY = m.ReadMemory(offsets.baseAddress, offsets.PosY);
            Hero.PosZ = m.ReadMemory(offsets.baseAddress, offsets.PosZ);

            Hero.TPosX = m.ReadMemory(offsets.TargetBaseAddress, offsets.TPosX);
            Hero.TPosY = m.ReadMemory(offsets.TargetBaseAddress, offsets.TPosY);
            Hero.TPosZ = m.ReadMemory(offsets.TargetBaseAddress, offsets.TPosZ);
            #endregion Position
            Hero.WeaponStrength = m.ReadMemory(offsets.TargetBaseAddress, offsets.WeaponStrength);
            Hero.MaxWeaponStrength = m.ReadMemory(offsets.TargetBaseAddress, offsets.MaxWeaponStrength);
            Hero.lutCounter = m.ReadMemory(offsets.TargetBaseAddress, offsets.lutCounter);
            #region Target
            Hero.targetId = m.ReadMemory(offsets.TargetBaseAddress, offsets.Target);
            if (m.ReadMemory(offsets.TargetBaseAddress, offsets.Target) != 0)
            {
                Hero.target = true;
            }
            else Hero.target = false;
            #endregion Target
            //TESTLABEL 
            Hero.Test = m.ReadMemory(offsets.baseAddress, offsets.Test);
            //TESTLABEL
        }

        public void refreshControls()
        {


            RefreshValue();
            UpdateList();

            if (Window.IsActive) { isActive = true; } else isActive = false;
 

            HpProgressBar.Maximum = Hero.FullHp;
            HpProgressBar.Value = Hero.CurrentHp;

            MpProgressBar.Maximum = Hero.FullMp;
            MpProgressBar.Value = Hero.CurrentMp;
            ValueHpBar.Content = Convert.ToInt32((HpProgressBar.Value / HpProgressBar.Maximum) * 100)+ " %";
            ValueMpBar.Content = Convert.ToInt32((MpProgressBar.Value / MpProgressBar.Maximum) * 100)+ " %";
            Hero.CurrentHp = Convert.ToInt32((HpProgressBar.Value / HpProgressBar.Maximum) * 100);
            Hero.CurrentMp = Convert.ToInt32((MpProgressBar.Value / MpProgressBar.Maximum) * 100);
           // ValueHpBar.Content = Convert.ToString(Hero.CurrentHp + "/" + Hero.FullHp); 
           // ValueMpBar.Content = Convert.ToString(Hero.CurrentMp + "/" + Hero.FullMp);

            labelPozX.Content = Convert.ToString(Hero.PosX);
            labelPozY.Content = Convert.ToString(Hero.PosY);
            labelPozZ.Content = Convert.ToString(Hero.PosZ);
            TlabelPozX.Content = Convert.ToString(Hero.TPosX);
            TlabelPozY.Content = Convert.ToString(Hero.TPosY);
            TlabelPozZ.Content = Convert.ToString(Hero.TPosZ);

            targetLabel.Content = Convert.ToString(Hero.target);
            WeaponLabel.Content = Convert.ToString(Hero.WeaponStrength + "/" + Hero.MaxWeaponStrength);
            TIdLabel.Content = Convert.ToString(Hero.targetId);
            ExpCountLabel.Content = Hero.ExpCount;
            StatusLabel.Content = Hero.Status;
            KillLabel.Content = Hero.MobCounter;
            LvlLabel.Content = Hero.lvl;
            LutCountLabel.Content = Hero.lutCounter;
            //ListBox1.Items.Add(Hero.Status);

            testLabel.Content = Convert.ToString(Hero.CurrentExp);
        }
        string SaveStatus;
        public bool UpdateList() 
        {
            if (Hero.Status != SaveStatus)
            {
                ListBox1.Items.Insert(0, "");
                if (Hero.target)
                {
                    ListBox1.Items.Insert(0, ">> HP " + Hero.CurrentHp + " " + "MP " + Hero.CurrentMp);
                }
                else { 
                   // Hero.ExpCounter(); 
                    ListBox1.Items.Insert(0, ">> Exp gained: " + Hero.GainExp);
                    ListBox1.Items.Insert(0, ">>--------------------------------<<");
                     }
                ListBox1.Items.Insert(0, ">> " + Hero.Status);
                ListBox1.Items.Insert(0, ">> " + CurrentTime() + " <<");
                
            }
            SaveStatus = Hero.Status;

            return false;
        }
        public string CurrentTime()
        {
            time = DateTime.Now;
            return Convert.ToString(time.Hour + ":" + time.Minute+":"+time.Second);
        }
        private void Greeting()
        {
            
            ListBox1.Items.Add("PerfectBot version: " + version);
            ListBox1.Items.Add("Administration is not responsibility");
            ListBox1.Items.Add("for your account");
            ListBox1.Items.Add("Time "+CurrentTime());
        }
        private void KeyCheck()
        {
            if (checkBox1.IsChecked == true)
            {
                Keyboard.d1 = true;
                Keyboard.Sleepd1 = Convert.ToInt32(SkillSleep1.Text);
            }
            else Keyboard.d1 = false;

            if (checkBox2.IsChecked == true)
            {
                Keyboard.d2 = true;
                Keyboard.Sleepd2 = Convert.ToInt32(SkillSleep2.Text);
            }
            else Keyboard.d2 = false;
            if (checkBox3.IsChecked == true)
            {
                Keyboard.d3 = true;
                Keyboard.Sleepd3 = Convert.ToInt32(SkillSleep3.Text);
            }
            else Keyboard.d3 = false;
            if (checkBox4.IsChecked == true)
            {
                Keyboard.d4 = true;
                Keyboard.Sleepd4 = Convert.ToInt32(SkillSleep4.Text);
            }
            else Keyboard.d4 = false;
            if (checkBox5.IsChecked == true)
            {
                Keyboard.d5 = true;
                Keyboard.Sleepd5 = Convert.ToInt32(SkillSleep5.Text);
            }
            else Keyboard.d5 = false;
            if (checkBox6.IsChecked == true)
            {
                Keyboard.d6 = true;
                Keyboard.Sleepd6 = Convert.ToInt32(SkillSleep6.Text);
            }
            else Keyboard.d6 = false;
            if (checkBox7.IsChecked == true)
            {
                Keyboard.d7 = true;
                Keyboard.Sleepd7 = Convert.ToInt32(SkillSleep7.Text);
            }
            else Keyboard.d7 = false;
            if (checkBox8.IsChecked == true)
            {
                Keyboard.d8 = true;
                Keyboard.Sleepd8 = Convert.ToInt32(SkillSleep8.Text);
            }
            else Keyboard.d8 = false;
            if (checkBox9.IsChecked == true)
            {
                Keyboard.d9 = true;
                Keyboard.Sleepd9 = Convert.ToInt32(SkillSleep9.Text);
            }
            else Keyboard.d9 = false;
            if (checkBox10.IsChecked == true)
            {
                Keyboard.d0 = true;
                Keyboard.Sleepd0 = Convert.ToInt32(SkillSleep10.Text);
            }
            else Keyboard.d0 = false;
            if (checkBox11.IsChecked == true)
            {
                Keyboard.f1 = true;
                Keyboard.Sleepf1 = Convert.ToInt32(SkillSleep11.Text);
            }
            else Keyboard.f1 = false;
            if (checkBox12.IsChecked == true)
            {
                Keyboard.f2 = true;
                Keyboard.Sleepf2 = Convert.ToInt32(SkillSleep12.Text);
            }
            else Keyboard.f2 = false;
            if (checkBox13.IsChecked == true)
            {
                Keyboard.f3 = true;
                Keyboard.Sleepf3 = Convert.ToInt32(SkillSleep13.Text);
            }
            else Keyboard.f3 = false;
            if (checkBox14.IsChecked == true)
            {
                Keyboard.f4 = true;
                Keyboard.Sleepf4 = Convert.ToInt32(SkillSleep14.Text);
            }
            else Keyboard.f4 = false;
            if (checkBox15.IsChecked == true)
            {
                Keyboard.f5 = true;
                Keyboard.Sleepf5 = Convert.ToInt32(SkillSleep15.Text);
            }
            else Keyboard.f5 = false;
            if (checkBox16.IsChecked == true)
            {
                Keyboard.f6 = true;
                Keyboard.Sleepf6 = Convert.ToInt32(SkillSleep16.Text);
            }
            else Keyboard.f6 = false;
            if (checkBox17.IsChecked == true)
            {
                Keyboard.f7 = true;
                Keyboard.Sleepf7 = Convert.ToInt32(SkillSleep17.Text);
            }
            else Keyboard.f7 = false;
            if (checkBox18.IsChecked == true)
            {
                Keyboard.f8 = true;
                Keyboard.Sleepf8 = Convert.ToInt32(SkillSleep18.Text);
            }
            else Keyboard.f8 = false;
            if (checkBox19.IsChecked == true)
            {
                Keyboard.f9 = true;
                Keyboard.Sleepf9 = Convert.ToInt32(SkillSleep19.Text);
            }
            else Keyboard.f9 = false;
            if (checkBox20.IsChecked == true)
            {
                Keyboard.f10 = true;
                Keyboard.Sleepf10 = Convert.ToInt32(SkillSleep20.Text);
            }
            else Keyboard.f10 = false;
        }
        private void saveSettings()
        {
            StreamWriter sw = File.CreateText("Setting.pb");
            sw.WriteLine(skillPauseBox.Text);
            #region SkillSleep
            sw.WriteLine(SkillSleep1.Text);
            sw.WriteLine(SkillSleep2.Text);
            sw.WriteLine(SkillSleep3.Text);
            sw.WriteLine(SkillSleep4.Text);
            sw.WriteLine(SkillSleep5.Text);
            sw.WriteLine(SkillSleep6.Text);
            sw.WriteLine(SkillSleep7.Text);
            sw.WriteLine(SkillSleep8.Text);
            sw.WriteLine(SkillSleep9.Text);
            sw.WriteLine(SkillSleep10.Text);
            sw.WriteLine(SkillSleep11.Text);
            sw.WriteLine(SkillSleep12.Text);
            sw.WriteLine(SkillSleep13.Text);
            sw.WriteLine(SkillSleep14.Text);
            sw.WriteLine(SkillSleep15.Text);
            sw.WriteLine(SkillSleep16.Text);
            sw.WriteLine(SkillSleep17.Text);
            sw.WriteLine(SkillSleep18.Text);
            sw.WriteLine(SkillSleep19.Text);
            sw.WriteLine(SkillSleep20.Text);
            sw.WriteLine(Convert.ToInt32(HealHpSlider.Value));
            sw.WriteLine(Convert.ToInt32(HealMpSlider.Value));
            #endregion
            sw.Close();
        }
        private void readSettings()
        {
            StreamReader sr = new StreamReader("Setting.pb");
            skillPauseBox.Text = sr.ReadLine();
            #region SkillSleep
            SkillSleep1.Text = sr.ReadLine();
            SkillSleep2.Text = sr.ReadLine();
            SkillSleep3.Text = sr.ReadLine();
            SkillSleep4.Text = sr.ReadLine();
            SkillSleep5.Text = sr.ReadLine();
            SkillSleep6.Text = sr.ReadLine();
            SkillSleep7.Text = sr.ReadLine();
            SkillSleep8.Text = sr.ReadLine();
            SkillSleep9.Text = sr.ReadLine();
            SkillSleep10.Text = sr.ReadLine();
            SkillSleep11.Text = sr.ReadLine();
            SkillSleep12.Text = sr.ReadLine();
            SkillSleep13.Text = sr.ReadLine();
            SkillSleep14.Text = sr.ReadLine();
            SkillSleep15.Text = sr.ReadLine();
            SkillSleep16.Text = sr.ReadLine();
            SkillSleep17.Text = sr.ReadLine();
            SkillSleep18.Text = sr.ReadLine();
            SkillSleep19.Text = sr.ReadLine();
            SkillSleep20.Text = sr.ReadLine();
            //Если ошибка , то следует просто убрать readSetting и записать значние , он не считывает Null
            HealHpProgressBar.Value = Convert.ToInt32(sr.ReadLine());
            HealHpLabel.Content = Convert.ToString(Convert.ToInt32(HealHpProgressBar.Value) + " %");
            HealHpSlider.Value = Convert.ToInt32(HealHpProgressBar.Value);
            Battle.HealHp = Convert.ToInt32(HealHpSlider.Value);

            HealMpProgressBar.Value = Convert.ToInt32(sr.ReadLine());
            HealMpLabel.Content = Convert.ToString(Convert.ToInt32(HealMpProgressBar.Value) + " %");
            HealMpSlider.Value = Convert.ToInt32(HealMpProgressBar.Value);
            Battle.HealHp = Convert.ToInt32(HealMpSlider.Value);
            #endregion
            sr.Close();
        }


        private void HealHpSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            HealHpProgressBar.Maximum = 100;
            HealHpProgressBar.Value = Convert.ToInt32(HealHpSlider.Value);
            HealHpLabel.Content = Convert.ToString(Convert.ToInt32(HealHpSlider.Value)+" %");
            Battle.HealHp = Convert.ToInt32(HealHpSlider.Value);
        }

        private void HealMpSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            HealMpProgressBar.Maximum = 100;
            HealMpProgressBar.Value = Convert.ToInt32(HealMpSlider.Value);
            HealMpLabel.Content = Convert.ToString(Convert.ToInt32(HealMpSlider.Value) + " %");
            Battle.HealMp = Convert.ToInt32(HealMpSlider.Value);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
            ListBox1.SelectedIndex = -1;
        }

        private void groupBox2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            KeyCheck();
        }

        private void saveLog()
        {
            ListBox1.Items.Add("Total death: ");
            ListBox1.Items.Add("Total expirience gained: "+ ExpCountLabel);
            ListBox1.Items.Add("Total kills: "+KillLabel);
            ListBox1.Items.Add("");
            TextWriter writer = new StreamWriter("Log.txt");
            foreach (var item in ListBox1.Items)
                writer.WriteLine(item.ToString());
            writer.Close();
        }

        #region KeyboardHook
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        const int WH_KEYBOARD_LL = 13; // Номер глобального LowLevel-хука на клавиатуру
        const int WM_KEYDOWN = 0x100; // Сообщения нажатия клавиши

        private LowLevelKeyboardProc _proc = hookProc;

        private static IntPtr hhook = IntPtr.Zero;

        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }


        public string TextMessage;

        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {

            int vkCode = Marshal.ReadInt32(lParam);

            //MessageBox.Show(Convert.ToString(vkCode));//160
            if (vkCode == 115) //F4
            {

                return (IntPtr)1;
            }

            if (vkCode == 114)//F3
            {
                Hero.targetId = m.ReadMemory(offsets.TargetBaseAddress, offsets.Target);
                Hero.Status = "Mob added";
                Hero.SaveMobs();

                return (IntPtr)1;
            }

            if (vkCode == 113)//F2
            {
                Pause = false;
                return (IntPtr)1;
            }
            if (vkCode == 112)//F1
            {
                Pause = true;
                return (IntPtr)1;
            }
            else
            {
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
            }
            //return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }
        #endregion

	}
}