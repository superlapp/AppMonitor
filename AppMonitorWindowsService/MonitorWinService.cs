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
            am = AppMonitor.Instance;
            am.StartMonitoring();
        }

        protected override void OnPause()
        {
            am.StopMonitoring();
        }

        protected override void OnContinue()
        {
            am.StartMonitoring();
        }

        protected override void OnStop()
        {
            am.StopMonitoring();
        }
    }
}
