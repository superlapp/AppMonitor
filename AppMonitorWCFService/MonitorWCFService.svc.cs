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
        public enum AppState
        {
            STARTED = 1,
            CLOSED = 0
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public bool IsAlive()
        {
            return true;
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
        public void AddApplicationEvent(string host, string user, DateTime eventDateTime, AppState state, string guid, string appTitle)
        {
            AppEvent ae;
            //
            if (state == AppState.STARTED)
            {
                ae = new AppEvent();
                ae.Host = host;
                ae.User = user;
                ae.Guid = guid;
                ae.DetectDT = eventDateTime;
                ae.AppTitle = appTitle;
                db.AppEvents.Add(ae);
            }
            else
            {
                ae = db.AppEvents.First(x => x.Host == host && x.User == user && x.Guid == guid);
                TimeSpan ts = eventDateTime - ae.DetectDT;
                //
                ae.IsLostDT = eventDateTime;
                ae.WorkingTime = ts.Ticks;
            }
            //
            System.IO.StreamWriter dd = new System.IO.StreamWriter(@"C:\AppTitles.txt", true);
            dd.WriteLine("NATIVE: " + state.ToString() + ": " + appTitle);
            dd.WriteLine("ON_WCF: " + state.ToString() + ": " + ae.AppTitle);
            dd.Flush();
            dd.Close();
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