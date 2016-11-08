using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AppMonitor
{
    class AppHelper
    {
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
            ai.AppTitle = (p.Id == 0) ? string.Empty : p.MainModule.FileVersionInfo.FileDescription;
            ai.AppPath = (p.Id == 0) ? string.Empty : p.MainModule.FileName;
            //
            if (ai.AppTitle.Trim() == string.Empty)
            {
                ai.AppTitle = p.ProcessName;
            }
            //
            return ai;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
    }
}