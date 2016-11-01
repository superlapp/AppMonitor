using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppMonitorWindowsService
{
    class ProcessHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        //
        IntPtr hwnd;
        //
        public struct ApplicationInfo
        {
            public int id;
            public string AppTitle;
            public string AppPath;
        }
        ApplicationInfo ai;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public ApplicationInfo GetActiveAppInfo()
        {
            hwnd = GetForegroundWindow();
            uint pid;
            GetWindowThreadProcessId(hwnd, out pid);
            Process p = Process.GetProcessById((int)pid);
            //
            ai = new ApplicationInfo();
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
    }
}
