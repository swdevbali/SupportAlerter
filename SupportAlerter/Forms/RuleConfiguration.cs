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
using System.Text.RegularExpressions;

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

        public RuleConfiguration(string ruleName, Settings settings)
        {
            InitializeComponent();
            this.ruleName = ruleName;
            this.settings = settings;

            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from rule where name='" + ruleName + "'";
            cmd.CommandType = CommandType.Text;
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                txtName.Text = rdr.GetString(rdr.GetOrdinal("name"));
                txtBodyContains.Text = rdr.GetString(rdr.GetOrdinal("contains"));
                chkSmsAlert.Checked = rdr.GetByte(rdr.GetOrdinal("send_sms")) == 1;
                chkVoiceCall.Checked = rdr.GetByte(rdr.GetOrdinal("voice_call")) == 1;
                chkBody.Checked = rdr.GetByte(rdr.GetOrdinal("use_body")) == 1;
                chkSubject.Checked = rdr.GetByte(rdr.GetOrdinal("use_subject")) == 1;
                chkSender.Checked = rdr.GetByte(rdr.GetOrdinal("use_sender")) == 1;
                txtSubjectContains.Text = rdr.GetString(rdr.GetOrdinal("subject_contains"));
                txtSenderContains.Text = rdr.GetString(rdr.GetOrdinal("sender_contains"));

            }
            else
            {
                chkBody.Checked = true;
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
            if (!PassValidation())
            {
                return false;
            }
            string sql;
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            MySqlCommand cmd = null;
            if (ruleName == "")
            {
                sql = "insert into rule(name,contains,send_sms,voice_call,use_body,use_sender,sender_contains,use_subject,subject_contains) values (@name,@body,@send_sms,@voice_call,@use_body,@use_sender,@sender_contains,@use_subject,@subject_contains)";
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("name", txtName.Text);
                cmd.Parameters.AddWithValue("body", txtBodyContains.Text);
                cmd.Parameters.AddWithValue("send_sms", Convert.ToInt32(chkSmsAlert.Checked));
                cmd.Parameters.AddWithValue("voice_call", Convert.ToInt32(chkVoiceCall.Checked));
                cmd.Parameters.AddWithValue("use_body", Convert.ToInt32(chkBody.Checked));
                cmd.Parameters.AddWithValue("use_sender", Convert.ToInt32(chkSender.Checked));
                cmd.Parameters.AddWithValue("sender_contains", txtSenderContains.Text);
                cmd.Parameters.AddWithValue("use_subject", Convert.ToInt32(chkSubject.Checked));
                cmd.Parameters.AddWithValue("subject_contains", txtSubjectContains.Text);
            }
            else
            {
                sql = "update rule set name=@name, contains=@body,send_sms=@send_sms,voice_call=@voice_call,use_body=@use_body,use_sender=@use_sender,sender_contains=@sender_contains,use_subject=@use_subject,subject_contains=@subject_contains where name=@oldName";
                cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("name", txtName.Text);
                cmd.Parameters.AddWithValue("body", txtBodyContains.Text);
                cmd.Parameters.AddWithValue("send_sms", Convert.ToInt32(chkSmsAlert.Checked));
                cmd.Parameters.AddWithValue("voice_call", Convert.ToInt32(chkVoiceCall.Checked));
                cmd.Parameters.AddWithValue("use_body", Convert.ToInt32(chkBody.Checked));
                cmd.Parameters.AddWithValue("use_sender", Convert.ToInt32(chkSender.Checked));
                cmd.Parameters.AddWithValue("sender_contains", txtSenderContains.Text);
                cmd.Parameters.AddWithValue("use_subject", Convert.ToInt32(chkSubject.Checked));
                cmd.Parameters.AddWithValue("subject_contains", txtSubjectContains.Text);
                cmd.Parameters.AddWithValue("oldName", ruleName);
            }
            
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected != 1)
            {
                MessageBox.Show("Error occured in saving your rule configuration. Please correct them before testing connection");
                cmd.Dispose();
                connection.Close();
                return false;
            }
            if(ruleName=="") settings.updateListRuleName(txtName.Text);
            cmd.Dispose();
            connection.Close();

            return true;
        }

        private bool PassValidation()
        {
            if (chkSubject.Checked || chkBody.Checked || chkSender.Checked)
            {
                return true;
            }
            else
            {
                MessageBox.Show("At least you must check one checkbox : sender, subject or body");
            }
            return false;
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            lvEmails.Items.Clear();
            int no = 0;
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
                                CoreFeature.getInstance().FetchRecentMessages(emailAccount,true);
                            }
                            else
                            {   //already done that, now only fetch new message
                                rdrInbox.Dispose();
                                CoreFeature.getInstance().FetchRecentMessages(emailAccount, false);
                            }
                        }
                        cmdInbox.Dispose();

                        SupportAlerterLibrary.model.Rule rule = new SupportAlerterLibrary.model.Rule
                        (txtName.Text, txtBodyContains.Text, chkSmsAlert.Checked, chkVoiceCall.Checked, chkBody.Checked, chkSender.Checked, txtSenderContains.Text, chkSubject.Checked, txtSubjectContains.Text);

                        string use_rules = "";
                        if (rule.use_body)
                        {
                            use_rules = " body like '%" + rule.contains + "%' ";
                        }

                        if (rule.use_sender)
                        {
                            if (use_rules.Equals(""))
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

                        string sql = "SELECT account_name,date,sender,subject FROM inbox where " + use_rules;
                        cmdInbox = new MySqlCommand(sql, CoreFeature.getInstance().getDataConnection());
                        rdrInbox = cmdInbox.ExecuteReader();
                        string[] sub = new string[5];
                        while (rdrInbox.Read())
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = "" + ++no;
                            item.SubItems.Add(rdrInbox.GetString(rdrInbox.GetOrdinal("account_name")));
                            item.SubItems.Add(rdrInbox.GetString(rdrInbox.GetOrdinal("date")));
                            item.SubItems.Add(rdrInbox.GetString(rdrInbox.GetOrdinal("sender")));
                            item.SubItems.Add(rdrInbox.GetString(rdrInbox.GetOrdinal("subject")));
                            lvEmails.Items.Add(item);
                            
                        }
                        lvEmails.Refresh();
                        rdrInbox.Close();
                        cmdInbox.Dispose();
                    }
                    CoreFeature.getInstance().getDataConnection().Close();
                }
                catch (Exception ex)
                {
                    CoreFeature.getInstance().LogActivity(LogLevel.Debug, "This is my error " + ex.Message, EventLogEntryType.Information);
                    rdr.Close();
                    CoreFeature.getInstance().getDataConnection().Close();
                }
            }

           
            Cursor = Cursors.Default;
        }

        private void chkBody_CheckedChanged(object sender, EventArgs e)
        {
            txtBodyContains.Enabled = chkBody.Checked;
        }

        private void chkSender_CheckedChanged(object sender, EventArgs e)
        {
            txtSenderContains.Enabled = chkSender.Checked;
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtSubjectContains.Enabled = chkSubject.Checked;
        }

        
    }
}
