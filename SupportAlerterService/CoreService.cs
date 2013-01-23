using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SupportAlerterService
{
    public partial class CoreService : ServiceBase
    {
        public CoreService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry(Program.EventLogName, "The service was started successfully.", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry(Program.EventLogName, "The service was stopped successfully.", EventLogEntryType.Information);
        }
    }
}
