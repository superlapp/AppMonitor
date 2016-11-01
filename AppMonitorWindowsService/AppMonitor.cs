using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMonitorWindowsService
{
    class AppMonitor
    {
        ProcessHelper ph;
        Process currentProcess = null;
        Process activeProcess = null;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public AppMonitor()
        {
            ph = new ProcessHelper();
        }
    }
}
