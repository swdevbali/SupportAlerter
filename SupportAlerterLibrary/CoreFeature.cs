using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupportAlerterLibrary
{
    public class CoreFeature
    {
        private readonly Pop3Client pop3Client = new Pop3Client();
        private readonly SqlCeConnection dataConnection = null;

        private static CoreFeature instance = null;
        private CoreFeature()
        {
            dataConnection = new SqlCeConnection("Data Source=|DataDirectory|\\Database\\AccountDatabase.sdf");
        }

        public static CoreFeature getInstance()
        {
            if (instance == null)
            {
                instance = new CoreFeature();
              }
            return instance;
        }

        public SqlCeConnection getDataConnection()
        {
            return dataConnection;
        }

        public bool TestConnection(bool guiMode, string server, int port, bool use_ssl, string username, string password)
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
                if (guiMode) MessageBox.Show("POP3 Server Authentication", "The server did not accept the user credentials!");
                else EventLog.WriteEntry(Program.EventLogName, "[POP3 Server Authentication] The server did not accept the user credentials!", EventLogEntryType.FailureAudit, 1);
            }
            catch (PopServerNotFoundException)
            {
                if (guiMode) MessageBox.Show("POP3 Retrieval", "The server could not be found");
                else EventLog.WriteEntry(Program.EventLogName, "[POP3 Retrieval] The server could not be found", EventLogEntryType.FailureAudit, 1);
            }
            catch (PopServerLockedException)
            {
                if (guiMode) MessageBox.Show("POP3 Account Locked", "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?");
                else EventLog.WriteEntry(Program.EventLogName, "[POP3 Account Locked] The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", EventLogEntryType.FailureAudit, 1);
            }
            catch (LoginDelayException)
            {
                if (guiMode) MessageBox.Show("POP3 Account Login Delay", "Login not allowed. Server enforces delay between logins. Have you connected recently?");
                else EventLog.WriteEntry(Program.EventLogName, "[POP3 Account Login Delay] Login not allowed. Server enforces delay between logins. Have you connected recently?", EventLogEntryType.FailureAudit, 1);
            }
            catch (Exception e)
            {
                if (guiMode) MessageBox.Show("POP3 Retrieval", "Error occurred retrieving mail. " + e.Message);
                else EventLog.WriteEntry(Program.EventLogName, "[POP3 Retrieval] Error occurred retrieving mail. " + e.Message, EventLogEntryType.FailureAudit, 1);
            }
            return false;
        }
    }
}
