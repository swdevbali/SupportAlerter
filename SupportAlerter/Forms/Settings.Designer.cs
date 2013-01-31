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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInfoService = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numEmailCheckInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.tabLayoutEmailAccount = new System.Windows.Forms.TableLayoutPanel();
            this.panelAccountDetail = new System.Windows.Forms.Panel();
            this.lblAccountInfo = new System.Windows.Forms.Label();
            this.lvAccount = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnRuleDelete = new System.Windows.Forms.Button();
            this.btnRuleAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRuleDetail = new System.Windows.Forms.Panel();
            this.lblRuleInfo = new System.Windows.Forms.Label();
            this.listRuleName = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTestDatabaseConnection = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDatabaseType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEmailCheckInterval)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabLayoutEmailAccount.SuspendLayout();
            this.panelAccountDetail.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlRuleDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(869, 530);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnStop);
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Controls.Add(this.lblInfoService);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.numEmailCheckInterval);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(861, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(196, 80);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(115, 80);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblInfoService
            // 
            this.lblInfoService.AutoSize = true;
            this.lblInfoService.Location = new System.Drawing.Point(112, 51);
            this.lblInfoService.Name = "lblInfoService";
            this.lblInfoService.Size = new System.Drawing.Size(65, 13);
            this.lblInfoService.TabIndex = 6;
            this.lblInfoService.Text = "Click to stop";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Service status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "second(s)";
            // 
            // numEmailCheckInterval
            // 
            this.numEmailCheckInterval.Location = new System.Drawing.Point(115, 15);
            this.numEmailCheckInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numEmailCheckInterval.Name = "numEmailCheckInterval";
            this.numEmailCheckInterval.Size = new System.Drawing.Size(50, 20);
            this.numEmailCheckInterval.TabIndex = 1;
            this.numEmailCheckInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Check email every";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRemoveAccount);
            this.tabPage1.Controls.Add(this.btnAddAccount);
            this.tabPage1.Controls.Add(this.tabLayoutEmailAccount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(861, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Email Accounts";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAccount.Image = global::SupportAlerter.Properties.Resources.delete_account;
            this.btnRemoveAccount.Location = new System.Drawing.Point(48, 449);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(32, 32);
            this.btnRemoveAccount.TabIndex = 3;
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccount.Image = global::SupportAlerter.Properties.Resources.add_account;
            this.btnAddAccount.Location = new System.Drawing.Point(10, 449);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(32, 32);
            this.btnAddAccount.TabIndex = 2;
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // tabLayoutEmailAccount
            // 
            this.tabLayoutEmailAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabLayoutEmailAccount.ColumnCount = 2;
            this.tabLayoutEmailAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.24561F));
            this.tabLayoutEmailAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.75439F));
            this.tabLayoutEmailAccount.Controls.Add(this.panelAccountDetail, 1, 0);
            this.tabLayoutEmailAccount.Controls.Add(this.lvAccount, 0, 0);
            this.tabLayoutEmailAccount.Location = new System.Drawing.Point(9, 33);
            this.tabLayoutEmailAccount.Name = "tabLayoutEmailAccount";
            this.tabLayoutEmailAccount.RowCount = 1;
            this.tabLayoutEmailAccount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabLayoutEmailAccount.Size = new System.Drawing.Size(846, 410);
            this.tabLayoutEmailAccount.TabIndex = 1;
            // 
            // panelAccountDetail
            // 
            this.panelAccountDetail.Controls.Add(this.lblAccountInfo);
            this.panelAccountDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccountDetail.Location = new System.Drawing.Point(241, 3);
            this.panelAccountDetail.Name = "panelAccountDetail";
            this.panelAccountDetail.Size = new System.Drawing.Size(602, 404);
            this.panelAccountDetail.TabIndex = 1;
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.AutoSize = true;
            this.lblAccountInfo.Location = new System.Drawing.Point(12, 12);
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(259, 13);
            this.lblAccountInfo.TabIndex = 0;
            this.lblAccountInfo.Text = "Click on an account name to configure its connection";
            // 
            // lvAccount
            // 
            this.lvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAccount.FormattingEnabled = true;
            this.lvAccount.Location = new System.Drawing.Point(3, 3);
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(232, 404);
            this.lvAccount.TabIndex = 2;
            this.lvAccount.SelectedIndexChanged += new System.EventHandler(this.lvAccount_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You can configure multiple email account for each user";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnRuleDelete);
            this.tabPage4.Controls.Add(this.btnRuleAdd);
            this.tabPage4.Controls.Add(this.tableLayoutPanel2);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(861, 504);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Notification Rules";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnRuleDelete
            // 
            this.btnRuleDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRuleDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuleDelete.Image = global::SupportAlerter.Properties.Resources.delete_account;
            this.btnRuleDelete.Location = new System.Drawing.Point(48, 449);
            this.btnRuleDelete.Name = "btnRuleDelete";
            this.btnRuleDelete.Size = new System.Drawing.Size(32, 32);
            this.btnRuleDelete.TabIndex = 5;
            this.btnRuleDelete.UseVisualStyleBackColor = true;
            this.btnRuleDelete.Click += new System.EventHandler(this.btnRuleDelete_Click);
            // 
            // btnRuleAdd
            // 
            this.btnRuleAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRuleAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuleAdd.Image = global::SupportAlerter.Properties.Resources.add_account;
            this.btnRuleAdd.Location = new System.Drawing.Point(10, 449);
            this.btnRuleAdd.Name = "btnRuleAdd";
            this.btnRuleAdd.Size = new System.Drawing.Size(32, 32);
            this.btnRuleAdd.TabIndex = 4;
            this.btnRuleAdd.UseVisualStyleBackColor = true;
            this.btnRuleAdd.Click += new System.EventHandler(this.btnRuleAdd_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.24561F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.75439F));
            this.tableLayoutPanel2.Controls.Add(this.pnlRuleDetail, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listRuleName, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 33);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(846, 410);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // pnlRuleDetail
            // 
            this.pnlRuleDetail.Controls.Add(this.lblRuleInfo);
            this.pnlRuleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRuleDetail.Location = new System.Drawing.Point(241, 3);
            this.pnlRuleDetail.Name = "pnlRuleDetail";
            this.pnlRuleDetail.Size = new System.Drawing.Size(602, 404);
            this.pnlRuleDetail.TabIndex = 1;
            // 
            // lblRuleInfo
            // 
            this.lblRuleInfo.AutoSize = true;
            this.lblRuleInfo.Location = new System.Drawing.Point(12, 12);
            this.lblRuleInfo.Name = "lblRuleInfo";
            this.lblRuleInfo.Size = new System.Drawing.Size(180, 13);
            this.lblRuleInfo.TabIndex = 0;
            this.lblRuleInfo.Text = "Click on a rule name to define its rule";
            // 
            // listRuleName
            // 
            this.listRuleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRuleName.FormattingEnabled = true;
            this.listRuleName.Location = new System.Drawing.Point(3, 3);
            this.listRuleName.Name = "listRuleName";
            this.listRuleName.Size = new System.Drawing.Size(232, 404);
            this.listRuleName.TabIndex = 2;
            this.listRuleName.SelectedIndexChanged += new System.EventHandler(this.listRuleName_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(404, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "You can define rules of notification of all the messages receive in the email acc" +
    "ounts";
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.58878F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.411215F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 586);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 539);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 44);
            this.panel1.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(785, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnTestDatabaseConnection
            // 
            this.btnTestDatabaseConnection.Location = new System.Drawing.Point(106, 157);
            this.btnTestDatabaseConnection.Name = "btnTestDatabaseConnection";
            this.btnTestDatabaseConnection.Size = new System.Drawing.Size(121, 23);
            this.btnTestDatabaseConnection.TabIndex = 21;
            this.btnTestDatabaseConnection.Text = "&Test Connection";
            this.btnTestDatabaseConnection.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(106, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(106, 104);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(121, 20);
            this.txtUsername.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Username";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(106, 78);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(121, 20);
            this.txtDatabase.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Database";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(106, 52);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(121, 20);
            this.txtHost.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Host";
            // 
            // cboDatabaseType
            // 
            this.cboDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabaseType.FormattingEnabled = true;
            this.cboDatabaseType.Items.AddRange(new object[] {
            "MySQL"});
            this.cboDatabaseType.Location = new System.Drawing.Point(106, 25);
            this.cboDatabaseType.Name = "cboDatabaseType";
            this.cboDatabaseType.Size = new System.Drawing.Size(121, 21);
            this.cboDatabaseType.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Database type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnTestDatabaseConnection);
            this.groupBox1.Controls.Add(this.cboDatabaseType);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Location = new System.Drawing.Point(18, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 202);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database storage";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 586);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEmailCheckInterval)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabLayoutEmailAccount.ResumeLayout(false);
            this.panelAccountDetail.ResumeLayout(false);
            this.panelAccountDetail.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnlRuleDetail.ResumeLayout(false);
            this.pnlRuleDetail.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tabLayoutEmailAccount;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Panel panelAccountDetail;
        private System.Windows.Forms.ListBox lvAccount;
        private System.Windows.Forms.Label lblAccountInfo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numEmailCheckInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfoService;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlRuleDetail;
        private System.Windows.Forms.Label lblRuleInfo;
        private System.Windows.Forms.ListBox listRuleName;
        private System.Windows.Forms.Button btnRuleDelete;
        private System.Windows.Forms.Button btnRuleAdd;
        private System.Windows.Forms.Button btnTestDatabaseConnection;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDatabaseType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}