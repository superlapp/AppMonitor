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
                List<WCF_Services.AppEvent> events = srv.GetEvents().Where(x => x.DetectDT >= eventDatePicker.SelectedDate).ToList();

                //List<WCF_Services.AppEvent> events = srv.GetEvents().ToList();

                eventsGrid.ItemsSource = events;
                //
                //await Task.Delay(200);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            WCF_Services.AppEvent ee = (WCF_Services.AppEvent)eventsGrid.SelectedItem;

            long tk = (long)ee.WorkingTime;

            TimeSpan ts = TimeSpan.FromTicks(tk);

            //label2.Content = ts.ToString();
        }
    }
}