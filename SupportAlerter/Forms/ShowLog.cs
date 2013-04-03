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
            MySqlConnection connection = CoreFeature.getInstance().getDataConnection();
            string sql = "select name from account order by name";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            lstAccount.Items.Clear();
            while (rdr.Read())
            {
                lstAccount.Items.Add(rdr.GetString(0));
            }

            rdr.Close();
            cmd.Dispose();
            connection.Close();
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
            connection.Close();
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
            string sql = null;

            if (chkByTime.Checked)
            {
                sql = "select * from log where occur >= " + dtStart.Value.Year + dtStart.Value.Month.ToString("D2") + dtStart.Value.Day.ToString("D2") + dtStart.Value.Hour.ToString("D2") + dtStart.Value.Minute.ToString("D2") + dtStart.Value.Second.ToString("D2");
                
                if (chkUseEndTime.Checked)
                {
                    sql = sql + " and occur <= " + dtEnd.Value.Year + dtEnd.Value.Month.ToString("D2") + dtEnd.Value.Day.ToString("D2") + dtEnd.Value.Hour.ToString("D2") + dtEnd.Value.Minute.ToString("D2") + dtEnd.Value.Second.ToString("D2");
                }
            }

            if (chkByAccount.Checked && lstAccount.CheckedItems.Count > 0)
            {
                for(int i=0; i < lstAccount.CheckedItems.Count; i++)
                {
                    string name = lstAccount.CheckedItems[i].ToString();
                    if (i == 0)
                    {
                        if (sql == null)
                        {
                            sql = "select * from log where (account_name='" + name + "' ";
                        }
                        else
                        {
                            sql = sql + " and (account_name='" + name + "' ";
                        }
                    }
                    else
                    {
                        sql = sql + " or account_name='" + name + "' ";
                    }

                    if (i == lstAccount.CheckedItems.Count - 1)
                    {
                        sql = sql + ")";
                    }
                }                
            }

            if (chkByEmailSubject.Checked)
            {
                if (sql == null)
                {
                    sql = "select * from log where message like '%Inserting email to inbox table%' and message like '%" + txtEmailSubjectContains.Text + "%' ";
                }
                else
                {
                    sql = sql + " and (message like '%Inserting email to inbox table%' and message like '%" + txtEmailSubjectContains.Text + "%')";
                }
            }

            if (chkBySmsContent.Checked)
            {
                if (sql == null)
                {
                    sql = "select * from log where message like '%Inserting into SMS table%' and message like '%" + txtSmsContains.Text + "%'";
                }
                else
                {
                    sql = sql + " and (message like '%Inserting into SMS table%' and message like '%" + txtSmsContains.Text + "%')";
                }
            }

            if (sql == null)
            {
                sql = "select * from log order by occur desc ";
            }
            else
            {
                sql = sql + " order by occur ";
            }

            if(chkUseLimit.Checked)
                sql = sql + " limit 0, " + numLimit.Value;

            showLog(sql);
        }

        private void chkUseTime_CheckedChanged(object sender, EventArgs e)
        {
            dtStart.Enabled = chkByTime.Checked;
            chkUseEndTime.Enabled = chkByTime.Checked;
            dtEnd.Enabled = chkByTime.Checked && chkUseEndTime.Checked;
            
        }

        private void chkUseEndTime_CheckedChanged(object sender, EventArgs e)
        {
            dtEnd.Enabled = chkUseEndTime.Checked;
        }

        private void chkUseLimit_CheckedChanged(object sender, EventArgs e)
        {
            numLimit.Enabled = chkUseLimit.Checked;
        }

        private void chkByAccount_CheckedChanged(object sender, EventArgs e)
        {
            lstAccount.Enabled = chkByAccount.Checked;
        }

        private void chkBySmsContent_CheckedChanged(object sender, EventArgs e)
        {
            txtSmsContains.Enabled = chkBySmsContent.Checked;
        }

        private void chkByEmailSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtEmailSubjectContains.Enabled = chkByEmailSubject.Checked;
        }

       
    }
}
