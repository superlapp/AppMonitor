using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppMonitor.WCF_Services;

namespace AppMonitor
{
    public partial class frmMain : Form
    {
        MonitorWCFService mon;
        Worker w;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public frmMain()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            StartMonitoring();
        }

        private void StartMonitoring()
        {
            mon = new MonitorWCFService();
            w = new Worker(mon, listView1);
            //
            w.StartMonitoring();
            //
            timer1.Start();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            w.StopMonitoring();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            w.Work();
        }
    }
}
