using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharedClasses;

namespace AppMonitorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppMonitorWPF.WCF_Services.MonitorWCFService srv;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            srv = new AppMonitorWPF.WCF_Services.MonitorWCFService();
        }

        private void getResultBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = srv.GetStatus() + " at " + DateTime.Now.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            requestsListBox.Items.Clear();
            //
            List<WCF_Services.Request> rr = srv.GetRequests().ToList();
            //
            foreach (WCF_Services.Request r in rr)
            {
                requestsListBox.Items.Add(r.RequestDateTime + " " + r.RequestText);
            }
        }

        bool scan = false;

        private void getTestsButton_Click(object sender, RoutedEventArgs e)
        {
            scan = true;
            DoScan();
        }

        async private void DoScan()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //
            try
            {
                while (scan == true)
                {
                    List<WCF_Services.AppEvent> tt = srv.GetEvents().ToList();
                    testsListBox.Items.Clear();

                    foreach (WCF_Services.AppEvent t in tt)
                    {
                        testsListBox.Items.Add(
                            t.EventDateTime.Value.ToLongTimeString() + " " + t.EventDateTime.Value.ToShortDateString() +
                            t.State + " " + t.AppTitle);

                        testsListBox.ScrollIntoView(t);
                    }
                    //
                    await Task.Delay(200);
                }
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                scan = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void stopTestBtn_Click(object sender, RoutedEventArgs e)
        {
            scan = false;
        }
    }
}
