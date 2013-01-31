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
            if(ruleName=="") settings.updateListRuleName(txtName.Text);
            cmd.Dispose();
            connection.Close();

            return true;
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
                        string sql = "SELECT account_name,date,sender,subject FROM inbox where body like '%" + txtContains.Text + "%'";
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
                    EventLog.WriteEntry(Program.EventLogName, "This is my error " + ex.Message);
                    rdr.Close();
                    CoreFeature.getInstance().getDataConnection().Close();
                }
            }

           
            Cursor = Cursors.Default;
        }

        
    }
}
