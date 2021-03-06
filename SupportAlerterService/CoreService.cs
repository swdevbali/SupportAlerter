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
            CoreFeature.getInstance().LogActivity(LogLevel.Normal, "The service was started successfully. Will checking email every " + RegistrySettings.emailCheckInterval + " second(s)", EventLogEntryType.Information);
            timer = new Timer(RegistrySettings.emailCheckInterval * 1000);// in seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start(); // <- important
        }

        protected override void OnStop()
        {
            CoreFeature.getInstance().LogActivity(LogLevel.Normal, "The service was stopped successfully.", EventLogEntryType.Information);
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            string sql;
            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Begin timed activity : Logging to email account and processing the rules", EventLogEntryType.Information);
            MySqlConnection dataConnection = null;
            try
            {   
                //1. LOOP ALL EMAIL ACCOUNTS
                dataConnection = CoreFeature.getInstance().getDataConnection();
                sql = "select name, server,port,use_ssl,username,password,active from account where active=1";
                MySqlCommand cmdAccount = new MySqlCommand(sql, dataConnection);
                MySqlDataReader rdrAccount = cmdAccount.ExecuteReader();
                List<Account> listAccount = new List<Account>();
                while (rdrAccount.Read())
                {
                    Account emailAccount = new Account(rdrAccount.GetString(rdrAccount.GetOrdinal("name")), rdrAccount.GetString(rdrAccount.GetOrdinal("server")), rdrAccount.GetInt32(rdrAccount.GetOrdinal("port")), rdrAccount.GetString(rdrAccount.GetOrdinal("username")), Cryptho.Decrypt(rdrAccount.GetString(rdrAccount.GetOrdinal("password"))), rdrAccount.GetByte(rdrAccount.GetOrdinal("use_ssl")) == 1, rdrAccount.GetByte(rdrAccount.GetOrdinal("active")) == 1);
                    listAccount.Add(emailAccount);
                    CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Will use active email " + emailAccount.name, EventLogEntryType.Information, emailAccount.name);
                }
                rdrAccount.Close();
                            
                //2. LOOP ALL NEW MESSAGES
                foreach (Account emailAccount in listAccount)
                {
                    CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Logging in to email account " + emailAccount.name, EventLogEntryType.Information,emailAccount.name);
                    MySqlDataReader rdrInbox = null;
                    sql = "SELECT count(*) FROM inbox i, account a where i.account_name = a.name and a.name=@name";
                    MySqlCommand cmdInbox = new MySqlCommand(sql, dataConnection);
                    cmdInbox.Parameters.AddWithValue("name", emailAccount.name);
                    rdrInbox = cmdInbox.ExecuteReader();

                    if (rdrInbox.Read())
                    {
                        if (rdrInbox.GetInt32(0) == 0)
                        {
                            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "No messages in inbox, try to fetch all last 30 days message to test the rule", EventLogEntryType.Information,emailAccount.name);
                            rdrInbox.Dispose();
                            CoreFeature.getInstance().FetchRecentMessages(emailAccount, true);
                        }
                        else
                        {
                            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Inbox already consisted of previous fetched message, now only fetch new message", EventLogEntryType.Information, emailAccount.name);
                            rdrInbox.Dispose();
                            CoreFeature.getInstance().FetchRecentMessages(emailAccount, false);
                        }
                    }
                    rdrInbox.Close();
                    cmdInbox.Dispose();

                    //3. APPLY THE RULES
                    CoreFeature.getInstance().LogActivity(LogLevel.Debug, "About to apply notification rules", EventLogEntryType.Information, emailAccount.name);
                    MySqlCommand cmdRule;
                    MySqlDataReader rdrRule;
                    string sqlRule = "SELECT * FROM rule r";
                    cmdRule = new MySqlCommand(sqlRule, dataConnection);
                    rdrRule = cmdRule.ExecuteReader();
                    List<SupportAlerterLibrary.model.Rule> listRule = new List<SupportAlerterLibrary.model.Rule>();
                    
                    while (rdrRule.Read())
                    {
                        SupportAlerterLibrary.model.Rule rule = 
                            new SupportAlerterLibrary.model.Rule(
                            rdrRule.GetString(rdrRule.GetOrdinal("name")),
                            rdrRule.GetString(rdrRule.GetOrdinal("contains")), 
                            rdrRule.GetByte(rdrRule.GetOrdinal("send_sms")) == 1, 
                            rdrRule.GetByte(rdrRule.GetOrdinal("voice_call")) == 1,
                            rdrRule.GetByte(rdrRule.GetOrdinal("use_body")) == 1, 
                            rdrRule.GetByte(rdrRule.GetOrdinal("use_sender")) == 1,
                            rdrRule.GetString(rdrRule.GetOrdinal("sender_contains")),
                             rdrRule.GetByte(rdrRule.GetOrdinal("use_subject")) == 1,
                            rdrRule.GetString(rdrRule.GetOrdinal("subject_contains"))
                            );
                        listRule.Add(rule);
                        CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Will use the rule " + rule.name + ". Use body=" + rule.use_body + ", body contains " + rule.contains + ". Use sender=" + rule.use_sender + ", sender contains=" + rule.sender_contains + ". Use subject=" + rule.use_subject + ", subject contains=" + rule.subject_contains + ". Send sms = " + rule.send_sms + ". Voice call = " + rule.voice_call, EventLogEntryType.Information, emailAccount.name);
                    }
                    rdrRule.Close();
                    cmdRule.Dispose();

                    foreach (SupportAlerterLibrary.model.Rule rule in listRule)
                    {
                        CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Using the rule " + rule.name, EventLogEntryType.Information, emailAccount.name);
                        string use_rules = "";
                        if (rule.use_body)
                        {
                            use_rules = " body like '%" + rule.contains + "%' ";
                        }

                        if (rule.use_sender)
                        {
                            if(use_rules.Equals(""))
                                use_rules += " sender like '%" + rule.sender_contains + "%' ";
                            else
                                use_rules += " and sender like '%" + rule.sender_contains + "%' ";
                        }

                        if (rule.use_subject)
                        {
                            if (use_rules.Equals(""))
                                use_rules += " subject like '%" + rule.subject_contains + "%' ";
                            else
                                use_rules += " and subject like '%" + rule.subject_contains + "%' ";
                        }

                        sql = "SELECT idinbox, account_name,date,sender,subject FROM inbox where " + use_rules + " and handled=0";
                        cmdInbox = new MySqlCommand(sql, dataConnection);
                        rdrInbox = cmdInbox.ExecuteReader();
                        List<Inbox> listInbox = new List<Inbox>();
                        while (rdrInbox.Read())
                        {
                            Inbox inbox = new Inbox(rdrInbox.GetInt32(rdrInbox.GetOrdinal("idinbox")), rdrInbox.GetString(rdrInbox.GetOrdinal("subject")));
                            listInbox.Add(inbox);
                            if (RegistrySettings.loggingLevel.Equals("Normal"))
                            {
                                CoreFeature.getInstance().LogActivity(LogLevel.Normal, "Email information : Date=" + inbox.date + ", Sender=" + inbox.sender + ", Subject=" + inbox.subject, EventLogEntryType.Information, emailAccount.name);
                            }
                            else if (RegistrySettings.loggingLevel.Equals("Debug"))
                            {
                                CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Email information : Date=" + inbox.date + ", Sender=" + inbox.sender + ", Subject=" + inbox.subject + ", Body = " + inbox.body, EventLogEntryType.Information, emailAccount.name);
                            }
                        }
                        rdrInbox.Close();
                        cmdInbox.Dispose();
                        foreach(Inbox inbox in listInbox)
                        {
                            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Acted upon the rule " + rule.name + " of message " + inbox.subject, EventLogEntryType.Information, emailAccount.name);
                            if (rule.send_sms)
                            {
                                string smsContent = "You have warning notification from SENDER";
                                MySqlCommand cmdSend = new MySqlCommand("insert into send_sms(idinbox,content,status,account_name) values(" + inbox.idinbox + ",'" + smsContent + "','Draft','" + emailAccount.name + "')", dataConnection);
                                cmdSend.ExecuteNonQuery();
                                CoreFeature.getInstance().LogActivity(LogLevel.Normal, "Inserting into SMS table. Content : " + smsContent, EventLogEntryType.Information, emailAccount.name);
                            }
                            if (rule.voice_call)
                            {
                                MySqlCommand cmdSend = new MySqlCommand("insert into voice_call(idinbox,status, account_name) values(" + inbox.idinbox + ",'Draft','" + emailAccount.name + "')", dataConnection);
                                cmdSend.ExecuteNonQuery();
                                CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Inserting into Voice_call table ", EventLogEntryType.Information, emailAccount.name);
                            }
                            
                            MySqlCommand cmdUpdateInbox = new MySqlCommand("update inbox set handled=1 where idinbox=" + inbox.idinbox, dataConnection);
                            cmdUpdateInbox.ExecuteNonQuery();
                            CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Set HANDLED=1 for the inbox entry ID = " + inbox.idinbox, EventLogEntryType.Information, emailAccount.name);
                        }
                    }
                    
                    rdrRule.Close();
                    cmdRule.Dispose();
                }

                //4. PROCESS, IF ANY, VOICE_CALL / SMS THAT NEED TO BE DELIVERED
                CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Processing of SMS/Voice Call", EventLogEntryType.Information);
                MySqlCommand cmdSms = new MySqlCommand("select idsend_sms, content,account_name from send_sms where status='Draft'", dataConnection);
                MySqlDataReader rdrSms = cmdSms.ExecuteReader();
                List<SendSms> listSendSms = new List<SendSms>();
                while (rdrSms.Read())
                {
                    listSendSms.Add(new SendSms(rdrSms.GetInt32(rdrSms.GetOrdinal("idsend_sms")), rdrSms.GetString(rdrSms.GetOrdinal("content")), rdrSms.GetString(rdrSms.GetOrdinal("account_name"))));
                }
                rdrSms.Close();
                cmdSms.Dispose();

                foreach(SendSms sendSms in listSendSms)
                {
                    SmsGateway.getInstance().processSmsNotification(sendSms);//once processed, the status will change into DELIVERED/FAILED
                    CoreFeature.getInstance().LogActivity(LogLevel.Normal, "Sending SMS. Content : '" +  sendSms.content + "'", EventLogEntryType.Information, sendSms.account_name);
                }

                MySqlCommand cmdVoiceCall = new MySqlCommand("select idvoice_call,status,account_name from voice_call where status='Draft'", dataConnection);
                MySqlDataReader rdrVoiceCall = cmdVoiceCall.ExecuteReader();
                List<VoiceCall> listVoiceCall = new List<VoiceCall>();
                while (rdrVoiceCall.Read())
                {
                    listVoiceCall.Add(new VoiceCall(rdrVoiceCall.GetInt32(rdrVoiceCall.GetOrdinal("idvoice_call")), rdrVoiceCall.GetString(rdrVoiceCall.GetOrdinal("status")), rdrVoiceCall.GetString(rdrVoiceCall.GetOrdinal("account_name"))));
                }
                rdrVoiceCall.Close();
                cmdVoiceCall.Dispose();

                foreach (VoiceCall voiceCall in listVoiceCall)
                {
                    SmsGateway.getInstance().processCallNotification(voiceCall);//once processed, the status will change into DELIVERED/FAILED
                    CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Voice call for voiceCall.id=" + voiceCall.idvoice_call, EventLogEntryType.Information, voiceCall.account_name);
                
                }

                CoreFeature.getInstance().getDataConnection().Close();
            }
            catch (Exception ex)
            {
                CoreFeature.getInstance().LogActivity(LogLevel.Normal, "[Internal Application Error] " + ex.Message, EventLogEntryType.Error);
                CoreFeature.getInstance().getDataConnection().Close();
            }
            dataConnection.Close();
            timer.Start();
        }

        internal void DoStop()
        {
            Stop();
        }
    }
}
