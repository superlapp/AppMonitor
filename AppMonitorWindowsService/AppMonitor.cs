using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMonitorWindowsService
{
    sealed class AppMonitor
    {
        private static AppMonitor _me = null;

        private ProcessHelper ph;
        private Process currentProcess = null;
        private Process activeProcess = null;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public static AppMonitor Instance
        {
            get
            {
                if (_me == null) { _me = new AppMonitor(); }
                return _me;
            }
        }
        
        private AppMonitor()
        {
            //
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void ApplicationFound()
        {

        }

        public void ApplicationIsLost()
        {

        }
    }
}
