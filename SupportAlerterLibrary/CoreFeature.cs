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

        public bool TestConnection(string name, string server, int port, bool use_ssl, string username, string password)
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
    }
}
