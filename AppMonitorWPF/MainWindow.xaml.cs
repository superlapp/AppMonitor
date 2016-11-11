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

namespace AppMonitorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppMonitorWPF.WCF_Services.MonitorWCFService srv;
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private void Window_Activated(object sender, EventArgs e)
        {
            srv = new AppMonitorWPF.WCF_Services.MonitorWCFService();
            eventDatePicker.SelectedDate = DateTime.Today;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //async private void DoScan()
        private void GetEvents()
        {
            try
            {
                long tk = 0;
                string frmt = @"hh\:mm\:ss";
                string workingTime = "";

                reportListView.Items.Clear();

                //
                List<WCF_Services.dbEvent> evs = srv.GetEvents().Where(x => x.DetectDT.ToShortDateString() == eventDatePicker.SelectedDate.Value.ToShortDateString() && x.WorkingTime != null).ToList();
                //
                List<WCF_Services.dbApplication> apps = srv.GetApplications("", "").ToList();
                foreach (WCF_Services.dbApplication app in apps)
                {
                    List<WCF_Services.dbEvent> evsPerApp = evs.FindAll(x => x.AppTitle == app.Caption);
                    //
                    tk = 0;
                    foreach (WCF_Services.dbEvent ev in evsPerApp)
                    {
                        tk = tk + (long)ev.WorkingTime;
                    }
                    TimeSpan ts = TimeSpan.FromTicks(tk);
                    workingTime = ts.ToString(frmt);
                    //
                    if (tk != 0)
                    {
                        ReportItem ri = new ReportItem();
                        ri.EventDate = eventDatePicker.SelectedDate ?? DateTime.Now;
                        ri.ApplicationTitle = app.Caption;
                        ri.WorkingTime = workingTime;
                        //
                        reportListView.Items.Add(ri);
                    }
                }
                //
                eventsGrid.ItemsSource = evs;
                //
                //await Task.Delay(200);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private void getEventsBtn_Click(object sender, RoutedEventArgs e)
        {
            GetEvents();
        }

        private void eventsGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            WCF_Services.dbEvent ee = (WCF_Services.dbEvent)eventsGrid.SelectedItem;
            long tk = (long)ee.WorkingTime;
            TimeSpan ts = TimeSpan.FromTicks(tk);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            reportListView.Items.Clear();
        }
    }
}