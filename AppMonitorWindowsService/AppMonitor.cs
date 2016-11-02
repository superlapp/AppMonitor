using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppMonitorWindowsService.WCF_Services;

namespace AppMonitorWindowsService
{
    sealed class AppMonitor : AppHelper
    {
        private static AppMonitor _me = null;
        //
        private MonitorWCFService mon = new MonitorWCFService();
        //private AppHelper ah = new AppHelper();
        private AppHelper.AppInfo currentProcess;
        private AppHelper.AppInfo activeProcess;
        //
        private DateTime startTime = DateTime.Now;
        //
        bool work = false;
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
        public void StartMonitoring(EventLog ev)
        {
            try
            {
                work = true;
                //
                activeProcess = base.GetActiveAppInfo();
                //startTime = DateTime.Now;
                //
                //ApplicationFound(activeProcess, startTime);
                //currentProcess = activeProcess;
                //
                while (work)
                {
                    ////if (currentProcess.id != activeProcess.id)
                    ////{
                    ////    ev.WriteEntry(currentProcess.AppTitle + " closed at " + DateTime.Now.ToString());

                    ////    ev.WriteEntry(activeProcess.AppTitle + " found at " + DateTime.Now.ToString());

                    ////    //ApplicationIsLost(currentProcess, DateTime.Now);
                    ////    //ApplicationFound(activeProcess, startTime);

                    ////    currentProcess = activeProcess;
                    ////}
                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {
                ev.WriteEntry(ex.Message + "!");
            }
        }

        public void StopMonitoring()
        {
            work = false;
        }

        private void ApplicationFound(AppHelper.AppInfo ai, DateTime dt)
        {
            startTime = DateTime.Now;
            //
            mon.ApplicationFound(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
        }

        private void ApplicationIsLost(AppHelper.AppInfo ai, DateTime dt)
        {
            mon.ApplicationIsLost(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
        }
    }
}
