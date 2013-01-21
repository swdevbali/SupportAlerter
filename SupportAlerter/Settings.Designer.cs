namespace SupportAlerter
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panelTop = new System.Windows.Forms.Panel();
            this.useSslCheckBox = new System.Windows.Forms.CheckBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.labelServerAddress = new System.Windows.Forms.Label();
            this.popServerTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.useSslCheckBox);
            this.panelTop.Controls.Add(this.labelPassword);
            this.panelTop.Controls.Add(this.passwordTextBox);
            this.panelTop.Controls.Add(this.labelUsername);
            this.panelTop.Controls.Add(this.loginTextBox);
            this.panelTop.Controls.Add(this.labelServerPort);
            this.panelTop.Controls.Add(this.portTextBox);
            this.panelTop.Controls.Add(this.labelServerAddress);
            this.panelTop.Controls.Add(this.popServerTextBox);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(509, 291);
            this.panelTop.TabIndex = 2;
            // 
            // useSslCheckBox
            // 
            this.useSslCheckBox.AutoSize = true;
            this.useSslCheckBox.Location = new System.Drawing.Point(128, 65);
            this.useSslCheckBox.Name = "useSslCheckBox";
            this.useSslCheckBox.Size = new System.Drawing.Size(68, 17);
            this.useSslCheckBox.TabIndex = 4;
            this.useSslCheckBox.Text = "Use SSL";
            this.useSslCheckBox.UseVisualStyleBackColor = true;
            // 
            // labelPassword
            // 
            this.labelPassword.Location = new System.Drawing.Point(64, 119);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(64, 23);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(128, 119);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 20);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Text = "muhammad";
            // 
            // labelUsername
            // 
            this.labelUsername.Location = new System.Drawing.Point(64, 88);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(64, 23);
            this.labelUsername.TabIndex = 6;
            this.labelUsername.Text = "Username";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(128, 88);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(150, 20);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Text = "ekowibowo@swdevbali.com";
            // 
            // labelServerPort
            // 
            this.labelServerPort.Location = new System.Drawing.Point(97, 39);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(31, 23);
            this.labelServerPort.TabIndex = 3;
            this.labelServerPort.Text = "Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(128, 39);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(150, 20);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "110";
            // 
            // labelServerAddress
            // 
            this.labelServerAddress.Location = new System.Drawing.Point(16, 8);
            this.labelServerAddress.Name = "labelServerAddress";
            this.labelServerAddress.Size = new System.Drawing.Size(112, 23);
            this.labelServerAddress.TabIndex = 1;
            this.labelServerAddress.Text = "POP Server Address";
            // 
            // popServerTextBox
            // 
            this.popServerTextBox.Location = new System.Drawing.Point(128, 8);
            this.popServerTextBox.Name = "popServerTextBox";
            this.popServerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.popServerTextBox.Size = new System.Drawing.Size(150, 20);
            this.popServerTextBox.TabIndex = 0;
            this.popServerTextBox.Text = "mail.swdevbali.com";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(523, 323);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelTop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(515, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Email";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.23529F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(529, 374);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 39);
            this.panel1.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(277, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(358, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(439, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "&Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(529, 374);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.CheckBox useSslCheckBox;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label labelServerAddress;
        private System.Windows.Forms.TextBox popServerTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}