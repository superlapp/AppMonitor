using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppMonitorWPF
{
    class ServiceHelper
    {
        AppMonitorWPF.WCF_Services.MonitorWCFService srv = new WCF_Services.MonitorWCFService();
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //public async void ConnectAsync()
        //{
        //    var task = Task<bool>.Factory.StartNew(() => Connect());
        //    await task;
        //}

        private bool Connect()
        {
            bool result = false;
            try
            {
                srv = new AppMonitorWPF.WCF_Services.MonitorWCFService();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
            }
            return result;
        }
        //---------------------------------------------------------------------
        public async void GetApplicationsAsync(DateTime date)
        {
            var task = Task<List<WCF_Services.dbEvent>>.Factory.StartNew(() => GetApplications(date));
            await task;
        }

        private List<WCF_Services.dbEvent> GetApplications(DateTime date)
        {
            List<WCF_Services.dbEvent> result;
            result = srv.GetEvents().Where(x => x.DetectDT.ToShortDateString() == date.ToShortDateString() && x.WorkingTime != null).ToList();
            return result;
        }
    }
}