using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
        private async void Window_Activated(object sender, EventArgs e)
        {
            var connectTask = Task<string>.Factory.StartNew(() => Connect());
            await connectTask;
            connectStatusLabel.Content = connectTask.Result.ToString();
            //
            eventDatePicker.SelectedDate = DateTime.Today;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private string Connect()
        {
            srv = new AppMonitorWPF.WCF_Services.MonitorWCFService();
            return "connected";
        }

        List<ReportItem> im = new List<ReportItem>();

        private void GetEvents()
        {
            try
            {
                long tk = 0;
                string frmt = @"hh\:mm\:ss";
                string workingTime = "";
                
                //
                List<WCF_Services.dbEvent> evs = srv.GetEvents().Where(x => x.DetectDT.ToShortDateString() == eventDatePicker.SelectedDate.Value.ToShortDateString() && x.WorkingTime != null).ToList();


                im.Clear();
                

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
                        if (ts.TotalSeconds >= 1)
                        {
                            ReportItem ri = new ReportItem();
                            ri.ShowInChart = true;
                            ri.EventDate = eventDatePicker.SelectedDate ?? DateTime.Now;
                            ri.ApplicationTitle = app.Caption;
                            ri.WorkingTime = workingTime;
                            ri.WorkingTicks = tk;
                            //
                            im.Add(ri);
                        }
                    }
                }
                //
                reportListView.Items.Clear();

                List<KeyValuePair<string, long>> ccc = new List<KeyValuePair<string, long>>();

                //List<ReportItem> rr = im.OrderBy(o => o.WorkingTime).ToList();
                im.Sort((x, y) => y.WorkingTime.CompareTo(x.WorkingTime));
                foreach (ReportItem r in im)
                {
                    reportListView.Items.Add(r);
                }
                //
                eventsGrid.ItemsSource = evs;

                FillChart();
                
                //
                //await Task.Delay(200);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FillChart()
        {
            List<KeyValuePair<string, long>> source = new List<KeyValuePair<string, long>>();
            //
            foreach (ReportItem r in im.Where(x => x.ShowInChart == true))
            {
                source.Add(new KeyValuePair<string, long>(r.ApplicationTitle, r.WorkingTicks));
            }
            //
            ((PieSeries)mcChart.Series[0]).ItemsSource = source;

            //((BarSeries)mcChart2.Series[0]).ItemsSource = source;
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FillChart();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FillChart();
        }
    }
}