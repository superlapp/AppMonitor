using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace AppMonitor
{
    class AppHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        IntPtr hwnd;
        AppInfo ai;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public AppInfo GetActiveAppInfo()
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
    }
}