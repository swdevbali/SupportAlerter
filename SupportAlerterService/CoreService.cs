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
            try
            {   
                //1. LOOP ALL EMAIL ACCOUNTS
                MySqlCommand cmdAccount = CoreFeature.getInstance().getDataConnection().CreateCommand();
                cmdAccount.CommandText = "select name, server,port,use_ssl,username,password,active from account where active=1";
                cmdAccount.CommandType = CommandType.Text;
                MySqlDataReader rdrAccount = cmdAccount.ExecuteReader();
                List<Account> listAccount = new List<Account>();
                while (rdrAccount.Read())
                {
                    listAccount.Add(new Account(rdrAccount.GetString(rdrAccount.GetOrdinal("name")), rdrAccount.GetString(rdrAccount.GetOrdinal("server")), rdrAccount.GetInt32(rdrAccount.GetOrdinal("port")), rdrAccount.GetString(rdrAccount.GetOrdinal("username")), Cryptho.Decrypt(rdrAccount.GetString(rdrAccount.GetOrdinal("password"))), rdrAccount.GetByte(rdrAccount.GetOrdinal("use_ssl")) == 1, rdrAccount.GetByte(rdrAccount.GetOrdinal("active")) == 1));
                }
                rdrAccount.Close();
                            
                //2. LOOP ALL NEW MESSAGES
                foreach (Account emailAccount in listAccount)
                {
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
                    rdrInbox.Close();
                    cmdInbox.Dispose();

                    //3. APPLY THE RULES
                    MySqlCommand cmdRule;
                    MySqlDataReader rdrRule;
                    string sqlRule = "SELECT name,contains,send_sms,voice_call FROM rule r";
                    cmdRule = new MySqlCommand(sqlRule, CoreFeature.getInstance().getDataConnection());
                    rdrRule = cmdRule.ExecuteReader();
                    List<SupportAlerterLibrary.model.Rule> listRule = new List<SupportAlerterLibrary.model.Rule>();
                    
                    while (rdrRule.Read())
                    {
                        listRule.Add(new SupportAlerterLibrary.model.Rule(rdrRule.GetString(rdrRule.GetOrdinal("name")), rdrRule.GetString(rdrRule.GetOrdinal("contains")), rdrRule.GetByte(rdrRule.GetOrdinal("send_sms"))==1,rdrRule.GetByte(rdrRule.GetOrdinal("voice_call"))==1));
                    }
                    rdrRule.Close();
                    cmdRule.Dispose();

                    foreach (SupportAlerterLibrary.model.Rule rule in listRule)
                    {
                        string sql = "SELECT idinbox, account_name,date,sender,subject FROM inbox where body like '%" + rule.contains + "%' and handled=0";
                        cmdInbox = new MySqlCommand(sql, CoreFeature.getInstance().getDataConnection());
                        rdrInbox = cmdInbox.ExecuteReader();
                        List<Inbox> listInbox = new List<Inbox>();
                        while (rdrInbox.Read())
                        {
                            listInbox.Add(new Inbox(rdrInbox.GetInt32(rdrInbox.GetOrdinal("idinbox")), rdrInbox.GetString(rdrInbox.GetOrdinal("subject"))));
                        }
                        rdrInbox.Close();
                        cmdInbox.Dispose();
                        foreach(Inbox inbox in listInbox)
                        {
                            EventLog.WriteEntry(Program.EventLogName, "Acted upon the rule " + rule.contains + " of message " + inbox.subject);
                            if (rule.send_sms)
                            {
                                MySqlCommand cmdSend = new MySqlCommand("insert into send_sms(idinbox,content,status) values(" + inbox.idinbox + ",'You have warning notification from SENDER','Draft')", CoreFeature.getInstance().getDataConnection());
                                cmdSend.ExecuteNonQuery();
                            }
                            if (rule.voice_call)
                            {
                                MySqlCommand cmdSend = new MySqlCommand("insert into voice_call(idinbox,status) values(" + inbox.idinbox + ",'Draft')", CoreFeature.getInstance().getDataConnection());
                                cmdSend.ExecuteNonQuery();
                            }
                            
                            MySqlCommand cmdUpdateInbox = new MySqlCommand("update inbox set handled=1 where idinbox=" + inbox.idinbox, CoreFeature.getInstance().getDataConnection());
                            cmdUpdateInbox.ExecuteNonQuery();
                        }
                    }
                    
                    rdrRule.Close();
                    cmdRule.Dispose();
                }

                //4. PROCESS, IF ANY, VOICE_CALL / SMS THAT NEED TO BE DELIVERED
                MySqlCommand cmdSms = new MySqlCommand("select idsend_sms, content from send_sms where status='Draft'", CoreFeature.getInstance().getDataConnection());
                MySqlDataReader rdrSms = cmdSms.ExecuteReader();
                List<SendSms> listSendSms = new List<SendSms>();
                while (rdrSms.Read())
                {
                    listSendSms.Add(new SendSms(rdrSms.GetInt32(rdrSms.GetOrdinal("idsend_sms")),rdrSms.GetString(rdrSms.GetOrdinal("content"))));
                }
                rdrSms.Close();
                cmdSms.Dispose();

                foreach(SendSms sendSms in listSendSms)
                {
                    SmsGateway.getInstance().processSmsNotification(sendSms);//once processed, the status will change into DELIVERED/FAILED
                }

                MySqlCommand cmdVoiceCall = new MySqlCommand("select idvoice_call,status from voice_call where status='Draft'", CoreFeature.getInstance().getDataConnection());
                MySqlDataReader rdrVoiceCall = cmdVoiceCall.ExecuteReader();
                List<VoiceCall> listVoiceCall = new List<VoiceCall>();
                while (rdrVoiceCall.Read())
                {
                    listVoiceCall.Add(new VoiceCall(rdrVoiceCall.GetInt32(rdrVoiceCall.GetOrdinal("idvoice_call")), rdrVoiceCall.GetString(rdrVoiceCall.GetOrdinal("status"))));
                }
                rdrVoiceCall.Close();
                cmdVoiceCall.Dispose();

                foreach (VoiceCall voiceCall in listVoiceCall)
                {
                    SmsGateway.getInstance().processCallNotification(voiceCall);//once processed, the status will change into DELIVERED/FAILED
                }

                CoreFeature.getInstance().getDataConnection().Close();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Program.EventLogName, "This is my error " + ex.Message);
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
