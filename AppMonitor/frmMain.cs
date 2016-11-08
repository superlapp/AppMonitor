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
        bool canClose = false;
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
            if (IsWCFAlive() == true)
            {
                statusLabel.Text = "Service connected";
                //
                //BeginInvoke(new MethodInvoker(
                //    delegate
                //    {
                //        Hide();
                //    }));
                StartMonitoring();
            }
            else
            {
                MessageBox.Show(
                    "Service not available. Application will be closed.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                canClose = true;
                this.Close();
            }
        }

        private bool IsWCFAlive()
        {
            statusLabel.Text = "Connecting to server...";
            mon = new MonitorWCFService();
            bool isAlive = false;
            bool boolSpc = false;
            mon.IsAlive(out isAlive, out boolSpc);
            return isAlive;
        }

        private void StartMonitoring()
        {
            this.Hide();
            w = new Worker(mon, listView1);
            w.StartMonitoring();
            timer1.Start();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                if (w != null)
                {
                    w.StopMonitoring();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            w.Work();
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void hideWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void closeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canClose = true;
            this.Close();
        }

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible == true)
                {
                    this.Hide();
                }
                else
                {
                    this.Show();
                }
            }
        }
    }
}