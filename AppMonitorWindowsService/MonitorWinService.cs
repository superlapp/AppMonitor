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
            //
            timer1.Start();
        }

        protected override void OnPause()
        {
            timer1.Stop();
        }

        protected override void OnContinue()
        {
            timer1.Start();
        }

        protected override void OnStop()
        {
            timer1.Stop();
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            //
        }
    }
}
