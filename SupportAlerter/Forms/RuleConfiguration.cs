using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SupportAlerterLibrary;
using System.Diagnostics;
using OpenPop.Mime;
using SupportAlerterLibrary.model;

namespace SupportAlerter.Forms
{
    public partial class RuleConfiguration : UserControl
    {
        private string ruleName;
        private Settings settings;

        public RuleConfiguration()
        {
            InitializeComponent();
        }

        public RuleConfiguration(string p, Settings settings)
        {
            InitializeComponent();
            this.ruleName = p;
            this.settings = settings;

            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from rule where name='" + ruleName + "'";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txtName.Text = rdr.GetString(rdr.GetOrdinal("name"));
                txtContains.Text = rdr.GetString(rdr.GetOrdinal("contains"));
                chkSmsAlert.Checked = rdr.GetByte(rdr.GetOrdinal("send_sms")) == 1;
                chkVoiceCall.Checked = rdr.GetByte(rdr.GetOrdinal("voice_call")) == 1;
            }

            cmd.Dispose();
            rdr.Dispose();
            connection.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveRule();
        }

        private bool saveRule()
        {
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            MySqlCommand cmd = connection.CreateCommand();
            if (ruleName == "")
            {
                cmd.CommandText = "insert into rule(name,contains,send_sms,voice_call) values ('" + txtName.Text + "','" + txtContains.Text + "'," + Convert.ToInt32(chkSmsAlert.Checked) + "," + Convert.ToInt32(chkVoiceCall.Checked) +  ")";
            }
            else
            {
                cmd.CommandText = "update rule set name='" + txtName.Text + "', contains='" + txtContains.Text + "',send_sms=" + Convert.ToInt32(chkSmsAlert.Checked) + ",voice_call=" + Convert.ToInt32(chkVoiceCall.Checked) +  " where name='" + ruleName + "'";
            }
            cmd.CommandType = CommandType.Text;
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected != 1)
            {
                MessageBox.Show("Error occured in saving your rule configuration. Please correct them before testing connection");
                cmd.Dispose();
                connection.Close();
                return false;
            }
            settings.updateListRuleName(txtName.Text);
            cmd.Dispose();
            connection.Close();

            return true;
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (saveRule())
            {
                //check whether inbox is empty. If it's do the recent: connection to get lat 30days messages
                MySqlDataReader rdr = null;
                try
                {
                    MySqlCommand cmd = CoreFeature.getInstance().getDataConnection().CreateCommand();
                    cmd.CommandText = "select name, server,port,use_ssl,username,password,active from account where active=1";
                    cmd.CommandType = CommandType.Text;
                    rdr = cmd.ExecuteReader();
                    List<Account> listAccount = new List<Account>();
                    while (rdr.Read())
                    {
                        listAccount.Add(new Account(rdr.GetString(rdr.GetOrdinal("name")), rdr.GetString(rdr.GetOrdinal("server")), rdr.GetInt32(rdr.GetOrdinal("port")), rdr.GetString(rdr.GetOrdinal("username")), Cryptho.Decrypt(rdr.GetString(rdr.GetOrdinal("password"))), rdr.GetByte(rdr.GetOrdinal("use_ssl")) == 1, rdr.GetByte(rdr.GetOrdinal("active")) == 1));
                    }
                    rdr.Close();
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
                            {
                                FetchRecentMessages(emailAccount);
                            }

                        }
                        rdrInbox.Dispose();
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
            }
        }

        //focusing first on gMail account using recent: in username
        private static void FetchRecentMessages(Account emailAccount)
        {
            if (SupportAlerterLibrary.CoreFeature.getInstance().Connect(emailAccount.name, emailAccount.server, emailAccount.port, emailAccount.use_ssl, "recent:" + emailAccount.username, emailAccount.password))
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

                    //save to appropriate inbox
                    MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "insert into inbox(account_name,sender,subject,body) values ('" + emailAccount.name + "','" + message.Headers.From + "','" +  message.Headers.Subject + "','" +  messageBody + "')";
                    cmd.CommandType = CommandType.Text;
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected != 1)
                    {
                        MessageBox.Show("Error occured in saving your connection info. Please correct them before testing connection");
                        cmd.Dispose();
                        connection.Close();
                    }
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
    }
}
