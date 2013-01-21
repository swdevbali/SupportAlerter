using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupportAlerter
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            RegistrySettings.loadValues();
            /*popServerTextBox.Text = RegistrySettings.pop3ServerAddress;
            portTextBox.Text = RegistrySettings.pop3ServerPort+"";
            useSslCheckBox.Checked  = RegistrySettings.pop3UseSSL.Equals("True");
            loginTextBox.Text = RegistrySettings.pop3Username;
            passwordTextBox.Text = RegistrySettings.pop3Password;*/

            string dbfile = "|DataDirectory|\\Database\\AccountDatabase.sdf";
            using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + dbfile))
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select name from account order by name";
                cmd.CommandType = CommandType.Text;
                SqlCeDataReader rdr = cmd.ExecuteReader();
                lvAccount.Items.Clear();
                /*if (!rdr.HasRows)
                {
                    lblAccountInfo.Text = "You don't have any email account configured. Please add an account";
                }*/
                while (rdr.Read())
                {
                  lvAccount.Items.Add(rdr.GetString(0));
                }

                cmd.Dispose();
                rdr.Dispose();
                connection.Dispose();
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
            /*
            RegistrySettings.pop3ServerAddress = popServerTextBox.Text;
            RegistrySettings.pop3ServerPort = Convert.ToInt32(portTextBox.Text);
            RegistrySettings.pop3UseSSL = useSslCheckBox.Checked + "";
            RegistrySettings.pop3Username = loginTextBox.Text;
            RegistrySettings.pop3Password = Cryptho.Encrypt(passwordTextBox.Text);
            */
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

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            SaveValues();
            RegistrySettings.writeValues();
            if (Program.supportAlerter.TestConnection())
            {
                MessageBox.Show(this,"Connection succeeded!");
            }
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccount.SelectedIndex >= 0)
            {
                panelAccountDetail.Controls.Clear();
                panelAccountDetail.Controls.Add(new EmailAccount(lvAccount.Text));

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
                if (MessageBox.Show("Are you sure you want to delete this account?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string dbfile = "|DataDirectory|\\Database\\AccountDatabase.sdf";
                    using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + dbfile))
                    {
                        connection.Open();
                        SqlCeCommand cmd = connection.CreateCommand();
                        cmd.CommandText = "delete from account where name='" + lvAccount.Text + "'";
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        lvAccount.Items.RemoveAt(lvAccount.SelectedIndex);
                        cmd.Dispose();
                        connection.Dispose();
                    }
                }
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            lvAccount.Items.Add("");
            lvAccount.SelectedIndex = lvAccount.Items.Count - 1;
        }
    }
}
