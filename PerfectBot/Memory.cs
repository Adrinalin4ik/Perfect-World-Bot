using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PerfectBot 
{
    class Memory 
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        public int pID;
        public void GetProcess(string name)
        {
            var pList = Process.GetProcesses();

            if (pList.Count() != 0)
            {
                foreach (var process in pList)
                {
                    if (process.ProcessName == name)
                    {
                        pID = process.Id;
                        return;
                    }
                }
            }
            return;
        }


        public int ReadMemory(int baseAddress, int[] offset)
        {
            if (pID != 0 && baseAddress != 0 && offset.Length != 0)
            {
                byte[] buffer = new byte[4];
                IntPtr temp;
                var handle = OpenProcess(0x001F0FFF, false, pID);
                ReadProcessMemory(handle, (IntPtr)baseAddress, buffer, 4, out temp);
                for (var i = 0; i < offset.Length; i++)
                {
                    baseAddress = BitConverter.ToInt32(buffer, 0);
                    baseAddress += offset[i];
                    ReadProcessMemory(handle, (IntPtr)baseAddress, buffer, 4, out temp);
                }
                var results = BitConverter.ToInt32(buffer, 0);
                CloseHandle(handle);
                return results;
            }
            return 0;
        }


    }
}