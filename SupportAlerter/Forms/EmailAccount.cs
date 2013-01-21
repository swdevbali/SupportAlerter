using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace SupportAlerter
{
    public partial class EmailAccount : UserControl
    {
        private string accountName;

        public EmailAccount()
        {
            InitializeComponent();

        }

        public EmailAccount(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            string dbfile = "|DataDirectory|\\Database\\AccountDatabase.sdf";
            using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + dbfile))
            {
                connection.Open();
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
                }

                cmd.Dispose();
                rdr.Dispose();
                connection.Dispose();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string dbfile = "|DataDirectory|\\Database\\AccountDatabase.sdf";
            using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + dbfile))
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                if (accountName == "")
                {
                    cmd.CommandText = "insert into account(name,server,port,use_ssl,username,password) values ('" + txtName.Text + "','" + txtServer.Text  + "'," + txtPort.Value  + "," + Convert.ToInt32( chkUseSSL.Checked)  + ",'" + txtUsername.Text  + "','" + Cryptho.Encrypt(txtPassword.Text)  + "')";
                }
                else
                {
                    cmd.CommandText = "update account set name='" + txtName.Text + "', server='" + txtServer.Text + "',port=" + txtPort.Value + ",use_ssl=" + Convert.ToInt32(chkUseSSL.Checked) + ",username='" + txtUsername.Text + "',password='" + Cryptho.Encrypt(txtPassword.Text) + "' where name='" + accountName + "'";
                }
                    cmd.CommandType = CommandType.Text;
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected != 1)
                {
                    MessageBox.Show("Error occured in saving your connection info. Please correct them before testing connection");
                    cmd.Dispose();
                    connection.Dispose();
                    return;
                }
                

                cmd.Dispose();
                connection.Dispose();
            }
        }
    }
}
