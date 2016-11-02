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
            am = new AppMonitor();
            am.StartMonitoring();
            timer1.Start();
        }

        protected override void OnPause()
        {
            //am.StopMonitoring();
        }

        protected override void OnContinue()
        {
            //am.StartMonitoring();
        }

        protected override void OnStop()
        {
            //am.StopMonitoring();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            am.Monitoring();
        }
    }
}
