using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AppMonitorWCFService
{
    public class MonitorWCFService : IMonitorWCFService
    {
        public string GetStatus()
        {
            return "Service is running";
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void ApplicationFound(string host, string user, string app, DateTime datetime)
        {
            //
        }

        public void ApplicationIsLost(string host, string user, string app, DateTime datetime)
        {
            //
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public List<string> GetHosts()
        {
            List<string> hosts = new List<string>();
            //
            //
            return hosts;
        }

        public List<string> GetUsers(string host)
        {
            List<string> users = new List<string>();
            //
            //
            return users;
        }

        public List<string> GetApplications(string host, string users)
        {
            List<string> apps = new List<string>();
            //
            //
            return apps;
        }
    }
}
