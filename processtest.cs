using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace CSharp_code_injection
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        static void Main()
        {
            //프로세스 시작
            Process lghub = Process.Start(@"C:\Program Files\LGHUB\lghub.exe");

            // 핸들 가져오기
            IntPtr lghubHandle = lghub.MainWindowHandle;


            Process[] processes = Process.GetProcesses();
            List<string> processList = new List<string>();


            //foreach (Process process in processes)
            //{
            //    processList.Add(process.ProcessName);
            //}

            //processList.Sort();

            //foreach(var item in processList)
            //{
            //    Console.WriteLine(item);
            //}
            

            // process.Close();
        }
    }
}
