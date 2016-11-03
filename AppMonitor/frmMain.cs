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
            mon = new MonitorWCFService();
        }

        private void StartMonitoring()
        {

        }
    }
}
