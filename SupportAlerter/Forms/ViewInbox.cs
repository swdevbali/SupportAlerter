using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SupportAlerterLibrary;

namespace SupportAlerter.Forms
{
    public partial class ViewInbox : Form
    {
        public ViewInbox()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            String sql = "select * from inbox";
            MySqlCommand cmd = new MySqlCommand(sql, CoreFeature.getInstance().getDataConnection());
            MySqlDataReader rdr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            int i = 0;
            while (rdr.Read())
            {
                DataGridViewButtonColumn buttonBody = new DataGridViewButtonColumn();
                buttonBody.Text = "View";
                dataGridView1.Rows.Add(new object[] { ++i, rdr.GetString(rdr.GetOrdinal("date")), rdr.GetString(rdr.GetOrdinal("sender")), rdr.GetString(rdr.GetOrdinal("subject")), "View", rdr.GetInt32(rdr.GetOrdinal("idinbox")) });
            }
            rdr.Close();
            cmd.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                String sql = "select body from inbox where idinbox=@idinbox";
                MySqlCommand cmd = new MySqlCommand(sql, CoreFeature.getInstance().getDataConnection());
                cmd.Parameters.Add(new MySqlParameter("idinbox", dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show(rdr.GetString(rdr.GetOrdinal("body")));
                }
                rdr.Close();
                cmd.Dispose();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
