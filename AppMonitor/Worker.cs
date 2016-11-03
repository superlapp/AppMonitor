using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMonitor.WCF_Services;
using System.Windows.Forms;

namespace AppMonitor
{
    class Worker : AppHelper;
    {
        MonitorWCFService mon;
        AppInfo activeProcess;
        AppInfo currentProcess;
        //
        DateTime startTime = DateTime.Now;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public Worker(MonitorWCFService mon)
        {
            this.mon = mon;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void StartMonitoring()
        {
            try
            {
                mon = new MonitorWCFService();
                activeProcess = GetActiveAppInfo();
                startTime = DateTime.Now;
                ApplicationFound(activeProcess, startTime);
                //
                currentProcess = activeProcess;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Work()
        {
            try
            {
                activeProcess = GetActiveAppInfo();

                if (activeProcess.Id != 0)
                {
                    //
                    if (currentProcess.Id != activeProcess.Id)
                    {
                        ApplicationIsLost(currentProcess, DateTime.Now);

                        ApplicationFound(activeProcess, startTime);
                        //
                        currentProcess = activeProcess;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StopMonitoring()
        {
            mon.Dispose();
        }

        private void ApplicationFound(AppInfo ai, DateTime dt)
        {
            mon.ApplicationFound(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
        }

        private void ApplicationIsLost(AppInfo ai, DateTime dt)
        {
            mon.ApplicationIsLost(Environment.MachineName, Environment.UserName, ai.AppTitle, dt, true);
        }
    }
}
