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
            int save_result = -999;
            string err_text1 = "";
            string err_text2 = "";
            try
            {
                IncomingRequest ir = new IncomingRequest();
                ir.Request = "GetStatus";
                ir.TimeOfReceiving = DateTime.Now;
                db.IncomingRequests.Add(ir);
                save_result = db.SaveChanges();
            }
            catch (Exception ex)
            {
                err_text1 = (ex == null) ? "" : ex.Message;
                err_text2 = (ex.InnerException == null) ? "" : ex.InnerException.Message;
            }
            //
            return "Service is running " +
                err_text1.ToString() + "\r\n" +
                err_text2.ToString() + "\r\n" +
                save_result.ToString();
        }

        public List<Request> GetRequests()
        {
            List<Request> requests = new List<Request>();
            //
            foreach (IncomingRequest ir in db.IncomingRequests)
            {
                requests.Add(new Request(ir.TimeOfReceiving, ir.Request));
            }
            //
            return requests;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void AddApplicationEvent(string host, string user, DateTime eventDateTime, int state, string appTitle)
        {
            AppEvent ae = new AppEvent();
            //
            ae.Host = host;
            ae.User = user;
            ae.EventDateTime = eventDateTime;
            ae.State = state;
            ae.AppTitle = appTitle;
            //
            db.AppEvents.Add(ae);
            //
            db.SaveChanges();
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

        public List<AppEvent> GetEvents()
        {
            return db.AppEvents.ToList();
        }
    }
}