﻿using SupportAlerterLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
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
        private Timer timer;
        public CoreService()
        {
            InitializeComponent();
        }

        public void DoStart()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            RegistrySettings.loadValues();
            EventLog.WriteEntry(Program.EventLogName, "The service was started successfully. Will checking email every " + RegistrySettings.emailCheckInterval + " minute(s)", EventLogEntryType.Information);
            timer = new Timer(RegistrySettings.emailCheckInterval * 60 * 1000/60);// minimum of a minute, but let me tweak it here for a second
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start(); // <- important
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry(Program.EventLogName, "The service was stopped successfully.", EventLogEntryType.Information);
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            try
            {   
                if(CoreFeature.getInstance().getDataConnection().State==ConnectionState.Closed) CoreFeature.getInstance().getDataConnection().Open();
                MySqlCommand cmd = CoreFeature.getInstance().getDataConnection().CreateCommand();
                cmd.CommandText = "select name, server,port,use_ssl,username,password from account where active=1";
                cmd.CommandType = CommandType.Text;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string name = rdr.GetString(rdr.GetOrdinal("name"));
                    string server = rdr.GetString(rdr.GetOrdinal("server"));
                    int port = rdr.GetInt32(rdr.GetOrdinal("port"));
                    bool use_ssl = rdr.GetByte(rdr.GetOrdinal("use_ssl")) == 1;
                    string username = rdr.GetString(rdr.GetOrdinal("username"));
                    string password = Cryptho.Decrypt(rdr.GetString(rdr.GetOrdinal("password")));

                    if (SupportAlerterLibrary.CoreFeature.getInstance().TestConnection(name, server, port, use_ssl, username, password))
                    {
                        EventLog.WriteEntry(Program.EventLogName, "Login success for " + name);
                    }
                }
                rdr.Dispose();
                CoreFeature.getInstance().getDataConnection().Close();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Program.EventLogName, "This is my error " + ex.Message);
            }
            timer.Start();
        }

        internal void DoStop()
        {
            Stop();
        }
    }
}
