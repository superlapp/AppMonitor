using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMonitorWindowsService
{
    public partial class MonitorWinService : ServiceBase
    {
        AppMonitor am;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public MonitorWinService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AddLog("Service started");
            //
            try
            {
                am = new AppMonitor();
                am.StartMonitoring(eventLog1);
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }

        protected override void OnPause()
        {
            //am.StopMonitoring();

            AddLog("Service paused");
        }

        protected override void OnContinue()
        {
            //am.StartMonitoring();
        }

        protected override void OnStop()
        {
            //am.StopMonitoring();
            AddLog("Service stopped");
        }

        public void AddLog(string log)
        {
            try
            {
                if (!EventLog.SourceExists("MonitorWinService"))
                {
                    EventLog.CreateEventSource("MonitorWinService", "MonitorWinService");
                }
                eventLog1.WriteEntry(log);
            }
            catch { }
        }
    }
}
