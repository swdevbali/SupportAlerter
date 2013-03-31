using MySql.Data.MySqlClient;
using SupportAlerterLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupportAlerter.Forms
{
    public partial class ShowLog : Form
    {
        public ShowLog()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
        }

        private void showLog(string sql=null)
        {
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            if (sql == null)
            {
                 sql = "select * from  log  order by occur desc limit 0, " + numLimit.Value;
            }

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();            
            int iAccountName;
            while (rdr.Read())
            {
                string accountName = "";
                iAccountName = rdr.GetOrdinal("account_name");
                if (!rdr.IsDBNull(iAccountName))
                {
                    accountName = rdr.GetString(iAccountName);
                }
                dataGridView1.Rows.Add(new object[] { rdr.GetDateTime(rdr.GetOrdinal("occur")), accountName, rdr.GetString(rdr.GetOrdinal("message")) });
            }
            rdr.Close();
            cmd.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            showLog();
            timer1.Start();
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                timer1.Interval = Convert.ToInt32(numSeconds.Value) * 1000;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void numSeconds_ValueChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                timer1.Stop();
                timer1.Interval = Convert.ToInt32(numSeconds.Value) * 1000;
                timer1.Start();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "select * from  log  where occur >= " + dtStart.Value.Year + dtStart.Value.Month + dtStart.Value.Day + dtStart.Value.Hour + dtStart.Value.Minute + dtStart.Value.Second + " order by occur limit 0, " + numLimit.Value;
            showLog(sql);
        }
    }
}
