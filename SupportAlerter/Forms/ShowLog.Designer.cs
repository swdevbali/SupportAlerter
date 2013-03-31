namespace SupportAlerter.Forms
{
    partial class ShowLog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowLog));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUseLimit = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.numLimit = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstAccount = new System.Windows.Forms.CheckedListBox();
            this.chkByAccount = new System.Windows.Forms.CheckBox();
            this.chkByTime = new System.Windows.Forms.CheckBox();
            this.chkUseEndTime = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.numSeconds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 180);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(863, 118);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 200F;
            this.Column1.HeaderText = "Time generated";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Account Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Message";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkUseLimit);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.numLimit);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 180);
            this.panel1.TabIndex = 5;
            // 
            // chkUseLimit
            // 
            this.chkUseLimit.AutoSize = true;
            this.chkUseLimit.Checked = true;
            this.chkUseLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseLimit.Location = new System.Drawing.Point(95, 153);
            this.chkUseLimit.Name = "chkUseLimit";
            this.chkUseLimit.Size = new System.Drawing.Size(15, 14);
            this.chkUseLimit.TabIndex = 9;
            this.chkUseLimit.UseVisualStyleBackColor = true;
            this.chkUseLimit.CheckedChanged += new System.EventHandler(this.chkUseLimit_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(12, 151);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "&Display data";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // numLimit
            // 
            this.numLimit.Location = new System.Drawing.Point(150, 151);
            this.numLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLimit.Name = "numLimit";
            this.numLimit.Size = new System.Drawing.Size(67, 20);
            this.numLimit.TabIndex = 5;
            this.numLimit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstAccount);
            this.groupBox2.Controls.Add(this.chkByAccount);
            this.groupBox2.Controls.Add(this.chkByTime);
            this.groupBox2.Controls.Add(this.chkUseEndTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtEnd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtStart);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 113);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Log";
            // 
            // lstAccount
            // 
            this.lstAccount.Enabled = false;
            this.lstAccount.FormattingEnabled = true;
            this.lstAccount.Location = new System.Drawing.Point(320, 42);
            this.lstAccount.Name = "lstAccount";
            this.lstAccount.Size = new System.Drawing.Size(201, 64);
            this.lstAccount.TabIndex = 7;
            // 
            // chkByAccount
            // 
            this.chkByAccount.AutoSize = true;
            this.chkByAccount.Location = new System.Drawing.Point(297, 21);
            this.chkByAccount.Name = "chkByAccount";
            this.chkByAccount.Size = new System.Drawing.Size(80, 17);
            this.chkByAccount.TabIndex = 6;
            this.chkByAccount.Text = "By account";
            this.chkByAccount.UseVisualStyleBackColor = true;
            this.chkByAccount.CheckedChanged += new System.EventHandler(this.chkByAccount_CheckedChanged);
            // 
            // chkByTime
            // 
            this.chkByTime.AutoSize = true;
            this.chkByTime.Location = new System.Drawing.Point(21, 21);
            this.chkByTime.Name = "chkByTime";
            this.chkByTime.Size = new System.Drawing.Size(60, 17);
            this.chkByTime.TabIndex = 5;
            this.chkByTime.Text = "By time";
            this.chkByTime.UseVisualStyleBackColor = true;
            this.chkByTime.CheckedChanged += new System.EventHandler(this.chkUseTime_CheckedChanged);
            // 
            // chkUseEndTime
            // 
            this.chkUseEndTime.AutoSize = true;
            this.chkUseEndTime.Enabled = false;
            this.chkUseEndTime.Location = new System.Drawing.Point(41, 71);
            this.chkUseEndTime.Name = "chkUseEndTime";
            this.chkUseEndTime.Size = new System.Drawing.Size(15, 14);
            this.chkUseEndTime.TabIndex = 4;
            this.chkUseEndTime.UseVisualStyleBackColor = true;
            this.chkUseEndTime.CheckedChanged += new System.EventHandler(this.chkUseEndTime_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End time";
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "MM/dd/yy - hh:mm:ss";
            this.dtEnd.Enabled = false;
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(128, 68);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(137, 20);
            this.dtEnd.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start time";
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "MM/dd/yy - hh:mm:ss";
            this.dtStart.Enabled = false;
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(128, 42);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(137, 20);
            this.dtStart.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Limit";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkAutoRefresh);
            this.groupBox1.Controls.Add(this.numSeconds);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(553, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 113);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Refresh Settings";
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(21, 19);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(117, 17);
            this.chkAutoRefresh.TabIndex = 1;
            this.chkAutoRefresh.Text = "Auto Refresh every";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // numSeconds
            // 
            this.numSeconds.Location = new System.Drawing.Point(144, 16);
            this.numSeconds.Name = "numSeconds";
            this.numSeconds.Size = new System.Drawing.Size(47, 20);
            this.numSeconds.TabIndex = 2;
            this.numSeconds.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSeconds.ValueChanged += new System.EventHandler(this.numSeconds_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "second(s)";
            // 
            // eventLog1
            // 
            this.eventLog1.Log = "Application";
            this.eventLog1.Source = "SMS Alert from eMail";
            this.eventLog1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ShowLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 298);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLimit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSeconds;
        private System.Windows.Forms.NumericUpDown numLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkByTime;
        private System.Windows.Forms.CheckBox chkUseEndTime;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chkUseLimit;
        private System.Windows.Forms.CheckBox chkByAccount;
        private System.Windows.Forms.CheckedListBox lstAccount;
    }
}