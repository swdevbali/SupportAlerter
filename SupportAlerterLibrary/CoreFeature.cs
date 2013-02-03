using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportAlerterLibrary.model;
using OpenPop.Mime;
using System.Text.RegularExpressions;

namespace SupportAlerterLibrary
{
    public class CoreFeature
    {
        private readonly Pop3Client pop3Client = new Pop3Client();
        private readonly MySqlConnection  dataConnection = null;
        private static CoreFeature instance = null;
        
        private CoreFeature()
        {
            RegistrySettings.loadValues();
            dataConnection = new MySqlConnection("Server="+ RegistrySettings.mysqlHost + ";Database=" + RegistrySettings.mysqlDatabase  +";Uid=" + RegistrySettings.mysqlUsername + ";Pwd=" + RegistrySettings.mysqlPassword);
        }

        public static CoreFeature getInstance()
        {
            if (instance == null)
            {
                instance = new CoreFeature();
            }
            return instance;
        }

        public Pop3Client getPop3Client()
        {
            return pop3Client;
        }

        public MySqlConnection getDataConnection()
        {
            if (dataConnection.State == ConnectionState.Closed)
            {
                try
                {
                    dataConnection.Open();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Database connection error : " + ex.Message);
                    EventLog.WriteEntry(Program.EventLogName, "Database connection error : " + ex.Message);
                    return null;
                }
            }
            return dataConnection;
        }

        public bool Connect(string name, string server, int port, bool use_ssl, string username, string password)
        {
            try
            {
                if (pop3Client.Connected) pop3Client.Disconnect();
                pop3Client.Connect(server, port, use_ssl);
                pop3Client.Authenticate(username, password);
                return true;
            }
            catch (InvalidLoginException)
            {
                EventLog.WriteEntry(Program.EventLogName, "[POP3 Server Authentication] for " + name + ". The server did not accept the user credentials!", EventLogEntryType.FailureAudit, 1);
            }
            catch (PopServerNotFoundException)
            {
                EventLog.WriteEntry(Program.EventLogName, "[POP3 Retrieval] for " + name + ". The server could not be found", EventLogEntryType.FailureAudit, 1);
            }
            catch (PopServerLockedException)
            {
                EventLog.WriteEntry(Program.EventLogName, "[POP3 Account Locked] for " + name + ". The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", EventLogEntryType.FailureAudit, 1);
            }
            catch (LoginDelayException)
            {
                EventLog.WriteEntry(Program.EventLogName, "[POP3 Account Login Delay] for " + name + ". Login not allowed. Server enforces delay between logins. Have you connected recently?", EventLogEntryType.FailureAudit, 1);
            }
            catch (Exception e)
            {
                EventLog.WriteEntry(Program.EventLogName, "[POP3 Retrieval] for " + name + ". Error occurred retrieving mail. " + e.Message, EventLogEntryType.FailureAudit, 1);
            }
            return false;
        }

        //focusing first on gMail account using recent: in username
        public void FetchRecentMessages(Account emailAccount, bool isFetchLast30days)
        {
            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            string emailUsername = null;

            if (isFetchLast30days)
                emailUsername = "recent:" + emailAccount.username;
            else emailUsername = emailAccount.username;

            if (SupportAlerterLibrary.CoreFeature.getInstance().Connect(emailAccount.name, emailAccount.server, emailAccount.port, emailAccount.use_ssl, emailUsername, emailAccount.password))
            {
                int count = SupportAlerterLibrary.CoreFeature.getInstance().getPop3Client().GetMessageCount();
                for (int i = 1; i <= count; i++)
                {
                    //Regards to : http://hpop.sourceforge.net/exampleSpecificParts.php
                    OpenPop.Mime.Message message = SupportAlerterLibrary.CoreFeature.getInstance().getPop3Client().GetMessage(i);
                    MessagePart messagePart = message.FindFirstPlainTextVersion();
                    if (messagePart == null) messagePart = message.FindFirstHtmlVersion();
                    string messageBody = null;
                    if (messagePart != null) messageBody = messagePart.GetBodyAsText();

                    messageBody = Regex.Replace(messageBody, "<.*?>", string.Empty);
                    //save to appropriate inbox
                    connection = CoreFeature.getInstance().getDataConnection();
                    string sql = "insert into inbox(account_name,sender,subject,body,date) values (@account_name,@sender,@subject,@body,@date)";
                    cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@account_name", emailAccount.name);
                    cmd.Parameters.AddWithValue("@sender", message.Headers.From);
                    cmd.Parameters.AddWithValue("@subject", message.Headers.Subject);
                    cmd.Parameters.AddWithValue("@body", messageBody);
                    cmd.Parameters.AddWithValue("@date", message.Headers.Date);

                    try
                    {
                        int rowAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(Program.EventLogName, ex.Message);
                    }
                    cmd.Dispose();
                    connection.Close();
                }
            }
            else
            {
                EventLog.WriteEntry(Program.EventLogName, "Unable to login to your email");
            }
        }
    }
}
