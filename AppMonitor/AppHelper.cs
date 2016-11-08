using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AppMonitor
{
    class AppHelper
    {
        IntPtr hwnd;
        AppInfo ai;
        //
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
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
            if (p.Id == 0)
            {
                ai = null;
            }
            else
            {
                ai.Id = p.Id;
                ai.AppPath = p.MainModule.FileName;
                ai.AppTitle = (p.MainModule.FileVersionInfo.FileDescription == null) ? p.ProcessName : p.MainModule.FileVersionInfo.FileDescription;
            }
            //
            return ai;
        }
    }
}