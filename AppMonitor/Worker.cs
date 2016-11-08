using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMonitor.WCF_Services;
using System.Windows.Forms;

namespace AppMonitor
{
    class Worker : AppHelper
    {
        ListView lv;
        MonitorWCFService mon;
        AppInfo activeProcess;
        AppInfo currentProcess;
        //
        DateTime startTime = DateTime.Now;
        //
        Guid activeWindowGuid;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public Worker(MonitorWCFService mon, ListView lv)
        {
            this.mon = mon;
            this.lv = lv;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void StartMonitoring()
        {
            try
            {
                lv.Items.Clear();

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
            //try
            //{
                activeProcess = GetActiveAppInfo();

                if (activeProcess != null)
                {
                    if (activeProcess.Id != 0)
                    {
                        //
                        if (currentProcess.Id != activeProcess.Id)
                        {
                            startTime = DateTime.Now;
                            //
                            ApplicationIsLost(currentProcess, DateTime.Now);
                            ApplicationFound(activeProcess, startTime);
                            //
                            currentProcess = activeProcess;
                        }
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public void StopMonitoring()
        {
            try
            {
                AddItem(currentProcess, DateTime.Now, true);
                ApplicationIsLost(currentProcess, DateTime.Now);
                mon.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplicationFound(AppInfo ai, DateTime dt)
        {
            activeWindowGuid = Guid.NewGuid();
            //
            AddItem(ai, dt, false);
            mon.AddApplicationEvent(Environment.MachineName, Environment.UserName, dt, true, WCF_Services.MonitorWCFServiceAppState.STARTED, true, activeWindowGuid.ToString(), ai.AppTitle);
        }

        private void ApplicationIsLost(AppInfo ai, DateTime dt)
        {
            AddItem(ai, dt, true);
            mon.AddApplicationEvent(Environment.MachineName, Environment.UserName, dt, true, WCF_Services.MonitorWCFServiceAppState.CLOSED, true, activeWindowGuid.ToString(), ai.AppTitle);
        }

        private void AddItem(AppInfo ai, DateTime dt, bool isLost)
        {
            ListViewItem lvi = new ListViewItem("");
            lvi.ImageIndex = (isLost == false) ? 0 : 1;
            lvi.SubItems.Add(dt.ToLongTimeString());
            lvi.SubItems.Add(ai.AppTitle);
            lv.Items.Add(lvi);
            lvi.Selected = true;
            lvi.EnsureVisible();
        }
    }
}