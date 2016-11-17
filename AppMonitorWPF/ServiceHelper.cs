using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMonitorWPF
{
    class ServiceHelper
    {
        //

        public async void Connect()
        {
            var task = Task<bool>.Factory.StartNew(() => ConnectTask());
            await task;
        }

        private bool ConnectTask()
        {
            return true;
        }

        public async void GetApplication()
        {

        }
    }
}