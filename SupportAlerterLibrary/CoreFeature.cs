﻿using OpenPop.Pop3;
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
        //private MySqlConnection  dataConnection = null;
        private static CoreFeature instance = null;
        
        private CoreFeature()
        {
            RegistrySettings.loadValues();
            createConnection();
        }

        private MySqlConnection createConnection()
        {
            return new MySqlConnection("Server=" + RegistrySettings.mysqlHost + ";Database=" + RegistrySettings.mysqlDatabase + ";Uid=" + RegistrySettings.mysqlUsername + ";Pwd=" + RegistrySettings.mysqlPassword);
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
            MySqlConnection dataConnection;
            dataConnection = createConnection();
            if (dataConnection.State == ConnectionState.Closed)
            {
                try
                {
                    dataConnection.Open();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Database connection error : " + ex.Message);
                    CoreFeature.getInstance().LogActivity(LogLevel.Normal, "Database connection error : " + ex.Message,EventLogEntryType.Error);
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
                CoreFeature.getInstance().LogActivity(LogLevel.Normal,  "[POP3 Server Authentication] for " + name + ". The server did not accept the user credentials!", EventLogEntryType.FailureAudit);
            }
            catch (PopServerNotFoundException)
            {
                CoreFeature.getInstance().LogActivity(LogLevel.Normal, "[POP3 Retrieval] for " + name + ". The server could not be found", EventLogEntryType.FailureAudit);
            }
            catch (PopServerLockedException)
            {
                CoreFeature.getInstance().LogActivity(LogLevel.Normal,  "[POP3 Account Locked] for " + name + ". The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", EventLogEntryType.FailureAudit);
            }
            catch (LoginDelayException)
            {
                CoreFeature.getInstance().LogActivity(LogLevel.Normal, "[POP3 Account Login Delay] for " + name + ". Login not allowed. Server enforces delay between logins. Have you connected recently?", EventLogEntryType.FailureAudit);
            }
            catch (Exception e)
            {
                CoreFeature.getInstance().LogActivity(LogLevel.Normal,  "[POP3 Retrieval] for " + name + ". Error occurred retrieving mail. " + e.Message, EventLogEntryType.FailureAudit);
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
            {
                emailUsername = "recent:" + emailAccount.username;
                CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Fetching *last 30 days* message", EventLogEntryType.Information, emailAccount.name);
            }
            else
            {
                emailUsername = emailAccount.username;
                CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Fetching *new* message", EventLogEntryType.Information, emailAccount.name);
            }

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
                    string sql = "insert into inbox(account_name,sender,subject,body,date, handled) values (@account_name,@sender,@subject,@body,@date, 0)";
                    cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@account_name", emailAccount.name);
                    cmd.Parameters.AddWithValue("@sender", message.Headers.From);
                    cmd.Parameters.AddWithValue("@subject", message.Headers.Subject);
                    cmd.Parameters.AddWithValue("@body", messageBody);
                    cmd.Parameters.AddWithValue("@date", message.Headers.Date);

                    try
                    {
                        int rowAffected = cmd.ExecuteNonQuery();
                        CoreFeature.getInstance().LogActivity(LogLevel.Normal, "Inserting email to inbox table. Sender : " + message.Headers.From + "\nSubject : " + message.Headers.Subject + "\nBody : " + messageBody, EventLogEntryType.Information, emailAccount.name);
                    }
                    catch (Exception ex)
                    {
                        CoreFeature.getInstance().LogActivity(LogLevel.Normal, "[Internal Application Error] FetchRecentMessages " + ex.Message, EventLogEntryType.Information);
                    }
                    cmd.Dispose();
                    connection.Close();
                }
            }
            else
            {
                CoreFeature.getInstance().LogActivity(LogLevel.Debug, "Unable to login to your email", EventLogEntryType.Information);
            }
        }

        public void LogActivity(LogLevel logLevel, string message, EventLogEntryType eventLogEntryType, string account=null)
        {
            if (RegistrySettings.loggingLevel.Equals("None")) return;
            
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            string sql = "insert into log(message, account_name) values (@message, @account_name)";
            
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@message", message);
            cmd.Parameters.AddWithValue("@account_name", account);
            

            

            if (logLevel == LogLevel.Debug && (RegistrySettings.loggingLevel.Equals("Debug") || RegistrySettings.loggingLevel.Equals("Normal")))
            {
                int rowAffected = cmd.ExecuteNonQuery();
            }
            else if (logLevel == LogLevel.Normal && RegistrySettings.loggingLevel.Equals("Normal"))
            {
                int rowAffected = cmd.ExecuteNonQuery();
            }
            cmd.Dispose();
            connection.Close();
         }
    }

    public enum LogLevel
    {
        Normal,
        Debug
    }
}
