using SupportAlerterLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SupportAlerterService
{
    public partial class CoreService : ServiceBase
    {
        private Timer _timer;
        private static int _count = 0;
        public CoreService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry(Program.EventLogName, "The service was started successfully.", EventLogEntryType.Information);
            _timer = new Timer(/*10 * 60 */ 5 * 1000);// 1 minute
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            //_timer.Start(); // <- important
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry(Program.EventLogName, "The service was stopped successfully.", EventLogEntryType.Information);
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();
            try
            {
                CoreFeature.getInstance().getDataConnection().Open();
                SqlCeCommand cmd = CoreFeature.getInstance().getDataConnection().CreateCommand();
                cmd.CommandText = "select server,port,use_ssl,username,password from account where active=true'";
                cmd.CommandType = CommandType.Text;
                SqlCeDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    if (SupportAlerterLibrary.CoreFeature.getInstance().TestConnection(false,"mail.swdevbali.com", 110, false, "ekowibowo@swdevbali.com", "muhammad"))
                    {
                        EventLog.WriteEntry(Program.EventLogName, "Login success : " + _count++);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Program.EventLogName, "This is my error " + ex.Message);
            }
            _timer.Start();
        }
    }
}
