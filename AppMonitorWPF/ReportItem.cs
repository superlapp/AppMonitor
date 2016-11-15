using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMonitorWPF
{
    class ReportItem
    {
        public bool ShowInChart { get; set; }
        public DateTime EventDate { get; set; }
        public string ApplicationTitle { get; set; }
        public string WorkingTime { get; set; }
        public long WorkingTicks { get; set; }
    }
}