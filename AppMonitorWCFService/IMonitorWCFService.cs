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
        List<string> GetRequests();

        [OperationContract]
        void ApplicationFound(string host, string user, string app, DateTime datetime);

        [OperationContract]
        void ApplicationIsLost(string host, string user, string app, DateTime datetime);

        [OperationContract]
        List<string> GetHosts();

        [OperationContract]
        List<string> GetUsers(string host);

        [OperationContract]
        List<string> GetApplications(string host, string users);

        [OperationContract]
        List<string> GetTests();
    }
}
