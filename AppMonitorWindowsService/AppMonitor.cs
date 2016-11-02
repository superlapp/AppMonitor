using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppMonitorWindowsService.WCF_Services;
using System.Runtime.InteropServices;

namespace AppMonitorWindowsService
{
    class AppMonitor
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        IntPtr hwnd;
        
        public struct AppInfo
        {
            public int id;
            public string AppTitle;
            public string AppPath;
        }
        AppInfo ai;
        //---------------------------------------------------------------------
        private MonitorWCFService mon;
        private AppInfo currentProcess; //= new AppInfo();
        private AppInfo activeProcess;
        //
        private DateTime startTime = DateTime.Now;
        //
        bool work = false;
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
            ai.id = p.Id;
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
        public void StartMonitoring(EventLog ev)
        {
            try
            {
                mon = new MonitorWCFService();

                work = true;

                activeProcess = GetActiveAppInfo();

                startTime = DateTime.Now;

                ApplicationFound(activeProcess, startTime);
                //
                currentProcess = activeProcess;
                //
                while (work)
                {
                    if (currentProcess.id != activeProcess.id)
                    {
                        ApplicationIsLost(currentProcess, DateTime.Now);
                        ApplicationFound(activeProcess, startTime);

                        currentProcess = activeProcess;
                    }
                    Thread.Sleep(200);

                    work = false;
                }
            }
            catch (Exception ex)
            {
                work = false;
                mon.Dispose();
                ev.WriteEntry(ex.Message + "!");
            }
        }

        public void StopMonitoring()
        {
            work = false;
            mon.Dispose();
        }
        //---------------------------------------------------------------------
        private void ApplicationFound(AppInfo ai, DateTime dt)
        {
            //mon.ApplicationFound(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
        }

        private void ApplicationIsLost(AppInfo ai, DateTime dt)
        {
            //mon.ApplicationIsLost(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
        }
    }
}
