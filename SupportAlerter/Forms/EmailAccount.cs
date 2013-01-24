using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using SupportAlerterLibrary;

namespace SupportAlerter
{
    public partial class EmailAccount : UserControl
    {
        private string accountName;
        private Settings settings;

        public EmailAccount()
        {
            InitializeComponent();

        }

        public EmailAccount(string accountName, Settings settings)
        {
            InitializeComponent();
            this.accountName = accountName;
            this.settings = settings;
            SqlCeConnection connection = CoreFeature.getInstance().getDataConnection();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from account where name='" + accountName  + "' order by name";
            cmd.CommandType = CommandType.Text;
            SqlCeDataReader rdr = cmd.ExecuteReader();
                
            if (rdr.Read())
            {
                txtName.Text = rdr.GetString(rdr.GetOrdinal("name"));
                txtServer.Text = rdr.GetString(rdr.GetOrdinal("server"));
                txtPort.Value = rdr.GetInt32(rdr.GetOrdinal("port"));
                chkUseSSL.Checked = rdr.GetByte(rdr.GetOrdinal("use_ssl"))==1;
                txtUsername.Text = rdr.GetString(rdr.GetOrdinal("username"));
                txtPassword.Text = Cryptho.Decrypt(rdr.GetString(rdr.GetOrdinal("password")));
                chkActive.Checked = rdr.GetByte(rdr.GetOrdinal("active")) == 1;
            }

            cmd.Dispose();
            rdr.Dispose();
            connection.Close();
            
        }

        private bool saveConnection()
        {
            SqlCeConnection connection = CoreFeature.getInstance().getDataConnection();
            SqlCeCommand cmd = connection.CreateCommand();
            if (accountName == "")
            {
                cmd.CommandText = "insert into account(name,server,port,use_ssl,username,password,active) values ('" + txtName.Text + "','" + txtServer.Text + "'," + txtPort.Value + "," + Convert.ToInt32(chkUseSSL.Checked) + ",'" + txtUsername.Text + "','" + Cryptho.Encrypt(txtPassword.Text) + "'," + Convert.ToInt32(chkActive.Checked) + ")";
            }
            else
            {
                cmd.CommandText = "update account set name='" + txtName.Text + "', server='" + txtServer.Text + "',port=" + txtPort.Value + ",use_ssl=" + Convert.ToInt32(chkUseSSL.Checked) + ",username='" + txtUsername.Text + "',password='" + Cryptho.Encrypt(txtPassword.Text) + "', active=" + Convert.ToInt32(chkActive.Checked) + " where name='" + accountName + "'";
            }
            cmd.CommandType = CommandType.Text;
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected != 1)
            {
                MessageBox.Show("Error occured in saving your connection info. Please correct them before testing connection");
                cmd.Dispose();
                connection.Close();
                return false;
            }
            settings.updateListAccountName(txtName.Text);
            cmd.Dispose();
            connection.Close();
            
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveConnection();
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (saveConnection())
            {
                if (Program.mainForm.TestConnection(txtServer.Text, Convert.ToInt32(txtPort.Value), chkUseSSL.Checked, txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show(this, "Connection succeeded!");
                }
            }
        }

        
    }
}
