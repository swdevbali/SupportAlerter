using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            popServerTextBox.Text = RegistrySettings.pop3ServerAddress;
            portTextBox.Text = RegistrySettings.pop3ServerPort+"";
            useSslCheckBox.Checked  = RegistrySettings.pop3UseSSL.Equals("True");
            loginTextBox.Text = RegistrySettings.pop3Username;
            passwordTextBox.Text = RegistrySettings.pop3Password;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveValues();
            RegistrySettings.writeValues();
            Close();
        }

        private void SaveValues()
        {
            RegistrySettings.pop3ServerAddress = popServerTextBox.Text;
            RegistrySettings.pop3ServerPort = Convert.ToInt32(portTextBox.Text);
            RegistrySettings.pop3UseSSL = useSslCheckBox.Checked + "";
            RegistrySettings.pop3Username = loginTextBox.Text;
            RegistrySettings.pop3Password = Cryptho.Encrypt(passwordTextBox.Text);
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
    }
}
