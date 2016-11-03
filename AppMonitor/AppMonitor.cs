using AppMonitorWindowsService.WCF_Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace AppMonitor
{
    class AppMonitor
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        IntPtr hwnd;

        AppInfo ai;
        //---------------------------------------------------------------------
        private MonitorWCFService mon;
        private AppInfo currentProcess;
        private AppInfo activeProcess;
        //
        private DateTime startTime = DateTime.Now;

        //

        FileStream fs;
        StreamWriter sw;


        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public AppMonitor()
        {
            //
        }

        private AppInfo GetActiveAppInfo()
        {
            hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            //
            ai = new AppInfo();
            ai.Id = p.Id;
            ai.AppTitle = (p.Id == 0) ? "" : p.MainModule.FileVersionInfo.FileDescription;
            ai.AppPath = (p.Id == 0) ? "" : p.MainModule.FileName;
            //
            if (ai.AppTitle.Trim() == "")
            {
                ai.AppTitle = p.ProcessName;
            }
            //
            return ai;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void StartMonitoring()
        {
            try
            {
                fs = new FileStream(@"C:\logs.txt", FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);

                mon = new MonitorWCFService();
                activeProcess = GetActiveAppInfo();
                startTime = DateTime.Now;
                ApplicationFound(activeProcess, startTime);
                //
                currentProcess = activeProcess;
            }
            catch (Exception ex)
            {
                sw.WriteLine("Err: " + ex.Message);
                sw.Flush();
            }
        }

        public void Monitoring()
        {
            activeProcess = GetActiveAppInfo();
            sw.WriteLine("--> " + ai.AppTitle);
            sw.Flush();


            //try
            //{
            //    activeProcess = GetActiveAppInfo();

            //    if (activeProcess.Id != 0)
            //    {
            //        //
            //        if (currentProcess.Id != activeProcess.Id)
            //        {
            //            ApplicationIsLost(currentProcess, DateTime.Now);

            //            ApplicationFound(activeProcess, startTime);
            //            //
            //            currentProcess = activeProcess;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    sw.WriteLine("Err: " + ex.Message);
            //    sw.Flush();
            //}
        }

        public void StopMonitoring()
        {
            mon.Dispose();
        }
        //---------------------------------------------------------------------
        private void ApplicationFound(AppInfo ai, DateTime dt)
        {
            //mon.ApplicationFound(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
            sw.WriteLine("Found: " + ai.AppTitle);
            sw.Flush();
        }

        private void ApplicationIsLost(AppInfo ai, DateTime dt)
        {
            //mon.ApplicationIsLost(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
            sw.WriteLine("Lost: " + ai.AppTitle);
            sw.Flush();
        }
    }
}
