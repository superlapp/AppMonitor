using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AppMonitorWCFService
{
    [DataContract]
    public class AppInfo
    {
        [DataMember]
        public string Host { get; set; }
        [DataMember]
        public string User { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public DateTime EventDateTime { get; set; }
        [DataMember]
        public string AppTitle { get; set; }
        //
        public AppInfo(string host, string user, int state, DateTime eventDateTime, string appTitle)
        {
            Host = host;
            User = user;
            State = state;
            EventDateTime = eventDateTime;
            AppTitle = appTitle;
        }
    }
}