using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AppMonitorWCFService
{
    [ServiceContract]
    public interface IMonitorWCFService
    {
        [OperationContract]
        string GetStatus();

        [OperationContract]
        void ApplicationFound(string host, string user, string app, DateTime datetime);

        [OperationContract]
        void ApplicationIsLost(string host, string user, string app, DateTime datetime);
    }
}
