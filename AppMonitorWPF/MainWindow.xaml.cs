using System;
using System.Collections.Generic;
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

        private void connectToWCFBtn_Click(object sender, RoutedEventArgs e)
        {
            srv = new AppMonitorWPF.WCF_Services.MonitorWCFService();
            connectToWCFBtn.Content = "Connected";
            connectToWCFBtn.IsEnabled = false;
        }

        private void getResultBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = srv.GetStatus() + " at " + DateTime.Now.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            requestsListBox.Items.Clear();
            //
            string[] rq = srv.GetRequests();
            //
            foreach (string r in rq)
            {
                requestsListBox.Items.Add(r);
            }
        }
    }
}
