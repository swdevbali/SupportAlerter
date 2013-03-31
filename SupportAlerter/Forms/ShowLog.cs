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

        private void showLog()
        {
            /*EventLog myLog = new EventLog();
            myLog.Log = Program.EventLogName;
            
            dataGridView1.Rows.Clear();
            foreach (EventLogEntry entry in myLog.Entries)
            {
                dataGridView1.Rows.Add(new object[] { entry.TimeGenerated, entry.Message });
            }    
             */
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            string sql = "select * from  log  order by occur desc limit 0, " + numLimit.Value;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(new object[] { rdr.GetDateTime(rdr.GetOrdinal("occur")), rdr.GetString(rdr.GetOrdinal("message")) });
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
    }
}
