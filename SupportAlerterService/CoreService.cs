using SupportAlerterLibrary;
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
using OpenPop.Mime;
using SupportAlerterLibrary.model;

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
            timer = new Timer(RegistrySettings.emailCheckInterval * 1000);// in seconds
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
            MySqlDataReader rdr = null;
            try
            {   
                MySqlCommand cmd = CoreFeature.getInstance().getDataConnection().CreateCommand();
                cmd.CommandText = "select name, server,port,use_ssl,username,password from account where active=1";
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string name = rdr.GetString(rdr.GetOrdinal("name"));
                    string server = rdr.GetString(rdr.GetOrdinal("server"));
                    int port = rdr.GetInt32(rdr.GetOrdinal("port"));
                    bool use_ssl = rdr.GetByte(rdr.GetOrdinal("use_ssl")) == 1;
                    string username = rdr.GetString(rdr.GetOrdinal("username"));
                    string password = Cryptho.Decrypt(rdr.GetString(rdr.GetOrdinal("password")));

                    if (SupportAlerterLibrary.CoreFeature.getInstance().Connect(name, server, port, use_ssl, username, password))
                    {
                        int count = SupportAlerterLibrary.CoreFeature.getInstance().getPop3Client().GetMessageCount();
                        EventLog.WriteEntry(Program.EventLogName, "Login success for " + name + " will processed " + count + " message(s)");
                        for (int i = 1; i <= count; i++)
                        {
                            //Regards to : http://hpop.sourceforge.net/exampleSpecificParts.php
                            Message message = SupportAlerterLibrary.CoreFeature.getInstance().getPop3Client().GetMessage(i);
                            MessagePart messagePart = message.FindFirstPlainTextVersion();
                            if (messagePart == null) messagePart = message.FindFirstHtmlVersion(); 
                            string messageBody = null;
                            if(messagePart!=null) messageBody = messagePart.GetBodyAsText();

                            //check whether inbox is empty. If it's do the recent: connection to get lat 30days messages
                            MySqlDataReader rdrAccount = null;
                            try
                            {
                                MySqlCommand cmdAccount = CoreFeature.getInstance().getDataConnection().CreateCommand();
                                cmdAccount.CommandText = "select name, server,port,use_ssl,username,password,active from account where active=1";
                                cmdAccount.CommandType = CommandType.Text;
                                rdrAccount = cmdAccount.ExecuteReader();
                                List<Account> listAccount = new List<Account>();
                                while (rdr.Read())
                                {
                                    listAccount.Add(new Account(rdr.GetString(rdr.GetOrdinal("name")), rdr.GetString(rdr.GetOrdinal("server")), rdr.GetInt32(rdr.GetOrdinal("port")), rdr.GetString(rdr.GetOrdinal("username")), Cryptho.Decrypt(rdr.GetString(rdr.GetOrdinal("password"))), rdr.GetByte(rdr.GetOrdinal("use_ssl")) == 1, rdr.GetByte(rdr.GetOrdinal("active")) == 1));
                                }
                                rdr.Close();
                                foreach (Account emailAccount in listAccount)
                                {
                                    //Application.DoEvents();
                                    MySqlDataReader rdrInbox = null;
                                    MySqlCommand cmdInbox = CoreFeature.getInstance().getDataConnection().CreateCommand();
                                    cmdInbox.CommandText = "SELECT count(*) FROM inbox i, account a where i.account_name = a.name and a.name='" + emailAccount.name + "'";
                                    cmdInbox.CommandType = CommandType.Text;
                                    rdrInbox = cmdInbox.ExecuteReader();

                                    if (rdrInbox.Read())
                                    {
                                        if (rdrInbox.GetInt32(0) == 0)
                                        {   //no messages in inbox, try to fetch all last 30 days message to test the rule
                                            rdrInbox.Dispose();
                                            CoreFeature.getInstance().FetchRecentMessages(emailAccount, true);
                                        }
                                        else
                                        {   //already done that, now only fetch new message
                                            rdrInbox.Dispose();
                                            CoreFeature.getInstance().FetchRecentMessages(emailAccount, false);
                                        }
                                    }

                                    MySqlCommand cmdRule;
                                    MySqlDataReader rdrRule;
                                    string ruleContains;
                                    string sqlRule = "SELECT contains,send_sms,voice_call FROM rule r";
                                    cmdRule = new MySqlCommand(sqlRule, CoreFeature.getInstance().getDataConnection());
                                    rdrRule = cmdRule.ExecuteReader();
                                    while (rdrRule.Read())
                                    {
                                        ruleContains = rdrRule.GetString(rdrRule.GetOrdinal("contains"));
                                        string sql = "SELECT account_name,date,sender,subject FROM inbox where body like '%" + ruleContains + "%'";
                                        cmdInbox = new MySqlCommand(sql, CoreFeature.getInstance().getDataConnection());
                                        rdrInbox = cmdInbox.ExecuteReader();
                                        string[] sub = new string[5];
                                        while (rdrInbox.Read())
                                        {
                                            EventLog.WriteEntry(Program.EventLogName, "Acted upon the rule " + ruleContains);
                                        }
                                    }
                                    rdrRule.Close();
                                    cmdRule.Dispose();
                                    rdrInbox.Close();
                                    cmdInbox.Dispose();
                                }
                                CoreFeature.getInstance().getDataConnection().Close();
                            }
                            catch (Exception ex)
                            {
                                EventLog.WriteEntry(Program.EventLogName, "This is my error " + ex.Message);
                                rdr.Close();
                                CoreFeature.getInstance().getDataConnection().Close();
                            }
                            CoreFeature.getInstance().FetchRecentMessages(null, true);


                            //EventLog.WriteEntry(Program.EventLogName, message.Headers.Subject + " -- " + messageBody);
                        }
                    }
                }
                rdr.Close();
                CoreFeature.getInstance().getDataConnection().Close();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Program.EventLogName, "This is my error " + ex.Message);
                rdr.Close();
                CoreFeature.getInstance().getDataConnection().Close();
            }
            timer.Start();
        }

        internal void DoStop()
        {
            Stop();
        }
    }
}
