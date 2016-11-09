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
        bool IsAlive();

        [OperationContract]
        void AddApplicationEvent(string host, string user, DateTime eventDateTime, MonitorWCFService.AppState state, string guid, string appTitle);

        [OperationContract]
        List<dbHost> GetHosts();

        [OperationContract]
        List<dbUser> GetUsers(string host);

        [OperationContract]
        List<dbApplication> GetApplications(string host, string user);

        [OperationContract]
        List<dbEvent> GetEvents();
    }
}