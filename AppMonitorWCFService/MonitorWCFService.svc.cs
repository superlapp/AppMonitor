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
        wcf_dbEntities db = new wcf_dbEntities();
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public string GetStatus()
        {
            //IncomingRequest ir = new IncomingRequest();
            //ir.Request = "GetStatus";
            //ir.TimeOfReceiving = DateTime.Now;
            //db.IncomingRequests.Add(ir);
            //db.SaveChanges();
            //
            return "Service is running";
        }

        public List<string> GetRequests()
        {
            List<string> requests = new List<string>();
            //
            requests = db.IncomingRequests.Select(x => x.Request + " " + x.TimeOfReceiving.ToString()).ToList();
            //
            return requests;
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
