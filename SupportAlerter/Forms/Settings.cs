using SupportAlerter.Helper;
using SupportAlerterLibrary;
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


            ReadValues();
            SqlCeConnection connection = CoreFeature.getInstance().getDataConnection();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select name from account order by name";
            cmd.CommandType = CommandType.Text;
            SqlCeDataReader rdr = cmd.ExecuteReader();
            lvAccount.Items.Clear();

            while (rdr.Read())
            {
                lvAccount.Items.Add(rdr.GetString(0));
            }

            cmd.Dispose();
            rdr.Dispose();
            connection.Close();
        }

        private void ReadValues()
        {
            numEmailCheckInterval.Value = RegistrySettings.emailCheckInterval;
            updateServiceStatus();
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
                    SqlCeConnection connection = CoreFeature.getInstance().getDataConnection();
                    SqlCeCommand cmd = connection.CreateCommand();
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


       

    }
}
