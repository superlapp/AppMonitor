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

        public List<string> GetRequests()
        {
            List<string> requests = new List<string>();
            //
            foreach (IncomingRequest ir in db.IncomingRequests)
            {
                requests.Add(
                    ir.Request + " at " +
                    ir.TimeOfReceiving.ToString("dd.MM.yy hh:mm:ss"));
            }
            //
            return requests;
        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------
        public void ApplicationFound(string host, string user, string app, DateTime datetime)
        {
            Test t = new Test();
            t.MessageTxt = string.Format("F: {0};{1};{2};{3}", host, user, app, datetime.ToString("dd.MM.yy hh:mm:ss"));
            db.Tests.Add(t);
            db.SaveChanges();
        }

        public void ApplicationIsLost(string host, string user, string app, DateTime datetime)
        {
            Test t = new Test();
            t.MessageTxt = string.Format("L: {0};{1};{2};{3}", host, user, app, datetime.ToString("dd.MM.yy hh:mm:ss"));
            db.Tests.Add(t);
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

        public List<string> GetTests()
        {
            List<string> tests = new List<string>();
            //
            foreach (Test t in db.Tests)
            {
                tests.Add(t.MessageTxt);
            }
            //
            return tests;
        }
    }
}
