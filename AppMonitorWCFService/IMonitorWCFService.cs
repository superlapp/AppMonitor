using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AppMonitorWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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
