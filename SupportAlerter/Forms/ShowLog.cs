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
            EventLog myLog = new EventLog();
            myLog.Log = Program.EventLogName;
            dataGridView1.Rows.Clear();
            foreach (EventLogEntry entry in myLog.Entries)
            {
                dataGridView1.Rows.Add(new object[] { entry.TimeGenerated, entry.Message });
            }    
            
        }
    }
}
