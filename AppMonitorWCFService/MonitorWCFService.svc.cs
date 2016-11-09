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
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void AddApplicationEvent(string host, string user, DateTime eventDateTime, AppState state, string guid, string appTitle)
        {
            dbEvent ev;
            //
            if (state == AppState.STARTED)
            {
                ev = new dbEvent();
                ev.Host = host;
                ev.User = user;
                ev.Guid = guid;
                ev.DetectDT = eventDateTime;
                ev.AppTitle = appTitle;
                db.dbEvents.Add(ev);
                //
                long cnt = db.dbHosts.LongCount(x => x.Caption == host);
                if (cnt == 0)
                {
                    dbHost hs = new dbHost();
                    hs.Caption = host;
                    db.dbHosts.Add(hs);
                }

                cnt = db.dbUsers.LongCount(x => x.Caption == user);
                if (cnt == 0)
                {
                    dbUser usr = new dbUser();
                    usr.Caption = host;
                    db.dbUsers.Add(usr);
                }

                cnt = db.dbApplications.LongCount(x => x.Caption == appTitle);
                if (cnt == 0)
                {
                    dbApplication ap = new dbApplication();
                    ap.Caption = appTitle;
                    db.dbApplications.Add(ap);
                }
            }
            else
            {
                ev = db.dbEvents.First(x => x.Host == host && x.User == user && x.Guid == guid);
                TimeSpan ts = eventDateTime - ev.DetectDT;
                //
                ev.IsLostDT = eventDateTime;
                ev.WorkingTime = ts.Ticks;
            }
            //
            db.SaveChanges();
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public List<dbHost> GetHosts()
        {
            List<string> hosts = new List<string>();
            //
            //
            return db.dbHosts.ToList();
        }

        public List<dbUser> GetUsers(string host)
        {
            //List<string> users = new List<string>();
            //
            //
            return db.dbUsers.ToList();
        }

        public List<dbApplication> GetApplications(string host, string user)
        {
            //List<dbApplication> aps = new List<dbApplication>();
            //

            //
            return db.dbApplications.ToList();
        }

        public List<dbEvent> GetEvents()
        {
            return db.dbEvents.ToList();
        }
    }
}