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
        WCF_Services.MonitorWCFService srv = new WCF_Services.MonitorWCFService();

        ServiceHelper sh = new ServiceHelper();

        List<ReportItem> chartList = new List<ReportItem>();

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hostsComboBox.FontStyle = FontStyles.Italic;
            hostsComboBox.Items.Add("Loading...");
            hostsComboBox.SelectedIndex = 0;

            usersComboBox.FontStyle = FontStyles.Italic;
            usersComboBox.Items.Add("Loading...");
            usersComboBox.SelectedIndex = 0;


            GetHostsAsync();            
            eventDatePicker.SelectedDate = DateTime.Today;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private async void GetHostsAsync()
        {
            var task = Task<WCF_Services.dbHost[]>.Factory.StartNew(() => GetHosts());
            await task;

            hostsComboBox.Items.Clear();
            hostsComboBox.FontStyle = FontStyles.Normal;

            hostsComboBox.ItemsSource = task.Result;
            hostsComboBox.DisplayMemberPath = "Caption";
            hostsComboBox.SelectedIndex = 0;
            //
            GetUsersAsync();
        }

        private WCF_Services.dbHost[] GetHosts()
        {
            WCF_Services.dbHost[] result = null;
            try
            {
                result = srv.GetHosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
            return result;
        }

        private async void GetUsersAsync()
        {
            string host = ((WCF_Services.dbHost)hostsComboBox.SelectedValue).Caption;
            //
            var task = Task<WCF_Services.dbUser[]>.Factory.StartNew(() => GetUsers(host));
            await task;
            usersComboBox.Items.Clear();
            usersComboBox.FontStyle = FontStyles.Normal;
            usersComboBox.ItemsSource = task.Result;
            usersComboBox.DisplayMemberPath = "Caption";
            usersComboBox.SelectedIndex = 0;
        }

        private WCF_Services.dbUser[] GetUsers(string host)
        {
            WCF_Services.dbUser[] result = null;
            try
            {
                result = srv.GetUsers(host);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //
            return result;
        }

        private async void GetEventsAsync()
        {
            getEventsBtn.IsEnabled = false;
            //
            string host = ((WCF_Services.dbHost)hostsComboBox.SelectedValue).Caption;
            string user = ((WCF_Services.dbUser)usersComboBox.SelectedValue).Caption;
            DateTime date = eventDatePicker.SelectedDate.Value;
            //
            var task = Task<List<WCF_Services.dbEvent>>.Factory.StartNew(() => GetEvents(host, user, date));
            await task;
            var result = task.Result;
            //-----------------------------------------------------------------
            long totalTime = 0;

            long tk = 0;
            string timeFormatter = @"hh\:mm\:ss";
            string workingTime = "";
            chartList.Clear();

            var apps = srv.GetApplications("", "").ToList();
            foreach (WCF_Services.dbApplication app in apps)
            {
                var evsPerApp = result.FindAll(x => x.AppTitle == app.Caption);
                //
                tk = 0;
                foreach (WCF_Services.dbEvent ev in evsPerApp)
                {
                    totalTime = totalTime + (long)ev.WorkingTime;

                    tk = tk + (long)ev.WorkingTime;
                }
                TimeSpan ts = TimeSpan.FromTicks(tk);
                workingTime = ts.ToString(timeFormatter);
                double minLimit = Convert.ToInt32(AppMonitorWPF.Properties.Settings.Default.MinTimeLimit);
                //
                if (tk != 0)
                {
                    if (ts.TotalSeconds >= minLimit)
                    {
                        ReportItem ri = new ReportItem();
                        ri.ShowInChart = true;
                        ri.EventDate = date;
                        ri.ApplicationTitle = app.Caption;
                        ri.WorkingTime = workingTime;
                        ri.WorkingTicks = tk;
                        //
                        if (IsHidden(app.Caption) == false)
                        {
                            chartList.Add(ri);
                        }
                    }
                }
            }

            TimeSpan ts2 = TimeSpan.FromTicks(totalTime);

            label1.Content = ts2.ToString(timeFormatter);

            //
            reportListView.Items.Clear();
            //var ccc = new List<KeyValuePair<string, long>>();
            //List<ReportItem> rr = im.OrderBy(o => o.WorkingTime).ToList();
            chartList.Sort((x, y) => y.WorkingTime.CompareTo(x.WorkingTime));
            foreach (ReportItem r in chartList)
            {
                reportListView.Items.Add(r);
            }
            //
            eventsGrid.ItemsSource = result;
            FillChart();
            //
            //await Task.Delay(200);
            //
            getEventsBtn.IsEnabled = true;
        }

        private List<WCF_Services.dbEvent> GetEvents(string host, string user, DateTime date)
        {
            var result = new List<WCF_Services.dbEvent>();
            result = srv.GetEvents().Where(x => x.DetectDT.ToShortDateString() == date.ToShortDateString() && x.WorkingTime != null).ToList();
            return result;
        }

        private bool IsHidden(string app)
        {
            bool r = false;
            //
            if (Properties.Settings.Default.HiddenApps != null)
            {
                foreach (string happ in Properties.Settings.Default.HiddenApps)
                {
                    if (happ.ToLower().Contains('*'))
                    {
                        if (happ.StartsWith("*") == true && happ.EndsWith("*") == true)
                        {
                            r = app.ToLower().Contains(happ.ToLower().Replace("*", ""));
                        }
                        if (happ.StartsWith("*") == true && happ.EndsWith("*") == false)
                        {
                            r = app.ToLower().EndsWith(happ.ToLower().Replace("*", ""));
                        }
                        if (happ.StartsWith("*") == false && happ.EndsWith("*") == true)
                        {
                            r = app.ToLower().StartsWith(happ.ToLower().Replace("*", ""));
                        }
                    }
                    else
                    {
                        r =  (app.ToLower() == happ.ToLower()) ? true : false;
                    }
                }
            }
            return r;
        }

        private void FillChart()
        {
            var source = new List<KeyValuePair<string, long>>();
            foreach (ReportItem r in chartList.Where(x => x.ShowInChart == true))
            {
                source.Add(new KeyValuePair<string, long>(r.ApplicationTitle, r.WorkingTicks));
            }
            ((PieSeries)mcChart.Series[0]).ItemsSource = source;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        private void getEventsBtn_Click(object sender, RoutedEventArgs e)
        {
            GetEventsAsync();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            winOptions wo = new winOptions();
            wo.ShowDialog();
        }


    }
}