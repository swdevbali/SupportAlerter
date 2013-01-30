using SupportAlerter.Helper;
using SupportAlerterLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SupportAlerter.Forms;

namespace SupportAlerter
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            RegistrySettings.loadValues();


            ReadValues();
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            lvAccount.Items.Clear();

            if (connection != null)
            {
                //email accounts
                MySqlCommand cmd;
                MySqlDataReader rdr;
                cmd = connection.CreateCommand();
                cmd.CommandText = "select name from account order by name";
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    lvAccount.Items.Add(rdr.GetString(0));
                }
                cmd.Dispose();
                rdr.Dispose();

                //rules
                cmd = connection.CreateCommand();
                cmd.CommandText = "select name from rule order by name";
                cmd.CommandType = CommandType.Text;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listRuleName.Items.Add(rdr.GetString(0));
                }
                cmd.Dispose();
                rdr.Dispose();
                
                connection.Close();
            }
            cboDatabaseType.SelectedIndex = 0;
        }

        private void ReadValues()
        {
            numEmailCheckInterval.Value = RegistrySettings.emailCheckInterval;
            updateServiceStatus();
            txtHost.Text = RegistrySettings.mysqlHost;
            txtDatabase.Text = RegistrySettings.mysqlDatabase;
            txtUsername.Text = RegistrySettings.mysqlUsername;
            txtPassword.Text = RegistrySettings.mysqlPassword;
        }

        private void updateServiceStatus()
        {
            lblInfoService.Text = ServiceManagement.getServiceStatus();
            if (lblInfoService.Text.Contains("Running"))
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else if (lblInfoService.Text.Contains("Stopped"))
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveValues();
            RegistrySettings.writeValues();
            Close();
        }

        private void SaveValues()
        {

            RegistrySettings.emailCheckInterval = Convert.ToInt32(numEmailCheckInterval.Value);
            RegistrySettings.mysqlHost = txtHost.Text;
            RegistrySettings.mysqlDatabase = txtDatabase.Text;
            RegistrySettings.mysqlUsername = txtUsername.Text;
            RegistrySettings.mysqlPassword = txtPassword.Text;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveValues();
            RegistrySettings.writeValues();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccount.SelectedIndex >= 0)
            {
                panelAccountDetail.Controls.Clear();
                panelAccountDetail.Controls.Add(new EmailAccount(lvAccount.Text, this));

            }
            else
            {
                panelAccountDetail.Controls.Clear();
                panelAccountDetail.Controls.Add(lblAccountInfo);
            }
        }

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            if (lvAccount.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this account?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "delete from account where name='" + lvAccount.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    lvAccount.Items.RemoveAt(lvAccount.SelectedIndex);
                    cmd.Dispose();
                    connection.Close();
                   
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            lvAccount.Items.Add("");
            lvAccount.SelectedIndex = lvAccount.Items.Count - 1;
        }

        internal void updateListAccountName(string p)
        {
            lvAccount.Items[lvAccount.SelectedIndex] = p;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            ServiceManagement.startService();
            updateServiceStatus();
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            ServiceManagement.stopService();
            updateServiceStatus();
            btnStart.Enabled = true;
        }

        private void btnTestDatabaseConnection_Click(object sender, EventArgs e)
        {
            SaveValues();
            RegistrySettings.writeValues();
            try
            {
                MySqlConnection con = new MySqlConnection("Server=" + RegistrySettings.mysqlHost + ";Database=" + RegistrySettings.mysqlDatabase + ";Uid=" + RegistrySettings.mysqlUsername + ";Pwd=" + RegistrySettings.mysqlPassword);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection succees!");
                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error : " + ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnRuleAdd_Click(object sender, EventArgs e)
        {
            listRuleName.Items.Add("");
            listRuleName.SelectedIndex = listRuleName.Items.Count - 1;
        }

        private void listRuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listRuleName.SelectedIndex >= 0)
            {
                pnlRuleDetail.Controls.Clear();
                pnlRuleDetail.Controls.Add(new RuleConfiguration(listRuleName.Text, this));

            }
            else
            {
                pnlRuleDetail.Controls.Clear();
                pnlRuleDetail.Controls.Add(lblRuleInfo);
            }
        }

        internal void updateListRuleName(string p)
        {
            listRuleName.Items[listRuleName.SelectedIndex] = p;   
        }

        private void btnRuleDelete_Click(object sender, EventArgs e)
        {
            if (listRuleName.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this rule?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "delete from rule where name='" + listRuleName.Text + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    listRuleName.Items.RemoveAt(listRuleName.SelectedIndex);
                    cmd.Dispose();
                    connection.Close();

                }
            }
        }
    }
}
