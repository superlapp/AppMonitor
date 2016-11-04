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
        List<Request> GetRequests();






        [OperationContract]
        void AddApplicationEvent(string host, string user, DateTime eventDateTime, int state, string appTitle);

        [OperationContract]
        List<string> GetHosts();

        [OperationContract]
        List<string> GetUsers(string host);

        [OperationContract]
        List<string> GetApplications(string host, string users);

        [OperationContract]
        List<AppEvent> GetEvents();
    }
}