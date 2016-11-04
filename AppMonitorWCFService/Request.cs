using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AppMonitorWCFService
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public DateTime RequestDateTime { get; set; }
        [DataMember]
        public string RequestText { get; set; }
        //
        public Request(DateTime requestDateTime, string requestText)
        {
            RequestDateTime = requestDateTime;
            RequestText = requestText;
        }
    }
}